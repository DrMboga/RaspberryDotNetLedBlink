# RaspberryDotNetLedBlink
This is a small example how to use [.net Platform Invoke](https://learn.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke) with [PIGPIO](https://abyz.me.uk/rpi/pigpio/cif.html) library.

This project uses .Net 9. 
Instructions how to istall .Net SDK to your Raspberry Pi you can find [here](https://learn.microsoft.com/en-gb/dotnet/core/install/linux-debian?tabs=dotnet9)

A small tip how to set up your dev envinornment:
1. I have set up my RPI as [headless device](https://www.raspberrypi.com/documentation/computers/configuration.html#setting-up-a-headless-raspberry-pi)
2. Set up [SSH Public Key Authentication](https://www.ssh.com/academy/ssh/public-key-authentication#setting-up-public-key-authentication-for-ssh)
3. Debug code in VS Code on my dev machine via [Remote SSH](https://code.visualstudio.com/docs/remote/ssh)
