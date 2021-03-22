# ASP.NET-Core-Web-Api
Basic CRUD operations with Authentication

## How Can You Test Api
When you run the project, you should add `/swagger` extention to the opened path.

Swagger is showing the endpoints of project. 

You can not use Users' endpoints only except `/api/Users/Post` `Create a user` so you must create a user for self.

Then you must execute `/api/Auth/Login` under Auth for taking the genereted token.

You must enter the given token from login to Value paramater as `Baerer <given token>` at Authorize.

While clicking the Authorize button, you must authorize.

Now you can use other endpoints at Users.
