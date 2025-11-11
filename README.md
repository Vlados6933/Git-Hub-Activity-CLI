# GitHub Activity CLI

A simple .NET console application to fetch and display a user's recent public activity from the GitHub API.

## 🚀 Features

* **Fetch User Activity:** Get the recent public activity for any valid GitHub user.
* **Detailed Parsing:** Correctly parses and displays key events, including:
    * `PushEvent` (with commit count)
    * `WatchEvent` (Starred)
    * `IssuesEvent` (Opened/Closed)
    * `PullRequestEvent` (Opened/Closed/Merged)
    * `CreateEvent` (Repository creation)
* **Handles All Events:** Includes a default handler to display all other event types (`ForkEvent`, `MemberEvent`, etc.) for a complete activity log.
* **Zero Dependencies:** Built entirely with built-in .NET libraries (`HttpClient` and `System.Text.Json`). No external packages or frameworks are required.
* **Interactive UI:** Features a clean banner and a continuous loop, allowing you to check multiple users without restarting the application.

## 🛠️ Technology Stack

* **C#** & **.NET**
* **GitHub REST API** (v3)
* **System.Net.Http** (for API calls)
* **System.Text.Json** (for JSON parsing)

## ⌨️ How to Use

1.  Clone the repository or download the source code.
2.  Run the application using `dotnet run` or by executing the compiled `.exe`.
3.  The application will start and display a banner.
4.  At the prompt, type the command in the following format: `github-activity <username>`
5.  Press **Enter**. The application will fetch and display the user's activity.
6.  After the activity is displayed, press any key to return to the main prompt and check another user.

### Example

<img width="1160" height="473" alt="image" src="https://github.com/user-attachments/assets/969fd8b2-edfc-4bda-a0e1-cec6dfeca255" />



## 📄 Technical Details

This project demonstrates clean C# practices for a console application, including:

* **Service-Oriented Design:** Logic is properly separated into services (`GitGubService`, `PrintUserActivity`, `InputValidationService`).
* **Asynchronous Programming:** Uses `async/await` for efficient, non-blocking network requests.
* **API Compliance:** Correctly handles GitHub API requirements, such as setting a `User-Agent` header.
* **Robust JSON Parsing:** Uses `System.Text.Json` (via `JsonElement` and `Dictionary<string, object>`) to parse the complex, nested JSON response from the GitHub Events API.
* **Error Handling:** Includes `try-catch` blocks to prevent crashes from unexpected JSON structures or API errors (e.g., user not found).
