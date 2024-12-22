void setup()
{
  Serial.begin(115200);
}

void loop()
{
  if (Serial.available())
  {
    String mode = Serial.readStringUntil('\n');
    if (mode == "ManVsMan")
    {
      String playerOneMove = Serial.readStringUntil('\n');
      String playerTwoMove = Serial.readStringUntil('\n');
      String result = determineWinner(playerOneMove, playerTwoMove);
      Serial.println(result);
    }

    if (mode == "ManVsAI")
    {
      String playerOneMove = Serial.readStringUntil('\n');
      String playerTwoMove = getRandomMove();
      String result = determineWinner(playerOneMove, playerTwoMove);
      Serial.println(playerTwoMove + "\n" + result);
    }

    if (mode == "AIvsAI")
    {
      String playerOneMove = getRandomMove();
      String playerTwoMove = getRandomMove();
      String result = determineWinner(playerOneMove, playerTwoMove);
      Serial.println(playerOneMove + "\n" + playerTwoMove + "\n" + result);
    }
  }
}

String getRandomMove()
{
  int randomNumber = random(0, 3);
  if (randomNumber == 0) 
    return "Rock";
  else if (randomNumber == 1) 
    return "Paper";
  else 
    return "Scissors";
}

String determineWinner(String playerOneMove, String playerTwoMove)
{
  if (playerOneMove == playerTwoMove) return "     Draw";
  if ((playerOneMove == "Rock" && playerTwoMove == "Scissors") ||
    (playerOneMove == "Paper" && playerTwoMove == "Rock") ||
    (playerOneMove == "Scissors" && playerTwoMove == "Paper"))
  {
    return "Client wins!";
  }
  else
  {
    return "Server wins!";
  }
}
