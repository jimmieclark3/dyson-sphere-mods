# TweakMecha

This mod allows you to tweak your mecha. 
You can change warp speed, and cruise speed at the moment.  More to come later.
The speed is configurable in AUs or LYs.

## Note

This mod doesn't modify any entities and should not affect any save data.  
Any issues with the mod after a game update can be bypassed by disabling the mod until it is updated.

## Usage
Install the mod and start up the game for the config file to be generated.  
If you desire to change the default configuration (Max warp speed 1 LY), you'll need to restart the game.

## Configuration

### Disclaimer
**Setting speeds > 0.5 LYs may prove difficult when trying to "crash land" into a planet.**
It is recommended to exit warp when near a planet if you choose to select a speed that high.

### WarpSpeed
> Speed at which you'd like the maximum warp to be set. This can be in LYs or AUs depending on the configuration of `SpeedType`
- `Type: double`
- `Default value: 1.0`

### WarpSpeedType
> Speed measurement to use when configuring the speed. This can be AU or LY. Note LY = 60 * AU.
- `Type: ESpeed [AU/LY]`
- `Default value: LY`

### CruiseSpeed
> Speed at which you'd like the maximum warp to be set. This can be in LYs or AUs depending on the configuration of `SpeedType`
- `Type: double`
- `Default value: 1.0`

### CruiseSpeedType
> Speed measurement to use when configuring the speed. This can be AU or LY. Note LY = 60 * AU.
- `Type: ESpeed [AU/LY]`
- `Default value: LY`

## Changelog

### v1.0.0
- Initial Release

## Thanks
Thanks to modding community in general.


Credit to https://dsp.thunderstore.io/package/3therios/IncreaseMaxWarpSpeed/ for the initial code, and his shoutout to the blow folks
"Shoutout to `sp00ktober` and `Pasukaru` as I referenced some code and conventions from them. This helped me build this mod cause I'm a noob."