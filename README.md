# ProjectPilot

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

### POST
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
Request body:
* id - required - Role id
> Deletes a role. If HTTP status code is 200, then a role was deleted.

### comments

### GET
URL: ```http://localhost:5000?requestType=comments```<br />
Response: ```[pls insert the response example pls lol thansk]```<br />
Request queries:
* type - required - Type of comments to return. Can be "project", "reply" and "requirement"
* project_id - required if type is "project" - Project id
* comment_id - required if type is "reply" - Comment id
* requirement_id - required if type is "requirement" - Requirement id
> Returns an array of roles comments according to comment type and queries

### POST
URL: ```http://localhost:5000?requestType=comment1```<br />
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
URL: ```http://localhost:5000?requestType=comment1```<br />
Request body:
* id - required - Id of a comment to edit
* value - required - Comment's new value
> Edits a comment, returns an HTTP status code. 200 is successful

### DELETE
URL: ```http://localhost:5000?requestType=comments```<br />
Request queries:
* id - required - Id of comment to delete
> Deletes a comment, returns an HTTP status code. 200 is successful,

### requirements

### GET
URL: ```http://localhost:5000?requestType=requirements```<br />
Response: ```[pls insert the response example pls lol thansk]```<br />
Request queries:
* project_id_ - required - Project id of a project we need to get requirements for
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
* type - required - Requirement's type
* id - required - Id of a requirement to edit
* name - required - Name of a requirement to edit
* status - required - Requirement's status
> Edits a requirement, returns an HTTP status code. 200 is successful

### DELETE
URL: ```http://localhost:5000?requestType=requirement```<br />
Request queries:
* project_id_ - required - Project id of a project we need to get requirements for
> Creates a requirement, returns an HTTP status code. 200 is successful

### relations

### GET
URL: ```http://localhost:5000?requestType=relations```<br />
Response: ```[pls insert the response example pls lol thansk]```<br />
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
* project_id - required - Project id of a project we need to get requirements for
> Deletes a relation, returns an HTTP status code. 200 is successful