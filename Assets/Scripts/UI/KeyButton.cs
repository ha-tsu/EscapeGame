using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// マップ上の表示に使うボタン
/// クリックで入手
/// </summary>
public class KeyButton : Button
{
    [SerializeField] string targetId;
    Key key;
    public override void Start()
    {
        base.Start();
        if (this.targetId.Equals(""))
        {
            Debug.Log("KeyButton target has not defined");
            return;
        }
        this.key = (Key)MysteryManager.GetInstance().SearchIIdentifiable(targetId);
        this.gameObject.GetComponent<Image>().sprite = this.key.GetImage();
        if (this.key.GetOnPlayer())
        {
            this.gameObject.SetActive(false);
        }
    }

    public override void OnClick()
    {
        // 自身の対応KeyをPlayerに取得させる
        MysteryManager.GetInstance().GetPlayer().GainKey(this.key);
        Debug.Log(this.key.GetName() + " picked.");
        this.gameObject.SetActive(false);
    }
}