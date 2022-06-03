
using System.Timers;

public class JobExecutedEventArgs : EventArgs {
    public State LatestState { get; set; }
}


public class PeriodicExecutor : IDisposable
{
    public PeriodicExecutor(StateService stateService)
    {
        this.stateService = stateService;
    }
    public event EventHandler<JobExecutedEventArgs> JobExecuted;
    void OnJobExecuted(State state)
    {
        JobExecuted?.Invoke(this, new JobExecutedEventArgs() { LatestState = state });
    }

    System.Timers.Timer _Timer;
    bool _Running;
    private readonly StateService stateService;

    public void StartExecuting()
    {
        if (!_Running)
        {
            // Initiate a Timer
            _Timer = new System.Timers.Timer();
            _Timer.Interval = 1000;  // every 5 mins
            _Timer.Elapsed += HandleTimer;
            _Timer.AutoReset = true;
            _Timer.Enabled = true;

            _Running = true;
        }
    }
    async void HandleTimer(object source, ElapsedEventArgs e)
    {
        // Execute required job
        var state = await stateService.GetLatest();

        // Notify any subscribers to the event
        OnJobExecuted(state);
    }
    public void Dispose()
    {
        if (_Running)
        {
            // Clear up the timer
        }
    }
}
