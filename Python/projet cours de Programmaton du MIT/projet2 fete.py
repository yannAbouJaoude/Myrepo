#input: une liste d'horraire deprésence des célébrités a la fête
#Output: Le moment où il y a le plus de célébrités


edt = [(6, 8), (6, 12), (6, 7), (7, 8), (7, 10), (8, 9), (8, 10), (9, 12),
            (9, 10), (10, 11), (10, 12), (11, 12)]
edt2 = [(6.0, 8.0), (6.5, 12.0), (6.5, 7.0), (7.0, 8.0), (7.5, 10.0), (8.0, 9.0),
          (8.0, 10.0), (9.0, 12.0), (9.5, 10.0), (10.0, 11.0), (10.0, 12.0), (11.0, 12.0)]
edt3 = [(6, 7), (7,9), (10, 11), (10, 12), (8, 10), (9, 11), (6, 8),
          (9, 10), (11, 12), (11, 13), (11, 14)]

def bestTimeToPartySmart(edt1, ystart, yend):
    times = []
    for c in edt1:
        times.append((c[0], 'start'))
        times.append((c[1], 'end'))

    sortlist(times)


    maxcount, temps = chooseTimeConstrained(times, ystart, yend)


    print ('Il faut aller à la fête à', temps,
           'il y aura', maxcount, 'célébrité à ce moment')
    

def sortlist(tlist):
    for index in range(len(tlist)-1):
        ismall = index
        for i in range(index, len(tlist)):
            if tlist[ismall][0] > tlist[i][0] or \
               (tlist[ismall][0] == tlist[i][0] and \
                tlist[ismall][1] > tlist[i][1]):
                ismall = i
        tlist[index], tlist[ismall] = tlist[ismall], tlist[index]
    
    return


def chooseTimeConstrained(times, ystart, yend):

    rcount = 0
    maxcount = 0
    temps = 0
    
    for t in times:
        if t[1] == 'debut':
            rcount = rcount + 1
        elif t[1] == 'fin':
            rcount = rcount - 1
        if rcount > maxcount and t[0] >= ystart and t[0] < yend:
            maxcount = rcount
            temps = t[0]

    return maxcount, temps

bestTimeToPartySmart(edt2, 10.0, 12.0)
        