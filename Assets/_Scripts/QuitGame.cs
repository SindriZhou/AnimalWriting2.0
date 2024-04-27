using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    // 在Unity的Inspector面板中分配Button组件
    public Button quitButton;

    void Start()
    {
        // 添加按钮点击事件监听器
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
