import serial
from firebase import firebase

# Firebase setup
FIREBASE_ROOT = 'https://vendinghealth-alpha.firebaseio.com'
firebase = firebase.FirebaseApplication(FIREBASE_ROOT, None)

#Arduino Communication
serial_port = '/dev/ttyUSB0'
baud_rate = 9600
ser = serial.Serial(serial_port, baud_rate)

def formatForFirebase(id):
	return `id` + ' '

def updateUserBalance(user, product):
	user["balance"] = user["balance"] - product["kcal"]
	userpath = '/Users/' + hcUserID
	val = {"balance" : user["balance"]}
	result = firebase.patch(userpath, val)

def getUserByID( id ):
	result = firebase.get('/Users', None)
 	user = result.get(id)
	if(user == None):
		return None
	else:
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

def getProductID_fromArduino():
	prodID = ser.readline()
	return prodID

def _readLineSerial():
	line = ser.readline()
	line = line.decode("utf-8")
	return line

def getProductStock(product):
	return 2

while True:
	line = _readLineSerial()
	id = extractCardID(line)
	cost = extractProductCost(line)

	user = getUserByID(id)
	if user == None:
		ser.write("U0")		#put Arduino in FINDING_USER state
		continue
	else:
		ser.write("U1")		#put Arduino in FOUND_USER state

	balance = getBalance(user)
	productID = getProductID_fromArduino(ser)
	product = getProductByID(productID)
	productCost = getProductCost(product)

	if (balance - productCost) >= 0:
		print("print in serial that it can vend")
	else:
		print("print in serial that it can't vend. also show insufficient funds")

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
