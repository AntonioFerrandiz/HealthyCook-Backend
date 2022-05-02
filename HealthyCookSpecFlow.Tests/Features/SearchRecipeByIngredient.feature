﻿Feature: SearchRecipeByIngredient
	As a user I want to search for recipes by entering the ingredients I have in my home

@searchRecipeByIngredient
Scenario: User selects two ingredients of his choice
	Given the first ingredient is egg
	And  the second ingredient is potatoes
	When he presses the button "Search recipes".
	Then will then be shown a list of recipes that he can cook with the selected ingredients.
	| Recipe Name       | Description                                                          |
	| Huevo frito       | Aprende a preparar un huevo frito de la mejor manera                 |
	| Papa rebozada     | No te quedes con hambre y sacale provecho a las papas que tienes     |
	| Ensalada de papas | Prepara una rica ensalada de papas con huevo en menos de 10 minutos! | 
	
Scenario: User selects an ingredient and does not find recipes
	Given the ingredient is kiwi
	When he presses the button "Search recipes".
	Then a message will be displayed
	| Message                                         |
	| No se han encontrado recetas que contengan kiwi | 

Scenario: User does not select any ingredient 
	Given user searches for recipes without selecting ingredients
	Then a warning message will be displayed
	| Warning Message                           |
	| Debes seleccionar al menos un ingrediente | 