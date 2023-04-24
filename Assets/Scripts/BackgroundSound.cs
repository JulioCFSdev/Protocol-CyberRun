using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundSound : MonoBehaviour
{
    #region Parameters

    private AudioSource audioBox;
    [SerializeField] private AudioClip[] musics;
    private int currentMusic;
    private float remainMusicTime;
    public static BackgroundSound bs;

    #endregion

    private void Awake()
    {
        if(bs != null) Destroy(gameObject);

        bs = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        audioBox = GetComponent<AudioSource>();
        
        currentMusic = 0;
        audioBox.PlayOneShot(musics[currentMusic]);
        remainMusicTime = musics[currentMusic].length;
        Invoke(nameof(PlayMusic),remainMusicTime);
    }

    private void PlayMusic()
    {
        currentMusic++;
        if (currentMusic >= musics.Length) currentMusic = 0;
        
        audioBox.Stop();
        audioBox.PlayOneShot(musics[currentMusic]);
        remainMusicTime = musics[currentMusic].length;
        
        Invoke(nameof(PlayMusic),remainMusicTime);
    }
}