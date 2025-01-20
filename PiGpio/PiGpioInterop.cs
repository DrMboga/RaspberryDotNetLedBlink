using System;
using System.Runtime.InteropServices;

namespace RaspberryDotNetLedBlink.PiGpio;

// Library documentation: https://abyz.me.uk/rpi/pigpio/cif.html#gpioWrite

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
