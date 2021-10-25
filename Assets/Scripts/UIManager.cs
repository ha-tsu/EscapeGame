using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UIを管理するためのクラス
/// あらゆるUIに関するMonoBehaviourを継承するクラスは直接的か間接的にこのクラスからアクセスできるようにする。
/// 具体的にはこのクラスにゲッターとセッターを用意する。対象のクラスのvoid Start()内でこのセッターで登録する。
///  </summary>
public class UIManager
{
    private static UIManager instance;

    private MessageWindow messageWindow;
    private MessageLogWindow messageLogWindow;
    private ItemBoxView itemBoxView;
    private List<Button> buttons;
    private SelectedKeyView selecetdKeyView;


    private UIManager()
    {
        this.buttons = new List<Button>();
    }

    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            instance = new UIManager();
        }
        return instance;
    }

    public void Reset()
    {
        this.buttons = new List<Button>();
        this.messageLogWindow = null;
        this.messageWindow = null;
        this.itemBoxView = null;
        this.selecetdKeyView = null;
    }
    public void SetMessageWindow(MessageWindow m)
    {
        this.messageWindow = m;
        return;
    }

    public MessageWindow GetMessageWindow()
    {
        return this.messageWindow;
    }

    public void SetMessageLogWindow(MessageLogWindow m)
    {
        this.messageLogWindow = m;
        return;
    }

    public MessageLogWindow GetMessageLogWindow()
    {
        return this.messageLogWindow;
    }

    public void SetItemBoxView(ItemBoxView i)
    {
        this.itemBoxView = i;
    }
    public ItemBoxView GetItemBoxView()
    {
        return this.itemBoxView;
    }

    public void SetSelectedKeyView(SelectedKeyView v)
    {
        this.selecetdKeyView = v;
    }

    public SelectedKeyView GetSelectedKeyView()
    {
        return this.selecetdKeyView;
    }
    public void AddMessage(string msg)
    {
        this.messageWindow.AddMessage(msg);
        return;
    }

    public void AddButton(Button b)
    {
        this.buttons.Add(b);
    }

    public List<Button> GetButtons()
    {
        return this.buttons;
    }

    public Button SearchButton(string id)
    {
        Button ret = null;
        foreach (Button identifiable in this.buttons)
        {
            if (identifiable.GetID().Equals(id))
            {
                ret = identifiable;
                break;
            }
        }
        return ret;
    }
}