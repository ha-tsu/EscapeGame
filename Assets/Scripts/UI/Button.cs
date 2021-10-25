using UnityEngine;

public abstract class Button : MonoBehaviour, IIdentifiable
{
    MysteryManager mm;
    protected string id;

    public virtual void Start()
    {
        this.mm = MysteryManager.GetInstance();
        this.id = gameObject.name;
        UIManager.GetInstance().AddButton(this);
    }

    public abstract void OnClick();

    public void SetName(string name)
    {
        this.id = name;
    }

    public string GetID()
    {
        return this.id;
    }

}