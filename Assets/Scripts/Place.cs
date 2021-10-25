using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// マップ上の場所を司るクラス
/// </summary>
public class Place : IIdentifiable, ISavable
{
    private string id;
    private string name;
    private bool visible;
    private bool onPlayer;


    public Place(string id, string name)
    {
        this.id = id;
        this.name = name;

    }

    public string GetID()
    {
        return this.id;
    }

    public string GetName()
    {
        return this.name;
    }

    public bool GetOnPlayer()
    {
        return this.onPlayer;
    }

    public void SetOnPlayer(bool b)
    {
        this.onPlayer = b;
        return;
    }

    public void Save(string num)
    {

    }

    public void Load(string num)
    {

    }
}