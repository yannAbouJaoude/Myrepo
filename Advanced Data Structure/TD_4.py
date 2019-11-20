
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
		print()

def insert(curNode,value):
	
	if(curNode.value==None):
		curNode.value=value
		print("Value added : ",value)

	elif(value<curNode.value):
		print(value," is lower than ",curNode.value)
		if curNode.left: insert(curNode.left,value)
		else:
			curNode.left=node(value)
			print("Value added : ",value)

	elif(value>curNode.value):

		print(value," is highter than ",curNode.value)
		if curNode.right: insert(curNode.right,value)
		else:
			curNode.right=node(value)
			print("Value added : ",value)

	else:
		print(value," is found, no value added")

root=node()

#Exercice 1

insert(root,8)
insert(root,13)
insert(root,6)
insert(root,10)
insert(root,21)
insert(root,19)
insert(root,58)
insert(root,0)
insert(root,68)

printTreeByLevel(root)
print("")
printTree(root,0)
print("")
printTree(root,1)

#Exercice 2

def find(curNode,value):
	if curNode == None: return False
	elif curNode.value == None: return False
	elif value<curNode.value: return find(curNode.left,value)
	elif value>curNode.value: return find(curNode.right,value)
	else: return curNode

print()
print(find(root,58).value)
print(find(root,3))

#Exercice 3
insert(root,47)

#Exercice 4

def minValue(current): 
    if current.left: 
        return minValue( current.left)   
    return current  

print(minValue(root).value)

def deleteNode(root, value): 
  
    if root==None: return root  
    if value < root.value: root.left = deleteNode(root.left, value) 
    elif(value > root.value): root.right = deleteNode(root.right, value) 
    else: 
        if root.left == None : 
            temp = root.right  
            root = None 
            return temp  
              
        elif root.right == None : 
            temp = root.left  
            root = None
            return temp 
        temp = minValue(root.right) 
        root.value = temp.value 
        root.right = deleteNode(root.right , temp.value) 
    return root  

deleteNode(root,58)
print("")
printTree(root,1)

#Exercice 5
def deleteMin(root): 
	if root.left: 
		root.left=deleteMin(root.left)
		return root
	else :
		if(root.right): return root.right
		else : return None

def deleteMax(root): 
	if root.right: 
		root.right=deleteMax(root.right)
		return root
	else:
		if(root.left): return root.left
		else : return None

deleteMin(root)
print("")
printTree(root,1)
deleteMax(root)
print("")
printTree(root,1)

#Exercice 6

#root=None
#Garbage collector is very effective and do the job perfectly in python. 

#Exercice 7

def compareTree(root1,root2):
	tmp = True
	if root.left!= None : tmp = compareTree(root1.left,root2.left)
	if root.right!= None and tmp: tmp = compareTree(root1.right,root2.right)
	if root1.value!=root2.value: tmp=False
	return tmp

#Execice 8

def isABinaryTree(root):
	tmp = True
	if root.left!= None : tmp = isABinaryTree(root.left)
	if root.right!= None and tmp: tmp = isABinaryTree(root.right)
	if root.right!= None and root.left!= None :
		if root.left.value>root.value or root.value>root.right.value: tmp= False	
	return tmp

#Execice 9

def printTreeDecreasingOrder(root):

	if root.right!= None :
		printTreeDecreasingOrder(root.right)
	print (root.value,end=" ")
	if root.left!= None :
		printTreeDecreasingOrder(root.left)

print()
printTreeDecreasingOrder(root)








