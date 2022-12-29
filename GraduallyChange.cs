using UnityEngine;
public static class GraduallyChange
{
    /// <summary>Gradually changes a given value to target value.</summary>
    /// <param name="from">Start value.</param>
    /// <param name="callback">Lambda for assigning gradually changing value to a variable.</param>
    /// <param name="to">Target value.</param>
    /// <param name="duration">How long it will take start value to reach target value? In seconds.</param>
    /// <param name="smoothness">How rough it will interpolate between start value and target value.</param>
    public static System.Collections.IEnumerator To(System.Func<float> from, System.Action<float> callback, float to, float duration, float smoothness = 1)
    {
        var t = 0f;
        var current = from();
        while (current != to)
        {
            t += Time.fixedDeltaTime;
            t = Mathf.Clamp01(t / duration);
            current = Lerp(current, to, t * smoothness);
            if (current.IsSimiliarTo(to))
            {
                callback(to);
                break;
            }
            callback(current);
            yield return new WaitForFixedUpdate();
        }
    }
    /// <summary>Checks if a and b similiar to eachother by delta.</summary>
    /// <param name="delta">Minimum difference between numbers.</param>
    /// <returns>True if numbers are similiar</returns>
    public static bool IsSimiliarTo(this float a, float b, float delta = 0.01f) => Mathf.Abs(b - a) <= delta;
    public static float Lerp(float a, float b, float t) => (1 - t) * a + b * t;
}
