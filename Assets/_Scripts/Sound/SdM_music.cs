using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SdM_music : MonoBehaviour
{
    public static SdM_music instance;

    int SceneNum = 0;

    public AudioSource audioSource;
    [SerializeField]
    private AudioClip BigMap, Home, Plaza;

    void Start()
    {
        instance = this;
        Invoke("SceneCheck", 0.1f);
    }

    private void Update()
    {
        if(SceneNum != Player.SceneNum)
        {
            SceneCheck();
            SceneNum = Player.SceneNum;
        }
    }

    public void SceneCheck()
    {
        if (Player.SceneNum == 1)
            audioSource.clip = BigMap;
        if (Player.SceneNum == 2)
            audioSource.clip = Home;
        if (Player.SceneNum == 3)
            audioSource.clip = Plaza;

        audioSource.Play();
    }
}
