﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SdM_ui : MonoBehaviour
{
    public static SdM_ui instance;

    public AudioSource audioSource;
    [SerializeField]
    private AudioClip GameStart,HomeDoorOpen,HomeDoorClose,FillInfo,NewQuest,addFriend,openChat,PushButton,Score,keyboard,wrong;

    public void Awake()
    {
        instance = this;
    }

    public void IsStart()
    {
        audioSource.clip = GameStart;
        audioSource.Play();
    }

    public void DoorOpen()
    {
        audioSource.clip = HomeDoorOpen;
        audioSource.Play();
    }

    public void DoorClose()
    {
        audioSource.clip = HomeDoorClose;
        audioSource.Play();
    }

    public void Info()
    {
        audioSource.clip = FillInfo;
        audioSource.Play();
    }

    public void Quest()
    {
        audioSource.clip = NewQuest;
        audioSource.Play();
    }

    public void AddFriend()
    {
        audioSource.clip = addFriend;
        audioSource.Play();
    }

    public void OpenChat()
    {
        audioSource.clip = openChat;
        audioSource.Play();
    }

    public void Button()
    {
        audioSource.clip = PushButton;
        audioSource.Play();
    }

    public void score()
    {
        audioSource.clip = Score;
        audioSource.Play();
    }

    public void key()
    {
        audioSource.clip = keyboard;
        audioSource.Play();
    }

    public void Wrong()
    {
        audioSource.clip = wrong;
        audioSource.Play();
    }
}
