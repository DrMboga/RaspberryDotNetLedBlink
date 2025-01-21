using System;

namespace RaspberryDotNetLedBlink.PiGpio;

public class GpioStateChangedEventArgs: EventArgs
{
    public int Gpio { get; }
    public GpioLevel Level { get; }
    public uint Tick { get; }

    public GpioStateChangedEventArgs(int gpio, GpioLevel level, uint tick)
    {
        Gpio = gpio;
        Level = level;
        Tick = tick;
    }
}
