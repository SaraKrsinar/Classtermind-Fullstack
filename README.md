Classtermind – School Subjects Information System  
.NET Web API + Angular Frontend

Overview:
Classtermind is a full-stack application built with ASP.NET Core Web API and Angular, designed to manage school subject information.

It allows users to view, add, and explore subjects — combining predefined academic subjects with user-created ones stored in a JSON file. The app demonstrates principles 
of Clean Architecture, SOLID, and polymorphism, with a modern UI.

Features:

Backend (.NET Web API)
- Get all subjects (predefined + user-added)
- Get subject details by name
- Add a new subject (stored in subjects.json)
- Generate a study plan per subject and available hours
- Uses polymorphic serialization with $type discriminator

Frontend (Angular)
- View list of all subjects
- See detailed information per subject
- Add a new subject via form - then it directly adds it to the subjects.json in the backend
- Navigate between views
- Generate personalized study plans
- Responsive layout with Bootstrap styling

Technologies Used:

Backend:
- ASP.NET Core 8 Web API
- C# with Clean Architecture
- System.Text.Json for polymorphic serialization
- Swagger/OpenAPI for API testing

Frontend:
- Angular 20
- Bootstrap CSS
- Angular Router
- Standalone components & HttpClient

Project Structure:

Backend (ClasstermindS)
- Domain
  -> BaseSubject.cs, PredefinedSubject.cs, ExternalSubject.cs, Subject.cs, ISubject.cs
- Application
  -> SubjectDto.cs, SubjectService.cs, ISubjectService.cs, NotFoundException.cs
- Infrastructure
  -> SubjectRepository.cs, SubjectsContext.cs, ISubjectRepository.cs
- WebApi
  -> SubjectsController.cs, Program.cs, appsettings.json, launchSettings.json

Frontend (classtermind)
- src/app
  - components
    -> add-subject/
    -> subject-card/
    -> subject-detail/
    -> subject-list/
  - models
    -> subject-dto.model.ts
  - services
    -> subject.service.ts
  - app-routing-module.ts
  - app-module.ts
  - app.ts, app.html, app.css
- index.html
- main.ts
- styles.css

Each subject contains:
- Name
- Description
- WeeklyClasses
- IsMandatory
- Credits
- Literature Used

How to Run:

Backend:
1. Open terminal and navigate to ClasstermindS.WebApi
2. Run:
   dotnet run
3. Open browser to:
   https://localhost:7150/swagger

Frontend:
1. Open terminal and navigate to classtermind
2. Run:
   npm install
   ng serve
3. Open browser to:
   http://localhost:4200

Highlights:
- Predefined and user-added subjects coexist in the same system.
- Subjects are polymorphic (via BaseSubject, ExternalSubject, PredefinedSubject).
- JSON file is used for persistent storage without a database.
- Clean Architecture: domain, application, infrastructure, and presentation.

Future Plans:
The Classtermind application can be further enhanced with the following:

- Authentication & Authorization:
  Implement user login and role-based access (e.g., admin vs student).
- Database Integration:
  Replace the JSON file with a database like SQL Server or PostgreSQL for better scalability.
- Edit/Delete Subjects:
  Allow editing and deleting of user-added subjects.
- User Dashboard:
  Provide a dashboard for personalized study tracking and saved plans.
- Testing:
  Add unit and integration tests for both backend and frontend.
- Deployment:
  Host the solution on Azure, Vercel, GitHub Pages, or similar platforms.
