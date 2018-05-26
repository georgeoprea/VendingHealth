#include<MFRC522.h>
#include<SPI.h>

#define SDAPIN 10
#define RESETPIN 9

#define L_TRIG_PIN 2
#define L_ECHO_PIN 3

#define R_TRIG_PIN 4
#define R_ECHO_PIN 5

#define R_BUTTON A0
#define L_BUTTON A1

#define R_MOTOR 7
#define L_MOTOR 6

#define WAIT_FOR_TAG 1
#define CARD_CONFIRMATION 2
#define PRODUCT_SELECTION 3
#define STOCK_AND_BALANCE_CHECK 4
#define VENDING 5

#define BLUELED A5

void turnOnBlue(){
  analogWrite(BLUELED, 255);
}

void turnOffBlue(){
  analogWrite(BLUELED, 0);
}

int motorToSpin = 0;
int state = WAIT_FOR_TAG;
byte found_tag;             //variable used to check if the tag was found
byte read_tag;              //variable used to store anti collision value to read Tag info
byte tag_data[MAX_LEN];     //variable used to store the full tag data
byte tag_serial_num[5];     //variable used to store the tag serial number
int l_button_state = 0;
int r_button_state = 0;
MFRC522 nfc(SDAPIN, RESETPIN);

void vend(const int echo, const int trig, const int motor){
  long duration;
  int cm = 8;

  while(cm > 4){

  digitalWrite(trig, LOW);
  delayMicroseconds(2);
  digitalWrite(trig, HIGH);
  delayMicroseconds(10);
  digitalWrite(trig, LOW);
    duration = pulseIn(echo, HIGH);

    cm = duration * 0.034 / 2;
//    Serial.print(cm);
//    Serial.print(" cm ");
//    Serial.print("Motor "); Serial.print(motor);Serial.println(" is spinning");
    start_motor(motor);

  }
  motorToSpin = 0;
  stop_all_motors();
}

void stop_all_motors(){
  analogWrite(L_MOTOR, 0);
  analogWrite(R_MOTOR, 0);
}

void start_motor(int motor){    //parameter is pin number of motor
  analogWrite(motor, 255);
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
  pinMode(BLUELED, OUTPUT);

  pinMode(L_BUTTON, INPUT);
  pinMode(R_BUTTON, INPUT);

  pinMode(L_TRIG_PIN, OUTPUT);
  pinMode(L_ECHO_PIN, INPUT);

  pinMode(R_TRIG_PIN, OUTPUT);
  pinMode(R_ECHO_PIN, INPUT);

//  Serial.print("Found chip RC522 ");
//  Serial.print("Firmware version 0x ");
//  Serial.println(version, HEX);
//  Serial.println();
}
void loop() {

  switch(state){

    case WAIT_FOR_TAG :
      found_tag = nfc.requestTag(MF1_REQIDL, tag_data);

      if(found_tag == MI_OK){
        delay(200);
        read_tag = nfc.antiCollision(tag_data);
        memcpy(tag_serial_num, tag_data, 4);

        // Serial.print("Tag detected. Serial number: ");
        for(int i = 0; i < 4; i++){
          Serial.print(tag_serial_num[i], HEX);
          Serial.print(" ");
        }
        Serial.println();
        state = CARD_CONFIRMATION;
      }
      break;

    case CARD_CONFIRMATION:
      char response;
      if( Serial.available() > 0){
        response = Serial.read();
        pinMode(L_BUTTON, INPUT);
        if(response == 'Y'){
          state = PRODUCT_SELECTION;
        }
        else {
          printf("User not found\n");
          state = WAIT_FOR_TAG;
        }
      }
      break;

    case PRODUCT_SELECTION:
      l_button_state = digitalRead(L_BUTTON);
      r_button_state = digitalRead(R_BUTTON);

      if(l_button_state == HIGH && r_button_state == LOW){
        Serial.println("1");
        state = STOCK_AND_BALANCE_CHECK;
        motorToSpin = L_MOTOR;
      }
      else if (l_button_state == LOW && r_button_state == HIGH){
        Serial.println("2");
        state = STOCK_AND_BALANCE_CHECK;
        motorToSpin = R_MOTOR;
      }
      break;

    case STOCK_AND_BALANCE_CHECK:
      if( Serial.available() > 0){
        response = Serial.read();
        if(response == 'Y'){
          turnOnBlue();
          state = VENDING;
        } else {
          turnOffBlue();
          state = WAIT_FOR_TAG;
        }
      }
      break;

      case VENDING:
        if(motorToSpin == L_MOTOR)
          vend(L_ECHO_PIN, L_TRIG_PIN, motorToSpin);
        else
          vend(R_ECHO_PIN, R_TRIG_PIN, motorToSpin);
        state = WAIT_FOR_TAG;
        break;

      default:
        state = WAIT_FOR_TAG;
    }
}