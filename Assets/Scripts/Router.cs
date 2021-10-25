using System.Collections.Generic;
using UnityEngine;

// フラグの管理者
public class Router
{
    private List<Flag> flags;

    public Router()
    {
        this.flags = new List<Flag>();
    }

    public void AddFlag(Flag flag)
    {
        if (this.flags == null)
        {
            return;
        }
        foreach (Flag item in this.flags)
        {
            if (item.GetID().Equals(flag.GetID()))
            {
                Debug.Log("同一IDのFlagは既に追加されています。" + item.GetID());
                return;
            }
        }
        this.flags.Add(flag);
        return;
    }

    private List<Flag> CheckFlags()
    { // 全てのチェック済みフラグを返す
        List<Flag> trueFlags = new List<Flag>();
        foreach (Flag flag in this.flags)
        {
            if (flag.GetIsChecked())
            {
                trueFlags.Add(flag);
            }
        }
        return trueFlags;
    }

    public void Check()
    {
        foreach (Flag flag in this.flags)
        {
            flag.Check();
        }
    }

    private Flag SearchFlag(string id)
    {
        Flag ret = null;
        foreach (Flag flag in this.flags)
        {
            if (flag.GetID() == id)
            {
                ret = flag;
                break;
            }
        }
        return ret;
    }

    public string RouteCheck()
    {

        return "00"; // 戻り値を参照してManagerでシナリオを決定
    }

    private void Goal()
    {
        Debug.Log("Goal"); // ゴール時の処理を書く
    }

    // 全てのフラグを保存
    public void Save(string num)
    {
        foreach (Flag item in this.flags)
        {
            item.Save(num);
        }
        return;
    }

    public void Load(string num)
    {
        foreach (Flag f in this.flags)
        {
            f.Load(num);
        }
    }

    public void Load()
    {

    }

}