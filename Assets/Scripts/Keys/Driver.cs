using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Driver : Key
{
    public Driver() : base("K03", "Driver", "This is a simple ScrewDriver")
    {

    }


    public override void Use()
    {
        if (this.GetUsed())
        {
            Debug.Log("driver is used");
        }
        else
        {
            Debug.Log("driver is not used");
        }
        base.Use();
        // 選択されたLockが「ネジ止めされた箱」だった場合、「ハサミ」を入手
        // 「トイレットペーパー」だった場合、「トイレットペーパー」を入手
    }


}