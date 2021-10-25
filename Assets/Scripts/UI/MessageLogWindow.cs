using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageLogWindow : MonoBehaviour
{
    private List<string> logs;
    [SerializeField] Text window;

    void Start()
    {
        UIManager.GetInstance().SetMessageLogWindow(this);
        this.logs = new List<string>();
    }

    public void AddLogs(string log)
    {
        this.logs.Add(log);
        this.window.text += "\n" + log;
    }

}