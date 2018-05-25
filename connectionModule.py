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

# Firebase Communication

def updateUserBalance(user, userID, product):
	user["balance"] = user["balance"] - product["kcal"]
	userpath = '/Users/' + userID
	result = firebase.patch(userpath, user)

def getUserByID( id ):
	result = firebase.get('/Users', None)
 	user = result.get(id)
	if(user == None):
		return None
	else:
		return user

def getProductByID( id ):
	result = firebase.get('/Products', None)
 	product = result.get(id)
	if(product == None):
		return None
	else:
		return product

def getProductCost( product ):
	return product.get("kcal")

def getBalance( user ):
	return user.get("balance")

def hasStock(product):
	if product["stock"] > 0:
		return True
	else:
		return False

def updateStock(product, productID):
	product["stock"] = product["stock"] - 1
	productpath = '/Products/' + ProductID
	result = firebase.patch(userpath, product)

def hasMoney(balance, cost):
	if balance >= cost:
		return True
	else:
		return False

def getProductStock(product):
	return product.get("stock")

# Arduino data extraction

def extractCardID( line ):
	id = line
	# return "47 C1 8D AB"  # TODO: for test
	return id

def getProductID(line):
	prodID = line
	return prodID

def _readLineSerial():
	#make blocking
	line = ser.readline()
	line = line.decode("utf-8")
	return line

while True:
	line = _readLineSerial()		#expect card number
	id = line
	user = getUserByID(id)
	if user == None:
		ser.write("N")		#put Arduino in FINDING_USER state
		continue
	else:
		ser.write("Y")		#put Arduino in FOUND_USER state

	# product extraction
	line = _readLineSerial()		#expect button number
	productID = formatForFirebase(line)
	product = getProductByID(productID)
	productCost = getProductCost(product)	#number of kcal of product
	balance = getBalance(user)
	if hasMoney(balance, productCost) && hasStock(product):
		ser.write("Y")
		updateStock(product, productID)
		updateUserBalance(user, userID, product)
	else:

		ser.write("N")


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
