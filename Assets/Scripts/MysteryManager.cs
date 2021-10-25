using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 脱出ゲーム部分のマネージャー
/// 謎を解く鍵となるアイテムをKey、謎そのものをLockで実装
/// どのような条件を達成したのかをFlagで実装、Routerで管理
/// </summary>
public class MysteryManager
{
    private static MysteryManager mysteryManager; // マネージャー
    private DataSaver saver; // 救世主
    private List<Key> keys; // アイテム（鍵）
    private List<Lock> locks; // 錠
    private Router router; // ルート決定のフラグ
    private Player player; // Player
    private List<Place> places; // 場所

    private MysteryManager()
    {
        this.keys = new List<Key>();
        this.locks = new List<Lock>();
        this.router = new Router();
        this.places = new List<Place>();

        this.CreateKeys();
        this.CreateLocks();
        this.CreateFlags();
        this.CreatePlaces();

        this.player = new Player();
    }

    // インスタンスのゲッター
    public static MysteryManager GetInstance()
    {
        if (mysteryManager == null)
        {
            mysteryManager = new MysteryManager();
        }
        return mysteryManager;
    }

    /// <summary>
    /// ゲームの初期化処理
    /// </summary>
    public void Initialize()
    {
        this.keys = new List<Key>();
        this.locks = new List<Lock>();
        this.router = new Router();
        this.places = new List<Place>();
        this.player.Initialize();
        this.CreateKeys();
        this.CreateLocks();
        this.CreateFlags();
        this.CreatePlaces();
    }

    // Keyの追加処理。同一IDは弾く。
    public void Add(Key target)
    {
        foreach (Key item in this.keys)
        {
            if (item.GetID().Equals(target.GetID()))
            {
                Debug.Log("同一IDのKeyは既に追加されています。" + item.GetID());
                return;
            }
        }
        Debug.Log("Key:" + target.GetID() + "is added.");
        this.keys.Add(target);
    }

    // Lockの追加処理。同一IDは弾く。
    public void Add(Lock target)
    {
        foreach (Lock item in this.locks)
        {
            if (item.GetID().Equals(target.GetID()))
            {
                Debug.Log("同一IDのLockは既に追加されています。" + item.GetID());
                return;
            }
        }
        Debug.Log("Lock:" + target.GetID() + "is added.");
        this.locks.Add(target);
    }

    // Flagの追加処理。Routerを参照。
    public void Add(Flag target)
    {
        this.router.AddFlag(target);
    }

    // 必要なKeyを生成するメソッド
    private void CreateKeys()
    {
        this.Add(new BlankKey());
        this.Add(new MasterKey());
        this.Add(new Driver());
        this.Add(new Dynamite());
        this.Add(new IceBlock());
        this.Add(new KeyInIce());
        this.Add(new MysteryPaper());
        this.Add(new Scisssors());
        this.Add(new ToiletPaper());
        this.Add(new VinylTape());
        // TODO key generate
        return;
    }

    // 必要なLockを生成するメソッド
    private void CreateLocks()
    {
        this.Add(new BlankLock());
        this.Add(new ToiletLock());
        this.Add(new WireLock());
        // TODO lock generate
        return;
    }

    // 必要なFlagを生成するメソッド
    private void CreateFlags()
    {
        // flag generate
        this.Add(new BlankFlag());
        return;
    }

    /// <summary>
    /// 必要なPlaceを生成するメソッド
    /// </summary>
    private void CreatePlaces()
    {
        // create places
        this.places.Add(new Place("P00", ""));
        this.places.Add(new Place("P01", "Entarance"));
        this.places.Add(new Place("P02", "shosai"));
        this.places.Add(new Place("P03", "toilet"));
        this.places.Add(new Place("P04", "bath"));
        this.places.Add(new Place("P05", "bedroom"));
        this.places.Add(new Place("P06", "rouka"));
        this.places.Add(new Place("P07", "kitchen"));
        this.places.Add(new Place("P08", "dining"));
        this.places.Add(new Place("P09", "living"));
        this.places.Add(new Place("P10", "souko"));
    }
    // Saverのゲッター
    public DataSaver GetSaver()
    {
        return this.saver;
    }

    // Routerのゲッター
    public Router GetRouter()
    {
        return this.router;
    }

    // Placeのリスト
    public List<Place> GetPlaces()
    {
        return this.places;
    }

    // 各フィールドのbool変数のtrueのKeyのリストを返すメソッドを書く

    // Key all
    public List<Key> GetKeys()
    {
        return this.keys;
    }

    /// <summary>
    /// プレイヤーの所持状態にあるKeyの一覧を返す
    /// </summary>
    /// <returns></returns>
    public List<Key> GetKeyOnPlayer()
    {
        List<Key> ret = new List<Key>();
        foreach (Key item in this.keys)
        {
            if (item.GetOnPlayer())
            {
                ret.Add(item);
            }
        }
        return ret;
    }

    // 表示可能なKeyのリスト
    public List<Key> GetKeyVisible()
    {
        List<Key> ret = new List<Key>();
        foreach (Key item in this.keys)
        {
            if (item.GetVisible())
            {
                ret.Add(item);
            }
        }
        return ret;
    }

    // 使用可能なKeyのリスト
    public List<Key> GetKeyUsable()
    {
        List<Key> ret = new List<Key>();
        foreach (Key item in this.keys)
        {
            if (item.GetUsable())
            {
                ret.Add(item);
            }
        }
        return ret;
    }

    // 使用済みのKeyのリスト
    public List<Key> GetKeyUsed()
    {
        List<Key> ret = new List<Key>();
        foreach (Key item in this.keys)
        {
            if (item.GetUsed())
            {
                ret.Add(item);
            }
        }
        return ret;
    }

    // 未使用のKeyのリスト
    public List<Key> GetKeyNoUsed()
    {
        List<Key> ret = new List<Key>();
        foreach (Key item in this.keys)
        {
            if (!item.GetUsed())
            {
                ret.Add(item);
            }
        }
        return ret;
    }


    // 各フィールドのbool変数がtrueのLockのリストを返すメソッドを書く

    // lock all
    public List<Lock> GetLocks()
    {
        return this.locks;
    }

    // 表示可能なLockのリスト
    public List<Lock> GetLockVisible()
    {
        List<Lock> ret = new List<Lock>();
        foreach (Lock item in this.locks)
        {
            if (item.GetVisible())
            {
                ret.Add(item);
            }
        }
        return ret;
    }

    // 未解錠なLockのリスト
    public List<Lock> GetLockUnlocked()
    {
        List<Lock> ret = new List<Lock>();
        foreach (Lock item in this.locks)
        {
            if (item.GetUnlocked())
            {
                ret.Add(item);
            }
        }
        return ret;
    }

    // 解錠済みなLockのリスト
    public List<Lock> GetLockLocked()
    {
        List<Lock> ret = new List<Lock>();
        foreach (Lock item in this.locks)
        {
            if (!item.GetUnlocked())
            {
                ret.Add(item);
            }
        }
        return ret;
    }

    // 選択状態にあるKeyの取得
    public Key GetSelectedKey()
    {
        Key ret = null;
        foreach (Key i in this.keys)
        {
            if (i.GetSelected())
            {
                ret = i;
                break;
            }
        }
        return ret;
    }

    // Playerのゲッター
    public Player GetPlayer()
    {
        return this.player;
    }

    /// <summary>
    /// IDで検索可能なものを検索して返すメソッド
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IIdentifiable SearchIIdentifiable(string id)
    {
        IIdentifiable ret = null;

        foreach (IIdentifiable i in this.keys)
        {
            if (id.Equals(i.GetID()))
            {
                ret = i;
                break;
            }
        }

        foreach (IIdentifiable i in this.locks)
        {
            if (id.Equals(i.GetID()))
            {
                ret = i;
                break;
            }
        }

        foreach (IIdentifiable i in this.places)
        {
            if (id.Equals(i.GetID()))
            {
                ret = i;
                break;
            }
        }

        return ret;
    }

    // TODO Routerで決定したルートに従って、シナリオを読み込むメソッドを書く

    // データのセーブ 引数int型に応じたセーブスロットにデータを保存
    public void Save(int i)
    {
        switch (i)
        {
            case 1: this.saver.SaveData("01"); break;
            case 2: this.saver.SaveData("02"); break;
            case 3: this.saver.SaveData("03"); break;
            case 4: this.saver.SaveData("04"); break;
        }
    }

    // データのロード 引数int型に応じたセーブスロットからデータを保存
    public void Load(int i)
    {
        switch (i)
        {
            case 1: this.saver.LoadData("01"); break;
            case 2: this.saver.LoadData("02"); break;
            case 3: this.saver.LoadData("03"); break;
            case 4: this.saver.LoadData("04"); break;
        }
    }
}