void setup() 
{
  Serial.begin(9600); 
}

void loop() 
{
  if (Serial.available()) 
  {
    String message = Serial.readStringUntil('\n'); 
    String modifiedMessage = message + " Hello, client!"; 
    Serial.println(modifiedMessage); 
    delay(1000); 
  }
}
