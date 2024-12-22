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
    /// <summary>
    /// Represents the main form of the application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Serial port for communication.
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// Score of Player One.
        /// </summary>
        private int playerOneScore = 0;

        /// <summary>
        /// Score of Player Two.
        /// </summary>
        private int playerTwoScore = 0;

        /// <summary>
        /// Move selected by Player One.
        /// </summary>
        private string playerOneMove;

        /// <summary>
        /// Move selected by Player Two.
        /// </summary>
        private string playerTwoMove;

        /// <summary>
        /// Current game mode.
        /// </summary>
        private string mode;

        /// <summary>
        /// File path for the configuration file.
        /// </summary>
        private string filePath = "config.xml";

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            SetupSerialPort();

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

        /// <summary>
        /// Handles the Load event of the form.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e) { }

        /// <summary>
        /// Configures the serial port for communication.
        /// </summary>
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

        /// <summary>
        /// Handles the Rock button click event for Player One.
        /// </summary>
        private void btnRockOne_Click(object sender, EventArgs e) => PlayerOneMove("Rock");

        /// <summary>
        /// Handles the Paper button click event for Player One.
        /// </summary>
        private void btnPaperOne_Click(object sender, EventArgs e) => PlayerOneMove("Paper");

        /// <summary>
        /// Handles the Scissors button click event for Player One.
        /// </summary>
        private void btnScissorsOne_Click(object sender, EventArgs e) => PlayerOneMove("Scissors");

        /// <summary>
        /// Handles the Rock button click event for Player Two.
        /// </summary>
        private void btnRockTwo_Click(object sender, EventArgs e) => PlayerTwoMove("Rock");

        /// <summary>
        /// Handles the Paper button click event for Player Two.
        /// </summary>
        private void btnPaperTwo_Click(object sender, EventArgs e) => PlayerTwoMove("Paper");

        /// <summary>
        /// Handles the Scissors button click event for Player Two.
        /// </summary>
        private void btnScissorsTwo_Click(object sender, EventArgs e) => PlayerTwoMove("Scissors");

        /// <summary>
        /// Opens the configuration form.
        /// </summary>
        private void btnConfig_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        /// <summary>
        /// Sends the selected moves and mode to the server.
        /// </summary>
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

        /// <summary>
        /// Sets the move for Player One.
        /// </summary>
        /// <param name="move">The move chosen by Player One.</param>
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

        /// <summary>
        /// Sets the move for Player Two.
        /// </summary>
        /// <param name="move">The move chosen by Player Two.</param>
        private void PlayerTwoMove(string move)
        {
            playerTwoMove = move;
            imgPlayerTwoMove.Image = Image.FromFile("Check.png");
            lblMessage.Text = " Let's play!";
            lblMessage.Font = new Font("Segoe UI", 14);
            lblMessage.Location = new Point(322, 336);
        }

        /// <summary>
        /// Handles data received from the serial port.
        /// </summary>
        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadExisting();
            Invoke(new Action(() =>
            {
                ProcessServerResponse(data);
            }));
        }

        /// <summary>
        /// Processes the response from the server.
        /// </summary>
        /// <param name="response">The response received from the server.</param>
        private void ProcessServerResponse(string response)
        {
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

        /// <summary>
        /// Displays a dialog when the game is over.
        /// </summary>
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

        /// <summary>
        /// Resets the game to its initial state.
        /// </summary>
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

        /// <summary>
        /// Calculates and updates the score based on the winner.
        /// </summary>
        /// <param name="winner">The character representing the winner ('C' for Client, 'S' for Server).</param>
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

        /// <summary>
        /// Handles the FormClosing event of the main form.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }
}
