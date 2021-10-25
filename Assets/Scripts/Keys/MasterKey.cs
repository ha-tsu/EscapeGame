using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Keyの実装クラスのサンプル
public class MasterKey : Key
{

    public MasterKey() : base("K99", "master_key", "it can unlock all locks.")
    {

    }

    public override void Use()
    {
        if (this.GetUsed())
        {
            Debug.Log("master is used");
        }
        else
        {
            Debug.Log("master is not used");
        }
        base.Use();
    }
}