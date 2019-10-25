#TD1 machine learning Yann Abou Jaoude A4 IBO01 04/09/2019

# Delete all les variables

rm(list=ls())

# Create the vector x=(1,7,3,4). 

x <- c(1,7,3,4)

#Create the vector y=(100,99,98,...,2,1)

y = 100:1

#Compute x3+y4  Answers: 100

x[3]+y[4]

#compute cos(x3)+sin(x2)e−y2  Answers: -0.9899925

cos(x[3])+sin(x[2])*exp(−y[2])

#Set x3=0 and y2=−1

x[3]=0
y[2]=-1

#Recompute the previous expressions. (Answers: 97, 2.785875)

x[3]+y[4]
cos(x[3])+sin(x[2])*exp(−y[2])

#Index y by x+1 and store it as z. What is the output? (Answer: z is c(-1, 93, 100, 96)) 

z= y[x+1]

#Compute the 90%, 95% and 99% quantiles of a F distribution with df1 = 1 and df2 = 5. 
#Answer: 4.060420, 6.607891, 16.258177

F90=qf(p=0.90,df1=1,df2=5)
F95=qf(p=0.95,df1=1,df2=5)
F99=qf(p=0.99,df1=1,df2=5)

#Sample 100 points from a Poisson with lambda = 5

rpois(100, lambda=5)

#Plot the density of a t #distribution with df = 1 (use a sequence spanning from -4 to 4).
#Add lines of different colors with the densities for df = 5, df = 10, df = 50 and df = 100

x = seq(-4,4)
y = dt(x = x, df= 1)
plot(x,y,type="l", col="blue")
y = dt(x = x, df= 5)
lines(x,y,type="l", col="red")
y = dt(x = x, df= 10)
lines(x,y,type="l", col="black")
y = dt(x = x, df= 50)
lines(x,y,type="l", col="yellow")
y = dt(x = x, df= 100)
lines(x,y,type="l", col="green")

# Nous chargeonsle fichier donnée par M.Ghassany sur son site. Il contient 28 samples de 5 variables

load("EU.RData")

#Compute the regression of CamCom2011 into Population2010. Save that model as the variable myModel.

myModel <- lm(formula = CamCom2011 ~ Population2010, data = EU)

#Access the objects residuals and coefficients of myModel.
myModel$residuals
myModel$coefficients

#Compute the summary of myModel and store it as the variable summaryMyModel.
summaryMyModel <- summary(myModel)

#Access the object sigma of myModel
summaryMyModel$sigma


