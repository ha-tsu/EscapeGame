using UnityEngine;
using UnityEngine.UI;

public class SelectedKeyView : MonoBehaviour
{

    void Start()
    {
        UIManager.GetInstance().SetSelectedKeyView(this);
        this.UpdateView();
    }

    public void UpdateView()
    {
        if (MysteryManager.GetInstance().GetSelectedKey() == null)
        {
            return;
        }
        this.gameObject.GetComponent<Image>().sprite = MysteryManager.GetInstance().GetSelectedKey().GetIcon();
    }
}