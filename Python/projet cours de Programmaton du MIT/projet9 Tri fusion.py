



#This procedure selects a pivot and partitions the list into 3 sublists
#It only uses one element worth of additional storage for the pivot!
def pivotPartitionClever(lst, start, end):
    
    pivot = lst[end] 
    bottom = start - 1       
    top = end
    moves = 0

    done = False
    while not done: 

        while not done:
            #Move rightward from left searching for element > pivot
            bottom += 1 
            if bottom == top: 
                done = True 
                break
            if lst[bottom] > pivot: 
                lst[top] = lst[bottom]
                moves += 1
                #print (lst, 'bottom =', bottom, 'top = ', top)
                break 

        while not done:
            #Move leftward from right searching for element < pivot
            top -= 1
            if top == bottom: 
                done = True 
                break
            if lst[top] < pivot: 
                lst[bottom] = lst[top]
                moves += 1
                #print (lst, 'bottom =', bottom, 'top = ', top)
                break 

    lst[top] = pivot 
    #print (lst)
    return top, moves


def quicksort(lst, start, end):

    moves = 0
    if start < end: 
        split, moves = pivotPartitionClever(lst, start, end)
        moves += quicksort(lst, start, split - 1)
        moves += quicksort(lst, split + 1, end)
    return moves
    
a = [4, 65, 2, -31, 0, 99, 83, 782, 1]
print ('Initial list is:', a)
print ('Moves = :', quicksort(a, 0, len(a) - 1))
print ('Sorted list is:', a)

L = list(range(100))
print ('Initial list is:', L)
print ('Moves = :', quicksort(L, 0, len(L) - 1))
print ('Sorted list is:', L)

D = list(range(99, -1, -1))
print ('Initial list is:', D)
print ('Moves = :', quicksort(D, 0, len(D) - 1))
print ('Sorted list is:', D)

R = [0] * 100
R[0] = 29
for i in range(100):
    R[i] = (9679 * R[i-1] + 12637 * i) % 2287
print ('Initial list is:', R)
print ('Moves = :', quicksort(R, 0, len(R) - 1))
print ('Sorted list is:', R)