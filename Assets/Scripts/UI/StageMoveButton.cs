using UnityEngine;

/// <summary>
/// プレイヤーの移動を司るボタン
/// </summary>
public class StageMoveButton : Button
{
    [SerializeField] string nextStageID;
    private MysteryManager mysteryManager;
    private GameManager gameManager;

    public override void Start()
    {
        base.Start();
        this.mysteryManager = MysteryManager.GetInstance();
        this.gameManager = GameManager.GetGameManager();
        this.id = "StageMoveButtonTo" + this.nextStageID;
        this.gameObject.SetActive(this.VisibleCheck());
    }

    private bool VisibleCheck()
    {
        bool ret = true;
        if (this.nextStageID.Equals("Test"))
        {
            ret = false;
        }
        return ret;
    }

    public override void OnClick()
    {
        Place next = (Place)this.mysteryManager.SearchIIdentifiable(this.nextStageID);
        if (next.Equals(null))
        {
            Debug.Log("StageMoveButton：IDが異なっています。");
            return;
        }
        this.mysteryManager.GetPlayer().Move(next);
        this.gameManager.MoveScene(nextStageID);

    }
}