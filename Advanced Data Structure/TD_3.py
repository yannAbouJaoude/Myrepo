"""
Exercice 1

Pre-Order
MGDAHKLTRVUW
ABDFGEC
ABCDEFG

In-Order
ADHGKLMRUVTW
GFDBEAC
ACEGFDB

Post-Order
AHDLKGUVRWTM
GFDEBCA
GFEDCBA
"""

class node:

	def __init__(self, value=None, left=None, right=None):
		self.value = value
		self.left = left
		self.right = right

def printTree(root,order):
	#preorder
	if order==0:		
		print (root.value,end=" ")
	if root.left!= None :
		printTree(root.left,order)
	#inorder
	if order==1:
		print (root.value,end=" ")
	if root.right!= None :
		printTree(root.right,order)
	#postorder
	if order==2:
		print (root.value,end=" ")

def printTreeByLevel(root):
		thislevel = [root]

		# While there is another level
		while thislevel:
			nextlevel = list()
			#Print all the nodes in the current level, and store the next level in a list
			for node in thislevel:
				print(node.value,end=" ")
				if node.left: nextlevel.append(node.left)
				if node.right: nextlevel.append(node.right)
			thislevel = nextlevel

#Exercice 3

# Pre-Order of the first BT is : A, B, D, G, H, E, I, C, F, J.
root = node("A")  
root.left = node("B")  
root.right = node("C")  

root.left.left = node("D")  
root.left.right = node("E")  
root.right.left = node("F")   

root.left.left.left = node("G")  
root.left.left.right = node("H")  
root.left.right.left = node("I")   
root.right.left.left = node("J")
 
printTree(root,0)
print()  

#In-Order of second BT is : A, B, C, D, E, F, G, H, I, J, K.

root = node("A")  
root.right = node("B")   
root.right.right = node("C")   
root.right.right.right = node("D")   
root.right.right.right.right = node("E")   
root.right.right.right.right.right = node("F")   
root.right.right.right.right.right.right = node("G")   
root.right.right.right.right.right.right.right = node("H")   
root.right.right.right.right.right.right.right.right = node("I")  
root.right.right.right.right.right.right.right.right.right = node("J") 
root.right.right.right.right.right.right.right.right.right.right = node("K")
 
printTree(root,1)
print()

# Post-Order third BT is : H, I, D, J, K, E, B, L, F, G, C, A.
root = node("A")  
root.left = node("B")  
root.right = node("C")  

root.left.left = node("D")  
root.left.right = node("E")  
root.right.left = node("F")   
root.right.right = node("G") 

root.left.left.left = node("H")  
root.left.left.right = node("I")  
root.left.right.left = node("J")   
root.left.right.right = node("K") 
root.right.left.left = node("L")  
 
printTree(root,2)
print()

#Level-Order four BT is : H, I, D, J, K, E, B, L, F, G, C, A.
root = node("H")  
root.left = node("I")  
root.right = node("D")  

root.left.left = node("J")  
root.left.right = node("K")  
root.right.left = node("E")   
root.right.right = node("B") 

root.left.left.left = node("L")  
root.left.left.right = node("F")  
root.left.right.left = node("G")   
root.left.right.right = node("C") 
root.right.left.left = node("A")  

printTreeByLevel(root)
print();

#Exercice 4

def generatePerfectTree(n,level=0,value=1):
	root=node(value)
	value=(value-2**level)*2
	level=level+1;
	if level!=n :
		root.left=generatePerfectTree(n,level,value+2**level)
		root.right=generatePerfectTree(n,level,value+2**level+1)

	return root
root=generatePerfectTree(4)
printTreeByLevel(root)
print();

#Exercice 5

print("height 1 : average height of nodes = 0")
print("height 2 : average height of nodes = 1/3")
print("height 1 : average height of nodes = 2/3")

#Exercice 6
# voir les fonctions printTree et printTreeByLevel
#Exercice 7

def printAllpath(root,path=""):
	if path=="":
		path=str(root.value)
	if root.left!= None :
		printAllpath(root.left,path+"/"+str(root.left.value))
	print(path)
	if root.right!= None :
		printAllpath(root.right,path+"/"+str(root.right.value))

printAllpath(root);

#Exercice 8
def size(root):
	if root!=None:
		counter=1;
	if root.left!= None :
		counter=counter+size(root.left)
	if root.right!= None :
		counter=counter+size(root.right)
	return counter

print("Size of generated tree: ", size(root))

def maxdepth(root):
	left=0
	right=0
	if root.left!= None :
		left=1+maxdepth(root.left)
	if root.right!= None :
		right=1+maxdepth(root.right)
	if right>left:
		left=right
	return left

print("maxdepth of generated tree: ", maxdepth(root))



