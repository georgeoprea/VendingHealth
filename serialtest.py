import serial
from firebase import firebase

FIREBASE_ROOT = 'https://vendinghealth-alpha.firebaseio.com'
firebase = firebase.FirebaseApplication(FIREBASE_ROOT, None)

serial_port = '/dev/ttyUSB0'
baud_rate = 9600

ser = serial.Serial(serial_port, baud_rate)
while True:
	line = ser.readline()
	line = line.decode("utf-8")
	if "47 C1 8D AB" in line:
		ser.write("y")
		while True:
			response = ser.readline()
			print(line)
			if "done" in response:
				break
		else:
			ser.write("n")
		print(line)
