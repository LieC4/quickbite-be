# QuickBite - Food Delivery Application




https://user-images.githubusercontent.com/67655940/230050226-0dc5fcfe-71c0-4986-9661-beb08e1b7a76.mp4


<br>
QuickBite is a food delivery application that simplifies the process of ordering food online. Users can browse through various restaurants and cuisines, select their favorite dishes, and have them delivered right to their doorstep. This application is developed using .NET for the backend, React for the frontend, and uses Entity Framework to access the database. We used the Stripe API for the payment process and deployed the application on Azure.

## Functionality
- User Registration and Authentication: Users and restaurants can create an account, log in, and access all the features of the app.
- Restaurant and Menu Management: The app displays a list of restaurants and their menus. Restaurants can add their dishes to their menu. Users can select their preferred restaurant and browse through the menu to select their favorite dishes.
- Order Placement: Users can order food and the restaurant will be notified after the order is placed

## Features
- **Search and Filter:** Users have the option to filter and search for the desired food.
- **Payment Gateway Integration:** We used the Stripe API for the payment feature to ensure a safe and secure payment process.
- **Cart Option:** The user has the option to edit the content of their cart, such as changing the quantity or adding/removing a product.

## Tech Stack
- **Entity Framework (EF):** EF is an open-source ORM framework for .NET applications. It simplifies database access and management, making it easier to develop data-driven applications.
- **Azure:** Azure is a cloud computing platform that provides various services such as virtual machines, databases, and storage. We used Azure to host and deploy the application.
- **.NET:** .NET is a free, cross-platform, open-source framework for building applications. We used .NET to develop the backend of the application.
- **React:** React is a JavaScript library used for building user interfaces. We used React to develop the frontend of the application.

## External APIs
- **Stripe API:** We used the Stripe API for the payment process.

## Deployment

We deployed the application on Azure. With Azure, we could ensure high availability, scalability, and security of the application.

### How to Run the Application
1. Clone the repository.
2. Run **'npm install'** in the QuickBite.UI directory to install the frontend dependencies.
3. Run **'dotnet restore'** in the QuickBite directory to restore the backend dependencies.
4. Run **'dotnet ef'** database update in the QuickBite directory to update the database.
5. Run **'dotnet run'** in the QuickBite directory to start the backend server.
6. Run **'npm start'** in the QuickBite.UI directory to start the frontend server.
7. Open **'http://localhost:3000'** in your browser to access the application.

### Contributors

- [Samet Kurt](https://github.com/sammkrt)
- [Jacopo Zarri](https://github.com/jacopo-zarri)
- [Anitas Vlad](https://github.com/AnitasVlad)

### License
This project is licensed under the MIT License.



