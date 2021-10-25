public interface ISelectable // 選択可能であることを示す
{
    void SetSelected(bool b);
    bool GetSelected();
    void Selected();
}