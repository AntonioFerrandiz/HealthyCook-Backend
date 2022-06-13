Feature: SearchNearbyRestaurants
	As a user I want to search for restaurants near my current location.

@searchNearbyRestaurants
Scenario: User searches for restaurants near him
	Given that the user is in the restaurants section
	When the user goes to the search bar for restaurants
	Then will then be presented with restaurants near your current location
	| Restaurant Name  | Ubication |
	| Polleria Pollito | a 1km     |
	| Menú Lola        | a 500m    | 
Scenario: User searches for restaurants near him but there are no restaurants near him
	Given that the user is in the restaurants section
	When the user goes to the search bar for restaurants
	And there is no restaurant near your location
	Then the user will then be notified that there is no restaurant available nearby.
	| Message                                               |
	| No hay ningún restaurante cerca a tu ubicación actual | 