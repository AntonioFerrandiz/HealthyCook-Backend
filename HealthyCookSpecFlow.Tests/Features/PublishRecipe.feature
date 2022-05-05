Feature: PublishRecipe
	As a user I want to publish a recipe on the platform so that others can learn new recipes.

@publishRecipe
Scenario: User add new recipe in the application
	Given a user wants to add a recipe
	When user add a new recipe
	| Name            | Description                                                 | Preparation                            |
	| Arroz con leche | El arroz con leche es un postre típico de la gastronomía... | Pasos para preparar el arroz con leche |
	Then the recipe will be published successfully

Scenario: User add recipe to application, but does not complete required fields
	Given a user wants to add a recipe
	And does not complete the recipe description field
	| Name            | Description                                                 | Preparation                            |
	| Arroz con leche |																| Pasos para preparar el arroz con leche |
	Then an error message will be displayed
	| Message Error                    |
	| Falta completar la descripción de la receta | 