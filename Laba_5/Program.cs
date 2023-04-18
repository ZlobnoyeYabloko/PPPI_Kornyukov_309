using System;
using System.Threading.Tasks;
using System.Net.Http;
using Laba_5;
using System.Net;

var client = new ApiClient();

// отримати випадковий жарт
var randomJokeResponse = await client.GetJokes();
if (randomJokeResponse.StatusCode == (int)HttpStatusCode.OK)
{
    Console.WriteLine($"Random joke: {randomJokeResponse.Data[0]}");
}
else
{
    Console.WriteLine($"Error: {randomJokeResponse.Message}");
}

// отримати жарти, що містять слово "computer"
var query = "born";
var searchJokesResponse = await client.SearchJokes(query);
if (searchJokesResponse.StatusCode == (int)HttpStatusCode.OK)
{
    Console.WriteLine($"Jokes about '{query}':");
    foreach (var joke in searchJokesResponse.Data)
    {
        Console.WriteLine(joke);
    }
}
else
{
    Console.WriteLine($"Error: {searchJokesResponse.Message}");
}

Console.ReadLine();