#include <SPI.h>
#include <MFRC522.h>

#include "geluidje.h"

#define RST_PIN         9
#define SS_PIN          10

#define ledrpin  6
#define ledgpin  5

MFRC522 mfrc522(SS_PIN, RST_PIN);

MFRC522::MIFARE_Key key;

String getsu = "";
unsigned long times;

unsigned long timesOfScan;

void beep(){
  tone(3,3000,240);
}

void setup() {
  pinMode(3, OUTPUT);
  pinMode(2,OUTPUT);
  digitalWrite(2,LOW);
  pinMode(ledrpin, OUTPUT);
  pinMode(ledgpin, OUTPUT);
  digitalWrite(ledrpin, LOW);
  digitalWrite(ledgpin,HIGH);
  
  Serial.begin(9600);
  while(!Serial);
  SPI.begin();
  mfrc522.PCD_Init();
  for (byte i = 0; i < 6; i++) {
     key.keyByte[i] = 0xFF; //change deze
  }
  
  digitalWrite(ledgpin, LOW);
  //startup(); // geluidje
}

void ledDontScan(){
  digitalWrite(ledrpin,HIGH);
  //digitalWrite(ledgpin,HIGH);
  delay(80);
  digitalWrite(ledrpin,LOW);
  //digitalWrite(ledgpin,LOW);
  delay(80);
}

void ledScan(){
  for(int x = 7; x<10; x++){
    digitalWrite(ledgpin,HIGH);
    delay(40);
    digitalWrite(ledgpin,LOW);
        delay(40);
  }
}

void dump_byte_array(byte *buffer, byte bufferSize) {
    String newGetsu = "";
    times = millis();

    for (byte i = 0; i < bufferSize; i++) {
        newGetsu += (buffer[i] < 0x10 ? " 0" : " ");
        newGetsu += (buffer[i]); }
            
    if(newGetsu != getsu){
          Serial.println(newGetsu);
          beep();
          ledScan();

          getsu = newGetsu; }else{ ledDontScan();}
      
}

void loop() {  
   if(times+1000 < millis()){
    getsu = "";
   }  
   if(!mfrc522.PICC_IsNewCardPresent()){ return;} // is er überhaupt een kaart
   if(!mfrc522.PICC_ReadCardSerial()){ return;}
   dump_byte_array(mfrc522.uid.uidByte, mfrc522.uid.size);    

}
