using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SdM_env : MonoBehaviour
{
    public static SdM_env instance;

    public AudioSource audioSource;
    [SerializeField]
    private AudioClip BigMap, Home, Plaza;

    void Start()
    {
        instance = this;
        Invoke("SceneCheck", 0.1f);
    }

    public void SceneCheck()
    {
        if(Player.SceneNum == 0 || Player.SceneNum == 1)
            audioSource.clip = BigMap;
        if(Player.SceneNum == 2)
            audioSource.clip = Home;
        if(Player.SceneNum == 3)
            audioSource.clip = Plaza;

        audioSource.Play();
    }
}
