using System;
using System.Runtime.InteropServices;

namespace RaspberryDotNetLedBlink.PiGpio;

// Library documentation: https://abyz.me.uk/rpi/pigpio/cif.html#gpioWrite

public static partial class PiGpioInterop
{
    /// <summary>
    /// Input GPIO Alert callback function delegate
    /// </summary>
    public delegate void gpioAlertCallback(int gpio, int level, uint tick);

    /// <summary>
    /// Initialises the library.
    /// </summary>
    /// <returns>pigpio version number if OK, otherwise <see cref="GpioErrorCode"/></returns>
    [LibraryImport("pigpio")]
    public static partial int gpioInitialise();

    /// <summary>
    /// Sets the GPIO mode, typically input or output.
    /// </summary>
    /// <returns>0 if OK, otherwise <see cref="GpioErrorCode"/></returns>
    [LibraryImport("pigpio")]
    public static partial int gpioSetMode(uint gpio, uint mode);

    /// <summary>
    /// Sets the GPIO level, on or off.
    /// </summary>
    /// <returns>0 if OK, otherwise <see cref="GpioErrorCode"/></returns>
    [LibraryImport("pigpio")]
    public static partial int gpioWrite(uint gpio, uint level);

    /// <summary>
    /// Sets or clears resistor pull ups or downs on the GPIO.
    /// </summary>
    /// <returns>0 if OK, otherwise <see cref="GpioErrorCode"/></returns>
    [LibraryImport("pigpio")]
    public static partial int gpioSetPullUpDown(uint gpio, uint pud);

    /// <summary>
    /// Registers a function to be called (a callback) when the specified GPIO changes state.
    /// </summary>
    /// <returns>0 if OK, otherwise <see cref="GpioErrorCode"/></returns>
    [LibraryImport("pigpio")]
    public static partial int gpioSetAlertFunc(uint gpio, gpioAlertCallback alertFunction);

    /// <summary>
    /// Terminates the library.
    /// This function resets the used DMA channels, releases memory, and terminates any running threads.
    /// </summary>
    [LibraryImport("pigpio")]
    public static partial void gpioTerminate();
}
