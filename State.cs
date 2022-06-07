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
            return DateTimeOffset.UtcNow >= Start && DateTimeOffset.UtcNow <= End;
        }
    }

    public bool IsComingUp
    {
        get
        {
            return DateTimeOffset.UtcNow <= Start;
        }
    }
    public bool IsJustPassed
    {
        get
        {
            return DateTimeOffset.UtcNow >= End && DateTimeOffset.UtcNow.Date == End.Date;
        }
    }
}