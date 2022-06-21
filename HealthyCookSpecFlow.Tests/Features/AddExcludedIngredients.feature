Feature: AddExcludedIngredients
	As a user 
	I want to add ingredients to my list of excluded ingredients in order 
	to prevent recipes containing these ingredients from appearing.

	Background: 
		Given the Endpoint http://localhost:50947/api/ExcludedIngredients is available

@addExcludedIngredients
Scenario: S001 User add new ingredient to its list of excluded ingredients
	When A user add new ingredient to his list
		| IngredientName | UserID |
		| Uva            | 1      | 
	Then A Response with status 200 is received

Scenario: S002 Add new excluded ingredient with null ingredient name
	When A Post Request is sent with IngredientName null
	| IngredientName | UserID |
	|                | 1      | 
	Then A Response with status 400 is received
Scenario: S003 Add excluded ingredient that was already on the list
	When A Post request is sent with IngredientName that was already in the list
	| IngredientName | UserID |
	| Uva            | 1      | 
	Then A Response with status 400 is received
	And A Message of "Ya agregaste este ingrediente a tu lista" is include in response body
Scenario: S004 A user searches for a recipe based on an ingredient
	When a user search recipe using an ingredient
	| Ingredient | ExcludedIngredient |
	| Tomate     | Pollo              |   
	Then A Response with status 200 is received
	And A RecipeFound Resource is included in Response Body
	| id  | dateCreated | active | published | name     | description                                                                                                                                                           | preparation                                                                                                                                                           | userID | user |
	| 107 | 13-06-2022  | 1      | 1         | Ensalada | Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas nec dui elementum, finibus nulla non, consectetur enim. Donec aliquet viverra lacus quis dignissim. | Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas nec dui elementum, finibus nulla non, consectetur enim. Donec aliquet viverra lacus quis dignissim. | 1      | null | 
	
Scenario: S005 A user searches for a recipe based on an ingredient but that ingredient is excluded from the list of ingredients
	When a user searches for a recipe with an ingredient that is on your list of excluded ingredients
	| Ingredient | ExcludedIngredient |
	| Pollo      | Pollo              |
	Then A Response with status 400 is received
	And A Message of "No puedes buscar una receta con un ingrediente que has agregado a la lista de ingredientes excluidos" is include in response body