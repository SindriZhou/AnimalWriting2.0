using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiaryManager : MonoBehaviour
{
    public TMP_InputField diaryInputField; // 指向你的InputField
    public Button saveButton; // 指向你的保存按钮
    public GameObject diaryEntryPrefab; // 预制体，用于显示日记条目
    public Transform diaryListContainer; // 指向你的Scroll View内容容器

    private List<string> diaryEntries = new List<string>(); // 用于存储所有日记条目

    void Start()
    {
        saveButton.onClick.AddListener(SaveDiaryEntry);
    }

    void SaveDiaryEntry()
    {
        string entry = diaryInputField.text;
        if (!string.IsNullOrEmpty(entry))
        {
            diaryEntries.Add(entry);
            diaryInputField.text = ""; // 清空输入框
            UpdateDiaryListUI();
        }
    }

    void UpdateDiaryListUI()
    {
        // 清除旧条目，以防重复
        foreach (Transform child in diaryListContainer)
        {
            Destroy(child.gameObject);
        }

        // 为每个日记条目创建一个UI元素
        foreach (string entry in diaryEntries)
        {
            GameObject newEntry = Instantiate(diaryEntryPrefab, diaryListContainer);
            newEntry.GetComponentInChildren<Text>().text = entry;
        }
    }
}