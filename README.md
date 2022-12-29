# 📐GraduallyChange
Gradually change a number to target number

![changingGif](https://user-images.githubusercontent.com/82342866/210013560-c9e7e46d-f719-4893-9111-395deded4b10.gif)

## 📜 Description
This function allows you to gradually change a value to a target value in given duration with/without smoothing!

#### ◤Features 💡
+ ➰Smoothing
+ 7️⃣Setting duration
+ 🙂Use with/without Update function!

## Initialization 💻
+ Add this script to your assets or copy the code and create a new script with name of "GraduallyChange".

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
| onComplete | Function when interpolation completed. |
