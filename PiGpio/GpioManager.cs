using System;

namespace RaspberryDotNetLedBlink.PiGpio;

public class GpioManager: IDisposable
{
    private bool disposed = false;

    /// <summary>
    /// Triggers when some input GPIO state changed. Works together with <see cref="InitInputButtonAsActiveLow"/> method.
    /// </summary>
    public event EventHandler<GpioStateChangedEventArgs>? GpioStateChanged;

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
            throw new GpioException($"set {pin} pin mode {mode} error", result);
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
            throw new GpioException($"PIN {pin} write error", result);
        }
    }

    /// <summary>
    /// This method is used for setup the typical pull-up configuration for a button.
    /// That means that it sets up the pull-up resistor so the PIN reads High by default.
    /// If this pin is connected to the button then other leg of the button should be connected to GND.
    /// When button is pressed, it will connect the pin to GND, causing the input pin to read Low.
    /// This will trigger the alert function callback. And this alert triggers <see cref="GpioStateChanged"/> event.
    /// </summary>
    public void InitInputPinAsPullUp(uint inputPin)
    {
        // Set input mode
        int result = PiGpioInterop.gpioSetMode(inputPin, (uint) GpioMode.Input);
        if (result < 0)
        {
            throw new GpioException($"set PIN {inputPin} as input error", result);
        }
        
        // Set up pull up resistor
        result = PiGpioInterop.gpioSetPullUpDown(inputPin, (uint)GpioPullMode.PullUp);
        if (result < 0)
        {
            throw new GpioException($"set PIN {inputPin} pull up error", result);
        }

        // Register callback
        result = PiGpioInterop.gpioSetAlertFunc(inputPin, GpioCallback);
        if (result < 0)
        {
            throw new GpioException($"set PIN {inputPin} callback function error", result);
        }
    }

    /// <summary>
    /// Callback function triggers when the specified GPIO changes state
    /// </summary>
    private void GpioCallback(int gpio, int level, uint tick)
    {
        GpioStateChanged?.Invoke(this, new GpioStateChangedEventArgs(gpio, (GpioLevel)level, tick));
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
