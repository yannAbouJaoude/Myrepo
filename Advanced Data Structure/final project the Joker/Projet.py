#Exercice 1

class station:

	def __init__(self, name,lattitude,longitude,id):
		self.name = name
		self.lattitude=lattitude
		self.longitude=longitude
		self.id=id
		self.edges = []

	def add(self,station2, line):
		self.edges.append(edge(self,station2,line))

	def describe(self):
		print("This is the ",self.name," station")
		print("From this station you can go to")
		for i in range(len(self.edges)):
			print(self.edges[i].destination.name, " by travelling through the ",self.edges[i].line," Line")

	def describeLineRecur(self,line,prev=None,ban=None):
		#ban est le nom de la premiere station , cette conditionpermet d'eviter detourner autour des lignes circulaire
		if ban==None :
			ban=self.name
		print(self.name,",",end="")
		tmp=0;
		for i in range(len(self.edges)):
			if(self.edges[i].line==line and self.edges[i].destination.name!=prev and self.edges[i].destination.name!=ban):
				if(tmp==1):
					print("")
					print("When you are at ",self.name,"station, If you take the metro in the other direction you will reach :")
				self.edges[i].destination.describeLineRecur(line,self.name,ban)				
				tmp=1

class edge:

	def __init__(self,station1,station2, line=None):
		self.weight = ((station1.lattitude-station2.lattitude)**2+(station1.longitude-station2.longitude)**2)**0.5
		self.line=line
		self.destination = station2

class GothamTransitInformation:

	def __init__(self):
		self.stations=[]
		self.stations.append(station("Wayne Central",503,389,0))#0
		#Vert
		self.stations.append(station("Exit Row",277,224,1))#1
		self.stations.append(station("Admiral Way",316,261,2))#2
		self.stations.append(station("The Arena",356,300,3))#3
		self.stations.append(station("The Exchange",406,350,4))#4
		self.stations.append(station("Kinsley",447,388,5))#5
		self.stations.append(station("Prosper St",475,412,6))#6
		self.stations.append(station("The Narrows",505,443,7))#7
		self.stations.append(station("Murtagh",537,515,8))#8
		self.stations.append(station("Haysville",578,611,9))#9
		#Noir
		self.stations.append(station("Ashing",377,240,10))#10
		self.stations.append(station("North Gainsly",470,240,11))#11
		self.stations.append(station("Billing Avenue",573,240,12))#12
		self.stations.append(station("Gainsly West",635,320,13))#13
		self.stations.append(station("Privvy",635,395,14))#14
		self.stations.append(station("New St",635,535,15))#15
		self.stations.append(station("The Gantry",545,535,16))#16
		self.stations.append(station("Rootsville",660,535,17))#17
		self.stations.append(station("The Banks",710,500,18))#18
		self.stations.append(station("Dullich",487,614,19))#19
		self.stations.append(station("StevensBurgh",407,610,20))#20
		self.stations.append(station("China Docks",300,580,21))#21
		self.stations.append(station("West Harlow",267,502,22))#22
		self.stations.append(station("Sheal Bridge",282,343,23))#23
		#Blanc
		self.stations.append(station("Townsend",212,312,24))#24
		self.stations.append(station("Roolsville Bridge",573,448,25))#25
		self.stations.append(station("East Docklands",700,573,26))#26
		#vert claire
		self.stations.append(station("Pattenden",24,434,27))#27
		self.stations.append(station("Quinsville",73,435,28))#28
		self.stations.append(station("Lower Sheal",118,457,29))#29
		self.stations.append(station("Sansem",180,463,30))#30
		self.stations.append(station("Belcom",293,465,31))#31
		self.stations.append(station("Fleeting",396,447,32))#32
		#Marron
		self.stations.append(station("West Horwlow",28,528,33))#33
		self.stations.append(station("Horslow",109,525,34))#34
		self.stations.append(station("Unamed Station",200,525,35))#35
		self.stations.append(station("Harlow",323,501,36))#36
		#Jaune
		self.stations.append(station("Byron Ave",572,125,37))#37
		self.stations.append(station("Yeavely",572,180,38))#38
		self.stations.append(station("23rd St",572,280,39))#39
		self.stations.append(station("East City Park",576,327,40))#40
		#Rouge
		self.stations.append(station("Jerrold",672,126,41))#41
		self.stations.append(station("Hackart",672,197,42))#42
		self.stations.append(station("Saunders",710,251,43))#43
		self.stations.append(station("Merchants Square",403,484,44))#44
		self.stations.append(station("Stokely",345,535,45))#45
		self.stations.append(station("Docks Bridge",271,606,46))#46
		#Orange
		self.stations.append(station("Endbury",368,87,47))#47
		self.stations.append(station("Sallow",368,152,48))#48
		self.stations.append(station("Marlon",371,207,49))#49
		self.stations.append(station("North City Cross",469,144,50))#50
		self.stations.append(station("Good St",463,296,51))#51
		self.stations.append(station("St Andrews",484,545,52))#52

		self.stations[0].add(self.stations[5],"Brown")
		self.stations[0].add(self.stations[4],"White")
		self.stations[0].add(self.stations[51],"Orange")
		self.stations[0].add(self.stations[40],"Red")
		self.stations[0].add(self.stations[14],"Brown")
		self.stations[0].add(self.stations[17],"White")
		self.stations[0].add(self.stations[7],"Orange")
		self.stations[0].add(self.stations[6],"Red")

		self.stations[1].add(self.stations[2],"Green")

		self.stations[2].add(self.stations[1],"Green")
		self.stations[2].add(self.stations[3],"Green")
		self.stations[2].add(self.stations[10],"Black")
		self.stations[2].add(self.stations[23],"Black")

		self.stations[3].add(self.stations[2],"Green")
		self.stations[3].add(self.stations[4],"Green")

		self.stations[4].add(self.stations[3],"Green")
		self.stations[4].add(self.stations[5],"Green")
		self.stations[4].add(self.stations[23],"White")
		self.stations[4].add(self.stations[0],"White")
		self.stations[4].add(self.stations[51],"Orange")
		self.stations[4].add(self.stations[32],"Orange")

		self.stations[5].add(self.stations[4],"Green")
		self.stations[5].add(self.stations[6],"Green")
		self.stations[5].add(self.stations[0],"Brown")
		self.stations[5].add(self.stations[32],"Brown")

		self.stations[6].add(self.stations[5],"Green")
		self.stations[6].add(self.stations[7],"Green")
		self.stations[6].add(self.stations[0],"Red")
		self.stations[6].add(self.stations[44],"Red")

		self.stations[7].add(self.stations[6],"Green")
		self.stations[7].add(self.stations[8],"Green")
		self.stations[7].add(self.stations[0],"Orange")
		self.stations[7].add(self.stations[52],"Orange")

		self.stations[8].add(self.stations[7],"Green")
		self.stations[8].add(self.stations[9],"Green")

		self.stations[9].add(self.stations[8],"Green")
		self.stations[9].add(self.stations[15],"Black")
		self.stations[9].add(self.stations[19],"Black")

		self.stations[10].add(self.stations[2],"Black")
		self.stations[10].add(self.stations[11],"Black")
		self.stations[10].add(self.stations[49],"Orange")
		self.stations[10].add(self.stations[51],"Orange")

		self.stations[11].add(self.stations[10],"Black")
		self.stations[11].add(self.stations[12],"Black")
		self.stations[11].add(self.stations[50],"Orange")
		self.stations[11].add(self.stations[51],"Orange")

		self.stations[12].add(self.stations[11],"Black")
		self.stations[12].add(self.stations[13],"Black")
		self.stations[12].add(self.stations[38],"Yellow")
		self.stations[12].add(self.stations[39],"Yellow")

		self.stations[13].add(self.stations[12],"Black")
		self.stations[13].add(self.stations[14],"Black")
		self.stations[13].add(self.stations[40],"Red")
		self.stations[13].add(self.stations[43],"Red")

		self.stations[14].add(self.stations[13],"Black")
		self.stations[14].add(self.stations[15],"Black")
		self.stations[14].add(self.stations[0],"Brown")

		self.stations[15].add(self.stations[14],"Black")
		self.stations[15].add(self.stations[16],"Black")
		self.stations[15].add(self.stations[17],"Black")
		self.stations[15].add(self.stations[9],"Black")

		self.stations[16].add(self.stations[15],"Black")
		self.stations[16].add(self.stations[25],"Yellow")
		self.stations[16].add(self.stations[20],"Yellow")	

		self.stations[17].add(self.stations[15],"Black")
		self.stations[17].add(self.stations[18],"Black")	
		self.stations[17].add(self.stations[25],"White")
		self.stations[17].add(self.stations[26],"White")		

		self.stations[18].add(self.stations[17],"Black")

		self.stations[19].add(self.stations[9],"Black")
		self.stations[19].add(self.stations[20],"Black")
		self.stations[19].add(self.stations[52],"Orange")

		self.stations[20].add(self.stations[19],"Black")
		self.stations[20].add(self.stations[21],"Black")
		self.stations[20].add(self.stations[16],"Yellow")
		self.stations[20].add(self.stations[44],"Orange")

		self.stations[21].add(self.stations[20],"Black")
		self.stations[21].add(self.stations[22],"Black")
		self.stations[21].add(self.stations[45],"Red")
		self.stations[21].add(self.stations[46],"Red")

		self.stations[22].add(self.stations[21],"Black")
		self.stations[22].add(self.stations[23],"Black")
		self.stations[22].add(self.stations[34],"Brown")
		self.stations[22].add(self.stations[36],"Brown")

		self.stations[23].add(self.stations[22],"Black")
		self.stations[23].add(self.stations[2],"Black")
		self.stations[23].add(self.stations[24],"White")
		self.stations[23].add(self.stations[4],"White")
		
		self.stations[24].add(self.stations[23],"White")

		self.stations[25].add(self.stations[0],"White")
		self.stations[25].add(self.stations[17],"White")
		self.stations[25].add(self.stations[40],"Yellow")
		self.stations[25].add(self.stations[16],"Yellow")

		self.stations[26].add(self.stations[17],"White")

		self.stations[27].add(self.stations[28],"Light Green")

		self.stations[28].add(self.stations[27],"Light Green")
		self.stations[28].add(self.stations[29],"Light Green")

		self.stations[29].add(self.stations[28],"Light Green")
		self.stations[29].add(self.stations[30],"Light Green")

		self.stations[30].add(self.stations[29],"Light Green")
		self.stations[30].add(self.stations[31],"Light Green")

		self.stations[31].add(self.stations[30],"Light Green")
		self.stations[31].add(self.stations[32],"Light Green")

		self.stations[32].add(self.stations[31],"Light Green")
		self.stations[32].add(self.stations[4],"Orange")
		self.stations[32].add(self.stations[44],"Orange")
		self.stations[32].add(self.stations[36],"Brown")
		self.stations[32].add(self.stations[5],"Brown")

		self.stations[33].add(self.stations[34],"Brown")

		self.stations[34].add(self.stations[33],"Brown")
		self.stations[34].add(self.stations[35],"Brown")

		self.stations[35].add(self.stations[34],"Brown")
		self.stations[35].add(self.stations[22],"Brown")

		self.stations[36].add(self.stations[22],"Brown")
		self.stations[36].add(self.stations[32],"Brown")

		self.stations[37].add(self.stations[38],"Yellow")

		self.stations[38].add(self.stations[37],"Yellow")
		self.stations[38].add(self.stations[12],"Yellow")

		self.stations[39].add(self.stations[12],"Yellow")
		self.stations[39].add(self.stations[40],"Yellow")

		self.stations[40].add(self.stations[39],"Yellow")
		self.stations[40].add(self.stations[25],"Yellow")
		self.stations[40].add(self.stations[0],"Red")
		self.stations[40].add(self.stations[13],"Red")

		self.stations[41].add(self.stations[42],"Red")

		self.stations[42].add(self.stations[41],"Red")
		self.stations[42].add(self.stations[43],"Red")

		self.stations[43].add(self.stations[13],"Red")
		self.stations[43].add(self.stations[42],"Red")

		self.stations[44].add(self.stations[6],"Red")
		self.stations[44].add(self.stations[45],"Red")
		self.stations[44].add(self.stations[32],"Orange")
		self.stations[44].add(self.stations[20],"Orange")

		self.stations[45].add(self.stations[44],"Red")
		self.stations[45].add(self.stations[21],"Red")

		self.stations[46].add(self.stations[21],"Red")

		self.stations[47].add(self.stations[48],"Orange")

		self.stations[48].add(self.stations[47],"Orange")
		self.stations[48].add(self.stations[49],"Orange")

		self.stations[49].add(self.stations[48],"Orange")
		self.stations[49].add(self.stations[10],"Orange")

		self.stations[50].add(self.stations[11],"Orange")

		self.stations[51].add(self.stations[10],"Orange")
		self.stations[51].add(self.stations[11],"Orange")
		self.stations[51].add(self.stations[4],"Orange")
		self.stations[51].add(self.stations[0],"Orange")

		self.stations[52].add(self.stations[7],"Orange")
		self.stations[52].add(self.stations[19],"Orange")

		self.graph = [] #Redondance desdonnee pour le 1.2, on y enregistre les edges
		for i in range(len(self.stations)):
			for j in range(len(self.stations[i].edges)):
				self.graph.append([self.stations[i].id,self.stations[i].edges[j].destination.id,self.stations[i].edges[j].weight])

	#Petite fonction utile pour kruskal
	def find(self, prevNode, i): 
		if prevNode[i] == i: 
			return i 
		return self.find(prevNode, prevNode[i])   

	def KruskalMST(self): 
  
		result =[] #On y met les edges du resultat
  
		i = 0 # L'index des edges de depart (trié) utilisé
		e = 0 # L'index des edges resultats utilisé
  
			#  On trie les edges par ordre croissant 
		self.graph =  sorted(self.graph,key=lambda item: item[2]) 
  
		prevNode = [] ; rang = [] 
  
		# On créé un subset de stations avec des elements uniques
		for node in range(len(self.stations)): 
			prevNode.append(node) 
			rang.append(0) 
	  
		# Le nombre d'edge doit etre égale à N-1 
		while e < len(self.stations) -1 : 
  
			u,v,w =  self.graph[i] 
			i = i + 1
			x = self.find(prevNode, u) 
			y = self.find(prevNode ,v) 
  
			#On inclut les edges en partant du plus petit,
			#on les inclus uniquement si ça ne créé pas de ligne de metro circulaire
			if x != y: 
				e = e + 1	 
				result.append([u,v,w]) 
				xroot = self.find(prevNode, x) 
				yroot = self.find(prevNode, y) 
  
				if rang[xroot] < rang[yroot]: 
					prevNode[xroot] = yroot 
				elif rang[xroot] > rang[yroot]: 
					prevNode[yroot] = xroot 

				else : 
					prevNode[yroot] = xroot 
					rang[xroot] += 1	
		print("The MST is composed of ",len(result),"results")		 		
		print ("Here are the line sections present in the MST")		
		for u,v,weight  in result: 
			#print ("%d -- %d == %d" % (u,v,weight)) 
			print("Stations:",self.stations[u].name,"\t",self.stations[v].name,"\t weight: ",round(weight,3))

#Exercice 2

Exercice2=[[0.0,8.1,9.2,7.7,9.3,2.3,5.1,10.2,6.1,7.0],
[8.1,0.0,12.0,0.9,12.0,9.5,10.1,12.8,2.0,1.0],
[9.2,12.0,0.0,11.2,0.7,11.1,8.1,1.1,10.5,11.5],
[7.7,0.9,11.2,0.0,11.2,9.2,9.5,12.0,1.6,1.1],
[9.3,12.0,0.7,11.2,0.0,11.2,8.5,1.0,10.6,11.6],
[2.3,9.5,11.1,9.2,11.2,0.0,5.6,12.1,7.7,8.5],
[5.1,10.1,8.1,9.5,8.5,5.6,0.0,9.1,8.3,9.3],
[10.2,12.8,1.1,12.0,1.0,12.1,9.1,0.0,11.4,12.4],
[6.1,2.0,10.5,1.6,10.6,7.7,8.3,11.4,0.0,1.1],
[7.0,1.0,11.5,1.1,11.6,8.5,9.3,12.4,1.1,0.0]]

def printSolution(dist, prevNode,src): 

	print("Vertex \t\tDistance from Source\tPath") 
	for i in range(0, len(dist)): 
		#print("\n%d --> %d \t\t%d \t\t\t\t\t" % (src, i, dist[i])), 
		print("g",src+1,"--> g",i+1," \t", round(dist[i],3),end='\t\t')
		printPath(prevNode,i) 
		print()
useless=[]
def printPath(prevNode, j): 
	global useless
	if prevNode[j] == -1 :  
		print("g",j+1, end=''), 
		return
	printPath(prevNode , prevNode[j]) 
	useless.append(prevNode[j]+1)
	print (" -> g",j+1,end='') 
def pruneUseless():
	global useless
	i=0
	while i < len(useless)-1:
		j=0
		while j < len(useless):
			if(useless[i]==useless[j]):
				useless.remove(useless[j])
			j=j+1
		i=i+1


def minDistance(dist,queue): 

	minimum = 10000
	min_index = -1
		  
	for i in range(len(dist)): 
		if dist[i] < minimum and i in queue: 
			minimum = dist[i] 
			min_index = i 
	return min_index 

def dijkstra(graph, src): 
  
	row = len(graph) 
	col = len(graph[0]) 
  
		# Dist contient toute les distance minimal de lasource a chacun des points
		# Au depart on met tout a 10000 
	dist = [10000] * row 
  
		#Ajout d'un tableau parentpour retenir le trajet 
	prevNode = [-1] * row  
	dist[src] = 0	  
	queue = [] 
	for i in range(row): 
		queue.append(i) 
			  
	while queue: 

		u = minDistance(dist,queue)  
  	  
		queue.remove(u) 
  
		for i in range(col): 
			if graph[u][i] and i in queue: 
				if dist[u] + graph[u][i] < dist[i]: 
					dist[i] = dist[u] + graph[u][i] 
					prevNode[i] = u 

	printSolution(dist,prevNode,src) 
 
#Exercice3

Exercice3=["louis","gabriel","leo","mael","paul","hugo","valentin","gabin","arthur","theo","jules","lucas","sacha","ethan","timeo","antoine","nathan","raphael","thomas","tom","matheo","mathis","samuel","tiago","baptiste","eliott","maxime","nolan","malo","aaron","marius","antonin","diego","leon","robin","simon","adam","axel","gaspard","martin","milo","nael","noe","mahe","mathys","titouan","achille","augustin","esteban","liam","camille","louise","lea","ambre","agathe","jade","julia","mila","alice","chloe","emma","andrea","anna","lucie","eden","romane","elise","lola","zoe","emy","leonie","mia","rose","candice","amelia","maelys","clemence","elena","manon","thais","valentine","eva","jeanne","lena","louna","mya","charlotte","clara","constance","iris","lise","lou","mathilde","olivia","inès","adèle","alicia","angelina","apolline","capucine"]

#1 Doit être greedy

import random
import sys

def BOGOsearch(data,value,i=1):
	r = random.randint(0, len(data)-1)
	if(data[r]==value):
		print("BOGO found The confirmed Joker ID ",value," in only ",i," iterations")
		print(value ,"is at the position",r,"of the database")
		print("BOGO is happy")
		return r
	elif(i>sys.getrecursionlimit()-2):
		print("BOGO tried to find",value,sys.getrecursionlimit()-2,"times but never found it")
		print("Now BOGO is tired.")
		return -1
	else:
		return BOGOsearch(data,value,i+1)

#2
def divideAndConquerSearch(value,a,min, max):
	m=(max-min)//2
	if max-min <=0:
		return -1;
	if a[min+m] == value:
		print("The divide and conquer search function found the confirmed Joker ID ",value)
		print(value ,"is at the position",min+m,"of the database")
		return m;
	a1=divideAndConquerSearch(value,a,min+m+1,max) 
	a2=divideAndConquerSearch(value,a,min,max-m-1)
	if(a1>a2):
		return a1
	return a2

#3
def quicksort_recursive(a):
	if len(a) == 0:
		return a
	p = len(a) // 2
	l = [i for i in a if i < a[p]]
	m = [i for i in a if i == a[p]]
	r = [i for i in a if i > a[p]]
	return quicksort_recursive(l) + m + quicksort_recursive(r)

def dichotomic_search(value,a,min, max):
	m=(max-min)//2
	if max-min <=0:
		return -1
	elif a[min+m] == value:
		print("The Dichotomic search function found the confirmed Joker ID",value)
		print(value ,"is at the position",min+m,"of the sorted database")
		return m;
	elif a[min+m] > value:
		dichotomic_search(value,a,min,max-m)
	else:
		dichotomic_search(value,a,min+m,max)

#Exercice 4


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

def sizeOfTree(root):
	a=0
	b=0
	if root.left!= None :
		a=sizeOfTree(root.left)
	if root.right!= None :
		b=sizeOfTree(root.right)
	return 1+a+b

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

def find(curNode,node):
	
	if(curNode.value==None):
		return false
	elif(node.value<curNode.value):

		if curNode.left: insert(curNode.left,node)
		else:
			return false

	elif(node.value>curNode.value):

		if curNode.right: insert(curNode.right,node)
		else:
			return false

	else:
		return false

def insert(curNode,node):
	
	if(curNode.value==None):
		curNode.value=node.value
		#print("Value added : ",value)

	elif(node.value<curNode.value):
		#print(node.value," is lower than ",curNode.value)
		if curNode.left: insert(curNode.left,node)
		else:
			curNode.left=node
			#print("Value added : ",node.value)

	elif(node.value>curNode.value):

		#print(node.value," is highter than ",curNode.value)
		if curNode.right: insert(curNode.right,node)
		else:
			curNode.right=node
			#print("Value added : ",node.value)

	else:
		print(node.value," is found, no value added")

def insertAVL(root, node): 
  
	if root==None : return node
	elif node.value < root.value:  root.left = insertAVL(root.left, node) 
	else: root.right = insertAVL(root.right, node) 
	balance = getBalance(root) 
	# Case 1 - Left Left 
	if balance > 1 and node.value < root.left.value: return rightRotate(root) 
	# Case 2 - Right Right 
	if balance < -1 and node.value > root.right.value: return leftRotate(root) 
	# Case 3 - Left Right 
	if balance > 1 and node.value > root.left.value: 
		root.left = leftRotate(root.left) 
		return rightRotate(root) 
	# Case 4 - Right Left 
	if balance < -1 and node.value < root.right.value: 
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

def minValue(current): 
    if(current.left): 
        return minValue( current.left)   
    return current  

def delete(root, value): 
  
	if root==None: return root  
	if value < root.value: root.left = delete(root.left, value) 
	elif(value > root.value): root.right = delete(root.right, value) 
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
		root.right = delete(root.right , temp.value) 
	return root  

def deleteAVL(root, key): 
  
	if not root: 
		return root 
 
	elif key < root.value: 
		root.left = deleteAVL(root.left, key) 
 
	elif key > root.value: 
		root.right = deleteAVL(root.right, key) 
 
	else: 
		if root.left is None: 
			temp = root.right 
			root = None
			return temp 
 
		elif root.right is None: 
			temp = root.left 
			root = None
			return temp 
  		
		temp = minValue(root.right) 
		root.value = temp.value 
		root.right = deleteAVL(root.right, temp.value) 
	#Si ya un seul noeud
	if root is None: 
		return root 
 
	# On met ajour la hauteur pour connaitre balance 
	root.height = 1 + max(getHeight(root.left),getHeight(root.right)) 
 
	balance = getBalance(root) 
 
	# On balance le tout si c'est pas balanced
	# Case 1 - Left Left 
	if balance > 1 and getBalance(root.left) >= 0: 
		return rightRotate(root) 
 
	# Case 2 - Right Right 
	if balance < -1 and getBalance(root.right) <= 0: 
		return leftRotate(root)   
	# Case 3 - Left Right 
	if balance > 1 and getBalance(root.left) < 0: 
		root.left = leftRotate(root.left) 
		return rightRotate(root)   
	# Case 4 - Right Left 
	if balance < -1 and getBalance(root.right) > 0: 
		root.right = rightRotate(root.right) 
		return leftRotate(root) 
  
	return root 

