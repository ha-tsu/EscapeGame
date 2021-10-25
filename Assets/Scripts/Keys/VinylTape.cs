using System.Collections;

public class VinylTape : Key
{
    public VinylTape() : base("K05", "vinyl tape", "")
    {

    }

    public override void Use()
    {
        // 選択されたのが玄関の機械だったら電源ケーブルをつないで使用可能にする
    }
}