using RaspberryDotNetLedBlink.PiGpio;

const int BlinkDelay = 500; // milliseconds
const uint LedPin = 23;

try
{
    using var gpio = new GpioManager();

    // Ctrl+C key handler
    Console.CancelKeyPress += (sender, e) =>
    {
        e.Cancel = true; // Cancel the termination
        Console.WriteLine("Ctrl+C pressed. Cleaning up...");
        gpio.Dispose();
        Environment.Exit(0);
    };

    gpio.SetPinMode(LedPin, GpioMode.Output);

    bool ledOn = false;
    // Infinite loop can be interrupted by Ctrl+C
    while (true)
    {
        ledOn = !ledOn;
        gpio.Write(LedPin, ledOn ? GpioLevel.High : GpioLevel.Low);
        Thread.Sleep(BlinkDelay);
    }
} catch(Exception e)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Error occured: '{e.Message}'");
    Console.ResetColor();
}