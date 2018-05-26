import serial
from firebase import firebase
import sys
import time

# Firebase setup
FIREBASE_ROOT = 'https://vendinghealth-alpha.firebaseio.com'
firebase = firebase.FirebaseApplication(FIREBASE_ROOT, None)

# Arduino Communication
serial_port = '/dev/ttyUSB0'
baud_rate = 9600
ser = serial.Serial(serial_port, baud_rate)

def formatForFirebase(id):
    return id + ' '


# Firebase Communication

def updateUserBalance(user, userID, product):
    user["balance"] = user["balance"] - product["kcal"]
    userpath = '/Users/' + userID
    result = firebase.patch(userpath, user)


def getUserByID(id):
    result = firebase.get('/Users', None)
    user = result.get(id)
    print "user::",
    print user
    return user


def getProductByID(id):
    result = firebase.get('/Products', None)
    product = result.get(id)
    print "product"
    print product
    if (product == None):
        return None
    else:
        return product


def getProductCost(product):
    return product.get("kcal")


def getBalance(user):
    return user.get("balance")


def hasStock(product):
    if product["stock"] > 0:
        return True
    else:
        return False


def updateStock(product, productID):
    product["stock"] = product["stock"] - 1
    productpath = '/Products/' + productID
    result = firebase.patch(productpath, product)


def hasMoney(balance, cost):
    if balance >= cost:
        return True
    else:
        return False


def getProductStock(product):
    return product.get("stock")

# Arduino data extraction
def extractCardID(line):
    id = line
    # return "47 C1 8D AB"  # TODO: for test
    return id


def getProductID(line):
    prodID = line
    return prodID


def _readLineSerial():
    line = ser.readline()
    line = line.decode('utf-8')
    line = line[:-2]
    print [line, line]
    sys.stdout.write("- Serial:\"" + line + "\"\n")
    time.sleep(0.5)

	#read whatever is left in the serial and discard it
    while ser.inWaiting():
        ser.readline()
    return line


def formatLineForID(line):
    id = line[:-1]
    return id


while True:
    line = _readLineSerial()  # expect card number
    id = formatLineForID(line)
    user = getUserByID(id)
    if user == None:
        print "user if: N"
        ser.write("N")  # put Arduino in FINDING_USER state
        continue
    else:
        print "user if: Y"
        ser.write("Y")  # put Arduino in FOUND_USER state

    # product extraction
    line = _readLineSerial()  # expect button number
    productID = formatForFirebase(line)
    sys.stdout.write("\""+productID + "\"")
    product = getProductByID(productID)
    productCost = getProductCost(product)  # number of kcal of product
    balance = getBalance(user)
    if hasMoney(balance, productCost) and hasStock(product):
        ser.write("Y")
        updateStock(product, productID)
        updateUserBalance(user, id, product)
    else:

        ser.write("N")