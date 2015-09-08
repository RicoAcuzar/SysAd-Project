const byte socketA=4;
const byte socketB=7;
const byte pin_led=13;
char buff=0;

void setup() {
  pinMode(socketA, OUTPUT);
  pinMode(socketB, OUTPUT);
  pinMode(pin_led, OUTPUT);
  Serial.begin(9600);
  digitalWrite(socketA, LOW);
  digitalWrite(socketB, LOW);
  digitalWrite(pin_led, LOW);
  delay(100);
  digitalWrite(socketA, HIGH);
  digitalWrite(socketB, HIGH);
  digitalWrite(pin_led, HIGH);
  delay(300);
  digitalWrite(socketA, LOW);
  digitalWrite(socketB, LOW);
  //digitalWrite(pin_led, LOW);
}

void loop() {
  if(Serial.available()>0) {
    buff=Serial.read();
    if(buff=='A') digitalWrite(socketA, LOW);
    else if(buff=='B') digitalWrite(socketA, HIGH);
    else if(buff=='C') digitalWrite(socketB, LOW);
    else if(buff=='D') digitalWrite(socketB, HIGH);
    else if(buff=='E') digitalWrite(pin_led, LOW);
    else if(buff=='F') digitalWrite(pin_led, HIGH);
    else { }
    delay(100);
  }
  delay(1);
}
