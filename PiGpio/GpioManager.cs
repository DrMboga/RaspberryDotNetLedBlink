using System;

namespace RaspberryDotNetLedBlink.PiGpio;

public class GpioManager: IDisposable
{
    private bool disposed = false;

    public GpioManager()
    {
        int initialized = PiGpioInterop.gpioInitialise();
        if (initialized < 0)
        {
            throw new GpioException("initialization error", initialized);
        }

        Console.WriteLine("GPIO initialized");
    }

    /// <summary>
    /// Sets operation mode to one PGIO pin
    /// </summary>
    /// <param name="pin">GPIO pin number</param>
    /// <param name="mode">Operational mode</param>
    /// <exception cref="GpioException"></exception>
    public void SetPinMode(uint pin, GpioMode mode)
    {
        int result = PiGpioInterop.gpioSetMode(pin, (uint)mode);
        if (result < 0)
        {
            throw new GpioException("set pin mode error", result);
        }
    }

    /// <summary>
    /// Writes a value to GPIO pin
    /// </summary>
    /// <param name="pin">GPIO pin number</param>
    /// <param name="level">Digital level</param>
    /// <exception cref="GpioException"></exception>
    public void Write(uint pin, GpioLevel level)
    {
        int result = PiGpioInterop.gpioWrite(pin, (uint) level);
        if (result < 0)
        {
            throw new GpioException("write error", result);
        }
    }

#region Dispose
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        // Check to see if Dispose has already been called.
        if(!this.disposed)
        {
            // If disposing equals true, dispose all managed
            // and unmanaged resources.
            if(disposing)
            {
                // Dispose managed resources.
            }

            // Call the appropriate methods to clean up
            // unmanaged resources here.
            // If disposing is false,
            // only the following code is executed.
            PiGpioInterop.gpioTerminate();
            Console.WriteLine("GPIO terminated");

            // Note disposing has been done.
            disposed = true;
        }
    }

    ~GpioManager()
    {
        Dispose(disposing: false);
    }
#endregion
}
