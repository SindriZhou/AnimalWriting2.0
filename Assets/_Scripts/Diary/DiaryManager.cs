using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiaryManager : MonoBehaviour
{
    public TMP_InputField diaryInputField; // ָ�����InputField
    public Button saveButton; // ָ����ı��水ť
    public GameObject diaryEntryPrefab; // Ԥ���壬������ʾ�ռ���Ŀ
    public Transform diaryListContainer; // ָ�����Scroll View��������

    private List<string> diaryEntries = new List<string>(); // ���ڴ洢�����ռ���Ŀ

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
            diaryInputField.text = ""; // ��������
            UpdateDiaryListUI();
        }
    }

    void UpdateDiaryListUI()
    {
        // �������Ŀ���Է��ظ�
        foreach (Transform child in diaryListContainer)
        {
            Destroy(child.gameObject);
        }

        // Ϊÿ���ռ���Ŀ����һ��UIԪ��
        foreach (string entry in diaryEntries)
        {
            GameObject newEntry = Instantiate(diaryEntryPrefab, diaryListContainer);
            newEntry.GetComponentInChildren<Text>().text = entry;
        }
    }
}