using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// 謎にあたる錠
// マップ上に固定で表示
// 保存可能、識別可能
public abstract class Lock : ISavable, IIdentifiable
{
    private string id; // 識別番号
    private string name; // 表示名
    private string info; // 表示情報
    private Sprite imageSprite; // 表示画像
    private Sprite iconSprite; // アイコン画像
    protected bool visible; // 表示可能か否か
    protected bool unlocked; // 解錠済みか否か

    // 変更する可能性のあるものはprotected, 不変のものはprivate

    public Lock(string id, string name, string info)
    {
        this.id = id;
        this.name = name;
        this.info = info;
        this.imageSprite = Resources.Load<Sprite>("Sprites/Image/" + id);
        this.iconSprite = Resources.Load<Sprite>("Sprites/Icon/" + id);
        this.visible = false;
        this.unlocked = false;
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

    public bool GetVisible()
    {
        return this.visible;
    }

    public bool GetUnlocked()
    {
        return this.unlocked;
    }

    public void SetVisible(bool b)
    {
        this.visible = b;
        return;
    }

    /// <summary>
    /// 状況から解錠することができるかどうかの判定
    /// </summary>
    /// <returns>　解錠できるかどうか　</returns>
    public abstract bool Try();
    /// <summary>
    /// 解錠されたときに呼び出す処理
    /// </summary>
    public abstract void Opened();

    // 解錠する際に呼び出すメソッド
    // 暗号の入力などが必要なものは子クラスのフィールドに解錠条件を判定する変数を用意しといてTryで判別可能にして暗号入力の最後にこれを呼び出す
    public void Unlock()
    {
        if (this.unlocked)
        {
            Debug.Log("Lock : " + this.id + " has been unlocked");
            return;
        }
        if (this.Try())
        {
            this.unlocked = true;
            Debug.Log("Lock : " + this.id + " is unlocked");
        }
        else
        {
            Debug.Log("Failed to unlock Lock : " + this.id);
            return;
        }
        this.Opened();
        return;
    }

    // 保存
    // Key : S00-L00
    // Value : 0,0,0
    // スロット00にid(L00)がfalse, false であることを保存
    public virtual void Save(string num)
    {
        string tof = "";

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

        // unlockedの保存内容決定
        if (this.unlocked)
        {
            tof += "1";
        }
        else
        {
            tof += "0";
        }

        // save
        PlayerPrefs.SetString("S" + num + "-" + this.id, tof);
    }

    // ロード
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
                        if (tof[0].Equals("1"))
                        {
                            this.visible = true;
                        }
                        break;
                    case 1:
                        if (tof[1].Equals("1"))
                        {
                            this.unlocked = true;
                        }
                        break;
                }
            }
        }
    }

}