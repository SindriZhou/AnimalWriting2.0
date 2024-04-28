using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiaryList : MonoBehaviour
{
    public TMP_InputField titleInput;
    public TMP_InputField contentInput;
    public GameObject diaryEntryPrefab;
    public Transform diaryEntriesParent;

    private void Start()
    {
        // 显示保存的日记
        ShowDiaries();
    }

    public void SaveDiary()
    {
        string title = titleInput.text;
        string content = contentInput.text;

        // 保存日记到PlayerPrefs
        PlayerPrefs.SetString(title, content);

        // 更新存储的所有日记键
        string existingKeys = PlayerPrefs.GetString("DiaryKeys", "");
        if (!string.IsNullOrEmpty(existingKeys))
        {
            existingKeys += ";"; // 使用分号分隔键
        }
        existingKeys += title;
        PlayerPrefs.SetString("DiaryKeys", existingKeys);

        PlayerPrefs.Save();

        // 更新显示
        ShowDiaries();
    }

    void ShowDiaries()
    {
        // 清空已有的显示
        foreach (Transform child in diaryEntriesParent)
        {
            Destroy(child.gameObject);
        }

        // 从PlayerPrefs获取所有日记键并显示
        string keys = PlayerPrefs.GetString("DiaryKeys", "");
        if (!string.IsNullOrEmpty(keys))
        {
            string[] allKeys = keys.Split(';');
            foreach (var key in allKeys)
            {
                GameObject diaryEntry = Instantiate(diaryEntryPrefab, diaryEntriesParent);
                diaryEntry.GetComponentInChildren<Text>().text = key;
            }
        }
    }

}