import serial
from firebase import firebase

# Firebase setup
FIREBASE_ROOT = 'https://vendinghealth-alpha.firebaseio.com'
firebase = firebase.FirebaseApplication(FIREBASE_ROOT, None)

#Arduino Communication
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

def extractProductID( line ):
	#parse line
	#extract ID

	return 2		# TODO: for test

def getProductByID( id ):
	result = firebase.get('/Products', None)
 	prod = result.get(id)
	if(prod == None):
		print("\nNULL PRODUCT\n")
		return None
	else:
		print("PRODUCT::::")
		print(product)
		return product

def getProductCost( product ):
	return product.get("kcal")

def getBalance( user ):
	return user.get("balance")

# TODO function that checks if cost is lower than balance

while True:
	line = ser.readline()
	print("serial line::: ", line)
	line = line.decode("utf-8")
	id = extractCardID( line )

	#
	# cost = extractProductCost( line )
	#
	# user = getUserByID(id)
	# if user == None:
	# 	ser.write("U0")
	# 	continue
	# else:
	# 	ser.write("U1")
	#
	# balance = getBalance(user)
	#
	# print("balance:" + balance)
	#
	# if (balance >= cost):
	# 	print("Vending...")
	#
	# 	ser.write("y")
	# 	while True:
	# 		response = ser.readline()
	# 		print(line)
	# 		if "done" in response:
	# 			print("Done Vending.")
	# 			break
	# 	else:
	# 		ser.write("n")
	# 	print(line)
	#


	if id in line:
		ser.write("y")
		while True:
			response = ser.readline()
			print(line)
			if "done" in response:
				break
		else:
			ser.write("n")
		print(line)
