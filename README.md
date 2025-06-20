# 🗓️ Dynamic TimeTable Generator (ASP.NET Core MVC - .NET 8)

A web application built with **ASP.NET Core MVC (v8)** that dynamically generates a weekly timetable based on user input such as working days, subjects per day, and total subjects.

---

## ✅ Features

- Input form to collect:
  - Number of Working Days (1–7)
  - Subjects per Day (Max 8)
  - Total Number of Unique Subjects
- Auto-calculates **Total Weekly Hours**
- Dynamically builds form to enter **each subject's hours**
- Real-time validation:
  - "Generate" button is disabled until all inputs are valid
  - Live display of total entered subject hours vs required
- Generates a timetable grid dynamically:
  - Columns = Working Days
  - Rows = Subjects per Day
- Subjects are **randomly placed** based on hours
- Fully responsive and validated form

---

## 💡 Technologies Used

| Layer         | Tech                                       |
|---------------|---------------------------------------------|
| Framework     | ASP.NET Core MVC (.NET 8 LTS)              |
| Language      | C#                                         |
| Frontend      | Razor Pages + Bootstrap + JavaScript       |
| Backend Logic | C# MVC Controllers + In-Memory Data        |
| Validation    | Data Annotations + JavaScript              |

---

## 🖼️ Screenshots

> *(Add screenshots here if available)*
![Screenshot 2025-06-20 224937](https://github.com/user-attachments/assets/6e9eae72-5106-4a73-ad5c-56dfe3cfcc6c)
![Screenshot 2025-06-20 224918](https://github.com/user-attachments/assets/eb5dd4f5-3e37-404a-927b-d60d8493099b)
![Screenshot 2025-06-20 224903](https://github.com/user-attachments/assets/b8a099fb-f725-4b78-8ac9-feb8da2ee715)
![Screenshot 2025-06-20 224755](https://github.com/user-attachments/assets/32390cba-cb33-435a-ad3c-017cbe606e21)

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/DynamicTimeTableGenerator.git
cd DynamicTimeTableGenerator
