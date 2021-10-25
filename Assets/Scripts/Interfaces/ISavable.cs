public interface ISavable // 保存可能であることを示す
{
    void Save(string num);
    void Load(string num);
}