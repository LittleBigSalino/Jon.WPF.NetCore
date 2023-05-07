# Project Specifications: Prompt Manager and Builder

## Overview

A C# .NET Framework WPF desktop application to manage and build prompts for various stages of software development, such as planning, defining specifications, defining build approach, coding assistance, and documentation.

## Features

1. Selection of prompt type based on software development stage.
2. Display and management of available prompts for the selected type.
3. Editing prompts with placeholders (fill-in-the-blank) and list options.
4. SQLite backend database for storing and managing prompts and list options.

## User Interface

- Main window with the following components:
  - ComboBox: Prompt type selection based on software development stage.
  - ListView: Display of available prompts for the selected type.
  - Controls for editing prompts, placeholders, and list options (e.g., TextBoxes, CheckBoxes).
  - Buttons for creating, editing, saving, and deleting prompts.

## Database Design

- SQLite database file (e.g., `prompts.db`).
- Tables:
  - `Prompts`: ID, prompt type, text, placeholders.
  - `ListOptions`: ID, prompt ID, list option text.

## Implementation

### 1. Set up the development environment

- Install Visual Studio with .NET Desktop Development workload.
- Create a new WPF Application project in C#.

### 2. Design the user interface

- Use the XAML designer to create the main window with necessary components.

### 3. Set up the SQLite database

- Install the 'System.Data.SQLite.Core' NuGet package.
- Create the database file and define the required tables.

### 4. Implement the data access layer

- Create a `DatabaseManager` class to handle SQLite operations.
- Implement CRUD methods for prompts and list options.

### 5. Implement the business logic layer

- Create a `PromptManager` class to perform operations on prompts and list options using `DatabaseManager`.
- Implement methods for CRUD operations and any other necessary operations.

### 6. Implement the UI logic

- Bind UI controls to data and actions provided by `PromptManager`.
- Implement event handlers for buttons and other controls.

### 7. Test the application

- Run the application and test each feature for proper functionality and database updates.

### 8. Refine and improve

- Make any necessary refinements and improvements based on usage and feedback.

By following these steps and specifications, the prompt manager and builder for various stages of software development should be fully implemented with a SQLite backend database.