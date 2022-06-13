Feature: AddExcludedIngredients
	As a user I want to add ingredients to my list of excluded ingredients in order to prevent recipes containing these ingredients from appearing.

@addExcludedIngredients
Scenario: User add new ingredient to its list of excluded ingredients
	Given a user is wants to add an ingredient to his list of excluded ingredients
	When the user adds a new ingredient to the list
	| IngredientName |
	| Zanahoria      |  
	Then the ingredient will then be added to your list of excluded ingredients.
	| Ingredientes Excluded |
	| Zanahoria             | 
	| Mani                  | 