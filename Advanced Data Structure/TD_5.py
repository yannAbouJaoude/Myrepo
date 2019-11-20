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

def insert(root, value): 
  
    #if root==None or value == root.value: return node(value) 
    if root==None : return node(value) 
    elif value < root.value:  root.left = insert(root.left, value) 
    elif value == root.value: return root 
    else: root.right = insert(root.right, value) 
    balance = getBalance(root) 

    # Case 1 - Left Left 
    if balance > 1 and value < root.left.value: return rightRotate(root) 
    # Case 2 - Right Right 
    if balance < -1 and value > root.right.value: return leftRotate(root) 
    # Case 3 - Left Right 
    if balance > 1 and value > root.left.value: 
        root.left = leftRotate(root.left) 
        return rightRotate(root) 
    # Case 4 - Right Left 
    if balance < -1 and value < root.right.value: 
        root.right = rightRotate(root.right) 
        return leftRotate(root) 

    return root 
  
def leftRotate(z): 
  
    y = z.right 
    T2 = y.left 
    y.left = z 
    z.right = T2 
    return y 
  
def rightRotate(z): 
  
    y = z.left 
    T3 = y.right 
  
    y.right = z 
    z.left = T3 

    return y 
  
  
def getBalance(root): 
    if not root: 
        return 0

    return getHeight(root.left) - getHeight(root.right) 

def getHeight(root):
	if root == None: return 0
	else : return 1+max(getHeight(root.left),getHeight(root.right))
   
 
exercice1 = node(10)
exercice1 =insert(exercice1, 20) 
exercice1 =insert(exercice1, 15) 
exercice1 =insert(exercice1, 25) 
exercice1 =insert(exercice1, 30) 
exercice1 =insert(exercice1, 16) 
exercice1 =insert(exercice1, 18) 
exercice1 =insert(exercice1, 19) 

print("Exercice 1") 
printTreeByLevel(exercice1) 

exercice2=node(7)
exercice2=insert(exercice2, 10) 
exercice2=insert(exercice2, 15) 
exercice2=insert(exercice2, 8) 
exercice2=insert(exercice2, 9) 
exercice2=insert(exercice2, 13) 

print("Exercice 2") 
printTreeByLevel(exercice2)

exercice3=node(80)
exercice3=insert(exercice3, 50) 
exercice3=insert(exercice3, 110) 
exercice3=insert(exercice3, 20) 
exercice3=insert(exercice3, 60) 
exercice3=insert(exercice3, 90) 
exercice3=insert(exercice3, 120) 
exercice3=insert(exercice3, 10) 
exercice3=insert(exercice3, 40) 
exercice3=insert(exercice3, 70) 
exercice3=insert(exercice3, 100)
exercice3=insert(exercice3, 30) 


print("Exercice 3") 
printTreeByLevel(exercice3) 
print("Added 65 to the tree") 
exercice3=insert(exercice3, 65) 
printTreeByLevel(exercice3) 
#Exercice 4
# see insert funct

  




