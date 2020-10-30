# Amingo


## Follow the following instruction:
1. Clone the repostory into a folder
2. Open cmd, powershell or git bash in current folder
3. Enter the "dotnet build" and wait for around 5 min
4. Edit AppSettings for connection string of MySQL(like user, password, server, and port)
5. Run command "dotnet ef database update"
6. Then enter "dotnet run" and open "https://localhost:{port}/"

  ## EndPoints of the Api with Required methods and Json body parameters 
  ### All Endpoints except Auth Controller need a JWTBearer token
        In Header add: 
        {
          Key: Authorization
          value: Bearer + "Token from Login"
        }

  ## Auth Controller
  
#### Post Request
###### Register: "https://localhost:{port}/api/Auth/register"
    {
     "username"     : "testuser"
     "password"     : "Password@1"
     "gender"       : "Male"/ "female"
     "dateOfBirth"  : "12/04/2000"
     "knownAs"      : "user"
     "city"         : "Delhi"
     "country"      : "India"
     }
#### Get Request
###### Login   : "https://localhost:{port}/api/Auth/login"
     { 
       "username": "testuser",
       "Password": "Password@1"
     }

  ## Users Controller

#### Get Requests 
###### Single User: "https://localhost:{port}/api/users/{id}"
###### All Users  : "https://localhost:{port}/api/users" 

#### Post Requests

###### Like User  : "https://localhost:{port}/api/users/{id}/like/{receiverId}"

#### Patch Requests
   
###### Update User: "https://localhost:{port}/api/users/{id}"
      [{
        "op": "replace"/"copy",
        "path": "username",
        "value": "newvalue"
        },
        {
        "op": "replace"/"copy",
        "path": "password",
        "value": "newvalue"
        },
        {
        "op": "replace"/"copy",
        "path": "knownAs",
        "value": "newvalue"
        },
        {
        "op": "replace"/"copy",
        "path": "city",
        "value": "newvalue"
        },
        {
        "op": "replace"/"copy",
        "path": "country",
        "value": "newvalue"
      }]
        
  
  ## Messages Controller
  
#### Get Requests
    
###### Single Message: "https://localhost:{port}/api/users/{userId}/messages/{id}"
###### Messages      : "https://localhost:{port}/api/users/{userId}/messages"
###### Chat Thread   : "https://localhost:{port}/api/users/{userId}/messages/thread/{receiverId}"
    
#### Post Requests
 
###### Create Message    : "https://localhost:{port}/api/users/{userId}/messages"
        {
          "senderId"    : 1
          "receiverId"  : 2
          "content"     : "Hello"
        }
###### MarkAsRead Message: "https://localhost:{port}/api/users/{userId}/messages/{id}/read"
###### DeleteMessage     : "https://localhost:{port}/api/users/{userId}/messages/{id}"
    
  ## Photos Controller
    
#### Get Requests

###### Single Photo : "https://localhost:{port}/api/users/{userId}/photos/{id}"
    
#### Post Requests

###### Post Photo   : "https://localhost:{port}/api/users/{userId}/photos/"
        {
          "File" : uploaded_file.png,
          "description": "File added"
        }
###### Set As Main  : "https://localhost:{port}/api/users/{userId}/photos/{id}/isMain"
#### Delete Requests
    
###### Delete Photo : "https://localhost:{port}/api/users/{userId}/photos/{id}"
