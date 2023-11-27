# Disaster Alleviation Foundation

The Disaster Alleviation Foundation is a non-profit organization dedicated to providing practical aid during disasters. This web application is designed to track donations, manage disaster-related activities, and ensure transparency in the foundation's operations.

## Tech Stack

- ASP.NET Core Web App (MVC)
- Identity for User Authentication
- Azure SQL Database

### Features

 **Color Scheme:**
   - The web application adheres to the foundation's color scheme, using purple and orange.

 **User Authentication:**
   - Secure user authentication is implemented to control access to different functionalities.
   - Two user roles: Admin and User.

 **Admin Features:**
   - Admin user have access to:
     - Add new disasters.
     - Allocate monetary funds to an active disaster.
     - Allocate goods to an active disaster.

 **User Features:**
   - Regular users have access to:
     - Capture new monetary donations with mandatory information (date and amount). Donors may choose to remain anonymous.
     - Capture new goods donations with mandatory information (date, number of items, category, and description). Donors may choose to remain anonymous.

 **Goods Categories:**
   - Pre-configured categories include:
     - Clothes
     - Non-perishable foods
   - Admin user can define new categories for goods.

 **Disaster Management:**
   - Admin user can capture new disasters with information such as start date, end date, location, and description.
   - It is possible to specify required aid types for each disaster (e.g., water provision, clothing, food).

 **Lists and Allocations:**
   - Admin user can view lists of:
     - All incoming monetary donations.
     - All incoming goods donations.
     - All disasters.
     - Allocation features:
       - Allocate money to an active disaster.
       - Allocate goods to an active disaster.
       - Capture the purchase of goods using available money, decreasing available funds, and adding goods to the inventory allocated to a specific disaster.

 **Transparency:**
   - Publicly accessible page displaying:
     - Total monetary donations received.
     - Total number of goods received.
     - Currently active disasters, with allocated money and goods.

 **Unit Tests:**
   - Implement unit tests to ensure the logic of the application, such as checking that you cannot allocate more goods than are available.

