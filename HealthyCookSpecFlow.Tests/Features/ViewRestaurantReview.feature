Feature: ViewRestaurantReview
	As a restaurant owner, I would like to see the reviews that have been made on my restaurant

@viewRestaurantReview
Scenario: The owner of the restaurant can view all the reviews made by his customers
	Given the restaurant owner goes to the "Profile" window
	And then to the "My Restaurant" section
	When the restaurant owner presses the "View reviews" button
	Then will be redirected to the reviews section where the restaurant owner will be able to see the reviews. 
	| User       | Commentary                        | Calification | Date       |
	| Pedrito007 | Estuvo todo muy rico, recomendado | 4.5          | 30-04-2022 | 

Scenario: The restaurant has no reviews
	Given that the owner of the restaurant is in the reviews section
	And there are no reviews
	| Reviews |
	|         |	
	Then a message will  be displayed
	| Message                   |
	| Por el momento no hay ninguna reseña | 
