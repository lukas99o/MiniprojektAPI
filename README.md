# MiniprojektAPITakeTwo

This is a exercise to create a Small api with some funcationallity to modify a database. The database is created in localdb so it cant be modified outside your pc.

For the api you can use Insomnia for example and provide these 5 requests for information in the database or alter the database:

1. GET Request: https://localhost:5000/people
   This will show all people in the database.

2. GET Request: https://localhost:5000/personinterests/1
   This will show all interests for a person. To pick a person modify the number at the end of the link.

3. Get Request: https://localhost:5000/personinterestlinks/1
   This will sohw all links for a interest and a specific person. To pick a person modify the number at the end of the link.

4. POST Request: https://localhost:5000/assigninterest
   Input json to assign a person to another interest in the database. For example:
   {
	"personID": 1,
	"interestID": 2
   }
   This will assign person with ID 1 to a interest with ID 2.

5. POST Request: https://localhost:5000/createinterestlink
   Input json to create a link for a person and a interest in the database. For example:
   {
	"PersonID": 1,
	"InterestID": 2,
	"Link": "https://www.w3schools.com/"
   }

Enitity Relationship Diagram for the database:
![image](https://github.com/lukas99o/MiniprojektAPI/assets/129649913/ff59679e-d8ac-4084-8396-6621a05be2eb)

Unified Modeling Language Diagram for the api:
![image](https://github.com/lukas99o/MiniprojektAPI/assets/129649913/985eb7eb-a747-4e2b-8a03-95cfe1f12d28)

