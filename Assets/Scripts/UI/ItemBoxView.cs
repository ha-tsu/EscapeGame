using UnityEngine;
using System.Collections.Generic;

public class ItemBoxView : MonoBehaviour
{
    private List<Key> itemBox;
    private List<KeyIcon> icons;
    private GameObject box;

    void Awake()
    {
        UIManager.GetInstance().SetItemBoxView(this);
        this.box = this.gameObject.transform.GetChild(0).gameObject;
    }

    void OnEnable()
    {
        this.itemBox = MysteryManager.GetInstance().GetKeyOnPlayer();
        this.icons = new List<KeyIcon>();
        KeyIcon icon = null;
        foreach (Key item in this.itemBox)
        {
            icon = Instantiate<KeyIcon>(Resources.Load<KeyIcon>("Prefabs/KeyIcon"));
            if (icon == null)
            {
                Debug.Log("NULL Icon");
                continue;
            }
            else
            {
                Debug.Log("Icon create " + item.GetID());
            }
            this.icons.Add(icon);
            icon.SetKey(item);
            icon.gameObject.transform.SetParent(this.box.transform);
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < this.icons.Count; i++)
        {
            Destroy(this.icons[i].gameObject);
        }
        this.icons = new List<KeyIcon>();
    }


}