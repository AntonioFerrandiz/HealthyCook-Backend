Feature: AddExcludedIngredients
	As a user 
	I want to add ingredients to my list of excluded ingredients in order 
	to prevent recipes containing these ingredients from appearing.

	Background: 
		Given the Endpoint http://localhost:50947/api/ExcludedIngredients is available

@addExcludedIngredients
Scenario: User add new ingredient to its list of excluded ingredients
	When A user add new ingredient to his list
		| IngredientName | UserID |
		| Uva            | 1      | 
	Then A Response with status 200 is received
	And A Excluded Ingredient Resource is included in Response Body
		| IngredientName | UserID |
		| Uva            | 1      | 

Scenario: Add new excluded ingredient with null ingredient name
	When A Post Request is sent with IngredientName null
	| IngredientName | UserID |
	|                | 1      | 
	Then A Response with status 400 is received
