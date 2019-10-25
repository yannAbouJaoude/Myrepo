#Question 1

dataset <- read.csv("Social_Network_Ads.csv", header = TRUE,sep = ",", quote = "\"",dec = ".", fill = TRUE, comment.char = "")

#Question 2

summary(dataset)
str(dataset)
# We prepare our small histogram of estimated salary according to age
hist(dataset$Age)
hist(dataset$EstimatedSalary)
colors <- c("red", "blue")
colors <- colors[as.numeric(dataset$Gender)]
#Affiche l'histogramme
plot(dataset$Age, dataset$EstimatedSalary, col = colors)
#Show the little man/woman legend at the top right
legend("topright", legend = levels(dataset$Gender), col =  c("red", "blue"), pch = c(1, 1))

#Question 3

library(caTools) # install it first in the console
set.seed(123)
# we use the function set.seed() with the same seed number
# to randomly generate the same values, you already know that right? 
#and you know why we want to generate the same values, am I wrong? 
split = sample.split(dataset$Purchased, SplitRatio = 0.75)
# here we chose the SplitRatio to 75% of the dataset,
# and 25% for the test set.
training_set = subset(dataset, split == TRUE)
# we use subset to split the dataset
test_set = subset(dataset, split == FALSE)

#Question 4

#,To scale (mettre à l'échelle)
# The scale is the relation between the real size of something and its size on a map, model, or diagram 
# In R , scale is a generic function whose default method centers and/or scales the columns of a numeric matrix.
training_set$Age <- scale(training_set$Age, center = TRUE, scale = TRUE)
training_set$EstimatedSalary <- scale(training_set$EstimatedSalary, center = TRUE, scale = TRUE)
test_set$Age <- scale(test_set$Age, center = TRUE, scale = TRUE)
test_set$EstimatedSalary <- scale(test_set$EstimatedSalary, center = TRUE, scale = TRUE)

#Question 5

#Fits a generalised linear model with a LASSO penalty, using an iteratively reweighted local linearisation approach, given a value of the penalty parameter (lamb).
glm1 <- glm(formula = Purchased ~ Age, family = binomial, data = training_set)

#Question 6

#We use the argument family to be binomial because we want to know if the person is a good target or not for the client. 
#It is a yes/no question, it is a binary choose.

#Question 7

glm1$coefficients
#p_hat(X) = exp(-0.9298602 + 1.9913460*X)/(1+exp(-0.9298602 + 1.9913460*X))

#Question 8

summary(glm1)
# Pr(>|z|) < 2e-16 for the feature age so we conclude that this feature is significant to the model.

#Question 9

#value of AIC of the model AIC=2k−2ln(^L)
glm1$aic

#Question 10

#Purchased in function of Age
plot(training_set$Age, training_set$Purchased)
#We add the curve of the obtained logistic regression model
curve(exp(-0.9298602 + 1.9913460*x)/(1+exp(-0.9298602 + 1.9913460*x)), add = TRUE)

#Question 11

#logistic regression model of purchasing the product in function of the age of a user and its salary
glm2 <- glm(formula = Purchased ~ Age + EstimatedSalary, family = binomial, data = training_set)

#Question 12

# We can see that the coefficient have 3 stars, so they are very significant:
# Age: Pr(>|z|)=2.83e-14
# EstimatedSalary : Pr(>|z|)=2.03e-09
# These very close to zero values means that the predictors significant to the new model
summary(glm2)

#Question 13

glm2$aic
# Yes because glm2$aic < glm1$aic
# We could expect it since EstimatedSalary is significant to the model

#Question 14

#ability of purchasing the product by the users
probability = predict(glm2, data.frame(test_set), type = "response")

#Question 15

#Transform the predicted values to 0 or 1
probability <- round(probability)

#Question 16

#evaluate the model and its predictions by computing the confusion matrix.
confusion_matrix = table(factor(test_set$Purchased, levels=c(1,0)),factor(probability, levels=c(1,0)))
#This is what we obtain
confusion_matrix

#Question 17

#Accuracy
Accuracy = (confusion_matrix[1, 1] + confusion_matrix[2, 2]) / length(test_set)
Accuracy
#Specificity
Specificity = confusion_matrix[2, 2] / (confusion_matrix[1, 2] + confusion_matrix[2, 2])
Specificity
#Sensitivity
Sensitivity = confusion_matrix[1, 1] / (confusion_matrix[1, 1] + confusion_matrix[2, 1])
Sensitivity
#Precision of the model
precisionOfTheModel = confusion_matrix[1, 1] / (confusion_matrix[1, 1] + confusion_matrix[1, 2])
precisionOfTheModel

#Question 18

# Install from cran.rstudio.com
library("ROCR")
pred <- prediction(probability, test_set$Purchased)
#calculate AUC value
auc <- performance(pred, "auc")
auc <- auc@y.values[[1]]
auc
pred <- performance(pred,"tpr","fpr")
#Plot the ROC curve 
plot(pred, col = "green")
abline(a=0, b=1, lty=2)

#Question 19

#Compare the AUC of the two models you fitted (one with only age and one with age and estimated salary) and plot their ROC curves in the same figure.
probability2 = predict(glm1, data.frame(test_set), type = "response")
probability2 <- round(probability2)

pred2 <- prediction(probability2, test_set$Purchased)
#calculate AUC value
auc2 <- performance(pred2, "auc")
auc2 <- auc2@y.values[[1]]
auc2

pred2 <- prediction(probability2, test_set$Purchased)
pred2 <- performance(pred2,"tpr","fpr")
plot(pred2, add=TRUE, col = "blue")
legend("bottomright", legend = c("Age","Age + EstimatedSalary"),
       col =  c("blue", "green"),
       pch = c("-", "-"))

# We can see on the model with only age that the AUC  is slightly above the AUC of the model with both the age and the salary.
# Visualy, we can see that the curves are almost the same. The salary have not a important impact for the prediction.
