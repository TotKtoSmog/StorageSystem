using StorageSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;

public class Mediator
{
    private static Mediator instance;
    private Mediator() { }

    public static Mediator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Mediator();
                Buff = new Dictionary<string, object>();
            }
                
            return instance;
        }
    }
    public static object getDataFromBuff(string key)
    {
        if(!Buff.ContainsKey(key)) return null;
        object data = Buff[key];
        Buff.Remove(key);
        return data;
    }
    public static void addDataInBuff(string key, object o)
    {
        if (Buff.ContainsKey(key))
            Buff.Remove(key);
        Buff.Add(key, o);
    }
    public static bool ContainsValue(string key)
        => Buff.ContainsKey(key);
    private static Dictionary<string, object> Buff;
    public event Action<string> ReceivingDateStoreKeeper;
    public event Action<string> RecevingDataPage;
    public event Action<string> GoToPage;
    public void SendStoreKeeperDate(string receiver, Storekeeper storekeeper)
    {
        Buff.Add(receiver, storekeeper);
        ReceivingDateStoreKeeper?.Invoke(receiver);
    }
    public void SendDataPage(string receiver, object data)
    {
        Buff.Add(receiver, data);
        RecevingDataPage?.Invoke(receiver);
    }    
    public void SendMessage(string receiver, string message)
    {
        Buff.Add(receiver, message);
        GoToPage?.Invoke(receiver);
    }
}