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
        // �ص�ԭ���������λ�ú���ת
        DiaryIntro.SetActive(false);
        WriteDiary.SetActive(true);
    }
}
