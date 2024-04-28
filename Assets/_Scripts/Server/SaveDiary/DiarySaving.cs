using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiarySaving : MonoBehaviour
{
    public TMP_InputField titleInput;
    public TMP_InputField contentInput;

    public void SaveDiary()
    {
        string title = titleInput.text;
        string content = contentInput.text;

        // 保存日记到PlayerPrefs
        PlayerPrefs.SetString(title, content);
        PlayerPrefs.Save();
    }
}
