public interface INotificationChannel
{
    void send(string message);
}

public class EmailChannel : INotificationChannel
{
    public void send(string message)
    {
        Console.WriteLine("Email: " + message);
    }
}

public class SmsChannel : INotificationChannel
{
    public void send(string message)
    {
        Console.WriteLine("SMS: " + message);
    }
}

public class PushNotificationChannel : INotificationChannel
{
    public void send(string message)
    {
        Console.WriteLine("Push Notification: " + message);
    }
}

public class NotificationService
{
    //private List<string channelName, INotificationChannel channel> channel = new List<string, INotificationChannel>();
    private Dictionary<string, INotificationChannel> _channels = new Dictionary<string, INotificationChannel>();
    public void AddChannel(string channelName, INotificationChannel channel)
    {
        _channels[channelName] = channel;
    }

    public void Notify(string channelName, string message)
    {
        if (_channels.ContainsKey(channelName))
        {
            _channels[channelName].send(message);
        }
        else
        {
            Console.WriteLine($"`{channelName}` channel not found");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var notificationService = new NotificationService();
        notificationService.AddChannel("Email", new EmailChannel());
        notificationService.AddChannel("SMS", new SmsChannel());
        notificationService.AddChannel("Push Notification", new PushNotificationChannel());

        notificationService.Notify("Email", "Hello Email");
        notificationService.Notify("SMS", "Hello SMS");
        notificationService.Notify("Push Notification", "Hello Push Notification");
    }
}