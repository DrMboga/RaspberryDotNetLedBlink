# RaspberryDotNetLedBlink
This is a small example how to use [.net Platform Invoke](https://learn.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke) with [PIGPIO](https://abyz.me.uk/rpi/pigpio/cif.html) library.

## Install .net on Raspberry Pi
This project uses .Net 9. 
Instructions how to istall .Net SDK to your Raspberry Pi you can find [here](https://learn.microsoft.com/en-gb/dotnet/core/install/linux-debian?tabs=dotnet9)

If the instructions don't work (as in my case). Instructions for manual .net installation:

1. Go to the [official website](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) And click `Download binaries -> Arm64` link. Copy the direct link from the download page.
2. Download the distribution on Pi:
```bash
wget <URL_OF_THE_ARM64_TARBALL>
```
3. Unpack `tar` pack:
```bash
sudo mkdir -p /usr/share/dotnet
sudo tar -zxf dotnet-sdk-9.<whatever version is in downloaded file>-linux-arm64.tar.gz -C /usr/share/dotnet
```
4. Setup symbolic link:
```bash
sudo ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet
```
5. Check if everything is OK
```bash
dotnet --version
```

## A small tip how to set up your dev envinornment:
1. I have set up my RPI as [headless device](https://www.raspberrypi.com/documentation/computers/configuration.html#setting-up-a-headless-raspberry-pi)
2. Set up [SSH Public Key Authentication](https://www.ssh.com/academy/ssh/public-key-authentication#setting-up-public-key-authentication-for-ssh)
3. Debug code in VS Code on my dev machine via [Remote SSH](https://code.visualstudio.com/docs/remote/ssh)
