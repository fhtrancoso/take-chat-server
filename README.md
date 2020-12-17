# take-chat-server

This is an initial version of an API where it has a WebSocket to provide a channel to exchange messages between the connected clients.
This API has the following REST Services:
- A service to check the messages history (GET: api/messages);
- A service to check all the users that are in the chat (GET: api/users);
- A service to insert a new user and a valid one (not existing) in the chat, used by the clients (POST: api/users);
- A service to get a specific user by name (GET: api/users/{name});
- All the models are independents;

# How to run:

It is just to download the code and run the solution by the IDE or you can publish it in a IIS.
Initially, it is started in the port 5000. So to connect to this WebSocket you need to use this URL: ws://localhost:5000/ws. If you do not have a client to connect you can use this website to test it: https://www.websocket.org/echo.html

# To do in the next version:
 We can do some upgrades:
	- I used the dependency injection to add two singletons (UserRepository and MessageRepository) to simulate a database. So we can add a real database;
	- I did not create a specific exception mechanism, to do some rules validations;
	- We could create a generic domain object to be returned to the controllers. With that we can return to the user (client) the exception, HTTP Status Code, and wich object it needs;
	- I did not use the Automapper to map the models between the layers;
	- The chat doesn't have authentication, by access token or another one;
	- We can add the documentation, like Swagger;