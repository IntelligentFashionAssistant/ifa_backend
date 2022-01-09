# IFA (Intelligent Fashion Assistant)

this is an api for the Intelligent Fashion Assistant

## rules : 

### general naming conventions : 
- parameter : camelCase 
- Methods, Properties : PascalCase 
- instance variables : _camelCase

### Persistence 
responsible for database operations
#### conventions
- get (specialized)
- get (generalized)
- post 
- put 
- delete

# Service  delete ( throw )
- shapeservice delete

# Features to Implement : 
- DTOs validation
- Status Code
- give user a Role in registration process
##~~~~~~~~~~~ user ~~~~~~~~~~~~~~~~~~
##~~~~~~~~~~~ Shop owner ~~~~~~~~~~~~~~~~~~
+ get all garments with their categories
##~~~~~~~~~~~ Admin ~~~~~~~~~~~~~~~~~~
+ get approved stores 
+ get not approved stores
- send email to shop owner when after reject the registration!!!
+ Add Categories, Groups, Properties, Colors and Shapes to database (define in Helper)
