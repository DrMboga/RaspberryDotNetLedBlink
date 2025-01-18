using RaspberryDotNetLedBlink.PiGpio;

int initialized = PiGpioInterop.gpioInitialise();

Console.WriteLine($"Hello, World! {initialized}");
