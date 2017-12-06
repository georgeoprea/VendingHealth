#include<MFRC522.h>
#include<SPI.h>

#define SDAPIN 10
#define RESETPIN 8
#define LED 6
#define BLUELED 7
#define GREENLED 2

byte found_tag; //variable used to check if the tag was found
byte read_tag; //variable used to store anti collision value to read Tag info
byte tag_data[MAX_LEN]; //variable used to store the full tag data
byte tag_serial_num[5]; //variable used to store the tag serial number
byte good_tag_serial_num[5] = {0x47, 0xC1, 0x8D, 0xAB}; //serial number we are looking for
MFRC522 nfc(SDAPIN, RESETPIN);

void setup() {
  SPI.begin();
  Serial.begin(9600);
  
  Serial.print("Looking for RFID Reader");
  nfc.begin();
  byte version = nfc.getFirmwareVersion();

  if(!version){
    Serial.println("Didn't find RC522 board");
    while(1);
  }

  pinMode(GREENLED, OUTPUT);
  pinMode(BLUELED, OUTPUT);

  digitalWrite(GREENLED, LOW);
  digitalWrite(BLUELED, LOW);

  Serial.print("Found chip RC522 ");
  Serial.print("Firmware version 0x ");
  Serial.println(version, HEX);
  Serial.println();
}

void loop() {
  
  String good_tag = "False";
  found_tag = nfc.requestTag(MF1_REQIDL, tag_data);

  if(found_tag == MI_OK){
    delay(200);
    read_tag = nfc.antiCollision(tag_data);
    memcpy(tag_serial_num, tag_data, 4);

    Serial.print("Tag detected. Serial number: ");
    for(int i = 0; i < 4; i++){
      analogWrite(LED, 255);
      Serial.print(tag_serial_num[i], HEX);
      analogWrite(LED, 0);
      Serial.print(" ");
    }
    Serial.println(""); 
    Serial.println();

    for(int i =0; i < 4; i++){
      if(good_tag_serial_num[i] != tag_serial_num[i]){
        break;
      }
      if(i == 3){
        good_tag = "TRUE";
      }
    }

  if(Serial.read() == 121){
    digitalWrite(GREENLED, HIGH);
    digitalWrite(BLUELED, LOW);
  }else{
    digitalWrite(GREENLED, LOW);
    digitalWrite(BLUELED, HIGH);
  }
//    if(good_tag == "TRUE"){
////      Serial.println("Success!");
////      Serial.println();
//        digitalWrite(GREENLED, HIGH);
//        digitalWrite(BLUELED, LOW);
//    }
//    else {
////      Serial.println("Tag not accepted!");
////      Serial.println();
//        digitalWrite(GREENLED, LOW);
//        digitalWrite(BLUELED, HIGH);   
//    }
////    digitalWrite(GREENLED, LOW);
////    digitalWrite(BLUELED, LOW);
  } 
}
