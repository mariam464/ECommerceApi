# 🛒 E-Commerce API

A RESTful API for an e-commerce platform built using **ASP.NET Core**. It provides functionality for product management, user authentication, and more.

## 🚀 Features

- 🔐 JWT Authentication (Register, Login)
- 🛍️ Product catalog with categories
- 📦 CRUD operations for product and category

## 🛠️ Tech Stack

- **Backend:** ASP.NET Core Web API
- **Authentication:** JWT Tokens
- **Database:** Entity Framework Core + SQL Server
- **Tools:** Visual Studio, Swagger, Git

## 📦 Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/mariam464/ECommerceApi.git
   cd ecommerce-api
   ```

2. **Set up the database:**
   - Update the connection string in `appsettings.json`.
   - Run the migrations (if applicable):
     ```bash
     dotnet ef database update
     ```

3. **Run the application:**
   ```bash
   dotnet run
   ```

4. **Access the API:**
   Open your browser or Postman at:
   ```
   https://localhost:7039/swagger
   ```

## 🔑 Authentication

Use the `/authentication/register` and `/api/authentication/login` endpoints to create an account and obtain a JWT token.  
Then, include the token in the `Authorization` header as follows:

```
Authorization: Bearer YOUR_TOKEN_HERE
```

## 📬 API Endpoints (Examples)

| Method | Endpoint              | Description                   |
|--------|-----------------------|-------------------------------|
| POST   | `/api/auth/register`  | Register a new user           |
| POST   | `/api/auth/login`     | Login and get JWT token       |
| GET    | `/api/products`       | Get all products              |



_(More endpoints available in Swagger)_

## 🧪 Testing

Use Postman or Swagger to test all endpoints.

## 🙋‍♀️ Author

Created by [Mariam Ahmed](https://github.com/mariam464)

## 📃 License

This project is licensed under the MIT License.
