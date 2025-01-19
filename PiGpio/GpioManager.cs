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
            // TODO: Throw exception
        }

        Console.WriteLine("GPIO initialized");
    }

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
}
