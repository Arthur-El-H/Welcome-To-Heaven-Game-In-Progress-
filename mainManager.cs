﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainManager : MonoBehaviour
{
    public string lastScene;
    int winsForOne = 0, WinsForTwo = 0;
    bool musicPlaying = true;
    AudioSource audio;

    public void resetWins()
    {
        winsForOne = 0;
        WinsForTwo = 0;
    }

    public void win(bool p1)
    {
        if (p1) { winsForOne++; }
        else { WinsForTwo++; }
    }

    public int getWinsForOne() { return winsForOne; }
    public int getWinsForTwo() { return WinsForTwo; }

    private void Awake()
    {
        //audio = GetComponent<AudioSource>();
        Screen.fullScreen = true;
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
        //audio.loop = true;
    }

    public void toggleMusic()
    {
        musicPlaying = !musicPlaying;
        if (!musicPlaying) { audio.Stop(); }
        else { audio.Play(); }
    }
}