# CRUD APPLICATION

# About project

The project is CRUD (Create, Read, Update, Delete), it's about employee management. The main goal of the project is to complete the classes.

# Technologies

- Angular 10
- .NET Core 3.1
- PostgresSQL 11

# Installation

### Pre Required

- NodeJs 12.6.0
- Npm 6.13.7
- Angular 10.0.4 or newer
- Visual Studio
- .NET Core 3.1
- PostgresSql 11
- Any database manager that allows you to connect to postgres (PgAdmin, DbBeaver etc.)

### 1. Clone the repository
  
  `git clone https://github.com/pjugowiec/CRUD_NET`
  
### 2. Backend

Open the `webApi` folder via Visual Studio, wait for all dependencies to be imported. Run application in debug mode. 
Check the database connection data `webApi/server/Properties/AppDbContext`. 
> **Insert new user to your database:**
> `INSERT INTO public."_adm_users"
(login, "password", email, is_active)
VALUES('admin', 'admin', 'admin@admin.com', true);
`

### 3. Frontend

Go to the `gui` folder via terminal (Unix), cmd (Windows), make sure nodeJs is accessible from console. 
Enter `npm install` or `yarn install` and then execute` ng serve` after the dependencies have been imported successfully.

### 4. Use application

Enter `localhost:4200` in your browser. Enter login details `admin` `admin`, after successful login you can use the application!
