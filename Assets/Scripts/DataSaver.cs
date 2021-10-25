using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// データの救世主。保存と読み込みを司る。
public class DataSaver
{
    private string selectedFolder; // セーブスロット名
    private static DataSaver instance;
    private MysteryManager manager;

    private DataSaver(MysteryManager manager)
    {
        this.manager = manager;

    }

    public static DataSaver GetInstance(MysteryManager manager)
    {
        if (instance == null)
        {
            instance = new DataSaver(manager);
        }
        return instance;
    }

    public string CheckSavedDatas()
    {
        string ret = "none";

        return ret;
    }

    public void ClearData(string num)
    {
        if (PlayerPrefs.HasKey("S" + num))
        {
            PlayerPrefs.DeleteKey("S" + num);
        }
    }

    // データの保存、引数でスロットを指定
    public void SaveData(string num)
    {
        PlayerPrefs.SetString("S" + num, "Active");
        // numを参照して全部を保存する処理
        foreach (ISavable item in manager.GetKeys())
        {
            item.Save(num);
        }

        foreach (ISavable item in manager.GetLocks())
        {
            item.Save(num);
        }

        foreach (ISavable item in manager.GetPlaces())
        {
            item.Save(num);
        }

        this.manager.GetRouter().Save(num);
    }

    public void LoadData(string num)
    {
        if (!PlayerPrefs.HasKey("S" + num))
        {
            Debug.Log("保存されていません");
            return;
        }

        foreach (ISavable item in manager.GetKeys())
        {
            item.Load(num);
        }

        foreach (ISavable item in manager.GetLocks())
        {
            item.Load(num);
        }

        foreach (ISavable item in manager.GetPlaces())
        {
            item.Load(num);
        }

        this.manager.GetRouter().Load(num);
    }

    // セーブスロットのゲッター
    public string GetSlot()
    {
        return this.selectedFolder;
    }
}