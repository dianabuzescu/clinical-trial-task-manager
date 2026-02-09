# Clinical Trial Task Manager

A web-based task management application designed to support operational workflows in clinical trials.  
The application simulates real-world scenarios from the eClinical domain, focusing on clarity, data integrity and enterprise-style architecture.

Built as a portfolio project to demonstrate full-stack development skills using **ASP.NET Core MVC**, **Entity Framework Core** and **SQL Server**.

---

## Project Overview

Clinical Trial Task Manager helps manage:
- clinical studies
- enrolled patients
- operational tasks associated with patients

The application emphasizes:
- clean architecture
- realistic business rules
- data relationships (Studies → Patients → Tasks)
- usability features such as filtering, sorting and dashboards

---

## Key Features

### Dashboard
- Overview of upcoming tasks
- Overdue tasks
- Task distribution by status

### Studies Management
- Create and manage clinical studies
- Track sponsor, status and start date

### Patients Management
- Assign patients to studies
- Unique patient code validation
- Birth date validation (no future dates allowed)

### Task Management
- Tasks linked to patients
- Enum-based **Priority** and **Status**
- Full CRUD functionality
- Business validations

### Advanced Filtering & Sorting
- Filter tasks by **Status** and **Priority**
- Search by **Task Title** or **Patient Code**
- Sort tasks by **Due Date**
- Clear filters with one click

### Enterprise Polish
- Filter state preserved when navigating Edit / Details / Delete
- Consistent dropdowns displaying `PatientCode - FullName`
- Robust handling of validation and foreign keys

---

## Tech Stack

**Backend**
- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- LINQ

**Database**
- SQL Server (LocalDB)
- EF Core Migrations
- Relational design with foreign keys

**Frontend**
- Razor Views
- Bootstrap 5

**Other**
- Git & GitHub
- Clean, layered architecture

---

## Database Setup & Demo Data

The project includes a SQL script with demo data for easy testing.

### To populate the database:

1. Run the application once to create the database (via EF migrations)
2. Open **SQL Server Object Explorer**
3. Right-click the database → **New Query**
4. Execute the script:

```sql
Database/seed-demo.sql
```

This will insert:
- demo studies
- demo patients
- demo tasks with realistic relationships

---

## How to Run the Project

1. Clone the repository:
```bash
git clone https://github.com/dianabuzescu/clinical-trial-task-manager.git
```

2. Open the solution in Visual Studio

3. Update the connection string if needed:
```bash
appsettings.json
```

4. Apply migrations:
```bash
Update-Database
```

5. Run the application

---

## Screenshots

<img width="1655" height="834" alt="image" src="https://github.com/user-attachments/assets/52fd6344-08aa-42a3-9938-47583a77ad00" />

Dashboard overview showing overdue and upcoming tasks, grouped by status

---

<img width="1919" height="567" alt="image" src="https://github.com/user-attachments/assets/89c86c93-a45b-4a79-b47a-0b3e492a55d3" />

Task list with advanced filtering, search and sorting by due date

---

<img width="862" height="772" alt="image" src="https://github.com/user-attachments/assets/d3605f9a-29e3-48e6-89c4-66c7cbcd4cb2" />

Creating a task with enum-based priority and status, linked to a patient

---

<img width="1803" height="503" alt="image" src="https://github.com/user-attachments/assets/1ae138d4-319f-41a7-8911-d6b9abe3ec78" />

Patients overview with assigned clinical studies

---

<img width="1761" height="520" alt="image" src="https://github.com/user-attachments/assets/34fea5c3-e0b7-4bcb-8f0d-3ffe7cf483b0" />

Clinical studies management with sponsor and status tracking

---

## Purpose

This project was built as a learning and portfolio application, with a strong focus on:

- enterprise-style development

- realistic domain modeling

- clean, readable code

- practices commonly used in clinical software systems

---

## Author

**Diana Buzescu**

Computer Science Engineering student | Interested in full-stack development and enterprise software systems

[LinkedIn](https://www.linkedin.com/in/diana-buzescu-b02a97290/)

---

## License

This project is for educational and demonstration purposes.

