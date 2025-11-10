# GitHub Activity CLI

A simple .NET console application to fetch and display a user's recent public activity from the GitHub API.

(Простое консольное .NET-приложение для получения и отображения последней публичной активности пользователя с GitHub API.)

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

github-activity octocat

ForkEvent on octocat/Spoon-Knife

Starred octocat/git-consortium

Pushed 0 commits to octocat/test-repo

Created a new repository: octocat/Hello-World

opened a pull request in octocat/Hello-World Press any key to continue...

## 📄 Technical Details

This project demonstrates clean C# practices for a console application, including:

* **Service-Oriented Design:** Logic is properly separated into services (`GitGubService`, `PrintUserActivity`, `InputValidationService`).
* **Asynchronous Programming:** Uses `async/await` for efficient, non-blocking network requests.
* **API Compliance:** Correctly handles GitHub API requirements, such as setting a `User-Agent` header.
* **Robust JSON Parsing:** Uses `System.Text.Json` (via `JsonElement` and `Dictionary<string, object>`) to parse the complex, nested JSON response from the GitHub Events API.
* **Error Handling:** Includes `try-catch` blocks to prevent crashes from unexpected JSON structures or API errors (e.g., user not found).
