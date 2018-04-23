#include<MFRC522.h>
#include<SPI.h>

#define SDAPIN 10
#define RESETPIN 9

#define L_TRIG_PIN 3
#define L_ECHO_PIN 2

#define R_TRIG_PIN 4
#define R_ECHO_PIN 5

#define R_BUTTON A0
#define L_BUTTON A1

#define R_MOTOR 7
#define L_MOTOR 6

#define TAG_FOUND 1
#define FIND_TAG 0
#define VENDING 2

int state = FIND_TAG;
byte found_tag; //variable used to check if the tag was found
byte read_tag; //variable used to store anti collision value to read Tag info
byte tag_data[MAX_LEN]; //variable used to store the full tag data
byte tag_serial_num[5]; //variable used to store the tag serial number
byte good_tag_serial_num[5] = {0x47, 0xC1, 0x8D, 0xAB}; //serial number we are looking for
int l_button_state = 0;
int r_button_state = 0;
MFRC522 nfc(SDAPIN, RESETPIN);

void vend(const int echo, const int trig, const int motor){
  long duration;
  int cm = 8;

  while(cm > 4){

    digitalWrite(R_TRIG_PIN, LOW);
    delayMicroseconds(2);
    digitalWrite(R_TRIG_PIN, HIGH);

    delayMicroseconds(10);

    duration = pulseIn(R_ECHO_PIN, HIGH);

    cm = duration * 0.034 / 2;
    Serial.print(cm);
    Serial.println(" cm");
    //start_motor(motor);

  }
  stop_motors();
}

void stop_all_motors(){
  analogWrite(L_MOTOR, 0);
  analogWrite(R_MOTOR, 0);
}

void start_motor(int motor){		//parameter is pin number of motor
  analogWrite(motor, 130);
}

void setup() {
  SPI.begin();
  Serial.begin(9600);

  //Serial.print("Looking for RFID Reader");
  nfc.begin();
  byte version = nfc.getFirmwareVersion();

  if(!version){
    Serial.println("Didn't find RC522 board");
    while(1);
  }

	//  pinMode(GREENLED, OUTPUT);
	//  pinMode(BLUELED, OUTPUT);

	//  digitalWrite(GREENLED, LOW);
	//  digitalWrite(BLUELED, LOW);

  pinMode(L_BUTTON, INPUT);
  pinMode(R_BUTTON, INPUT);

  pinMode(L_TRIG_PIN, OUTPUT);
  pinMode(L_ECHO_PIN, INPUT);

  pinMode(R_TRIG_PIN, OUTPUT);
  pinMode(R_ECHO_PIN, INPUT);

  Serial.print("Found chip RC522 ");
  Serial.print("Firmware version 0x ");
  Serial.println(version, HEX);
  Serial.println();
}

void loop() {
  if (state == FIND_TAG){
    String good_tag = "False";
    found_tag = nfc.requestTag(MF1_REQIDL, tag_data);

    if(found_tag == MI_OK){
      delay(200);
      read_tag = nfc.antiCollision(tag_data);
      memcpy(tag_serial_num, tag_data, 4);

      Serial.print("Tag detected. Serial number: ");
      for(int i = 0; i < 4; i++){
        Serial.print(tag_serial_num[i], HEX);
        Serial.print(" ");
      }
      Serial.println();

      for(int i =0; i < 4; i++){
        if(good_tag_serial_num[i] != tag_serial_num[i]){
          break;
        }
        if(i == 3){
          good_tag = "TRUE";
          state = TAG_FOUND;
        }
      }
    }
  }

  else if(state ==  TAG_FOUND){
    if( Serial.available() > 0){
       char response;
       response = Serial.read();
       if(response == 'y'){
//        int time1 = millis();
//        int crnt_time = millis();
//        while(crnt_time - time1 < 2000){
//          crnt_time = millis();
//          digitalWrite(GREENLED, HIGH);
//          digitalWrite(BLUELED, LOW);
//        }
        state = VENDING;
//        digitalWrite(GREENLED, LOW);
      }
      else{
//        int time1 = millis();
//        int crnt_time = millis();
//        while(crnt_time - time1 < 2000){
//          crnt_time = millis();
//          digitalWrite(GREENLED, LOW);
//          digitalWrite(BLUELED, HIGH);
//        }
        state = FIND_TAG;
//        digitalWrite(BLUELED, LOW);
      }
    }
  }

  else if(state == VENDING){
    l_button_state = digitalRead(L_BUTTON);
    r_button_state = digitalRead(R_BUTTON);


    if(l_button_state == HIGH && r_button_state == LOW){
      vend(L_ECHO_PIN, L_TRIG_PIN, L_MOTOR);
      state = FIND_TAG;
    } else if (l_button_state == LOW && r_button_state == HIGH){
      vend(R_ECHO_PIN, R_TRIG_PIN, R_MOTOR);
      state = FIND_TAG;
    }
  }

}
