using System;

public class Mediator
{
    private static Mediator instance;
    private Mediator() { }

    public static Mediator Instance
    {
        get
        {
            if (instance == null)
                instance = new Mediator();
            return instance;
        }
    }

    public event Action<string, string> GoToMainUI;

    public void SendMessage(string receiver, string message)
        => GoToMainUI?.Invoke(receiver, message);
}