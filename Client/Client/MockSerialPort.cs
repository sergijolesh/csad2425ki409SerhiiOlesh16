using System;
using Client;
using Client.Wrapper;

namespace Client.Mock
{
    public class MockSerialPort : ISerialPort
    {
        private bool isOpen;
        private readonly Queue<string> responses;

        public MockSerialPort(Queue<string> responses) { this.responses = responses; }

        public bool IsOpen => this.isOpen;

        public void Open() { isOpen = true; }

        public void Close() { isOpen = false; }

        public void WriteLine(string message) { Console.WriteLine($"Mock WriteLine: {message}"); }

        public string ReadLine()
        {
            if (responses.Count > 0)
                return responses.Dequeue();

            Thread.Sleep(100);
            throw new TimeoutException("Mock timeout.");
        }
    }
}
