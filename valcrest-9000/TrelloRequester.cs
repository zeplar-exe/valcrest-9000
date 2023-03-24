using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Valcrest9000;

public class TrelloRequester
{
    private static Uri TrelloApiUrl { get; } = new("https://api.trello.com", UriKind.Absolute);
    public static HttpClient Client { get; } = new(new HttpClientHandler
    {
        AutomaticDecompression = DecompressionMethods.GZip
    });

    public async Task<HttpResponseMessage> RequestCardAsync(string id, params string[] fields)
    {
        var fieldsList = fields.ToList();
        
        fieldsList.Add($"key={Environment.GetEnvironmentVariable("TRELLO_API_KEY")}");
        fieldsList.Add($"token={Environment.GetEnvironmentVariable("TRELLO_API_TOKEN")}");
        
        var response = await Client.GetAsync($"{TrelloApiUrl}1/cards/{id}?{string.Join('&', fieldsList)}");

        return response;
    }

    public async Task<StreamReader?> RequestCardStreamAsync(string id, params string[] fields)
    {
        var result = await RequestCardAsync(id, fields);

        if (!result.IsSuccessStatusCode)
            return null;
        
        return new StreamReader(await result.Content.ReadAsStreamAsync());
    }
    
    public async Task<JObject?> RequestCardJsonAsync(string id, params string[] fields)
    {
        var reader = await RequestCardStreamAsync(id, fields);

        if (reader == null)
            return null;
        
        var json = await JObject.LoadAsync(new JsonTextReader(reader));

        return json;
    }
    
    public async Task<string?> RequestCardDescriptionAsync(string id)
    {
        var json = await RequestCardJsonAsync(id, "fields=desc");

        if (json == null)
            return null;

        return json["desc"]?.ToString();
    }
}