using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    private MessageLogWindow logWindow;
    private List<string> messages;
    private Text textBox;
    void Start()
    {
        UIManager.GetInstance().SetMessageWindow(this);
        this.textBox = this.gameObject.GetComponent<Text>();
    }


    public void AddMessage(string msg)
    {
        // テキストウィンドウに表示するテキストの追加
        this.messages.Add(msg);
    }

    public void SendMessage()
    {
        // テキストウィンドウに表示するテキストを進めて、古いものをMessageLogWindowに追加
        this.textBox.text = this.messages[0];
        this.logWindow.AddLogs(this.messages[0]);
        this.messages.RemoveAt(0);
    }
}