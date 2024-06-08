using Microsoft.Graph;
using Azure.Identity;
using Microsoft.Graph.Models;

var client = new DefaultAzureCredential();

var graphClient = new GraphServiceClient(client);

// Get users
try
{
    var usersResponse = await graphClient.Users.GetAsync(reqConfig =>
    {
        // reqConfig.QueryParameters.Orderby = new string []{ "DisplayName" };
        // reqConfig.QueryParameters.Filter = "displayName eq 'test'";
        reqConfig.QueryParameters.Top = 999;
    });

    if (usersResponse?.Value == null)
    {
        Console.WriteLine("Returned null :(");
        return;
    }

    Console.WriteLine($"Total user count: {usersResponse.Value.Count}\n");

    Console.WriteLine("ID | DisplayName | JobTitle | Created | UserPrincipalName");

    foreach (var user in usersResponse.Value)
    {
        Console.WriteLine($"{user.Id} - {user.DisplayName} - {user.JobTitle} - {user.CreatedDateTime} - {user.UserPrincipalName}");
    }

    Console.WriteLine("Executed successfully :)");
}
catch (Exception ex)
{
    Console.WriteLine($"Error occured. {ex.Message}");
}

// create a user

/*var newUser = new User
{
    GivenName = "test user",
    DisplayName = "Test User",
};*/






