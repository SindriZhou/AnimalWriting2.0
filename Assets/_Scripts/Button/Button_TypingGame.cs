using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // ����Ŀ��ؿ������ƻ�������
    public string levelName;

    public void LoadLevel()
    {
        // ʹ�ó�������������Ŀ��ؿ�
        SceneManager.LoadScene(levelName);
    }
}
