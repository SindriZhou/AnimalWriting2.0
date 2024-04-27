using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_WriteDiary : MonoBehaviour
{

    public GameObject DiaryIntro;
    public GameObject WriteDiary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WriteDiaryButton()
    {
        // 回到原来的摄像机位置和旋转
        DiaryIntro.SetActive(false);
        WriteDiary.SetActive(true);
    }
}
