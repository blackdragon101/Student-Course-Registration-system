# Student-Course-Registration-system

A Windows Forms application developed in C# for managing student course registration using WinForms effectively. The system uses a MySQL database backend to store data and allows administrators to add courses, assign instructors, and manage course registrations.

## Features

- **Add Courses:** Create new courses with name, credit hours, and department information.
- **Assign Instructors:** Assign instructors to courses for specific semesters.
- **User-Friendly Interface:** Intuitive WinForms-based UI for easy navigation and data entry.
- **Secure Database Integration:** Uses parameterized queries to interact with a MySQL database.
- **Department Support:** Handles multiple departments and keeps course information organized.

## Screenshots
<img width="959" alt="Screenshot 2025-05-17 000015" src="https://github.com/user-attachments/assets/c8a3ceb7-07a3-4a91-8a06-d2a1dab51f93" />
<img width="959" alt="Screenshot 2025-05-16 235857" src="https://github.com/user-attachments/assets/60a1f15a-c48c-4627-bc0e-ee3a38b9dac5" />
<img width="958" alt="Screenshot 2025-05-17 000052" src="https://github.com/user-attachments/assets/5934a14b-1191-4ef4-b40f-5eff5f8933c3" />
<img width="959" alt="Screenshot 2025-05-17 000143" src="https://github.com/user-attachments/assets/8c9a0521-58a5-4c29-aea4-bb9551dcf486" />
<img width="959" alt="Screenshot 2025-05-17 000236" src="https://github.com/user-attachments/assets/4870a46d-d6df-498c-8b20-3d2ffeaf3c27" />
<img width="959" alt="Screenshot 2025-05-17 000307" src="https://github.com/user-attachments/assets/660a323f-c4d7-4fc0-910a-d7a4dc2f27b3" />
<img width="959" alt="Screenshot 2025-05-17 000353" src="https://github.com/user-attachments/assets/32b53666-0dd1-41e6-8a38-1e6a6d71fd6d" />







## Technologies Used

- **C# (Windows Forms)** – Frontend UI and logic.
- **MySQL** – Backend database for persistent data storage.
- **.NET Framework** – Application runtime.
- **MySQL Connector/NET** – For database connectivity.

## Getting Started

### Prerequisites

- Windows OS
- Visual Studio (2017 or newer recommended)
- .NET Framework (4.7.2 or newer)
- MySQL Server (local or remote)
- MySQL Connector/NET

### Database Setup

1. Create a MySQL database named `regis_system_database`.
2. Run the following SQL to create tables:
    ```sql
    CREATE TABLE courses (
        Course_id INT AUTO_INCREMENT PRIMARY KEY,
        Course_name VARCHAR(100),
        Credit_hrs INT,
        Department VARCHAR(100)
    );

    CREATE TABLE course_assignments (
        Assignment_id INT AUTO_INCREMENT PRIMARY KEY,
        Course_id INT,
        Instructor_id VARCHAR(50),
        Semester INT,
        FOREIGN KEY (Course_id) REFERENCES courses(Course_id)
    );
    ```
3. Update the connection string in the source files (e.g., `Add_Course.cs`, `AddAssignment.cs`) with your MySQL credentials.

### Running the Application

1. Clone the repository:
    ```sh
    git clone https://github.com/blackdragon101/Student-Course-Registration-system.git
    ```
2. Open the solution in Visual Studio.
3. Restore NuGet packages (especially `MySql.Data`).
4. Build and run the project.

## Usage

- **Add a Course:** Enter course details and click "Add Course".
- **Assign Instructor:** Enter course ID, instructor ID, and semester, then click "Add Assignment".

## Project Structure

- `Add_Course.cs` – Logic for adding new courses.
- `AddAssignment.cs` – Logic for assigning instructors to courses.
- `*.Designer.cs` – UI layout files for the forms.

## Security Notes

- **Do NOT** hard-code database passwords in production. Use environment variables or secure configuration management.
- Ensure your MySQL server is secured and not exposed to the public internet.

## Contribution

Pull requests and suggestions are welcome! Please open an issue to discuss changes or enhancements.

## Link With Me
- Follow my LinkedIn Account for more updates on upcoming projects or Email me for project Collaborations.
  [LinkedIn](https://www.linkedin.com/in/fatima-masood-1a07352bb/)
  [Email Me](fammasood8404@outlook.com)

---

> Developed by [blackdragon101](https://github.com/blackdragon101)
