print ("")
print ("EXERCICE 1") 
print ("")
print ("Calcul du GCD with a recursive algorithm") 
def gcd(a,b): 
    if(b==0): 
        return a 
    else: 
        return gcd(b,a%b) 
  
a = 60
b= 48
  
# prints 12 
print ("The gcd of 60 and 48 is : ",end="") 
print (gcd(60,48)) 

print ("Calcul du GCD with a l'algorithme d'euclide") 
def gcdEuclide(x, y): 
  
   while(y): 
       x, y = y, x % y 
  
   return x 
  
a = 60
b= 48
  
# prints 12 
print ("The gcd of 60 and 48 is : ",end="") 
print (gcdEuclide(60,48)) 


def descendingCounter(x): 
  
   if(x>0): 
       print (x," ",end="")
       descendingCounter(x-1)

print ("Number 1-20 in descending order : ",end="") 
descendingCounter(20)

print ("")
print ("")
print ("EXERCICE 2")
print ("")

randomList=[59,25,4,5,8,5,8,9,6,8,2,85,75,258,52,654,58,52,6,5,82445,5,8,255,85,9,6,75,85,5858,96,58965,585,585,57,58,589,585,87,21,20,20,3,1,26]

print ("Here is the index of the max value of the list")
def Max(randomList,min,max): 
    if(min==max): 
        return randomList[min]
    elif(max-min==1):
    	if(randomList[min]>randomList[max]):
    		return min
    	else:
    		return max
    else: 
    	mid = int(min/2+max/2)
    	
    	a= Max(randomList, mid,max)
    	b= Max(randomList, min, mid)
    	if(randomList[a]>=randomList[b]):
    		return a
    	else:
    		return b
print(Max(randomList,0,len(randomList)-1)," The Value is ",randomList[Max(randomList,0,len(randomList)-1)])

print ("Here is the index of the min value of the list")

def Min(randomList,min,max): 
    if(min==max): 
        return randomList[min]
    elif(max-min==1):
    	if(randomList[min]<randomList[max]):
    		return min
    	else:
    		return max
    else: 
    	mid = int(min/2+max/2)
    	
    	a= Min(randomList, mid,max)
    	b= Min(randomList, min, mid)
    	if(randomList[a]<=randomList[b]):
    		return a
    	else:
    		return b
print(Min(randomList,0,len(randomList)-1)," The Value is ",randomList[Min(randomList,0,len(randomList)-1)])

print ("")
print ("EXERCICE 3")
print ("")

def exponential(number,power):
	if(power==1):
		return number
	elif(power == 2):
		return number * number
	elif(power%2==0):
		return exponential(exponential(number,power//2),2)
	elif(power%2==1):
	    return number*exponential(exponential(number,power//2),2)
print("Voici le resultat par l'algorithme récursif 87 puissance 19")
print(exponential(87,19))

def brutExponential (number, power): 
	result=1
	while (power>0):
		result= result*number
		power=power-1
	return result
print("Voici le resultat par l'algorithme brutal de 87 puissance 19")
print(brutExponential(87,19))
print("Les resultats par l'algorithme de force brute et par l'algorithme recursif sont les même")
print ("")
print ("EXERCICE 4")
print ("")
print("Voici la liste des nombres avant d'être triée")
print(randomList)

def quicksort_recursive(a):
    if len(a) == 0:
        return a
    p = len(a) // 2
    l = [i for i in a if i < a[p]]
    m = [i for i in a if i == a[p]]
    r = [i for i in a if i > a[p]]
    return quicksort_recursive(l) + m + quicksort_recursive(r)
print("Voici la liste des nombres trièe par un QuickSort")
print(quicksort_recursive(randomList))

def merge(gauche, droite):

    gauche_index = 0
    droite_index = 0
    result = []
    while gauche_index < len(gauche) and droite_index < len(droite):
        if gauche[gauche_index] < droite[droite_index]:
            result.append(gauche[gauche_index])
            gauche_index += 1
        else:
            result.append(droite[droite_index])
            droite_index += 1

    result += gauche[gauche_index:]
    result += droite[droite_index:]
    return result

def merge_sort(randomList):
    if len(randomList) <= 1:
        return randomList
    half = len(randomList) // 2
    gauche = merge_sort(randomList[:half])# truc trop cool pour prendre que la moitié d'un tableau
    droite = merge_sort(randomList[half:])

    return merge(gauche, droite)

print("Voici la liste des nombres trièe par un MergeSort")
print(merge_sort(randomList))

#randomListNoDuplicates=randomList[:] Copie le contenu de la liste, pas l'adresse

print ("")
print ("EXERCICE 5")
print ("")

def insertNoduplicates (randomListNoDuplicates,inside,min,max,value):
	mid=(min+max)//2
	if(len(inside)==0):
		inside.append(value)
		randomListNoDuplicates.append(value)
	elif(inside[mid]!=value):
	    if(min==max):
	    	inside[min:max]=[value]
	    	randomListNoDuplicates.append(value)
	    elif(inside[mid]>value):
	    	insertNoduplicates(randomListNoDuplicates,inside,mid+1,max,value)
	    else:
	    	insertNoduplicates(randomListNoDuplicates,inside,min,mid,value)

def removeDuplicates (randomList):
	randomListNoDuplicates=[]
	inside=[]
	for i in randomList :
		insertNoduplicates(randomListNoDuplicates,inside,0,len(inside)-1,i)
	return randomListNoDuplicates

print("Voici la liste des nombres sans les duplicatas")
print(removeDuplicates (randomList))

print ("")
print ("EXERCICE 6")
print ("")

import math
def dist(p1, p2):
    return math.sqrt((p1[0] - p2[0]) ** 2 + (p1[1] - p2[1]) ** 2)

def brute(ax):
    mi = dist(ax[0], ax[1])
    p1 = ax[0]
    p2 = ax[1]
    if len(ax) == 2:
        return p1, p2, mi
    for i in range(len(ax)-1):
        for j in range(i + 1, len(ax)):
            if i != 0 and j != 1:
                d = dist(ax[i], ax[j])
                if d < mi:  # Met a jour la distance minimum
                    mi = d
                    p1, p2 = ax[i], ax[j]
    return p1, p2, mi

def closest_pair(ax, ay):
    if len(ax) <= 3:
        return brute(ax)  # Quand il y a moins de 3 elements, on cherche de maniere brute
    mid = len(ax) // 2  # Division sans la virgule, on veux garder un entier
    Qx = ax[:mid]  # On garde lapartie droite du tableau
    Rx = ax[mid:]    # Determine le point du milieu surl'axe des abscisse   
    midpoint = ax[mid][0]  
    Qy = list()
    Ry = list()
    for x in ay:  # on divise en 2 verticalement
        if x[0] <= midpoint:
           Qy.append(x)
        else:
           Ry.append(x)    # On appel recursivement les 2 tableau   
    (p1, q1, mi1) = closest_pair(Qx, Qy)
    (p2, q2, mi2) = closest_pair(Rx, Ry)    # Dertermine la distance laplus faible entre 2 points d'un tableau   
    if mi1 <= mi2:
    	d = mi1
    	mn = (p1, q1)
    else:
        d = mi2
        mn = (p2, q2)    
    # Compte le nombre de points    
    (p3, q3, mi3) = closest_split_pair(ax, ay, d, mn)    
    # Determine la distance la plus courte  
    if d <= mi3:
        return mn[0], mn[1], d
    else:
        return p3, q3, mi3

def solution(x, y):
    a = list(zip(x, y))  # This produces list of tuples
    ax = sorted(a, key=lambda x: x[0])  # Presorting x-wise
    ay = sorted(a, key=lambda x: x[1])  # Presorting y-wise
    p1, p2, mi = closest_pair(ax, ay)  # Recursive D&C function
    return mi


    lst1 = [random.randint(-10**9, 10**9) for i in range(length)]
    lst2 = [random.randint(-10**9, 10**9) for i in range(length)]


def closest_split_pair(p_x, p_y, delta, best_pair):
    ln_x = len(p_x) 
    mx_x = p_x[ln_x // 2][0]    
    s_y = [x for x in p_y if mx_x - delta <= x[0] <= mx_x + delta]    
    best = delta  
    ln_y = len(s_y)  
    for i in range(ln_y - 1):
        for j in range(i+1, min(i + 7, ln_y)):
            p, q = s_y[i], s_y[j]
            dst = dist(p, q)
            if dst < best:
                best_pair = p, q
                best = dst
    return best_pair[0], best_pair[1], best       
import random
length=10000
lst1 = [random.randint(-10**9, 10**9) for i in range(length)]
lst2 = [random.randint(-10**9, 10**9) for i in range(length)]
print (solution(lst1,lst2))











