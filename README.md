# ProjectPilot
## About
ProjectPilot is a tool made for managing projects and requirements.
This tool is made using C# and an SQL database. Database is a MySQL Community Server, server side is an API and client side is using WPF.
## API Documentation
### GET projects
URL: ```http://localhost:5000?requestType=projects```<br />
Response: ```[{"id":1,"name":"test project2","description":"test project description","status":"active"}]```
> Returns an array of all existing projects in JSON format
### GET users
URL: ```http://localhost:5000?requestType=users```<br />
Response: ```[{"id":1,"username":"admin123","password":"password"},{"id":3,"username":"admin1234","password":"password"}]```
> Returns an array of all existing users in JSON format
### GET roles
URL: ```http://localhost:5000?requestType=roles&user_id=1&project_id=1```<br />
Response: ```[{"id":1,"username":"admin123","password":"password"},{"id":3,"username":"admin1234","password":"password"}]```<br />
Request queries:
* user_id - optional - User id
* project_id - optional - Project id
> Returns an array of roles according to queries
### POST register
URL: ```http://localhost:5000?requestType=register```<br />
Request body:
* username - required - User's username
* password - required - User's password
> Returns an HTTP status code. 200 is successful, which means that a new user was created.
### POST login
URL: ```http://localhost:5000?requestType=login```<br />
Request body:
* username - required - User's username
* password - required - User's password
> Returns an HTTP status code. 200 is successful, which means that a new user was created.
### POST project
URL: ```http://localhost:5000?requestType=project```<br />
Request body:
* id - optional - Project's id. If specified, a project will be edited.
* name - required - Project's name
* description - required - Project's description
* status - required - Project's status. It is "active", "deactivated" or "deleted"
> Creates or edits a project, returns an HTTP status code. 200 is successful, which means that a project was edited or created.
### POST role
URL: ```http://localhost:5000?requestType=role```<br />
Request body:
* user_id - required - User id
* project_id - required - Project id
* name - required - Role's name
> Creates a rolet, returns an HTTP status code. 200 is successful, which means that a role was created.
### DELETE role
URL: ```http://localhost:5000?requestType=role```<br />
Request body:
* id - required - Role id
> Deletes a role. If HTTP status code is 200, then a role was deleted.
