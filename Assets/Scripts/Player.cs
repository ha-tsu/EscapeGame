using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player : ISavable
{
    private string name; // 名前
    private const string firstname = "ZVSample04"; // デフォルトネーム(未定)
    private int turn; // 経過時間
    private Place currentPlace; // 現在地
    private Key selectKey; // 手に持ったアイテム

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Player()
    {
        this.name = firstname;
        this.turn = 0;
    }

    /// <summary>
    /// 名前のゲッター
    /// </summary>
    /// <returns>名前</returns>
    public string GetName()
    {
        return this.name;
    }

    /// <summary>
    /// 経過時間のゲッター
    /// </summary>
    /// <returns>経過時間</returns>
    public int GetTurn()
    {
        return this.turn;
    }

    /// <summary>
    /// 現在地のゲッター
    /// </summary>
    /// <returns>現在地</returns>
    public Place GetPlace()
    {
        return this.currentPlace;
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public void Initialize()
    {
        this.currentPlace = (Place)MysteryManager.GetInstance().SearchIIdentifiable("P00");
        this.turn = 0;
    }

    /// <summary>
    /// 場所の移動
    /// </summary>
    /// <param name="nextPlace"></param>
    public void Move(Place nextPlace)
    {
        if (currentPlace == null)
        {
            this.currentPlace = (Place)MysteryManager.GetInstance().SearchIIdentifiable("P00");
        }
        Debug.Log("player move " + this.currentPlace.GetName() + " to " + nextPlace.GetName());
        currentPlace.SetOnPlayer(false);
        nextPlace.SetOnPlayer(true);
        this.currentPlace = nextPlace;
    }

    public void Save(string num)
    {
        string save = "";
        // save内容の決定
        PlayerPrefs.SetString("S" + num + "-P", save);
    }

    public void Load(string num)
    {
        if (PlayerPrefs.HasKey("S" + num + "-P"))
        {
            string[] tof = PlayerPrefs.GetString("S" + num + "-P").Split(',');
            for (int i = 0; i < tof.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        if (tof[0].Equals("1"))
                        {

                        }
                        else
                        {

                        }
                        break;
                }
            }
        }
    }

    public void GainKey(Key key)
    {
        if (key.GetMovable())
        {
            key.SetOnPlayer(true);
        }
        MysteryManager.GetInstance().GetRouter().Check();
    }

    public void SetKey(Key key)
    {
        if (this.selectKey != null)
        {
            this.selectKey.SetSelected(false);
        }
        key.SetSelected(true);
        this.selectKey = key;
        UIManager.GetInstance().GetSelectedKeyView().UpdateView();
    }
}