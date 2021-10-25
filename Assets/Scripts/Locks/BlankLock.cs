using UnityEngine;

// Lockの実装クラスのサンプル
public class BlankLock : Lock
{
    public BlankLock() : base("L00", "blank_lock", "this is sample lock")
    {

    }

    public override bool Try()
    {
        bool ret = false;
        Key key = MysteryManager.GetInstance().GetSelectedKey();
        if (key == null)
        {
            return false;
        }
        if (key.GetID().Equals("K99"))
        {
            ret = true;
            Debug.Log("Open");
        }
        return ret;
    }

    public override void Opened()
    {
        UIManager.GetInstance().SearchButton("StageMoveButtonToTest").gameObject.SetActive(true);
    }
}