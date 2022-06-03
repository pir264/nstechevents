using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

public class StateService
{
    private readonly HttpClient httpClient;

    //public State LatestState { get; private set; }
    public StateService(HttpClient httpClient)
    {
        this.httpClient = httpClient;

    }
    public async Task<State> GetLatest()
    {
        var githubFile =  await httpClient.GetFromJsonAsync<GithubFile>("https://api.github.com/repos/nederlandsespoorwegen/nstechevents/contents/techtalks.json?ref=data");
        var content = Convert.FromBase64String(githubFile.Content);
        var state = JsonSerializer.Deserialize<State>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        return state;   
    }
    

}
