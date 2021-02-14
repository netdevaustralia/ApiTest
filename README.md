# Shopping Cart .NET5 WebApi
Sample .NET5 standard reference application, demonstrating CQRS application architecture. If you're new to CQRS, read the [CQRS in Microservices](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/cqrs-microservice-reads) guide.

Along with the CQRS pattern, the MediatR pattern is implemented to setup the custom project pipeline and prevent dependencies injection in controller layer. Please read about the MediatR pattern for more information [CQRS with MediatR](https://medium.com/@ducmeit/net-core-using-cqrs-pattern-with-mediatr-part-1-55557e90931b)

## Deployment

Deployement is done through the Azure web service and the api can be reached here [ShoppingCartWebAPI](https://shoppingcartapi20210214172845.azurewebsites.net/index.html)

## Project Structure

All the business related logic is written in Application layer. Contract implementation is provided in the Infrastructure layer.

### Architecture of the project 

![](images/ShoppingCart.png?raw=true)

## Test Cases

Test cases are written in XUnit and FluentAssertions. Test cases are written only for the Application layer and checking the business logic but they can be extended for the Infrastructure layer as well. The current test cases are the Unit test cases only.

## Code Consistency

All the common code rules are kept in editorConfig and can be modified as per the requirement of the development.

## Running Locally

The source code can be downloaded and just run the Presentation layer. There is not security implemented on the code level so you can just use the swagger to debug the code locally.


