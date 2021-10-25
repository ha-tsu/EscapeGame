using System.Collections;

public class Scisssors : Key
{
    public Scisssors() : base("K01", "Scissours", "We can cut papers, and iron once.")
    {

    }

    public override void Selected()
    {
        // 切る対象の選択ウィンドウを表示
    }

    public override void Use()
    {
        // 選択されたものを切る作業
        // Placeで選択可能なものを置いておき、選択されるものによって
        // 選択されたものが本だった場合、麻紐を入手。
        // ワイヤーだった場合、使用不可能に
        ISelectable selectedItem = MysteryManager.GetInstance().GetSelectedKey();
    }
}