using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Fungus;

public class Player : MonoBehaviour
{
    //����ͷ
    public GameObject Camera;
    public float rotationSpeed = 50f; // ��ת�ٶȣ���/�룩
    public float targetRotation = 67f; // Ŀ����ת�Ƕȣ��ȣ�
    private float currentRotation = 0f; // ��ǰ����ת�ĽǶȣ��ȣ�
    bool CanRotate = false;

    //ѡ��˵�
    public GameObject OptionsStg1;
    bool OptionsOpened = false;

    //�����Ϣ
    public GameObject Stg1_Name, Stg2_Portrait, Stg3_Tag;
    public GameObject PlayerStat;

    //ͷ��
    public static Sprite Portrait;
    public GameObject PorImage;

    //����
    public GameObject NameInput, NameText;
    public static string Name = "PlayerName";

    //Ǯ
    public TextMeshProUGUI Money;
    public int point = 0;

    //���˼��
    public GameObject IntroWindow;
    public TextMeshProUGUI Intro;

    //��ǰ����
    public static int SceneNum = 0;

    //������Ϸ
    public GameObject TypingGame,TypingGameMenu, Cube_Type2;

    void Start()
    {
        //�ر������Ϣ
        PlayerStat.SetActive(false);

        //���ѡ��˵�
        if (OptionsStg1.activeSelf == true)
            OptionsStg1.SetActive(false);
    }

    void Update()
    {
        //ѡ��˵�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionMenu();
        }

        if(CanRotate == true)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;

            if (currentRotation < targetRotation)
            {
                // ������������ϵ��Y����ת��ʵ�������ˮƽ��ת
                Camera.transform.Rotate(Vector3.right, rotationAmount);
                currentRotation += rotationAmount;
            }
            else
                CanRotate = false;
        }
    }

    public void OptionMenu()
    {
        if (!OptionsOpened)
        {
            OptionsOpened = true;
            OptionsStg1.SetActive(true);
        }
        else
        {
            OptionsOpened = false;
            OptionsStg1.SetActive(false);
        }
    }

    //��ʼ��Ϸ
    public void GameStart()
    {
        SceneNum = 1;
        CanRotate = true;
    }

    public void GameStartFree()
    {
        SceneNum = 1;
        CanRotate = true;
        GameObject.Find("Flowchart").GetComponent<Flowchart>().SendFungusMessage("FreeMode");
    }

    //�����Ϣ����
    public void SetName()
    {
        Debug.Log($"{NameInput.GetComponent<TextMeshProUGUI>().text.Length}");

        if (NameInput.GetComponent<TextMeshProUGUI>().text.Length < 2)
        {
        }
        else
        {
            Name = NameText.GetComponent<TextMeshProUGUI>().text = GameObject.Find("Flowchart").GetComponent<Flowchart>().GetVariable<StringVariable>("PlayerName").Value = NameInput.GetComponent<TextMeshProUGUI>().text;
            Stg1_Name.SetActive(false);
            Stg2_Portrait.SetActive(true);
            Debug.Log(Name);
        }
    }

    public void SetProtrait(Sprite P)
    {
        Portrait = P;
        PorImage.GetComponent<Image>().sprite = P;
        Stg2_Portrait.SetActive(false);
        Stg3_Tag.SetActive(true);
    }

    public void SetTag()
    {
        Stg3_Tag.transform.parent.gameObject.SetActive(false);
        PlayerStat.SetActive(true);

        Flowchart.BroadcastFungusMessage("Home_Tutorial2");
    }

    //�޸����ҽ���
    public void SetIntro()
    {
        if(Intro.text.Length < 2)
        { }
        else
        {
            IntroWindow.SetActive(false);
            Flowchart.BroadcastFungusMessage("Intro1");
            Click.allowClicking = true;
        }
    }

    //��Ǯ
    public void AddMoney()
    {
        Money.text = (point+100).ToString();
        point += 100;
    }

    public void OpenTyping()
    {
        Invoke("OT2", 0.7f);
    }

    public void OT2()
    {
        TypingGame.GetComponent<Animator>().SetTrigger("open");
    }

    public void CloseTyping() 
    {
        TypingGame.GetComponent<Animator>().SetTrigger("close");
        if(Cube_Type2.activeSelf == true)
            Cube_Type2.SetActive(false);
        Invoke("CT2", 0.7f);
    }

    void CT2()
    {
        TypingGameMenu.SetActive(true);

        for (int i = 0; i < TypingGame.transform.childCount; i++)
        {
            TypingGame.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
