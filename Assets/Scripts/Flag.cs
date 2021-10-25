using System.Collections;
using UnityEngine;

// ルート決定ののフラグ
public abstract class Flag : ISavable, IIdentifiable
{
    private string id; // 識別番号
    private string name; // 名前
    protected bool isChecked; // フラグが立ったかどうか

    // 変更する可能性のあるものはprotected, 不変のものはprivate

    public Flag(string id, string name)
    {
        this.id = id;
        this.name = name;
        this.isChecked = false;
    }

    public string GetID()
    {
        return this.id;
    }

    public string GetName()
    {
        return this.name;
    }

    public bool GetIsChecked()
    {
        return this.isChecked;
    }

    public abstract void Check(); // 実装クラスでチェック条件を設定

    // 保存
    // Key : S00-F00
    // Value : 0,0,0
    // スロット00にid(F00)がfalse であることを保存
    public virtual void Save(string num)
    {
        string tof = "";

        // isChecked の保存内容決定
        if (this.isChecked)
        {
            tof += "1";
        }
        else
        {
            tof += "0";
        }
        tof += ",";

        // save
        PlayerPrefs.SetString("S" + num + "-" + this.id, tof);
    }

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
                            this.isChecked = true;
                        }
                        else
                        {
                            this.isChecked = false;
                        }
                        break;
                }
            }
        }
    }
}