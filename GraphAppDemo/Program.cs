using Microsoft.Graph;
using Azure.Identity;

var client = new DefaultAzureCredential();

var graphClient = new GraphServiceClient(client);

try
{
    var usersPage = await graphClient.Users.GetAsync(reqConfig =>
    {
        reqConfig.QueryParameters.Orderby = new string []{ "DisplayName" };
        reqConfig.QueryParameters.Top = 250;
    });

    if (usersPage?.Value == null)
    {
        Console.WriteLine("Returned null :(");
        return;
    }

    Console.WriteLine($"Total user count: {usersPage.Value.Count}\n");

    Console.WriteLine("ID | DisplayName | JobTitle | Created");

    foreach (var user in usersPage.Value)
    {
        Console.WriteLine($"{user.Id} - {user.DisplayName} - {user.JobTitle} - {user.CreatedDateTime}");
    }

    Console.WriteLine("Executed successfully :)");
}
catch (Exception ex)
{
    Console.WriteLine($"Error occured. {ex.Message}");
}





