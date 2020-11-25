# DigitalMenu
API to serve Menu digitally

Run the project.
Use postman or any other similar tool (fiddler) to test the API.

To Insert:

Add the respective URL.
Send the following data in the request body,
```Javascript
{
	"name":"potato salad",
	"description":"boiled potatoes with herbs and vegetables",
	"price":"10 EUR",
	"category":"Salads",
	"timeAvailable":"Lunch",
	"isAvailabe": true,
	"timeToServe": "10 mins"
}
```
And post it.

To Read:

Use Get and browse to specific URLs

To get all Dishes,
https://localhost:<portno>/api/menu

To get a specific dish by id,
https://localhost:<portno>/api/menu/{id} 
