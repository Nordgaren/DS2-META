# DS2 META  
 Dark Souls 2 testing/debugging/practice tool  
 Based on a CE table by [Lord Radai](https://github.com/LordRadai)  
 
 Inspired by [DS-Gadget 3.0](https://github.com/JKAnderson/DS-Gadget) and uses [Property Hook](https://github.com/JKAnderson/PropertyHook) by [TKGP](https://github.com/JKAnderson/).  
 
 META stands for:  
M  
E  
T  
A  
 
# WARNING  
 There has been absolutely NO testing on this tool and online use. For offline use only. Use online at your own risk.  
 Even actions not locked behind a setting are considered unsafe for online use.  
 YOU HAVE BEEN WARNED  

## Requirements  
* [.NET 4.7.2](https://www.microsoft.com/net/download/thank-you/net472)  

## Installing  
* Extract contents of zip archive to it's own folder. You may have to run as admin if DS2S META crashes  

## Thank You  
**[ffleret](https://www.twitch.tv/ffleret)** Who bought be vanilla DS2 so I could port DS2S META over to vanilla  
**[TKGP](https://github.com/JKAnderson/)** Author of [DS Gadget](https://github.com/JKAnderson/DS-Gadget) and [Property Hook](https://github.com/JKAnderson/PropertyHook)  
**[Atvaark](https://github.com/Atvaark)** Author of the CE table used for this tool  
**[Lord Radai](https://github.com/LordRadai)** good mentor and contributor  
**[pseudostripy](https://github.com/pseudostripy)** Tester and contributor   

## Libraries  
[Property Hook](https://github.com/JKAnderson/PropertyHook) by [TKGP](https://github.com/JKAnderson/)  

[Costura](https://github.com/Fody/Costura) by [Fody](https://github.com/Fody) team  

[Octokit](https://github.com/octokit/octokit.net) by [Octokit](https://github.com/octokit) team  

[GlobalHotkeys](https://github.com/mrousavy/Hotkeys) by [Marc Rousavy](https://github.com/mrousavy)  

[Fasm.NET](https://github.com/JamesMenetrey/Fasm.NET) by [James Menetrey](https://github.com/JamesMenetrey)  

# Change Log  
### Beta 0.2  

* Program is now up to date with it's Scholar counterpart, except missing the Apply Special Effect function (Used to apply bonfire rest when warping and in the "Restore Humanity" button).  I will keep looking for it.  

* New Hotkey system using GlobalHotkeys library. Should fix issue with input delaying game

* Optimized GetHeld method, which should make looking up items in player inventory faster. Could use feedback from anyone who previously couldn't use the live inventory update feature.  

* Added check to make sure you have right version of the game loaded.  

* Changed to using Stable position in the player position restore system  

### Beta 0.0.0.5  

* Player and Stats tab implemented    

### Beta 0.0.0.1  

* Item Give and Bonfire Warp implemented    

* Working on catching up to DS2S META functionality  
