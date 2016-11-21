#include "pitches.h"

#define melodyPin 3
int underworld_melody[] = {
  0, NOTE_DS4, NOTE_CS4, NOTE_D4,
  NOTE_CS4, NOTE_DS4, 
  NOTE_DS4, NOTE_GS3,
  NOTE_G3, NOTE_CS4,
  NOTE_C4, NOTE_FS4,NOTE_F4, NOTE_E3, NOTE_AS4, NOTE_A4,
  NOTE_GS4, NOTE_DS4, NOTE_B3,
  NOTE_AS3, NOTE_A3, NOTE_GS3,
  0, 0, 0
};

int underworld_tempo[] = {
  6, 18, 18, 18,
  6, 6,
  6, 6,
  6, 6,
  18, 18, 18,18, 18, 18,
  10, 10, 10,
  10, 10, 10,
  3, 3, 3
};

void buzz(int targetPin, long frequency, long length) {
  digitalWrite(13,HIGH);
  long delayValue = 1000000/frequency/2;
  long numCycles = frequency * length/ 1000; 
  for (long i=0; i < numCycles; i++){
    digitalWrite(targetPin,HIGH);
    delayMicroseconds(delayValue);
    digitalWrite(targetPin,LOW);
    delayMicroseconds(delayValue); 
  }
}

 void startup(){
  int size = sizeof(underworld_melody) / sizeof(int);
     for (int thisNote = 0; thisNote < size; thisNote++) {
       int noteDuration = 1000/underworld_tempo[thisNote];
       buzz(melodyPin, underworld_melody[thisNote],noteDuration);
       int pauseBetweenNotes = noteDuration * 1.30;
       delay(pauseBetweenNotes);
       buzz(melodyPin, 0,noteDuration);
    }
} 

