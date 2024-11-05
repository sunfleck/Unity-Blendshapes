# Unity-Blendshapes
Script to initiate facial expressions at any time during a looped animation without using keyframes

![blendshapesDemo](https://github.com/user-attachments/assets/b50467a5-43be-4a79-b818-1c26e645941a)

# Purpose
If you are using a looped animation, it is cumbersome to change facial expression with keyframes when a specific event happens in your game. This is because in a loop that facial expression would be triggered on each pass through the loop. Also, the point of trigger would be fixed. This script solves that problem. The demo project uses Unity 6.

#Setup notes
1.	In Unity 2019, the Animator component on your NPC must have Update Mode set to “Animate Physics”.
2.	In Unity 6, the Animator component on your NPC must have “Animate Physics’ checked and Update Mode set to “Fixed”.
3.	The NPC will have an array of available blendshapes in the Head object.

![Image1](https://github.com/user-attachments/assets/45cc0f03-7930-4cbb-9ad3-e1bd1ba20cee)

   
4.	For each facial expression, an array of blendshapes is created and only those values of interest are set. For example, using the “look left” facial expression, the value of element 26 (the look_Left blendshape) in the array is set to 80.

![Image2](https://github.com/user-attachments/assets/1b302b34-5d15-4563-be70-15126df35d3d)


# Assets
I used the free “1toon teen” by JBGarraza available in the Unity Asset Store
https://assetstore.unity.com/packages/3d/characters/humanoids/1-toon-teen-135513

