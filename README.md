**Overview:**
TripSphere is a simple and user-friendly travel planning website. It helps people to plan trips, choose how they want to travel (like flight or train), and give feedback about their experience. This website is built using ASP.NET Core MVC with C#, and the database is managed using SQL Server. The entire website is hosted online using Microsoft Azure, so it is easy to access anytime and from anywhere.

**Features**

•	Plan Trips: Users can add trip details like place, country, number of days, budget, and travel mode.
•	Choose Travel Mode: Users can select from transport options like car, train, flight, etc.
•	Give Feedback: After the trip, users can give ratings (1 to 5) and write comments.
•	Add/Edit/Delete Trips: Users can create, view, update, and delete their trips and feedback.
•	Online Hosting: The app is uploaded on Microsoft Azure, so it works on the internet smoothly.
•	Mobile-Friendly Design: The layout adjusts nicely on phone, tablet, and desktop.



**API Endpoints Used**

1.	GET /Auth/Login
o	Displays the login page for users to enter their credentials.
2.	GET /Auth/Signup
o	Loads the signup/registration page for new users.
3.	GET /Feedback/Index
o	Retrieves and displays a list of submitted travel feedback.
4.	GET /Home/Contact
o	Shows the contact form for users to send a message or inquiry.
5.	GET /Test/Get
o	Likely used for testing purposes; retrieves sample or dummy data.

**Data Model(ERD)**

![ERD Daigram](https://github.com/user-attachments/assets/054b55f6-59d6-4fa8-944b-d14314ddf3cc)

 
This ERD shows how data is stored and connected in a travel-related application. It has three main tables: TravelMode, TravelPlans, and TravelFeedback. These tables are connected using primary keys (PK) and foreign keys (FK).

🔹 1. TravelMode
•	This table stores types of transport like bus, train, or flight.
•	Fields:
o	Id: the unique ID of each transport (Primary Key)
o	ModeOfTransport: name of the transport (like “Flight”)
•	Relationship:
o	One travel mode can be used in many travel plans.
o	This is called a one-to-many relationship.

🔹 2. TravelPlans
•	This table stores information about each trip.
•	Fields:
o	Id: the unique ID of the trip
o	Destination: place of the trip
o	Country: which country the trip is in
o	Duration: how long the trip is
o	Budget: how much the trip costs
o	TravelModeId: this links to the TravelMode table
•	Relationships:
o	One travel mode → many travel plans
o	One travel plan → many feedback entries

🔹 3. TravelFeedback
•	This table stores reviews or ratings about trips.
•	Fields:
o	FeedbackId: ID of the feedback
o	Destination: destination of the trip
o	Rating: score from 1 to 5
o	Comments: user's review
o	SubmittedOn: when the feedback was given
o	TripId: links to the trip (from TravelPlans)
•	Relationship:
o	One trip can have many feedback entries.



 Summary of Relationships
•	One travel mode can be used in many trips.
•	One trip can have many feedbacks.



**Detailed Overview of CRUD Operations**

In the TripSphere application, full CRUD (Create, Read, Update, Delete) functionality is implemented for managing Travel Plans, Feedback, and Contact Messages. These operations are built using ASP.NET Core MVC and Entity Framework Core.

1️.Travel Plans Module
Create: POST /TravelPlans/Create
•	Users can add a new travel plan by filling out a form with destination, country, duration, budget, and mode of transport.
•	HTTP POST method used in the TravelPlansController.
Read: GET /TravelPlans/Index
•	All travel plans are displayed in a list or card format using Razor Views.
•	Each plan can be viewed individually via the Details action.
Update: POST /TravelPlans/Edit/{id}
•	Users can edit existing plans. The form is pre-populated with existing values.
•	HTTP GET loads the form, HTTP POST updates the database record.

Delete: POST /TravelPlans/Delete/{id}
•	Users can remove a plan using the DeleteConfirmed action after a confirmation step.

2️.Travel Feedback Module
Create: POST /Feedback/Create
•	Feedback form allows users to rate a trip and leave comments. Rating is restricted between 1 and 5.
•	Uses TripId as a foreign key to link the feedback to a specific travel plan.


Read: GET /Feedback/Index
•	Feedbacks are displayed alongside their related destinations or in a feedback section.

Update:
•	Admin or users (if permitted) can update feedback through an editable form view.
Delete:
•	Feedback entries can be deleted using the Delete action in the controller.

3️.Contact Messages Module
Create: POST /Home/Contact
•	Visitors can submit messages through a "Contact Us" form.
•	Includes name, phone number, email, and message fields.
Read: 
•	Messages are displayed in the admin dashboard for review.
•	No update/delete operations implemented for simplicity and data integrity.
4. Travel Mode Module
•	Create:POST/TravelMode/Create
Admin can add transport modes (e.g., Bus, Flight).
•	Read:GET/TravelMode/Index
Lists all available travel modes.
•	Update/Delete: Enabled for admin for modifying or removing transport options.
5. Users
•	Create:POST/Auth/Signup
New users register through the signup form.
•	Read: User data is accessed internally (e.g., login).
•	Update/Delete: Not exposed publicly; managed internally or by admin.

**Notable Technical Challenges & Solutions**


While working on the Trip Sphere project, we faced some technical problems, but we also learned how to solve them step by step. One big challenge was deploying the project to Microsoft Azure. At first, our app was not connecting to the database properly. We solved this by updating the correct connection string in the appsettings. Production. Json file and setting the right values in the Azure portal.
We also had issues with foreign key relationships in our database. For example, linking travel feedback with travel plans was not working. We fixed this by checking the model classes and using proper foreign key annotations. Then we ran migrations again, and everything started working fine.
Another problem came from Razor Views not showing correctly. This happened because some view file names didn’t match the controller action names. We followed the correct MVC naming rules and organized the files properly, which fixed the issue.
Since we were working in a team, we also had some GitHub merge conflicts when two people worked on the same file. To handle this, we created separate branches, used pull requests, and discussed changes regularly to avoid conflicts.
We also found it a little tricky to use external APIs like NewsAPI. It took time to understand how to fetch data and show it in our Razor pages. We learned to use HttpClient, read the JSON response, and display it using models.
Finally, we noticed that our website was not mobile-friendly in the beginning. Some pages didn’t look good on phones. So, we used Bootstrap’s grid system and media queries to make the site responsive and work well on all screen sizes.



