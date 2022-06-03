using System.Text.Json.Serialization;

public class State
{
    public LiveSession Live { get; set; } = new();
}

public class LiveSession
{
    public string Title { get; set; }
    public string Link { get; set; }


    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }

    public bool IsLive
    {
        get
        {
            var a = DateTimeOffset.UtcNow;
            return DateTimeOffset.UtcNow >= Start && DateTimeOffset.UtcNow <= End;
        }
    }
}