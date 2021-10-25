using UnityEngine;

// Keyの実装クラスのサンプル
public class IceBlock : Key
{

    public IceBlock() : base("K06", "ice box", "")
    {

    }

    public override void Use()
    {
        // 溶けると冷凍鍵を入手する
        base.Use();
    }
}