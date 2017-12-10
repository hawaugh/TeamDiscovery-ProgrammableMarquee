# Vision Marquee System
The Vision Marquee System is a program that allows you to create a custom 96x16 Dot Matrix 
Marquee.  With the Vision Marquee, you can display custom messages using several built in 
effects, as well as the ability to display images from file.

Suggested IDE:  Visual Studio

Built on .NET Framework 4.5.2

Walk Through

-Splash Screen 

![splashscreen](https://user-images.githubusercontent.com/31226496/33809230-92c7b8b4-ddc1-11e7-8085-71dfb03e73dd.png)



Using the User Interface

![image](https://user-images.githubusercontent.com/31226496/33809424-b1b0c88a-ddc4-11e7-80f6-3868f8f150e8.png)
 
At the top you can see that there are two tabs. Text and Image. Select the text tab if it is not already.
   -	The text tab allows you to enter your own text and display it with the chosen.
   -	Notice how the text tab has black text on a white background indicating it is active.
   


![image](https://user-images.githubusercontent.com/31226496/33809441-f54a2a0a-ddc4-11e7-80ce-c8f57e8faee3.png)
-	Type the message you would like to display and select the color of the message you typed.
-	Next you select how you want to display that text. 


![image](https://user-images.githubusercontent.com/31226496/33809455-331f9734-ddc5-11e7-8a9a-0e984a6c1079.png) 
-	Special Effects makes your text stationary but is limited to 9 characters. 
-	Display Duration is how long your text displays before it moves on to the next segment.




-	Entrance Effect is what your text does until it gets to the center of the display.

![image](https://user-images.githubusercontent.com/31226496/33809478-64f3b70e-ddc5-11e7-8f25-4ba25ad48082.png)

- 9 currently available entrance effects
  - No Effect cause your text to just show up with no effect.
  - From top has your text slide in from the top.
  - Horizontal Split brings the text in from left and right in two separate parts and then connects the parts.
  - Dissolve adds one dot at a time until all of the text is visible.
  - The Schwoop brings your text down from the top but upside down, then curves up right-side up and returns to the center.
  - Crooked From Top brings your text in from the top right slated, then centers itself and straightens the character.
  
  

-	Middle Effect manipulates the text while it is being displayed.


![image](https://user-images.githubusercontent.com/31226496/33809483-7820959a-ddc5-11e7-826b-618ef33a9d89.png)
 
- 4 currently available middle effects	
  - No Effect does just that, nothing will happen to the text.
  - Random Colored Dots changes every dot in the text to change to a random color.
  - Flashing causes the text to fade out and then back in once.
  - The Wave causes 3 lines to move through the text fading in and out as they move along the text.
  - The Spotlight cause the text to dim slightly while a light looks over the text.

- Exit Effect is how your text leaves the display

![image](https://user-images.githubusercontent.com/31226496/33809508-0221ff9a-ddc6-11e7-88a4-34fa01e4afb0.png)

- 8 Currently available  exit effects 
  - No Effect causes the text to disappear.
  - Exit Top causes the text to slide up until it's no longer visible.
  - Exit Bottom causes the text to slide down until it's no longer visible.
  - Exit Left causes the text to slide left until it's no longer visible.
  - Exit right causes the text to slide right until it's no longer visible.
  - Horizontal Split splits the text into two parts and moves off screen in different directions.
  - Dissolve removes one dot at a time until all of the text is gone.
  - Diagonal Exit Top slides the text to the top left until it's no longer visible.
  - Diagonal Exit bottom slides the text to the  left until it's no longer visible.
  
 
 ![image](https://user-images.githubusercontent.com/31226496/33809578-221ca290-ddc7-11e7-8b2f-c98e4cf6ec1d.png)
 
- Scrolling Text causes your text to scroll to the left and has no limit on amount of characters that can be used.
  - Scroll Speed is how quickly your text moves across the screen with the default at 1 second for each character.
  - Random Colors causes each character to be a different color. Shown below.
  
  <a href="https://imgflip.com/gif/20u96z"><img src="https://i.imgflip.com/20u96z.gif" title="made at imgflip.com"/></a>
 

 
 
![image](https://user-images.githubusercontent.com/31226496/33809807-bd67de7e-ddca-11e7-9b75-d528b3fb79f0.png)

 
- Border Options controls the border of 1 dot around the display.

![image](https://user-images.githubusercontent.com/31226496/33809810-d092abc8-ddca-11e7-9215-2aa4ed9b1dd1.png)
 
- 4 border effects currently available 
  - No Border doesn’t display anything around the edge of the display.
  - Static Border causes one dot around the edge of the border to display the chosen color.
  - Rotating causes 3 dots to rotate counter-clockwise around the edge of the marquee.
  - Flashing Random Colors causes the border to fade out and in repeatedly change colors each interval.
  - Oscillating Random Colors causes the border to change to random colors going from right to left.

 
![image](https://user-images.githubusercontent.com/31226496/33809858-61c5e592-ddcb-11e7-8997-0e56636c3a09.png)

- Now if you switch to the image tab you can see that you can also add your own images.
- Notice how the image tab has black text on a white background indicating it is active.
  - Display Duration is how long you want the image to display in seconds.
  - Browse opens a window (shown below) where you can select the image you would like to load.
 
 
![image](https://user-images.githubusercontent.com/31226496/33809868-99fcafcc-ddcb-11e7-873f-7d002b576031.png)



![image](https://user-images.githubusercontent.com/31226496/33809870-9c0d8fc0-ddcb-11e7-93d3-0c7183d29e05.png)

-	Browse opens a window (shown below) where you can select the image you would like to load.
-	Preview loads the image and displays in Original Image and Scaled Image (show below)
  - Original Image shows how the image is scaled to fit the display
  - Scaled Image shows how the image will look once the pixels in the image are scaled to fit the display
 

![image](https://user-images.githubusercontent.com/31226496/33809886-b42d8fd8-ddcb-11e7-9ea5-b4e15c1d4df0.png)
 
 
![image](https://user-images.githubusercontent.com/31226496/33809888-bce92b46-ddcb-11e7-9774-87fab076b538.png)



![image](https://user-images.githubusercontent.com/31226496/33809891-c7420b94-ddcb-11e7-8fd4-b97a80831e83.png)
 
- Looking at the bottom of the User Interface you will see a section with boxes that we refer to as segments.
- Each segment is a different message or image so that you can chain together multiple messages or images up to 24 total segments.
  Empty means that the segment has no text or image data.
  - The button with a + adds a new segment which is place after the last segment.


![image](https://user-images.githubusercontent.com/31226496/33809891-c7420b94-ddcb-11e7-8fd4-b97a80831e83.png) 

- When pressint the + for a new segment
  - When text is in the segment button will display what the text says.
  - When an image is in the segment the segment button will display the text “image”.
  - The X button in the top right corner on the active segment will remove that segment and lose all settings for that segment.
  -You can also rearrange the segments by click and holding down the mouse button and then moving the segment over the you would like it    to move to. (Before and After shown below.)

 
![image](https://user-images.githubusercontent.com/31226496/33809933-5cad4e46-ddcc-11e7-87b0-e55dba8b0c9a.png)


![image](https://user-images.githubusercontent.com/31226496/33809938-665de3e2-ddcc-11e7-9b6e-fd938683e5a0.png)

 
![image](https://user-images.githubusercontent.com/31226496/33809941-6ea1870c-ddcc-11e7-80ac-1a8bd6d7e4ca.png)


 
- Looking at the left side of the User Interface, you will see two buttons. Exit and Start New Message.
  - Exit will close the window and any unsaved settings will be lost.
  - Start New Message will cause the windows to temporarily close and then reopen will at settings reset also losing any 
    unsaved settings.
    
    
    
![image](https://user-images.githubusercontent.com/31226496/33809949-8dec73b0-ddcc-11e7-8b2f-7e77ccd5a37e.png)

- Looking at the right side of the User Interface, you will see three buttons. Load XML, Save, and Run.
	- Run will take you to the display and displays the messages you set.
	- Save will open another window where you can select where to save a XML file that holds all your current settings.
	- Load XML will open another window where you will navigate to where you have saved a previous session and then add it to your current     session.

 
 
![image](https://user-images.githubusercontent.com/31226496/33809974-c2d82254-ddcc-11e7-9e4f-e6c4c3484dc6.png)

- Looking towards the top of the user interface, you will see two more controls. Marquee Background Color and an Ignore checkbox.
	- Marquee Background Color is used to change the background of the display. (White marquee Background Color show below.)
	- Ignore (checked) causes the segment to be skipped in the display without losing the settings.
  
  <a href="https://imgflip.com/gif/20uagu"><img src="https://i.imgflip.com/20uagu.gif" title="made at imgflip.com"/></a>
 
-	Inside of the display you will see 5 buttons. Exit, Pause, Play, Back to Menu, and Go To FullScreen.
	- Exit will close the window and any unsaved settings will be lost.
	- Pause will stop the display from moving and can be resumed anytime by pressing the play button
	- Play will resume the display from where it left off when paused.
	- Back to Menu will stop the display and return you to the User Interface.
	- Go to FullScreen when enlarge the display size to encompass the entire screen.
 
 
 
![image](https://user-images.githubusercontent.com/31226496/33810051-f7d327f0-ddcd-11e7-97cc-6a566b8aca44.png)

- When in FullScreen you can always return by pressing the X found in the top left.
