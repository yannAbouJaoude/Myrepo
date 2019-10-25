
#Resoud un sudoku entré en dure


backtracks = 0

secteurs = [ [0, 3, 0, 3], [3, 6, 0, 3], [6, 9, 0, 3],
            [0, 3, 3, 6], [3, 6, 3, 6], [6, 9, 3, 6],
            [0, 3, 6, 9], [3, 6, 6, 9], [6, 9, 6, 9] ]


def findNextCellToFill(grille):
    for x in range(0, 9):
        for y in range(0, 9):
            if grille[x][y] == 0:
                return x,y
    return -1,-1

def isValid(grille, i, j, e):
    rowOk = all([e != grille[i][x] for x in range(9)])
    if rowOk:
        columnOk = all([e != grille[x][j] for x in range(9)])
        if columnOk:
            #finding the top left x,y co-ordinates of
            #the section or sub-grille containing the i,j cell
            secTopX, secTopY = 3 *(i//3), 3 *(j//3)
            for x in range(secTopX, secTopX+3):
                for y in range(secTopY, secTopY+3):
                    if grille[x][y] == e:
                        return False
            return True
    return False


def makeImplications(grille, i, j, e):

    global secteurs

    grille[i][j] = e
    impl = [(i, j, e)]

    fini = False

    while not fini:
        fini = True

        for k in range(len(secteurs)):

            sectinfo = []

            #find missing elements in ith sector
            vset = {1, 2, 3, 4, 5, 6, 7, 8, 9}
            for x in range(secteurs[k][0], secteurs[k][1]):
                for y in range(secteurs[k][2], secteurs[k][3]):
                    if grille[x][y] != 0:
                        vset.remove(grille[x][y])

            #attach copy of vset to each missing square in ith sector
            for x in range(secteurs[k][0], secteurs[k][1]):
                for y in range(secteurs[k][2], secteurs[k][3]):
                    if grille[x][y] == 0:
                        sectinfo.append([x, y, vset.copy()])
            
            for m in range(len(sectinfo)):
                sin = sectinfo[m]
                
                #find the set of elements on the row corresponding to m and remove them
                rowv = set()
                for y in range(9):
                    rowv.add(grille[sin[0]][y])
                left = sin[2].difference(rowv)
                
                #find the set of elements on the column corresponding to m and remove them
                colv = set()
                for x in range(9):
                    colv.add(grille[x][sin[1]])
                left = left.difference(colv)
                             
                #check if the vset is a singleton
                if len(left) == 1:
                    val = left.pop()
                    if isValid(grille, sin[0], sin[1], val):
                        grille[sin[0]][sin[1]] = val
                        impl.append((sin[0], sin[1], val))
                        fini = False
                
    return impl

#This procedure undoes all the implications
def undoImplications(grille, impl):
    for i in range(len(impl)):
        grille[impl[i][0]][impl[i][1]] = 0
    return


#This procedure fills in the missing squares of a Sudoku puzzle
#obeying the Sudoku rules by guessing when it has to and performing
#implications when it can
def solveSudokuOpt(grille, i = 0, j = 0):

    global backtracks

    #find the next empty cell to fill
    i, j = findNextCellToFill(grille)
    if i == -1:
        return True

    for e in range(1, 10):
        #Try different values in i, j location
        if isValid(grille, i, j, e):

            impl = makeImplications(grille, i, j, e)
            
            if solveSudokuOpt(grille, i, j):
                return True
            #Undo the current cell for backtracking
            backtracks += 1
            undoImplications(grille, impl)

    return False

def printSudoku(grille):
    numrow = 0
    for row in grille:
        if numrow % 3 == 0 and numrow != 0:
            print (' ')
        print (row[0:3], ' ', row[3:6], ' ', row[6:9])
        numrow += 1       
    return

input = [[5,1,7,6,0,0,0,3,4],
         [2,8,9,0,0,4,0,0,0],
         [3,4,6,2,0,5,0,9,0],
         [6,0,2,0,0,0,0,1,0],
         [0,3,8,0,0,6,0,4,7],
         [0,0,0,0,0,0,0,0,0],
         [0,9,0,0,0,0,0,7,8],
         [7,0,3,4,0,0,5,6,0],
         [0,0,0,0,0,0,0,0,0]]

inp2  = [[5,1,7,6,0,0,0,3,4],
         [0,8,9,0,0,4,0,0,0],
         [3,0,6,2,0,5,0,9,0],
         [6,0,0,0,0,0,0,1,0],
         [0,3,0,0,0,6,0,4,7],
         [0,0,0,0,0,0,0,0,0],
         [0,9,0,0,0,0,0,7,8],
         [7,0,3,4,0,0,5,6,0],
         [0,0,0,0,0,0,0,0,0]]

hard  = [[8,5,0,0,0,2,4,0,0],
         [7,2,0,0,0,0,0,0,9],
         [0,0,4,0,0,0,0,0,0],
         [0,0,0,1,0,7,0,0,2],
         [3,0,5,0,0,0,9,0,0],
         [0,4,0,0,0,0,0,0,0],
         [0,0,0,0,8,0,0,7,0],
         [0,1,7,0,0,0,0,0,0],
         [0,0,0,0,3,6,0,4,0]]

diff  = [[0,0,5,3,0,0,0,0,0],
         [8,0,0,0,0,0,0,2,0],
         [0,7,0,0,1,0,5,0,0],
         [4,0,0,0,0,5,3,0,0],
         [0,1,0,0,7,0,0,0,6],
         [0,0,3,2,0,0,0,8,0],
         [0,6,0,5,0,0,0,0,9],
         [0,0,4,0,0,0,0,3,0],
         [0,0,0,0,0,9,7,0,0]]

solveSudokuOpt(inp2)
printSudoku(inp2)
print ('Backtracks = ', backtracks)

backtracks = 0
print(solveSudokuOpt(hard))
print ('Backtracks = ', backtracks)

backtracks = 0
print(solveSudokuOpt(diff))
print ('Backtracks = ', backtracks)