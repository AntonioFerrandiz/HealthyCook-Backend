Feature: AddExcludedIngredients
	As a user I want to add ingredients to my list of excluded ingredients in order to prevent recipes containing these ingredients from appearing.

@addExcludedIngredients
Scenario: User add new ingredient to its list of excluded ingredients
	Given a user is wants to add an ingredient to his list of excluded ingredients
	When the user adds a new ingredient to the list
	| IngredientName | UserID |
	| Uva            | 1      | 
	Then the ingredient will then be added to your list of excluded ingredients with status 200
#Scenario: User add new ingrediente to its list of excluded ingredients but no data is entered
#	When the user adds a new ingredient to the list
#	| IngredientName | UserID |
#	| Uvwa            | 1      | 
#	Then no ingredient will be added and there will be an error with status 200