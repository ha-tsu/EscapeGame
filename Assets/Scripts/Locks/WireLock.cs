using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireLock : Lock
{
   public WireLock() : base("L05", "wire_lock", "this is wire lock")
    {

    }

    public override bool Try()
    {
        bool ret = false;
        Key key = MysteryManager.GetInstance().GetSelectedKey();
        //Key gainKey = (Key)MysteryManager.GetInstance().SearchIIdentifiable("K04");
        if (key == null)
        {
            return false;
        }
        if (key.GetID().Equals("K01"))
        {
            ret = true;
            // MysteryManager.GetInstance().GetPlayer().GainKey(gainKey);
            // Debug.Log(gainKey.GetName() + " picked.");
            Debug.Log("Open");
        }
        return ret;
    }

    public override void Opened()
    {
        //倉庫に移動したいけどなんかTestしかだめっぽいコード書かれててわからん
        UIManager.GetInstance().SearchButton("StageMoveButtonToP10").gameObject.SetActive(true);
        Debug.Log("移動");
    }
}
