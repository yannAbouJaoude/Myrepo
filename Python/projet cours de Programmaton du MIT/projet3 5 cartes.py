
#choisis 5 cartes
#en donnant 4 cartes dans un ordre particulier, on peux trouver la 5eme


deck = ['A_C', 'A_D', 'A_H', 'A_S', '2_C', '2_D', '2_H', '2_S', '3_C', '3_D', '3_H', '3_S',
        '4_C', '4_D', '4_H', '4_S', '5_C', '5_D', '5_H', '5_S', '6_C', '6_D', '6_H', '6_S',
        '7_C', '7_D', '7_H', '7_S', '8_C', '8_D', '8_H', '8_S', '9_C', '9_D', '9_H', '9_S',
        '10_C', '10_D', '10_H', '10_S', 'J_C', 'J_D', 'J_H', 'J_S',
        'Q_C', 'Q_D', 'Q_H', 'Q_S', 'K_C', 'K_D', 'K_H', 'K_S']

def outputFirstCard(nombres, unDeux, cartes):


    encode = (nombres[unDeux[0]] - nombres[unDeux[1]]) % 13
    if encode > 0 and encode <= 6:
        cache = unDeux[0]
        autre = unDeux[1]
    else:
        cache = unDeux[1]
        autre = unDeux[0]
        encode = (nombres[unDeux[1]] - nombres[unDeux[0]]) % 13


    print ('Premiere carte est:', cartes[autre])

    return cache, autre, encode

def outputNext3Cards(code, ind):
    
    if code == 1:
        deuxieme, troisieme, quatrieme = ind[0], ind[1], ind[2]
    elif code == 2:
        deuxieme, troisieme, quatrieme = ind[0], ind[2], ind[1]
    elif code == 3:
        deuxieme, troisieme, quatrieme = ind[1], ind[0], ind[2]       
    elif code == 4:
        deuxieme, troisieme, quatrieme = ind[1], ind[2], ind[0]
    elif code == 5:
        deuxieme, troisieme, quatrieme = ind[2], ind[0], ind[1]
    else:
        deuxieme, troisieme, quatrieme = ind[2], ind[1], ind[0]

    print ('deuxieme carte est:', deck[deuxieme])
    print ('troisieme carte est:', deck[troisieme])
    print ('quatrieme carte est:', deck[quatrieme])

    
def sortList(tlist):
    for index in range(0, len(tlist)-1):
        ismall = index
        for i in range(index, len(tlist)):
            if tlist[ismall] > tlist[i]:
                ismall = i
        tlist[index], tlist[ismall] = tlist[ismall], tlist[index]
    
    return


def ComputerAssistant():

    print ('cartes are character strings as shown below.')
    print ('Ordering est:', deck)
    cartes, cind, cardsuits, cnumbers = [], [], [], []
    numsuits = [0, 0, 0, 0]
    number = 0
    while number < 99999:
        number = int(input('Please give random number of at least 6 digits:'))

    clist = []
    i = 0
    while len(clist) < 5:
        number = number * (i + 1) // (i + 2)
        n = number % 52
        i += 1
        if not n in clist:
            clist.append(n)


    for i in range(5):
        n = clist[i]
        cartes.append(deck[n])
        cind.append(n)
        cardsuits.append(n % 4)
        cnumbers.append(n // 4)
        numsuits[n % 4] += 1
        if numsuits[n % 4] > 1:
            pairsuit = n % 4
            
    carteh = []
    for i in range(5):
        if cardsuits[i] == pairsuit:
            carteh.append(i)

    cache, autre, encode = outputFirstCard(cnumbers, carteh, cartes)

    remindices = []
    for i in range(5):
        if i != cache and i != autre:
            remindices.append(cind[i])

    sortList(remindices)
    outputNext3Cards(encode, remindices)

    supposition = input('Quel est la carte cachée?')
    if supposition == cartes[cache]:
        print ('Bravo!')
    else:
        print ('perdu')

    return