public static class GraduallyChange
{
    /// <summary>Gradually changes a given value to target value.</summary>
    /// <param name="from">Start value.</param>
    /// <param name="callback">Lambda for assigning gradually changing value to a variable.</param>
    /// <param name="to">Target value.</param>
    /// <param name="duration">How long it will take start value to reach target value? In seconds.</param>
    /// <param name="isSmooth">Should interpolation be smooth?</param>
    /// <param name="onComplete">Function when interpolation completed.</param>
    public static System.Collections.IEnumerator To(System.Func<float> from, System.Action<float> callback, float to, float duration, bool isSmooth = false, System.Action onComplete = null)
    {
        if (duration <= 0) throw new DurationIsLessThanZeroException("Duration must be greater than zero");
        var t = 0f;
        var current = from();
        var fromValue = from();
        while (current != to)
        {
            t += UnityEngine.Time.fixedDeltaTime;
            t = Clamp(t, 0, duration);
            current = isSmooth ? LerpSmooth(fromValue, to, t / duration) : Lerp(fromValue, to, (t / duration));
            if (current.IsSimiliarTo(to))
            {
                callback(to);
                onComplete?.Invoke();
                break;
            }
            callback(current);
            yield return new UnityEngine.WaitForFixedUpdate();
        }
    }
    /// <summary>Checks if a and b similiar to eachother by delta.</summary>
    /// <param name="delta">Minimum difference between numbers.</param>
    /// <returns>True if numbers are similiar</returns>
    public static bool IsSimiliarTo(this float a, float b, float delta = 0.01f) => System.Math.Abs(b - a) <= delta;

    /// <summary>Lerps between a and b</summary>
    /// <param name="a">The start value, when t is 0</param>
    /// <param name="b">The start value, when t is 1</param>
    /// <param name="t">The t-value from 0 to 1 representing position along the lerp, clamped between 0 and 1</param>
    public static float Lerp(float a, float b, float t) => (1 - t) * a + t * b;

    /// <summary>Lerps between a and b, applying trigonometeric smoothing to the t-value</summary>
    /// <param name="a">The start value, when t is 0</param>
    /// <param name="b">The start value, when t is 1</param>
    /// <param name="t">The t-value from 0 to 1 representing position along the lerp, clamped between 0 and 1</param>
    public static float LerpSmooth(float a, float b, float t) => Lerp(a, b, SmoothCos01(t));

    /// <summary>Applies trigonometric smoothing to the 0-1 interval.</summary>
    public static float SmoothCos01(float x) => (float)System.Math.Cos(x * System.Math.PI) * -0.5f + 0.5f;
    
    /// <summary>Clamps value between min and max.</summary>
    /// <param name="value">The value to clamp</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value</param>
    public static float Clamp(float value, float min, float max) => value < min ? min : value > max ? max : value;
}

[System.Serializable]
public class DurationIsLessThanZeroException : System.Exception
{
    public DurationIsLessThanZeroException(string message) : base(message) { }
}
