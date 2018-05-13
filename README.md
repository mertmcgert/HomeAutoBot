# HomeAutobot for StreamDeck

## Currently Supported Services:
* LifX (https://www.lifx.com/) - Single bulb support
* Nest (https://nest.com/) - Single thermostat support

## Quick Setup Steps:
### Service API keys
1. (optional) Create a LifX developer account and get an auth bearer token (https://api.developer.lifx.com/)
2. (optional) Create a Nest developer account and get an auth bearer token, client id, client secret, etc. (https://developers.nest.com/)
3. Copy App.Config.Sample to App.Config, and place your authorization info into there

### Running the application from CMD/StreamDeck
1. Once built, you can run the app via CMD by typing:
`Autobot.exe --<command>=<option>`
2. On StreamDeck, make one System Open command for each command you'd like to use (see existing command arguments below)

### Existing Commandline Options
```
  --brightness     lifx modify brightness (-1.0 to 1.0)

  --color          lifx set color (hex or color name)

  --duration       lifx set fade duration

  --temperature    nest set temperature

  --gettemp        nest get temperature

  --addtotemp      nest add or subtract from temperature

  --hvacmode       nest set hvac mode

  --fan            nest set fan duration

  --help           Display this help screen.

  --version        Display version information.
 ```

### Notes
* If you don't want to use the SteamDeck pieces of the code, they're pretty easy to rip out. Then you'd just be left with a CLI for Nest and LifX
### Caveats
I am not planning on supporting this beyond fiddling with it for my own purposes. 
This was more a proof of concept / lazy attempt at making a home automation command console than it was an ongoing project 

