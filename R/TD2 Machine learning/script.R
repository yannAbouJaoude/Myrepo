#1. Load the Boston dataset from MASS package.

library(MASS)
dim(Boston)

#2. Split the dataset into traning set and testing set. (keep all the variables of the Boston data set)

variables = names(Boston) ##==c("lstat", "medv"))
trainingSet = Boston[1:400, variables]
testingSet = Boston[-1:-400, variables]

#3. Check if there is a linear relationship between the variables medv and age. (use cor() function).

cor(trainingSet$age,trainingSet$medv)

#4. Fit a model of housing prices in function of age and plot the observations and the regression line.

housingPriceModel = lm(medv ~ age, data = trainingSet)
plot(trainingSet$age, trainingSet$medv)
abline(housingPriceModel)

#5. Train a regression model using both lstat and age as predictors of median house value. (Remember that we transformed lstat, use the same transformation here). What is the obtained model?
  
regressionModel = lm(medv ~ age + log(lstat), data = trainingSet)
regressionModel

#6. Print the summary of the obtained regression model.

summary(regressionModel)

#7. Are the predictors significant ?
  
#The regressionscoefficients tells us that the age doesn't influence significatively the response whereas lstat seems to have a big influence.

#8. Is the model as a whole significant? Answer on this question must be detailed.

#The variables are not significant , they may change the response making it more random. This is why the model as a whole isnt significant

#9. Train a new model using all the variables of the dataset. (We can use . as a short cut instead of writing down all the variables names)

allVariableModel = lm(medv ~ ., data = trainingSet)
summary(allVariableModel)
allVariableModel

#10. When using all the variables as predictors, we didn't transform lstat. Re train the model using log(lstat) instead of lstat.

allVariableModelUsingLogLstat = lm(medv ~ . - lstat + log(lstat), data = trainingSet)
allVariableModelUsingLogLstat
summary(allVariableModelUsingLogLstat)

#11. Did R2 improve ?

#Yes, the model have been a very little bit improved : 0,785 - 0,733 = 0,052 ; it improved of 0,052.

#12. To see if there is correlated variables print the correlation matrix using the cor() function (round the correlations with 2 digits).

round(cor(trainingSet),digits = 2)

#13. Visualize the correlations using the corrplot package. To do so, install the corrplot package, load it, then use the function corrplot.mixed(). See this link for examples and to understand how to use it.

library(corrplot)
Correlation <- cor(trainingSet)
corrplot.mixed(Correlation)

#14. What is the correlation between tax and rad?
  
anotherModel = lm(medv ~ crim + zn + indus + chas + nox + rm + age + dis + rad + ptratio + black + log(lstat), data = trainingSet)
summary(anotherModel)

#15. Run the model again without tax. What happens to the R2? and for the F-statistic?

#On our new model R-squared is a little bit lower (0,7775) than the older one
#The model significance gains 4 points, form 108.4 to 112.7

#16. Calculate the mean squared error (MSE) for the last model.

rev(anova(anotherModel)$"Mean Squared")[1]

#17. In the Boston data set there is a categorical variable chas which corresponds to Charles River (= 1 if a suburb bounds the river; 0 otherwise). Use command str() to see how this variable is present in the dataset. How many of the suburbs in this data set bound the Charles river?
  
str(Boston)
sum(Boston$chas)
mean(Boston$chas)

#18. Create Boxplots of the median value of houses with respect to the variable chas. Do we observe some difference between the median value of houses with respect to the neighborhood to Charles River?
  
boxplot(medv~chas,data = trainingSet)

#19. Calculate ??i and ??j (in one line using the function aggregate()).

aggregate(medv~chas,data=trainingSet,mean)

#20. Apply an ANOVA test of medv whith respect to chas (use the function aov()). Print the result and the summary of it. what do you conclude ?

aov(medv~chas,data=trainingSet)
summary(aov(medv~chas,data=trainingSet))

#21. Fit a new model where the predictors are the Charles River and the Crime Rate. Interpret the coefficients of this model and conclude if the presence of the river adds a valuable information for explaining the house price.

lastModel = lm(medv ~ crim + chas, data = trainingSet)
summary(lastModel)

#22. Is chas is significant as well in the presence of more predictors?

#With more predictors we have more informations.So in most of the cases, chas may stay more and more significant as we add predictors

#23. Fit a model whith first order interaction term where predictors are lstat and age. Print its summary.

firstOrderinteractionsModel = lm(medv~age*lstat,data = trainingSet)
summary(firstOrderinteractionsModel)

#24. Fit a model with all the first order interaction terms.

firstOrderinteractionsAllVariableModel = lm(medv~ .^2,data = trainingSet)
summary(firstOrderinteractionsAllVariableModel)




