using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Services
{
    public static class PrintUserActivity
    {
        public static async Task PrintActivity(string userName)
        {
            GitGubService gitGubService = new GitGubService();
            List<Dictionary<string, object>>? response = await gitGubService.FetchActivity(userName);

            if (response == null)
            {
                Console.WriteLine("Unable to retrieve activity. (User may not be found.)");
                return;
            }

            foreach (var activity in response)
            {
                try
                {

                    string eventType = activity["type"].ToString();
                    var repoElement = (JsonElement)activity["repo"];
                    string repoName = repoElement.GetProperty("name").GetString();

                    switch (eventType)
                    {
                        case "PushEvent":
                            var pushPayload = (JsonElement)activity["payload"];
                            int commitCount = pushPayload.GetProperty("size").GetInt32();
                            Console.WriteLine($"- Pushed {commitCount} commits to {repoName}");
                            break;

                        case "IssuesEvent":
                            var issuePayload = (JsonElement)activity["payload"];
                            string issueAction = issuePayload.GetProperty("action").GetString();
                            Console.WriteLine($"- {issueAction} an issue in {repoName}");
                            break;

                        case "WatchEvent":
                            var watchPayload = (JsonElement)activity["payload"];
                            string watchAction = watchPayload.GetProperty("action").GetString();
                            if (watchAction == "started")
                            {
                                Console.WriteLine($"- Starred {repoName}");
                            }
                            break;

                        case "CreateEvent":
                            var createPayload = (JsonElement)activity["payload"];
                            string refType = createPayload.GetProperty("ref_type").GetString();
                            if (refType == "repository")
                            {
                                Console.WriteLine($"- Created a new repository: {repoName}");
                            }
                            else
                            {
                                Console.WriteLine($"- Created new {refType} in {repoName}");
                            }
                            break;

                        case "PullRequestEvent":
                            var prPayload = (JsonElement)activity["payload"];
                            string prAction = prPayload.GetProperty("action").GetString();
                            Console.WriteLine($"- {prAction} a pull request in {repoName}");
                            break;

                        default:
                            Console.WriteLine($"- {eventType} on {repoName}");
                            break;
                    }
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
