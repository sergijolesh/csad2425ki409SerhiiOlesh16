using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Client;
using Client.Mock;
using NUnit.Framework;

namespace Client.Tests
{
    [TestFixture]
    public class SerialClientTests
    {
        private MockSerialPort mockSerialPort;
        private SerialClient serialClient;
        private StringWriter consoleOutput;

        [SetUp]
        public void SetUp()
        {
            var mockResponses = new Queue<string>();
            mockResponses.Enqueue("Hello, Client!");
            mockResponses.Enqueue("Goodbye, Client!");

            mockSerialPort = new MockSerialPort(mockResponses);
            serialClient = new SerialClient(mockSerialPort);

            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(Console.Out);
            consoleOutput.Dispose();
        }

        [Test]
        public void Run_SendsHelloMessageAndReceivesResponse()
        {
            mockSerialPort.Open();

            var runThread = new Thread(() => serialClient.Run());
            runThread.Start();

            Thread.Sleep(3000);

            mockSerialPort.Close();
            runThread.Join();

            var output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("Sent to server: Hello, Server!"), "The client should send the expected message.");
            Assert.That(output, Does.Contain("Received from server: Hello, Client!"), "The client should receive the expected response.");
            Assert.That(output, Does.Contain("Closed the connection."), "The client should close the connection properly.");
        }

        [Test]
        public void Run_HandlesTimeoutExceptionGracefully()
        {
            var emptyResponses = new Queue<string>();
            mockSerialPort = new MockSerialPort(emptyResponses);
            serialClient = new SerialClient(mockSerialPort);
            mockSerialPort.Open();

            var runThread = new Thread(() => serialClient.Run());
            runThread.Start();

            Thread.Sleep(3000);

            mockSerialPort.Close();
            runThread.Join();

            var output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("Read/Write operation timed out."), "The client should handle timeout exceptions gracefully.");
            Assert.That(output, Does.Contain("Closed the connection."), "The client should close the connection properly.");
        }

        [Test]
        public void Run_HandlesGeneralExceptionGracefully()
        {
            var mockResponses = new Queue<string>();
            mockResponses.Enqueue(null);
            mockSerialPort = new MockSerialPort(mockResponses);
            serialClient = new SerialClient(mockSerialPort);
            mockSerialPort.Open();

            var runThread = new Thread(() => serialClient.Run());
            runThread.Start();

            Thread.Sleep(3000);

            mockSerialPort.Close();
            runThread.Join();

            var output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("Error:"), "The client should handle general exceptions gracefully.");
        }
    }
}
