using StorageSystem.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
    private static Dictionary<string, object> Buff;
    public event Action<string> ReceivingDateStoreKeeper;
    public event Action<string> GoToMainUI;
    public void SendStoreKeeperDate(string receiver, Storekeeper storekeeper)
    {
        Buff.Add(receiver, storekeeper);
        ReceivingDateStoreKeeper?.Invoke(receiver);
    }
        
    public void SendMessage(string receiver, string message)
    {
        Buff.Add(receiver, message);
        GoToMainUI?.Invoke(receiver);
    }
}