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
        // ��ʾ������ռ�
        ShowDiaries();
    }

    public void SaveDiary()
    {
        string title = titleInput.text;
        string content = contentInput.text;

        // �����ռǵ�PlayerPrefs
        PlayerPrefs.SetString(title, content);

        // ���´洢�������ռǼ�
        string existingKeys = PlayerPrefs.GetString("DiaryKeys", "");
        if (!string.IsNullOrEmpty(existingKeys))
        {
            existingKeys += ";"; // ʹ�÷ֺŷָ���
        }
        existingKeys += title;
        PlayerPrefs.SetString("DiaryKeys", existingKeys);

        PlayerPrefs.Save();

        // ������ʾ
        ShowDiaries();
    }

    void ShowDiaries()
    {
        // ������е���ʾ
        foreach (Transform child in diaryEntriesParent)
        {
            Destroy(child.gameObject);
        }

        // ��PlayerPrefs��ȡ�����ռǼ�����ʾ
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