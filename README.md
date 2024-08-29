# DirectoryNotifier

### Overview

**DirectoryNotifier** is a C# console application that monitors a specified directory for file changes, such as file creation and deletion, and notifies registered consumers about these changes in real-time. The application is designed for dynamic consumer management, allowing users to add or remove consumers during runtime via a console interface. The project is implemented using .NET Framework 6.0 and is built using Visual Studio for Mac.

### Features

- **Real-time Directory Monitoring**: Utilizes `FileSystemWatcher` to monitor a directory and detect file changes in real-time.
- **Dynamic Consumer Management**: Users can add or remove consumers on the fly, each consumer receiving notifications about file changes.
- **Event Notification**: Consumers are notified whenever files are added or removed from the monitored directory.
- **Memory Management**: Proper disposal of resources, including the `FileSystemWatcher` and event handlers, to prevent memory leaks.

### Usage

#### Prerequisites

- .NET Framework 6.0
- Visual Studio for Mac

#### Running the Application

1. Clone or download the repository.
2. Open the project in Visual Studio for Mac.
3. Build and run the solution.

#### Command Line Interface

When the application is running, interact with it using the following commands:

- **`a`** - Add a new consumer. You will be prompted to enter a name for the consumer.
- **`d`** - Delete a consumer by name. You will be prompted to enter the name of the consumer to remove.
- **`h`** - Display the help menu.
- **`q`** - Quit the application. This also disposes of all consumers and their resources.
