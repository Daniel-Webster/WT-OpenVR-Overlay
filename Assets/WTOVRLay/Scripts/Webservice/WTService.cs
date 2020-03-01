
public abstract class WTService
{
    
    public WTService(string service, int waitTime) {
        this.service = service;
        this.waitTime = waitTime;
    }
    protected const string URL = "http://localhost:8111/";
    protected string service;
    protected int waitTime;
}
