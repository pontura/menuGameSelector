﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainScreen : MonoBehaviour
{
    public List<GameItem> gameItems;
    public GameItem gameItem_to_instantiate;
    public Transform container;
    public int gameID = 0;    
    int totalSlots = 3;
    Settings.GamesData gamesData;
    Vector3 offset = new Vector2(400, 300);
    bool isLoadingGame;

    public void Init()
    {
        Events.Next += Next;
        Events.Prev += Prev;
        Events.RunGame += RunGame;

        //ExecuteProgramm("C:/videogames/reset.bat");
      //  ExecuteProgramm("C:/videogames/mainMenu/joyToKey/JoyToKeys.exe");

        Load();
        SetGame();
    }
    private void Reset()
    {
        //Events.Next -= Next;
        //Events.Prev -= Prev;
        //Events.RunGame -= RunGame;
    }
    private void Load()
    {
        int id = 0;
        gamesData = Data.Instance.settings.data;
        foreach (GameData data in gamesData.games)
        {
            LoadGame(data, id);
            id++;
        }
    }
    void SetGame()
    {
        gameItems[gameID].SetState(true);
        int _x = Get_X(gameID)*-1;
        print("SetGame " + gameID + " _x: " + _x);
        _x += (int)(offset.x);
        container.DOMove(new Vector2(_x, offset.y), 0.25f).SetEase(Ease.InCubic);
    }
    int GetNextGame(int qty)
    {
        int id = gameID + qty;
        if (id < 0)
            id = Data.Instance.settings.data.games.Length-1;
        else if (id > Data.Instance.settings.data.games.Length-1)
            id = 0;
        return id;
    }
    void LoadGame(GameData data, int id)
    {       
        GameItem newGameItem = Instantiate(gameItem_to_instantiate) as GameItem;
        newGameItem.transform.SetParent(container);
        int _x = Get_X(id);
        newGameItem.transform.localPosition = new Vector3(_x, 0, 0);
        newGameItem.Init(data);
        gameItems.Add(newGameItem);
    }
    int Get_X(int id)
    {
        return (id * (Data.Instance.settings.gameItemWidth + Data.Instance.settings.gameItemSeparation));
    }
    void Prev()
    {
        if (isLoadingGame)
            return;
        ResetItem();
        gameID++;
        if (gameID > Data.Instance.settings.data.games.Length-1)
            gameID = 0;
        SetGame();
    }
    void Next()
    {
        if (isLoadingGame)
            return;
        ResetItem();
        gameID--;
        if (gameID < 0)
            gameID = Data.Instance.settings.data.games.Length-1;
        SetGame();
    }
    void ResetItem()
    {
        gameItems[gameID].SetState(false);
    }
    void RunGame()
    {
        if (isLoadingGame)
            return;
        Reset();
        if (Data.Instance.loaderMask.state == LoaderMask.states.LOADING)
            return;
        Data.Instance.loaderMask.Init();
        StartCoroutine(LoadNewGame());
    }
    IEnumerator LoadNewGame()
    {
        isLoadingGame = true;
       // ExecuteProgramm("C:/videogames/mainMenu/OpenNewGame.bat");
        // ExecuteProgramm("C:/videogames/mainMenu/reset.bat");
        // ExecuteProgramm("C:/videogames/reset.bat");
        //yield return new WaitForSeconds(0.1f);
        //if (gameItems[gameID].data.joyToKey)
        //{
        //   // ExecuteProgramm("C:/videogames/games/" + gameItems[gameID].data.folder + "/joyToKey/JoyToKey.exe");
        //    yield return new WaitForSeconds(0.1f);
        //}        
        ExecuteProgramm("C:/videogames/games/" + gameItems[gameID].data.folder + "/" + gameItems[gameID].data.file);
        yield return new WaitForSeconds(3);
        isLoadingGame = false;
        // Application.Quit();
    }
    void ExecuteProgramm(string url)
    {
        string urlReal = string.Format("file://{0}", url);
        print(url);
        System.Diagnostics.Process.Start(urlReal);
    }
}
