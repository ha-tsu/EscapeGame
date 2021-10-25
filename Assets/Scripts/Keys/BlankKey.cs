using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Keyの実装クラスのサンプル
public class BlankKey : Key
{

    public BlankKey() : base("K00", "blank_key", "this is sample key")
    {

    }

    public override void Use()
    {
        if (this.GetUsed())
        {
            Debug.Log("blank is used");
        }
        else
        {
            Debug.Log("blank is not used");
        }
        base.Use();
    }
}