using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SdM_ui : MonoBehaviour
{
    public static SdM_ui instance;

    public AudioSource audioSource;
    [SerializeField]
    private AudioClip GameStart,HomeDoorOpen,HomeDoorClose,FillInfo,NewQuest,addFriend,openChat;

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
}
