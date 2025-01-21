using RaspberryDotNetLedBlink.PiGpio;

const int BlinkDelay = 500; // milliseconds
const uint LedPin = 23;
const uint ButtonPin = 24;

try
{
    // Initialize GPIO library
    using var gpio = new GpioManager();

    // Ctrl+C key handler
    Console.CancelKeyPress += (sender, e) =>
    {
        e.Cancel = true; // Cancel the termination
        Console.WriteLine("Ctrl+C pressed. Cleaning up...");
        // Terminate GPIO library and free resources
        gpio.Dispose();
        Environment.Exit(0);
    };

    // Set LED pin as output.
    gpio.SetPinMode(LedPin, GpioMode.Output);

    bool blinkModeOn = false;
    // Set Button pin as output and subscribe to state change
    gpio.InitInputPinAsPullUp(ButtonPin);
    gpio.GpioStateChanged += (_, e) => {
        Console.WriteLine($"GPIO PIN {e.Gpio} changed its state to {e.Level}");
        if(e.Gpio == ButtonPin && e.Level == GpioLevel.Low)
        {
            // Button pressed. Switch on or off the blinking mode
            blinkModeOn = !blinkModeOn;
        }
    };

    bool ledOn = false;
    // Infinite loop can be interrupted by Ctrl+C
    while (true)
    {
        if(blinkModeOn)
        {
            ledOn = !ledOn;
            gpio.Write(LedPin, ledOn ? GpioLevel.High : GpioLevel.Low);
        }
        Thread.Sleep(BlinkDelay);
    }
} catch(Exception e)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Error occurred: '{e.Message}'");
    Console.ResetColor();
}