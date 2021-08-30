<h2 align="center"> Assignment 3</h2>

<p> You have to create 5 projects. Each project must have the following things, but you must not copy the code after you complete one task. Rather do it from the start. </p>

<p>Common thing in each project:</p>

    1. Autofac configuration
    2. Serilog configuration
    3. Bootstrap admin panel configuration
    4. Repository configuration (both base repository and entity specific repository)
    5. Unit of work configuration (both base unit of work and context specific unit of work)
    6. Configure DBContext
    7. Create migrations
    8. Links in left menu in admin template
    9. CRUD (Add/Edit/Delete/List) feature with user interface

<p> Now here are the 5 different project names and entities in them. Use the correct Web Project name and accordingly name other project names as shown in class. Only create the entities listed in each project, you do not need to make a full system so do not make additional entities:
</p>

    1. TicketBookingSystem (Web Project name)
        a. Customer (Id, Name, Age, Address)
        b. Ticket (Id, CustomerId, Destination, Ticket Fee)
    2. SocialNetwork (Web Project name)
        a. Member (Id, Name, DateOfBirth, Address)
        b. Photo (Id, MemberId, PhotoFileName)
    3. AttendanceSystem (Web Project name)
        a. Student (Id, Name, StudentRollNumber)
        b. Attendance (Id, StudentId, Date)
    4. ECommerceSystem (Web Project name)
        a. Product (Id, Name, Price)
    5. InventorySystem ((Web Project name)
        a. Product (Id, Name, Price)
        b. Stock (Id, ProductId, Quantity)


<p>For each entity, column names are mentioned. You have to create a repository for each entity and you must create CRUD for each entity. 
</p>

<p>
Each project should have a separate solution and should be in a separate folder in the same “assignment-3” branch. Here project mean the group of projects like “ticket booking system”, etc
</p>
