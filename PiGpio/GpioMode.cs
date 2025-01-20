namespace RaspberryDotNetLedBlink.PiGpio;

/// <summary>
/// GPIO operational mode
/// </summary>
public enum GpioMode: uint
{
    Input = 0,
    Output = 1,
    Alt0 = 4,
    Alt1 = 5,
    Alt2 = 6,
    Alt3 = 7,
    Alt4 = 3,
    Alt5 = 2,
}
