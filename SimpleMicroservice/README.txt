
This microservice provides a basic API for adding products to a textfile, which acts as
a database. It uses ASP.NET Core and follows a simple architecture with a controller and a service layer.
A lot of the setting up in the "Program.cs" was done by using the asp.net core webapi template,
primarely to enable the use of swagger. The service layer is used to handle the business logic and the controller

The request was for me to make WRITE and READ functionality. 
I have implemented the write functionality in the form of a POST request, which adds a product to the textfile.
the read functionality is implemented in the form of a GET request, which reads all the products from the textfile.
Additionally i have made a GET request that reads a specific product from the textfile, based on the id of the product.

I have tested it using Postman and swagger, with both giving the same results

If this project should be taken further, things like unit testing, error handling and logging could be implemented.
Alternatively the project could be expanded to include more functionality, such as updating and deleting products.
or using a database instead of a textfile.

How to get started

1. Clone the repository:

git clone https://github.com/dinoen/SimpleMicroservice.git
cd SimpleMicroservice


2. Open the project in Visual Studio:

    - Open `SimpleMicroservice.sln` in Visual Studio.

3. Restore dependencies and build the project:

    - Visual Studio will automatically restore the dependencies. You can also restore them manually using the terminal:

'dotnet restore'
'dotnet build'   

4. Run the application:

    - Press `F5` or click the `Run` button in Visual Studio.

5. Testing the API Using Swagger

	1. Open Swagger by navigating to:

	https://localhost:5144/swagger/index.html

    This should be the default url when the application is ran from visual studio. 

	2. Click on the `POST` request and then click on `Try it out`.

	3. Fill in the request body with the following JSON:
	
	{
		"name": "Product 1",
		"price": 10.0
	}
	
	4. Click on `Execute` to send the request.

	5. You should see a response with the product that was added.

    or 

    6. Choose GET request
    
    7. Set the request URL:

    https://localhost:7296/api/product (for all products)
    https://localhost:7296/api/product/{id} (for a specific product, with "id" being an integer)

6. Testing the API Using Postman

    1. Open Postman and create a new `POST` request.

    2. Set the request URL:

    https://localhost:7296/api/product

    3. Fill in the request body with the following JSON (or something along those lines):
	
	{
		"name": "Product 1",
		"price": 10.0
	}

    or 

    1. Choose GET request
    
    2. Set the request URL:

    https://localhost:7296/api/product (for all products)
    https://localhost:7296/api/product/{id} (for a specific product with "id" being an integer)

    

    


    