using System.Net.Http.Json;


public class StateService
{
    private readonly HttpClient httpClient;

    //public State LatestState { get; private set; }
    public StateService(HttpClient httpClient)
    {
        this.httpClient = httpClient;

    }
    public async Task<State> GetLatest() => await httpClient.GetFromJsonAsync<State>("config.json");
    

}
