using System;
using System.IO.Ports;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        string portName = "/dev/ttyACM0"; // Replace with your Arduino's port
        int baudRate = 9600;

        // Create and configure the SerialPort object
        using (SerialPort serialPort = new SerialPort(portName, baudRate))
        {
            try
            {
                // Open the serial port
                serialPort.Open();
                Console.WriteLine("Serial port opened.");
                Thread.Sleep(2000);
                string incomingData;
                int count = 0;
                serialPort.Write("req");
                // Send a message to the Arduino
                serialPort.Close();
                Console.WriteLine("Serial port closed.");
                serialPort.Open();
                string rec = serialPort.ReadExisting();
                Console.WriteLine("received : " + rec);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Wait for user to close the console
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}