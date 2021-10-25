using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// ゲームの管理者
/// シーンの移動などの全体において共通する動作を司る
/// </summary>
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static GameManager GetGameManager()
    {
        if (!GameObject.FindGameObjectWithTag("GameManager"))
        {
            Debug.Log("GameManagerを生成しました");
            Instantiate((GameObject)Resources.Load("Prefabs/GameManager"));
        }
        return instance;
    }

    public void MoveScene(string name)
    {
        try
        {
            SceneManager.LoadScene(name);
            UIManager.GetInstance().Reset();
        }
        catch
        {
            Debug.Log("Scene : " + name + " doesnt exist");
        }

    }

    /// <summary>
    /// ゲーム開始の処理
    /// </summary>
    public void GameStart()
    {

    }

    /// <summary>
    /// ゲームの終了処理
    /// </summary>
    public void GameFinish()
    {

    }

    /// <summary>
    /// ゲームアプリ自体のの修了処理
    /// </summary>
    public void Quit()
    {
        // nya-n
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
                    UnityEngine.Application.Quit();
#endif
        // 拡張機能にインデント崩される
    }
}
