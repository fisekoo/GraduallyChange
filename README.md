# 📐GraduallyChange
Gradually change a value to target value

![changingGif](https://user-images.githubusercontent.com/82342866/210085382-59d22fb2-b8e3-427b-b4fd-967673792c1e.gif)


## 📜 Description
This function allows you to gradually change a value to a target value in given duration with/without smoothing!

#### ◤Features 💡
+ ➰Smoothing
+ 7️⃣Setting duration
+ 🙂Use with/without Update function!
+ ➖Works with both negative and positive numbers➕

## Initialization 💻
+ Add this script to your assets or copy the code and create a new script with name of "GraduallyChange" and paste the entire code.

## How to use ❓
+ Open a script where you want to change number
```csharp
StartCoroutine(GraduallyChange.To( () => startValue, x => startValue = x, targetValue, duration, isSmooth, OnChangeComplete ));
```
> isSmooth and OnChangeComplete is optional

## Optional parameters
| Parameter | Description |
| --- | --- |
| isSmooth | Should interpolation be smooth? |
| onComplete | Function to run when interpolation completed. |
