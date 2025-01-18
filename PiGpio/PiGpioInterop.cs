using System;
using System.Runtime.InteropServices;

namespace RaspberryDotNetLedBlink.PiGpio;

public static partial class PiGpioInterop
{
    [LibraryImport("pigpio")]
    public static partial int gpioInitialise();

    [LibraryImport("pigpio")]
    public static partial int gpioSetMode(uint gpio, uint mode);
    [LibraryImport("pigpio")]
    public static partial int gpioWrite(uint gpio, uint level);

    [LibraryImport("pigpio")]
    public static partial void gpioTerminate();
}
