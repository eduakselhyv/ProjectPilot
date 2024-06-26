# ProjectPilot
Tervetuloa ProjectPilotiin!

Projektimme keskipisteenä on luoda käyttäjäystävällinen projektinhallintasovellus, joka helpottaa erilaisten projektien hallintaa ja kommunikointia tiimien välillä.

## Tavoitteet
Projektimme pyrkii tarjoamaan seuraavia toimintoja käyttäjille:

- Käyttäjät voivat luoda käyttäjätunnuksia ja kirjautua sisään.
- Käyttäjät voivat luoda uusia projekteja ja lisätä niihin osallistujia.
- Käyttäjät voivat luoda kommentteja, vaatimuksia ja muita tarvittavia dokumentteja projektin sisällä.
- Käyttäjät voivat tarkastella projektin etenemistä ja tehdä tarvittavia muutoksia.

## About

ProjectPilot is a tool made for managing projects and requirements.
This tool is made using C# and an SQL database. Database is a MySQL Community Server, server side is an API and client side is using WPF.

## API Documentation

### users

## GET
URL: ```http://localhost:5000?requestType=users```<br />
Response: ```[{"id":1,"username":"admin123","password":"password"},{"id":3,"username":"admin1234","password":"password"}]```
> Returns an array of all existing users in JSON format

### register

### POST
URL: ```http://localhost:5000?requestType=register```<br />
Request body:
* username - required - User's username
* password - required - User's password
> Returns an HTTP status code. 200 is successful, which means that a new user was created.

### login

### POST
URL: ```http://localhost:5000?requestType=login```<br />
Request body:
* username - required - User's username
* password - required - User's password
> Returns an HTTP status code. 200 is successful, which means that a new user was created.

### projects

### GET
URL: ```http://localhost:5000?requestType=projects```<br />
Response: ```[{"id":1,"name":"test project2","description":"test project description","status":"active"}]```
> Returns an array of all existing projects in JSON format

### POST
URL: ```http://localhost:5000?requestType=project```<br />
Request body:
* id - optional - Project's id. If specified, a project will be edited.
* name - required - Project's name
* description - required - Project's description
* status - required - Project's status. It is "active", "deactivated" or "deleted"
> Creates or edits a project, returns an HTTP status code. 200 is successful, which means that a project was edited or created.

### roles

### GET
URL: ```http://localhost:5000?requestType=roles```<br />
Response: ```[{"id":1,"username":"admin123","password":"password"},{"id":3,"username":"admin1234","password":"password"}]```<br />
Request queries:
* user_id - optional - User id
* project_id - optional - Project id
> Returns an array of roles according to queries

### POST
URL: ```http://localhost:5000?requestType=role```<br />
Request body:
* user_id - required - User id
* project_id - required - Project id
* name - required - Role's name
> Creates a role, returns an HTTP status code. 200 is successful, which means that a role was created.

### DELETE
URL: ```http://localhost:5000?requestType=role```<br />
Request queries:
* id - required - Role id
> Deletes a role. If HTTP status code is 200, then a role was deleted.

### comments

### GET
URL: ```http://localhost:5000?requestType=comments```<br />
Response: ```[{"id":1,"username":"admin123","value":" new value test","edited":"2024-05-06T07:55:06","created":"2024-05-06T07:52:45","deleted":1},{"id":2,"username":"admin123","value":"new test comment for a project","edited":null,"created":"2024-05-06T07:57:08","deleted":0}]```<br />
Request queries:
* type - required - Type of comments to return. Can be "project", "reply" and "requirement"
* project_id - required if type is "project" - Project id
* comment_id - required if type is "reply" - Comment id
* requirement_id - required if type is "requirement" - Requirement id
> Returns an array of roles comments according to comment type and queries

### POST
URL: ```http://localhost:5000?requestType=comment```<br />
Request body:
* type - required - Type of comment to create. Can be "project", "reply" and "requirement"
* value - required - Comment's value
* project_id - required if type is "project" - Project id
* comment_id - required if type is "reply" - Comment id
* requirement_id - required if type is "requirement" - Requirement id
* user_id - required - User's id
* deleted - required - Boolean, 0 or 1
> Creates a comment, returns an HTTP status code. 200 is successful

### PUT
URL: ```http://localhost:5000?requestType=comment```<br />
Request body:
* id - required - Id of a comment to edit
* value - required - Comment's new value
> Edits a comment, returns an HTTP status code. 200 is successful

### DELETE
URL: ```http://localhost:5000?requestType=comment```<br />
Request queries:
* id - required - Id of comment to delete
> Deletes a comment, returns an HTTP status code. 200 is successful,

### requirements

### GET
URL: ```http://localhost:5000?requestType=requirements```<br />
Response: ```[{"id":1,"name":"new test name asdasd for requirement 1","status":"active","date":"2024-05-06T08:02:58","deleted":0},{"id":2,"name":"new test requirement 2","status":"active","date":"2024-05-06T08:03:11","deleted":0}]```<br />
Request queries:
* project_id - required - Project id of a project we need to get requirements for
> Returns an array of requirements

### POST
URL: ```http://localhost:5000?requestType=requirement```<br />
Request body:
* name - required - Name of requirement
* project_id - required - Project id
> Creates a requirement, returns an HTTP status code. 200 is successful

### PUT
URL: ```http://localhost:5000?requestType=requirement```<br />
Request body:
* type - required - What to edit in a requirement. It can be "name" or "status"
* id - required - Id of a requirement to edit
* name - required if type is "name" - Name of a requirement to edit
* status - required if type is "status" - Requirement's status
> Edits a requirement, returns an HTTP status code. 200 is successful

### relations

### GET
URL: ```http://localhost:5000?requestType=relations```<br />
Response: ```[{"id":2,"requirement_id":1,"requirement_relation_id":2}]```<br />
Request queries:
* requirement_id - required - Id of a requirement
> Returns an array of requirements

### POST
URL: ```http://localhost:5000?requestType=relation```<br />
Request body:
* requirement_id - required - First requirement id
* relation_id - required - seconds requirement id
> Creates a requirement, returns an HTTP status code. 200 is successful

### DELETE
URL: ```http://localhost:5000?requestType=relation```<br />
Request queries:
* id - required - Project id of a project we need to get requirements for
> Deletes a relation, returns an HTTP status code. 200 is successful
