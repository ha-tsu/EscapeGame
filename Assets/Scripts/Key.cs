using System.Collections;
using UnityEngine;

///<summary>
///  謎を解く鍵 保存可能、選択可能
/// アイテムボックスの中に入る
/// </summary>
public abstract class Key : ISavable, ISelectable, IIdentifiable
{
    private string id; // 識別番号
    private string name; // 表示名
    private string info; // 表示情報
    private Sprite imageSprite; // マップ画面での表示画像
    private Sprite iconSprite; // アイテムボックス内でのアイコン画像
    protected bool onPlayer; // プレイヤーの所持状態にあるかどうか
    protected bool movable;　// プレイヤーが移動させられるか、アイテムボックスに入れられるか
    protected bool visible; // 表示可能か
    protected bool usable; // 使用可能か
    protected bool used; // 使用済みか
    protected bool selected; // 選択しているかどうか。
    private bool burned; // 燃えたかどうか

    // 変更する可能性のあるものはprotected, 不変のものはprivateに設定

    public Key(string id, string name, string info)
    {
        this.id = id;
        this.name = name;
        this.info = info;
        this.imageSprite = Resources.Load<Sprite>("Sprites/Image/" + id);
        this.iconSprite = Resources.Load<Sprite>("Sprites/Icon/" + id);
        this.onPlayer = false;
        this.movable = true;
        this.visible = false;
        this.usable = false;
        this.used = false;
        this.selected = false;


    }

    public string GetID()
    {
        return this.id;
    }

    public string GetName()
    {
        return this.name;
    }

    public string GetInfo()
    {
        return this.info;
    }

    public Sprite GetImage()
    {
        return this.imageSprite;
    }

    public Sprite GetIcon()
    {
        return this.iconSprite;
    }

    public bool GetOnPlayer()
    {
        return this.onPlayer;
    }

    public bool GetVisible()
    {
        return this.visible;
    }

    public bool GetUsable()
    {
        return this.usable;
    }

    public bool GetUsed()
    {
        return this.used;
    }

    public bool GetSelected()
    {
        return this.selected;
    }

    public bool GetMovable()
    {
        return this.movable;
    }


    public void SetOnPlayer(bool b)
    {
        this.onPlayer = b;
        return;
    }
    public void SetVisible(bool b)
    {
        this.visible = b;
        Debug.Log("visible set" + !this.visible + "to" + this.visible);
        return;
    }

    public void SetUsable(bool b)
    {
        this.usable = b;
        Debug.Log("usable set" + !this.usable + "to" + this.usable);
        return;
    }
    public void SetSelected(bool b)
    {
        this.selected = b;
        Debug.Log("selected set" + !this.selected + "to" + this.selected);
        if (this.selected)
        {
            this.Selected();
        }
        return;
    }

    public void SetUsed(bool b)
    {
        this.used = b;
        Debug.Log("used set" + !this.used + "to" + this.used);
        return;
    }

    /// <summary>
    /// 燃える処理
    /// </summary>
    public void Burn()
    {
        this.burned = true;
        // TODO 画像を燃えた後に差し替える処理
    }


    /// <summary>
    /// アイテムの使用。
    /// Usedをtrueにする。
    /// 一度切りの使用のものなどはこれを上書きして使用不可にする
    /// </summary>
    public virtual void Use()
    {
        if (!this.usable)
        {
            Debug.Log("Key:" + this.id + " is not usable");
            return;
        }
        this.used = true;
        return;
    }

    // 保存
    // Key : S00-K00
    // Value : 0,0,0
    // スロット00にid(K00)がfalse, false, falseであることを保存
    public virtual void Save(string num)
    {
        string tof = "";

        if (this.onPlayer)
        {
            tof += "1";
        }
        else
        {
            tof += "0";
        }

        // visibleの保存内容決定
        if (this.visible)
        {
            tof += "1";
        }
        else
        {
            tof += "0";
        }
        tof += ",";

        // usableの保存内容決定
        if (this.usable)
        {
            tof += "1";
        }
        else
        {
            tof += "0";
        }
        tof += ",";

        // usedの保存内容決定
        if (this.used)
        {
            tof += "1";
        }
        else
        {
            tof += "0";
        }

        // save
        PlayerPrefs.SetString("S" + num + "-" + this.id, tof);

        return;
    }

    /// <summary>
    /// ロード
    /// </summary>
    /// <param name="num"></param>
    public virtual void Load(string num)
    {
        // 読み込むべきセーブデータがあるとき
        // load
        if (PlayerPrefs.HasKey("S" + num + "-" + this.id))
        {
            string[] tof = PlayerPrefs.GetString("S" + num + "-" + this.id).Split(',');
            for (int i = 0; i < tof.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        if (tof[i].Equals("1"))
                        {
                            this.onPlayer = true;
                        }
                        break;
                    case 1:
                        if (tof[i].Equals("1"))
                        {
                            this.visible = true;
                        }
                        break;
                    case 2:
                        if (tof[i].Equals("1"))
                        {
                            this.usable = true;
                        }
                        break;
                    case 3:
                        if (tof[i].Equals("1"))
                        {
                            this.used = true;
                        }
                        break;
                }
            }
        }

    }

    /// <summary>
    /// 選択されたときに呼び出すメソッド
    /// なにか処理が必要なものはここを上書きする
    /// </summary>
    public virtual void Selected()
    {
        Debug.Log(this.name + "が選択されました。");
        return;
    }


}