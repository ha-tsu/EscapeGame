using System.Collections;
using UnityEngine;

// Flagの実装クラスのサンプル
public class BlankFlag : Flag
{

    public BlankFlag() : base("f00", "blank flag")
    { // : base() は親コンストラクタの呼び出し
    }

    public override void Check()
    {

    }
}
