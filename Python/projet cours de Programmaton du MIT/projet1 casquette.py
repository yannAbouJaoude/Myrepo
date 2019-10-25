# Input: une série de B et F 
#Output is a set of commands (printed out) to get either all F's or all B's


casquettes = ['F', 'F', 'B', 'B', 'B', 'F', 'B', 'B', 'B', 'F', 'F', 'B', 'F' ]
casquettes2 = ['F', 'F', 'B', 'B', 'B', 'F', 'B', 'B', 'B', 'F', 'F', 'F', 'F' ]

def pleaseConform(casquettes):

    debut = 0
    avant = 0
    arriere = 0
    intervals = []


    for i in range(len(casquettes)):
        if casquettes[debut] != casquettes[i]:

            intervals.append((debut, i - 1, casquettes[debut]))
            
            if casquettes[debut] == 'F':
                avant += 1
            else:
                arriere += 1
            debut = i


    intervals.append((debut, len(casquettes) - 1, casquettes[debut]))
    if casquettes[debut] == 'F':
        avant += 1
    else:
        arriere += 1
 
##    print (intervals)
##    print (avant, arriere)
    if avant < arriere:
        echange = 'F'
    else:
        echange = 'B'
    for t in intervals:
        if t[2] == echange:
            #Exercise: if t[0] == t[1] change the printing!
            if t[0] == t[1]:
                print ('Personne a la position', t[0], 'doit retourner sa casquette')
            else:
                print ('Personnes des positions', t[0], 'à', t[1], 'doivent retourner leurs casquettes')
                
            
pleaseConform(casquettes)
##pleaseConform(casquettes2)