# Book Library Management System

## Introduction
This project is a Book Library Management System designed to manage three types of books: Paper Book, E-book, and Audio Book. Each type of book has common and unique properties.

## Features
- **Inheritance:** Utilizes inheritance for common properties among different book types.
- **Add Books:** Users can add books to the library with basic data and select the type of book, then enter specific data based on the type.
- **Read and Edit:** Users can view all books in the library, navigate between them, delete books, and edit book information.
- **File Handling:** Utilizes file operations to store and retrieve book information.

## Book Properties
### Common Properties
- Title
- Author
- Category
- Type

### Unique Properties
- **Paper Book:**
  - ISBN
  - Number of Pages
- **E-Book:**
  - Format
  - File Size
- **Audio Book:**
  - Narrator
  - Duration

## Implementation Details
- **Library Class:** Adds books to the library, writes them to a file, reads books from the file, and creates objects accordingly.
- **Writing to File:** Utilizes a virtual method in the `Book` class to write objects to the file.
- **User Interface:**
  - Add Menu: Allows users to enter basic book data and choose the type, enabling corresponding input fields.
  - Read and Edit: Displays all books with navigation options, enabling users to delete or edit books.

## Usage
1. **Add Books:** Enter basic book data, select the type, and input specific information.
2. **Read and Edit:** View all books, navigate between them, delete or edit books as needed.

## Video Tutorial
A video tutorial demonstrating the usage of the Book Library Management System:

https://github.com/rarsen/LibraryWindowsApplication/assets/100610615/d5a22637-ea67-4612-adb0-7d2e3ab370a0

