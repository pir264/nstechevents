using System.Text.Json.Serialization;

public class TechEvent {
    public string FeaturedVideo { get; set; }
    public string ChannelUrl { get; set; }
}

public class LiveEvent: TechEvent
{
    public LiveSession Live { get; set; } = new();
}


public class State
{

    public string FeaturedVideo { get; set; }
    public LiveEvent TechTalks { get; set; } = new();
    public TechEvent TechBits { get; set; } = new();
    public TechEvent TechDays { get; set; } = new();
}

public class LiveSession
{
    public bool Active { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Link { get; set; }


    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }

    public bool IsLive
    {
        get
        {
            return DateTimeOffset.UtcNow.AddMinutes(5) >= Start && DateTimeOffset.UtcNow <= End;
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