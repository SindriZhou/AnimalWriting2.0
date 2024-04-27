using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    // ��Unity��Inspector����з���Button���
    public Button quitButton;

    void Start()
    {
        // ��Ӱ�ť����¼�������
        quitButton.onClick.AddListener(QuitGame1);
    }


    public void QuitGame1()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
