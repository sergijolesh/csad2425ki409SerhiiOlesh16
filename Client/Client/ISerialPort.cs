using System;
using System.IO.Ports;

namespace Client.Wrapper
{
    public interface ISerialPort
    {
        void Open();
        void Close();
        void WriteLine(string message);
        string ReadLine();
        bool IsOpen { get; }
    }

    public class SerialPortWrapper : ISerialPort
    {
        private readonly SerialPort serialPort;

        public SerialPortWrapper(string portName, int baudRate)
        {
            serialPort = new SerialPort(portName, baudRate);
        }

        public bool IsOpen => serialPort.IsOpen;

        public void Open() => serialPort.Open();

        public void Close() => serialPort.Close();

        public void WriteLine(string message) => serialPort.WriteLine(message);

        public string ReadLine() => serialPort.ReadLine();
    }
}
