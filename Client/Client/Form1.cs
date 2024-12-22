using System;
using System.IO.Ports;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Threading;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.CodeDom;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Client
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private int playerOneScore = 0;
        private int playerTwoScore = 0;
        private string playerOneMove;
        private string playerTwoMove;
        private string mode;

        public Form1()
        {
            InitializeComponent();
            SetupSerialPort();

            string filePath = "config.xml";

            if (File.Exists(filePath))
            {
                XDocument xmlDoc = XDocument.Load(filePath);

                if ((bool)xmlDoc.Root.Element("ManVsMan"))
                {
                    mode = "ManVsMan";
                }

                if ((bool)xmlDoc.Root.Element("ManVsAI"))
                {
                    mode = "ManVsAI";
                    btnRockTwo.Enabled = false;
                    btnPaperTwo.Enabled = false;
                    btnScissorsTwo.Enabled = false;
                }

                if ((bool)xmlDoc.Root.Element("AIvsAI"))
                {
                    mode = "AIvsAI";
                    btnRockOne.Enabled = false;
                    btnPaperOne.Enabled = false;
                    btnScissorsOne.Enabled = false;
                    btnRockTwo.Enabled = false;
                    btnPaperTwo.Enabled = false;
                    btnScissorsTwo.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No saved data found.", "Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void SetupSerialPort()
        {
            serialPort = new SerialPort("COM3", 115200);
            serialPort.DataReceived += SerialPortDataReceived;

            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open serial port: {ex.Message}");
            }
        }

        private void btnRockOne_Click(object sender, EventArgs e) => PlayerOneMove("Rock");
        private void btnPaperOne_Click(object sender, EventArgs e) => PlayerOneMove("Paper");
        private void btnScissorsOne_Click(object sender, EventArgs e) => PlayerOneMove("Scissors");
        private void btnRockTwo_Click(object sender, EventArgs e) => PlayerTwoMove("Rock");
        private void btnPaperTwo_Click(object sender, EventArgs e) => PlayerTwoMove("Paper");
        private void btnScissorsTwo_Click(object sender, EventArgs e) => PlayerTwoMove("Scissors");
        private void btnConfig_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (mode == "ManVsAI")
            {
                serialPort.WriteLine(mode + "\n" + playerOneMove);
            }

            if (mode == "ManVsMan")
            {
                serialPort.WriteLine(mode + "\n" + playerOneMove + "\n" + playerTwoMove);
            }

            if (mode == "AIvsAI")
            {
                serialPort.WriteLine(mode);
                lblMessage.Font = new Font("Segoe UI", 14);
                lblMessage.Location = new Point(322, 336);
            }
        }

        private void PlayerOneMove(string move)
        {
            playerOneMove = move;
            imgPlayerOneMove.Image = Image.FromFile("Check.png");
            lblMessage.Text = " Let's play!";
            lblMessage.Font = new Font("Segoe UI", 14);
            lblMessage.Location = new Point(322, 336);

            if (mode == "ManVsAI")
            {
                imgPlayerTwoMove.Image = Image.FromFile("Check.png");
            }
        }

        private void PlayerTwoMove(string move)
        {
            playerTwoMove = move;
            imgPlayerTwoMove.Image = Image.FromFile("Check.png");
            lblMessage.Text = " Let's play!";
            lblMessage.Font = new Font("Segoe UI", 14);
            lblMessage.Location = new Point(322, 336);
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadExisting();
            Invoke(new Action(() =>
            {
                ProcessServerResponse(data);
            }));
        }

        private void ProcessServerResponse(string response)
        {
            string filePath = "config.xml";
            string[] lines = response.Split('\n');

            if (File.Exists(filePath))
            {
                XDocument xmlDoc = XDocument.Load(filePath);

                if ((bool)xmlDoc.Root.Element("ManVsMan"))
                {
                    lblMessage.Text = response;
                    imgPlayerOneMove.Image = Image.FromFile(playerOneMove + ".png");
                    imgPlayerTwoMove.Image = Image.FromFile(playerTwoMove + ".png");
                    calcScore(response[0]);
                }

                if ((bool)xmlDoc.Root.Element("ManVsAI"))
                {
                    lblMessage.Text = lines[1];
                    imgPlayerOneMove.Image = Image.FromFile(playerOneMove + ".png");
                    imgPlayerTwoMove.Image = Image.FromFile(lines[0] + ".png");
                    calcScore(lines[1][0]);
                }

                if ((bool)xmlDoc.Root.Element("AIvsAI"))
                {
                    lblMessage.Text = lines[2];
                    imgPlayerOneMove.Image = Image.FromFile(lines[0] + ".png");
                    imgPlayerTwoMove.Image = Image.FromFile(lines[1] + ".png");
                    calcScore(lines[2][0]);
                }
            }
            else
            {
                MessageBox.Show("No saved data found.", "Error");
            }
        }

        private void ShowGameOverDialog()
        {
            string winner = playerOneScore == 3 ? "Client" : "Server";
            var result = MessageBox.Show($"{winner} won! Start a new game?", "Game Over", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ResetGame();
            }
            else
            {
                Application.Exit();
            }
        }

        private void ResetGame()
        {
            playerOneScore = 0;
            playerTwoScore = 0;
            lblClientScore.Text = "0";
            lblServerScore.Text = "0";
            imgPlayerOneMove.Image = null;
            imgPlayerTwoMove.Image = null;
            lblMessage.Text = "Let's play!";
            lblMessage.Font = new Font("Segoe UI", 26);
            lblMessage.Location = new Point(275, 188);
        }

        private void calcScore(char winner)
        {
            if (winner == 'C')
            {
                ++playerOneScore;
            }

            if (winner == 'S')
            {
                ++playerTwoScore;
            }

            lblClientScore.Text = $"{playerOneScore}";
            lblServerScore.Text = $"{playerTwoScore}";

            if (playerOneScore == 3 || playerTwoScore == 3)
            {
                ShowGameOverDialog();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }
}
