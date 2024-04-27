using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RamdomTopics : MonoBehaviour
{
    public string[] buttonTexts; // �洢���п��ܵ��ı�
    public TextMeshProUGUI buttonText; // TextMeshPro���ı����

    void Start()
    {
        // ��ȡTextMeshPro���
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

        // ���ѡ��һ���ı�
        string randomText = buttonTexts[Random.Range(0, buttonTexts.Length)];
        // ���ı���ֵ����ť
        buttonText.text = randomText;
    }
}
