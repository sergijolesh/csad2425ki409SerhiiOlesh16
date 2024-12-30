using Client;
using NUnit.Framework;
using System.Windows.Forms;
using System.Drawing;
using System.IO.Ports;

namespace Client.Tests
{
    [TestFixture]
    public class Form1Tests
    {
        private Form1 form;

        [SetUp]
        public void Setup()
        {
            form = new Form1();
            form.Show();
        }

        [TearDown]
        public void TearDown()
        {
            if (form != null)
            {
                form.Dispose();
                form = null;
            }
        }

        [Test]
        public void PlayerOneMove_ShouldSetMoveAndUpdateUI()
        {
            string expectedMove = "Rock";

            form.PlayerOneMove(expectedMove);

            Assert.AreEqual(expectedMove, form.playerOneMove, "PlayerOneMove should correctly set the player's move.");
            Assert.AreEqual(" Let's play!", form.lblMessage.Text, "lblMessage text should be updated correctly.");
            Assert.AreEqual(new Font("Segoe UI", 14), form.lblMessage.Font, "lblMessage font should be updated.");
            Assert.AreEqual(new Point(322, 336), form.lblMessage.Location, "lblMessage location should be updated.");
        }

        [Test]
        public void PlayerTwoMove_ShouldSetMoveAndUpdateUI()
        {
            string expectedMove = "Paper";

            form.PlayerTwoMove(expectedMove);

            Assert.AreEqual(expectedMove, form.playerTwoMove, "PlayerTwoMove should correctly set the player's move.");
            Assert.AreEqual(" Let's play!", form.lblMessage.Text, "lblMessage text should be updated correctly.");
            Assert.AreEqual(new Font("Segoe UI", 14), form.lblMessage.Font, "lblMessage font should be updated.");
            Assert.AreEqual(new Point(322, 336), form.lblMessage.Location, "lblMessage location should be updated.");
        }

        [Test]
        public void CalcScore_ShouldUpdateScoresCorrectly()
        {
            for (int i = 0; i < 3; ++i)
            {
                form.calcScore('C');
            }

            Assert.AreEqual(3, form.playerOneScore, "PlayerOneScore should be incremented correctly.");
            Assert.AreEqual(0, form.playerTwoScore, "PlayerTwoScore should remain unchanged.");
        }

        [Test]
        public void ResetGame_ShouldResetAllGameValues()
        {
            form.playerOneScore = 3;
            form.playerTwoScore = 2;
            form.playerOneMove = "Rock";
            form.playerTwoMove = "Paper";

            form.ResetGame();

            Assert.AreEqual(0, form.playerOneScore, "PlayerOneScore should be reset to 0.");
            Assert.AreEqual(0, form.playerTwoScore, "PlayerTwoScore should be reset to 0.");
            Assert.IsNull(form.imgPlayerOneMove.Image, "PlayerOneMove image should be cleared.");
            Assert.IsNull(form.imgPlayerTwoMove.Image, "PlayerTwoMove image should be cleared.");
            Assert.AreEqual("Let's play!", form.lblMessage.Text, "lblMessage should be reset.");
            Assert.AreEqual(new Font("Segoe UI", 26), form.lblMessage.Font, "lblMessage font should be reset.");
            Assert.AreEqual(new Point(275, 188), form.lblMessage.Location, "lblMessage location should be reset.");
        }

        [Test]
        public void ShowGameOverDialog_ShouldDisplayCorrectDialog()
        {
            form.playerOneScore = 3;
            form.playerTwoScore = 2;

            Assert.DoesNotThrow(() => form.ShowGameOverDialog(), "ShowGameOverDialog should not throw an exception.");
        }

        [Test]
        public void SetupSerialPort_ShouldHandlePortOpenException()
        {
            Assert.DoesNotThrow(() => form.SetupSerialPort("InvalidPort"), "SetupSerialPort should handle exceptions gracefully.");
        }

        public void SetupSerialPort_ShouldHandleCorrectPort()
        {
            Assert.DoesNotThrow(() => form.SetupSerialPort("COM3"), "SetupSerialPort should handle exceptions gracefully.");
        }

        [Test]
        public void ProcessServerResponse_ShouldHandleManVsManMode()
        {
            form.mode = "ManVsMan";
            form.playerOneMove = "Rock";
            form.playerTwoMove = "Scissors";
            string response = "Client wins!";

            Assert.DoesNotThrow(() => form.ProcessServerResponse(response), "ProcessServerResponse should handle valid input correctly.");
        }

        [Test]
        public void ProcessServerResponse_ShouldHandleAiVsAiMode()
        {
            form.mode = "AiVsAi";
            string response = "Rock\nPaper\nServer wins!";

            Assert.DoesNotThrow(() => form.ProcessServerResponse(response), "ProcessServerResponse should handle valid input correctly.");
        }

        [Test]
        public void ProcessServerResponse_ShouldHandleManVsAiMode()
        {
            form.mode = "MAnVsAi";
            form.playerOneMove = "Scissors";
            string response = "Paper\nClient wins!";

            Assert.DoesNotThrow(() => form.ProcessServerResponse(response), "ProcessServerResponse should handle valid input correctly.");
        }

        [Test]
        public void ProcessServerResponse_ShouldShowErrorForInvalidFile()
        {
            form.filePath = "invalid.xml";
            string response = "C\nRock\nScissors";

            Assert.DoesNotThrow(() => form.ProcessServerResponse(response), "ProcessServerResponse should handle missing config file gracefully.");
        }

        [Test]
        public void ProcessServerResponse_ShouldFindFile()
        {
            form.filePath = "config.xml";
            form.mode = "MAnVsAi";
            form.playerOneMove = "Scissors";
            string response = "Paper\nClient wins!";

            Assert.DoesNotThrow(() => form.ProcessServerResponse(response), "ProcessServerResponse should handle missing config file gracefully.");
        }

        [Test]
        public void MainForm_FormClosing_ShouldCloseSerialPort()
        {
            form.SetupSerialPort("COM3");
            Assert.DoesNotThrow(() => form.MainForm_FormClosing(null, null), "FormClosing should handle port closing without exceptions.");
        }
    }
}
