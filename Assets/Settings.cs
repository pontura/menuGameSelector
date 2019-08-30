using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Settings : MonoBehaviour
{
    public GamesData data;
    public int gameItemWidth = 400;
    public int gameItemSeparation = 10;

    [Serializable]
    public class GamesData
    {
        public GameData[] games;
    }
    void Start()
    {
        StartCoroutine(Load());
    }
    private IEnumerator Load()
    {
        string songName = "C:/videogames/settings.json";
        string url = string.Format("file://{0}", songName);
        print(url);
        WWW www = new WWW(url);
        yield return www;
        data = JsonUtility.FromJson<GamesData>(www.text) as GamesData;
        int id = 0;
        foreach (GameData gameData in data.games)
        {
            gameData.id = id;
            id++;
        }
        GetComponent<MainScreen>().Init();
    }
}
