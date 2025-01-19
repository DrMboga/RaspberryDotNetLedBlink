using RaspberryDotNetLedBlink.PiGpio;

const int BlinkDelay = 500; // milliseconds

using var gpio = new GpioManager();

Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true; // Cancel the termination
    Console.WriteLine("Ctrl+C pressed. Cleaning up...");
    gpio.Dispose();
    Environment.Exit(0);
};

while (true)
{
    Thread.Sleep(1000 * BlinkDelay);
}