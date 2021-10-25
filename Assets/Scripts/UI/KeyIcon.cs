using UnityEngine;
using UnityEngine.UI;

public class KeyIcon : MonoBehaviour
{
    private Key key;
    private Sprite icon;


    void Start()
    {
        this.icon = this.gameObject.GetComponent<Image>().sprite;
        Debug.Log(this.icon.name);
    }

    public void SetKey(Key key)
    {
        Debug.Log("key set");
        this.key = key;
        this.gameObject.GetComponent<Image>().sprite = key.GetIcon();
    }

    public void OnClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            this.OnLeftClick();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            this.OnRightClick();
        }
        else
        {
            Debug.Log("真ん中！");
        }
    }

    public void OnRightClick()
    {
        // 説明ウィンドウを表示
        Debug.Log(this.key.GetName() + "右！");
    }

    public void OnLeftClick()
    {
        // アイテムを手に持たせる(selectedにする)
        Debug.Log(this.key.GetName() + "左！");
        MysteryManager.GetInstance().GetPlayer().SetKey(this.key);
    }
}