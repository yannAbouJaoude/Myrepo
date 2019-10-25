


def tileFourMissingYard(n, missing):
    #Initilization
    size = 2**n
    missingquad = []
    #Filling the list with the quadrants of each of the missing tiles
    for (r,c) in missing:
        missingquad.append(2*(r >= size//2) +(c >=size//2))
    count = 0
    #Counting the number of DIFFERENT quadrants the missing tiles cover
    for i in range(4):
        if i in missingquad:
            count +=1
    #If 4 quadrants are covered then we can tile
    if count == 4:
        return True
    #Checking for L-shaped arrangement of the missing tiles
    for (r,c) in missing:
        if (((r+1,c) in missing and (r,c+1) in missing) or ((r-1,c) in missing and (r,c+1) in missing) 
        or ((r+1,c) in missing and (r,c-1) in missing) or ((r-1,c) in missing and (r,c-1)in missing)):
            return True
    return False

tileFourMissingYard(3, [(4, 4), (1, 1), (2, 1), (1, 2)])
tileFourMissingYard(3, [(4, 4), (3, 1), (2, 1), (1, 2)])
tileFourMissingYard(3, [(3, 7), (4, 4), (4, 6), (4, 7)])