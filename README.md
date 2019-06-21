# BlindToilets
**Plan**
- Make a VR game which incorporates the player doing a simple task, and then having to do the same task, while visually impaired.
- The idea of the app is to give awareness of different types of visual impairments and to show how difficult simple tasks can be for different people.

### Update Log
https://jamesgrigg.github.io/Project1Portfolio/

## Production
This project runs on the most up-to-date version of Unity as of June 2019 (2019.1.7), so should run on at least that version to ensure the best possible performance. An Android SDK and Java JDK are both required to install the project onto a mobile device, and can be installed through Unity.

## Usage
This application is designed to run on a mobile device along side a Google Daydream VR Headset (with the controller). This also requires a "Daydream Ready Mobile Device" (see https://vr.google.com/daydream/smartphonevr/phones/ for a list of Daydream ready phones). The application was created in Untiy. Once installed onto the phone and opened, the user is put into the kitchen scene. They are able to interact with the environment using the Daydream controller. Instructions are provided in game on the exact controls. The user can look around by moving their head around in VR, and they are able to either play a game or enter a sandbox mode where there is no objectives and can just play with the environment and visual conditions.

## Main Issues
Shader Performance: Due to this running in VR, we almost require the app to run at 60fps to help reduce motion sickness in the app. Unfortunately, VR is already expensive to run on the phone, and to get the desired visual conditon into the game, I have had to user some shaders. Shaders do not run well on mobile devices, and running a couple of the visual conditions can cause some performance issues (around 40fps gameplay can occur), which can be noticable. This mainly just happens with Cataracts and sometimes Starbursts.

Menu Art: I am not an artist and have not implemented any designs onto the Constellation menu system for each of the options. They currently just use the default images that come with Daydream Elements, as I was too lazy to create new ones.

File Size: Due to me using Daydream Elements, the project is rather large. I tried changing it from Mono development due to being on mobile, but it caused a lot of issues so this can be something to fix in the future. Also removing someof the extra things (such as models) that Daydream Elements introduces will defintely help with file size.

## Scripts Used
To get some of they key things working in this app, I was required to write some custom scripts. Below are the Unity screenshots of the scripts, along with a description on what they do.

### Game Manager

![Image](ReadMeImages/GameManagerScript.png)

### Effect Manager

![Image](ReadMeImages/EffectManagerScript.png)

### Main Menu

![Image](ReadMeImages/MainMenurScript.png)

### Instruction Menu

![Image](ReadMeImages/InstructionsMenuScript.png)

### Restart Menu

![Image](ReadMeImages/RestartMenuScript.png)

### Slider Scripts

![Image](ReadMeImages/SliderScript.png)
