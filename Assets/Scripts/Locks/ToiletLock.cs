using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ToiletLock : Lock
{

    public ToiletLock() : base("L03", "toilet_lock", "this is toilet lock")
    {

    }

    public override bool Try()
    {
        bool ret = false;
        Key key = MysteryManager.GetInstance().GetSelectedKey();
        Key gainKey = (Key)MysteryManager.GetInstance().SearchIIdentifiable("K04");
        if (key == null)
        {
            return false;
        }
        if (key.GetID().Equals("K03"))
        {
            ret = true;
            MysteryManager.GetInstance().GetPlayer().GainKey(gainKey);
            Debug.Log(gainKey.GetName() + " picked.");
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
