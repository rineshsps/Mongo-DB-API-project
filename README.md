
#Test Senior Backend Web Developer 

Deployed URL : https://mongo-db-api-app.herokuapp.com/swagger/index.html



## API Reference

#### Task 1 : CRUD opration for Books

```http
  GET /api/Books
```
```http
  POST /api/Books
```
```http
  PUT /api/Books
```
```http
  GET /api/Books/{id}
```
```http
  DELETE /api/Books/{id}

```
 
#### Task 2 : Validate Binary String

```http
  GET api/Binary/ValidateBinary?value

```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `value` | `string` | **Required**. Bniary value |

  
## Database configuration



```

| Name              | Value                    
| :--------         | :-------
| ConnectionString  | `mongodb+srv://user1:pass-2@cluster0.8pzy0.mongodb.net/BookstoreDb?retryWrites=true&w=majority` 
| Database          | `BookstoreDb` 
| Collection        | `Books` 


  