Feature: RegisterUser
	As a user I would like to register within the application in order to be able to maintain my activity in the application.

@registerUser
Scenario: The user is successfully registered
	Given the user wants to register
	And goes to the account registration window
	When the user fills in the form with the requested information
	| Username   | Firstname | Lastname | Email               | Password        |
	| Pedrito007 | Pedro     | Humal    | pedrito01@gmail.com | pedritolomax01! | 
	Then the user will be successfully registered

Scenario: The user does not confirm his password
	Given the user wants to register
	When the user does not successfully confirm his password
	Then a warning message will be displayed on the password input
	| Warning Message              |
	| Las contraseñas no coinciden | 

Scenario: The user's email is already in use
	Given the user enters his email address
	And it is already in use by another user
	Then you will not be able to register and a message will be displayed
	| Message                                   |
	| El email ingresado ya se encuentra en uso | 