from firebase import firebase
# Firebase setup
FIREBASE_ROOT = 'https://vendinghealth-alpha.firebaseio.com'
firebase = firebase.FirebaseApplication(FIREBASE_ROOT, None)

hcProductID = 2
hcUserID = "47 C1 8D AB"

def formatForFirebase(id):
	return `id` + ' '

def updateUserBalance(user, product):
	user["balance"] = user["balance"] - product["kcal"]
	print user
	userpath = '/Users/' + hcUserID
	result = firebase.patch(userpath, user)
	# val = {"balance" : user["balance"]}
	# result = firebase.patch(userpath, val)

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

hcProductID = formatForFirebase(hcProductID)
user = getUserByID(hcUserID)
product = getProductByID(hcProductID)
updateUserBalance(user, product)
