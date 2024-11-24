using System;
using System.IO.Ports;
using System.Threading;
using Client.Wrapper;

namespace Client
{
    public class SerialClient
    {
        private readonly ISerialPort serialPort;

        public SerialClient(ISerialPort serialPort)
        {
            this.serialPort = serialPort;
        }

        public void Run()
        {
            try
            {
                serialPort.Open();
                Thread.Sleep(1000);
                while (serialPort.IsOpen)
                {
                    string helloMsg = "Hello, Server!";
                    serialPort.WriteLine(helloMsg);
                    Thread.Sleep(1000);
                    Console.WriteLine("Sent to server: " + helloMsg);

                    try
                    {
                        string response = serialPort.ReadLine();
                        Console.WriteLine("Received from server: " + response.Trim() + "\n");
                    }
                    catch (TimeoutException)
                    {
                        Console.WriteLine("Read/Write operation timed out.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                Console.WriteLine("Closed the connection.");
            }
        }

        static void Main()
        {
            ISerialPort serialPort = new SerialPortWrapper("COM3", 9600);

            var client = new SerialClient(serialPort);
            client.Run();
        }
    }
}
