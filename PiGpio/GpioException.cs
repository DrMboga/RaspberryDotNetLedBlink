using System;

namespace RaspberryDotNetLedBlink.PiGpio;

public class GpioException : ApplicationException
{
    public GpioException(string message, int gpioErrorCode) : base($"GPIO {message}. Error code: {gpioErrorCode} ({gpioErrorCode.GetPgioErrorDescription()})")
    {
    }
}
