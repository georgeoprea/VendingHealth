import serial
from firebase import firebase

FIREBASE_ROOT = 'https://vendinghealth-alpha.firebaseio.com'
firebase = firebase.FirebaseApplication(FIREBASE_ROOT, None)

serial_port = '/dev/ttyUSB0'
baud_rate = 9600
ser = serial.Serial(serial_port, baud_rate)

def getUserByID( id ):
	result = firebase.get('/Users', None)
 	user = result.get(id)
	if(user == None):
		print("\nNULL USER\n")
		return None
	else:
		print("User::::")
		print(user)
		return user

def extractCardID( line ):
	# TODO: parse line to get card ID:
	id = ""
	# id = line.parse...
	# return id
	return "47 C1 8D AB"  # TODO: for test

def extractProductCost( line ):
	#parse line
	#extract cost

	return 200		# TODO: for test

def getBalance( user ):
	return user.get("balance")

while True:
	line = ser.readline()
	line = line.decode("utf-8")
	id = extractCardID( line )
	cost = extractProductCost( line )

	user = getUserByID(id)
	if user == None:
		print("Non Existent User")
		continue

	balance = getBalance(user)

	print("balance:" + balance)

	if (balance >= cost):
		print("Vending...")

		ser.write("y")
		while True:
			response = ser.readline()
			print(line)
			if "done" in response:
				break
		else:
			ser.write("n")
		print(line)
	# if id in line:
	# 	ser.write("y")
	# 	while True:
	# 		response = ser.readline()
	# 		print(line)
	# 		if "done" in response:
	# 			break
	# 	else:
	# 		ser.write("n")
	# 	print(line)
