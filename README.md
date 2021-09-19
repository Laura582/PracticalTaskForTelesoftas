# Practical Task For Telesoftas

This is pratice tasks for QA position in Telesoftas. Test suite for UI and Android tests are written in C# and nUnit, tests are using Selenium web driver to interact with web browser and Appium with Selenium to interact with Android.

## Task 1 answers
1. When exiting the app from the main menu, alert dialog is shown to confirm exit action. Better UX would be similar to SEB application, when UX asks to click 'go back' for the second time to exit.
Alert dialog requires additional actions to confirm the 'exit' intent, which is not needed, because exit from the main menu will not loose any data and alert dialog is not confortable to deal with.
2. Meditation rating is confusing. Green, blue or yellow stars do not clearly convey if it is a good or bad meditation session. I would offer to update star rating to a more familiar design, where with the better rating more stars gets filled, as example: https://www.javatpoint.com/android-rating-bar-example
3. When selecting background music for meditation session user should hear an example of selection. With current UX user has to start meditation session to hear the background music.

### Bug found:
#### App: Meditation Timer & Log
#### Device: Galaxy Note 10+, SM-N975F/DS
#### Description: When adding a note to meditation session, most of UI is obstucted. 
How to reproduce: https://media.giphy.com/media/6wPL4EiFRhtKGbU3iM/giphy.gif?cid=790b76110e0e6605fb91c1cfdec9687b88aaaa6cddb7b944&rid=giphy.gif&ct=g

## Task 2
**Test steps:**
1. Go to https://www.globalsqa.com/demo-site/frames-and-windows/#iFrame
2. Close the blue dialog box
3. Count the number of cover images displayed in iframe 
4. Enter the number in the main page search box 

## Task 3
**Test steps:**
1. Go to http://the-internet.herokuapp.com/dynamic_loading/2 
2. Click button  "Start"
3. Check if loading bar visible
4. Read and print the text that is displayed


### Note

Selenium requires a driver to interface with the chosen browser. Link to driver:

|Name|Url|
|---|---|
|Chrome|https://sites.google.com/a/chromium.org/chromedriver/downloads|

Use this directory to store your web driver
```
\PracticalTaskForTelesoftas\chromedriver.exe
```


- If you are using Chrome version 94, please download ChromeDriver 94.0.4606.41
- If you are using Chrome version 93, please download ChromeDriver 93.0.4577.63
- If you are using Chrome version 92, please download ChromeDriver 92.0.4515.107

To run Android test you will need to set up an Appium server and Android emulator. In ExtraTaskTests.cs you will need to change deviceName to your device name and you will need to change appiumServer into your Appium server Uri
```
private readonly string appiumServer = "http://192.168.0.234:4723/whub";
private readonly string deviceName = "emulator-5554";
```
#### Note
You can search device name in Android Studio SDK folder by running 
```
adb devices
```

## Running the test
To run tests, you will need to go to the parent folder and open .sln file, open Test Explorer and click "Run All Tests In View" or click (Ctrl + R, V)
