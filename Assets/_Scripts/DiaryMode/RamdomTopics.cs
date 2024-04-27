using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RamdomTopics : MonoBehaviour
{
    public string[] buttonTexts; // 存储所有可能的文本
    public TextMeshProUGUI buttonText; // TextMeshPro的文本组件

    void Start()
    {
        // 获取TextMeshPro组件
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        if (buttonText != null && buttonTexts.Length > 0)
        {
            GenerateTopic();
        }
        else
        {
            Debug.LogWarning("Button text component or array is not set correctly.");
        }
    }

    public void GenerateTopic()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        // 随机选择一个文本
        string randomText = buttonTexts[Random.Range(0, buttonTexts.Length)];
        // 将文本赋值给按钮
        buttonText.text = randomText;
    }
}
