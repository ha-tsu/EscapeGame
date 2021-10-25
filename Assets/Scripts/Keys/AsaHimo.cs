using System.Collections;

public class AsaHimo : Key
{
    public AsaHimo() : base("K02", "Hemp string", "The string is made by hemp.This may be connect to the other hemp strings.")
    {

    }
    public override void Use()
    {
        // プレイヤーの現在地が寝室で爆弾を設置している場合に使用可能。
        // 爆弾の設置でusableに変更する
        // 所持数に応じて
    }
}