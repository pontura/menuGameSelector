﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAsset : MonoBehaviour
{
    public Sprite[] spritesToBG;
    public GameObject bg;
    public Image[] backgroundImages;
    float speed;
    bool isOn;

    void Start()
    {
        ChangeBG();
    }
    void Update()
    {
        Vector2 pos = bg.transform.localPosition;
        pos.y += speed * Time.deltaTime;
        if (pos.y > 0)
        {
            ChangeBG();
            pos.y = -90;
        }
        bg.transform.localPosition = pos;
        Invoke("ChangeSpeed", (float)Random.Range(5, 30) / 10);
    }
    void ChangeSpeed()
    {
        speed = (float)Random.Range(100, 400);
    }
    void ChangeBG()
    {
        Sprite s = spritesToBG[Random.Range(0, spritesToBG.Length)];
        foreach (Image image in backgroundImages)
            image.sprite = s;
    }
}
