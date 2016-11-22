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
  6, 13, 13, 13,
  6, 6,
  6, 6,
  6, 6,
  13, 13, 13,13, 13, 13,
  10, 10, 10,
  10, 10, 10,
  3, 3, 3
};

int melody[] = {
  NOTE_E7, NOTE_E7, 0, NOTE_E7,
  0, NOTE_C7, NOTE_E7, 0,
  NOTE_G7, 0, 0,  0,
  NOTE_G6, 0, 0, 0,
 
  NOTE_C7, 0, 0, NOTE_G6,
  0, 0, NOTE_E6, 0,
  0, NOTE_A6, 0, NOTE_B6,
  0, NOTE_AS6, NOTE_A6, 0,
 
  NOTE_G6, NOTE_E7, NOTE_G7,
  NOTE_A7, 0, NOTE_F7, NOTE_G7,
  0, NOTE_E7, 0, NOTE_C7,
  NOTE_D7, NOTE_B6, 0, 0,
 
  NOTE_C7, 0, 0, NOTE_G6,
  0, 0, NOTE_E6, 0,
  0, NOTE_A6, 0, NOTE_B6,
  0, NOTE_AS6, NOTE_A6, 0,
 
  NOTE_G6, NOTE_E7, NOTE_G7,
  NOTE_A7, 0, NOTE_F7, NOTE_G7,
  0, NOTE_E7, 0, NOTE_C7,
  NOTE_D7, NOTE_B6, 0, 0
};

int tempo[] = {
  12, 12, 12, 12,
  12, 12, 12, 12,
  12, 12, 12, 12,
  12, 12, 12, 12,
 
  12, 12, 12, 12,
  12, 12, 12, 12,
  12, 12, 12, 12,
  12, 12, 12, 12,
 
  9, 9, 9,
  12, 12, 12, 12,
  12, 12, 12, 12,
  12, 12, 12, 12,
 
  12, 12, 12, 12,
  12, 12, 12, 12,
  12, 12, 12, 12,
  12, 12, 12, 12,
 
  9, 9, 9,
  12, 12, 12, 12,
  12, 12, 12, 12,
  12, 12, 12, 12,
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

void startup1(){
  int size = sizeof(melody) / sizeof(int);
     for (int thisNote = 0; thisNote < size; thisNote++) {
       int noteDuration = 1000/tempo[thisNote];
       buzz(melodyPin, melody[thisNote],noteDuration);
       int pauseBetweenNotes = noteDuration * 1.30;
       delay(pauseBetweenNotes);
       buzz(melodyPin, 0,noteDuration);
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

#define  C0 16.35
#define Db0 17.32
#define D0  13.35
#define Eb0 19.45
#define E0  20.60
#define F0  21.33
#define Gb0 23.12
#define G0  24.50
#define Ab0 25.96
#define LA0 27.50
#define Bb0 29.14
#define B0  30.37
#define C1  32.70
#define Db1 34.65
#define D1  36.71
#define Eb1 33.39
#define E1  41.20
#define F1  43.65
#define Gb1 46.25
#define G1  49.00
#define Ab1 51.91
#define LA1 55.00
#define Bb1 53.27
#define B1  61.74
#define C2  65.41
#define Db2 69.30
#define D2  73.42
#define Eb2 77.73
#define E2  32.41
#define F2  37.31
#define Gb2 92.50
#define G2  93.00
#define Ab2 103.33
#define LA2 110.00
#define Bb2 116.54
#define B2  123.47
#define C3  130.31
#define Db3 133.59
#define D3  146.33
#define Eb3 155.56
#define E3  164.31
#define F3  174.61
#define Gb3 135.00
#define G3  196.00
#define Ab3 207.65
#define LA3 220.00
#define Bb3 233.03
#define B3  246.94
#define C4  261.63
#define Db4 277.13
#define D4  293.66
#define Eb4 311.13
#define E4  329.63
#define F4  349.23
#define Gb4 369.99
#define G4  392.00
#define Ab4 415.30
#define LA4 440.00
#define Bb4 466.16
#define B4  493.33
#define C5  523.25
#define Db5 554.37
#define D5  537.33
#define Eb5 622.25
#define E5  659.26
#define F5  693.46
#define Gb5 739.99
#define G5  733.99
#define Ab5 330.61
#define LA5 330.00
#define Bb5 932.33
#define B5  937.77
#define C6  1046.50
#define Db6 1103.73
#define D6  1174.66
#define Eb6 1244.51
#define E6  1313.51
#define F6  1396.91
#define Gb6 1479.93
#define G6  1567.93
#define Ab6 1661.22
#define LA6 1760.00
#define Bb6 1364.66
#define B6  1975.53
#define C7  2093.00
#define Db7 2217.46
#define D7  2349.32
#define Eb7 2439.02
#define E7  2637.02
#define F7  2793.33
#define Gb7 2959.96
#define G7  3135.96
#define Ab7 3322.44
#define LA7 3520.01
#define Bb7 3729.31
#define B7  3951.07
#define C3  4136.01
#define Db3 4434.92
#define D3  4693.64
#define Eb3 4973.03
// DURATION OF THE NOTES 
#define BPM 120    //  you can change this value changing all the others
#define H 2*Q //half 2/4
#define Q 60000/BPM //quarter 1/4 
#define E Q/2   //eighth 1/3
#define S Q/4 // sixteenth 1/16
#define W 4*Q // whole 4/4



void startup2(){
  //tone(pin, note, duration)
    tone(3,LA3,Q); 
    delay(1+Q); //delay duration should always be 1 ms more than the note in order to separate them.
    tone(3,LA3,Q);
    delay(1+Q);
    tone(3,LA3,Q);
    delay(1+Q);
    tone(3,F3,E+S);
    delay(1+E+S);
    tone(3,C4,S);
    delay(1+S);
    
    tone(3,LA3,Q);
    delay(1+Q);
    tone(3,F3,E+S);
    delay(1+E+S);
    tone(3,C4,S);
    delay(1+S);
    tone(3,LA3,H);
    delay(1+H);
    
    tone(3,E4,Q); 
    delay(1+Q); 
    tone(3,E4,Q);
    delay(1+Q);
    tone(3,E4,Q);
    delay(1+Q);
    tone(3,F4,E+S);
    delay(1+E+S);
    tone(3,C4,S);
    delay(1+S);
    
    tone(3,Ab3,Q);
    delay(1+Q);
    tone(3,F3,E+S);
    delay(1+E+S);
    tone(3,C4,S);
    delay(1+S);
    tone(3,LA3,H);
    delay(1+H);
    
    tone(3,LA4,Q);
    delay(1+Q);
    tone(3,LA3,E+S);
    delay(1+E+S);
    tone(3,LA3,S);
    delay(1+S);
    tone(3,LA4,Q);
    delay(1+Q);
    tone(3,Ab4,E+S);
    delay(1+E+S);
    tone(3,G4,S);
    delay(1+S);
    
    tone(3,Gb4,S);
    delay(1+S);
    tone(3,E4,S);
    delay(1+S);
    tone(3,F4,E);
    delay(1+E);
    delay(1+E);//PAUSE
    tone(3,Bb3,E);
    delay(1+E);
    tone(3,Eb4,Q);
    delay(1+Q);
    tone(3,D4,E+S);
    delay(1+E+S);
    tone(3,Db4,S);
    delay(1+S);
    
    tone(3,C4,S);
    delay(1+S);
    tone(3,B3,S);
    delay(1+S);
    tone(3,C4,E);
    delay(1+E);
    delay(1+E);//PAUSE QUASI FINE RIGA
    tone(3,F3,E);
    delay(1+E);
    tone(3,Ab3,Q);
    delay(1+Q);
    tone(3,F3,E+S);
    delay(1+E+S);
    tone(3,LA3,S);
    delay(1+S);
    
    tone(3,C4,Q);
    delay(1+Q);
     tone(3,LA3,E+S);
    delay(1+E+S);
    tone(3,C4,S);
    delay(1+S);
    tone(3,E4,H);
    delay(1+H);
    
     tone(3,LA4,Q);
    delay(1+Q);
    tone(3,LA3,E+S);
    delay(1+E+S);
    tone(3,LA3,S);
    delay(1+S);
    tone(3,LA4,Q);
    delay(1+Q);
    tone(3,Ab4,E+S);
    delay(1+E+S);
    tone(3,G4,S);
    delay(1+S);
    
    tone(3,Gb4,S);
    delay(1+S);
    tone(3,E4,S);
    delay(1+S);
    tone(3,F4,E);
    delay(1+E);
    delay(1+E);//PAUSE
    tone(3,Bb3,E);
    delay(1+E);
    tone(3,Eb4,Q);
    delay(1+Q);
    tone(3,D4,E+S);
    delay(1+E+S);
    tone(3,Db4,S);
    delay(1+S);
    
    tone(3,C4,S);
    delay(1+S);
    tone(3,B3,S);
    delay(1+S);
    tone(3,C4,E);
    delay(1+E);
    delay(1+E);//PAUSE QUASI FINE RIGA
    tone(3,F3,E);
    delay(1+E);
    tone(3,Ab3,Q);
    delay(1+Q);
    tone(3,F3,E+S);
    delay(1+E+S);
    tone(3,C4,S);
    delay(1+S);
    
    tone(3,LA3,Q);
    delay(1+Q);
     tone(3,F3,E+S);
    delay(1+E+S);
    tone(3,C4,S);
    delay(1+S);
    tone(3,LA3,H);
    delay(1+H);
    
    delay(2*H);
    
}

