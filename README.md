# 📐GraduallyChange
Gradually change a value to target value

![changingGif](https://user-images.githubusercontent.com/82342866/210463836-bfa1747e-2a72-41f7-b66d-119ebbcdf558.gif)

## 📜 Description
This function allows you to gradually change a value to a target value in given duration with/without smoothing!

#### ◤Features 💡
+ ➰Smoothing
+ 7️⃣Setting duration
+ 〽️Animation Curve support! [Usage](https://github.com/fisekoo/GraduallyChange/edit/main/README.md#%EF%B8%8F-with-animaton-curve)
+ 🎛️Control what happens after change completed!
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

### 〽️ With Animaton Curve
![curveGif](https://user-images.githubusercontent.com/82342866/211152375-80bd6a0c-531c-480d-8b08-26c5887d167e.gif)
+ Declare a AnimationCurve variable.

![image](https://user-images.githubusercontent.com/82342866/211152447-c904ffd0-58ba-49c9-81da-92af3464c87d.png)
+ Right click the FIRST keyframe and click "Edit key"

![image](https://user-images.githubusercontent.com/82342866/211152531-69d752b7-588d-402a-8448-440e40a6f376.png)
+ Set time to 0 and value to your start value.

![image](https://user-images.githubusercontent.com/82342866/211152596-388a564e-859b-4fd6-9801-426e58c37c71.png)

+ Right click the LAST keyframe and click "Edit key"
+ Set time to when do you want to end the change.
+ Set value to your end value.

![image](https://user-images.githubusercontent.com/82342866/211152696-c793aa9b-0ce2-43f8-8f2d-a2c48ad42ab0.png)
+ And then, you can tweak inbetween keyframes however you want!
```csharp
StartCoroutine(GraduallyChange.To( x => startValue = x, curve, loopCount, OnChangeComplete ));
```
> loopCount and onChangeComplete is optional

## Optional parameters
| Parameter | Description |
| --- | --- |
| isSmooth | Should interpolation be smooth? |
| loopCount | How many times the change will loop. |
| onComplete | Function to run when interpolation completed. |
