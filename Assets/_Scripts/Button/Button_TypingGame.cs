using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // 定义目标关卡的名称或者索引
    public string levelName;

    public void LoadLevel()
    {
        // 使用场景管理器加载目标关卡
        SceneManager.LoadScene(levelName);
    }
}
