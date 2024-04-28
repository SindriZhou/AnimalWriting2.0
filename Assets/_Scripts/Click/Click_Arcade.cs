using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Click_Arcade : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(1, 2, 1); // Ҫ�ƶ�����Ŀ��λ��
    public Vector3 targetRotation = new Vector3(2, 1, 1); // Ҫ���õ���תֵ

    public Vector3 targetPosition2 = new Vector3(1, 2, 1); // Ҫ�ƶ�����Ŀ��λ��
    public Vector3 targetRotation2 = new Vector3(2, 1, 1); // Ҫ���õ���תֵ
    public bool CanOpenGame = false;
    public bool CanCloseGame = false;
    public float movementDuration2 = 0.7f;

    public string targetTag = "Arcade"; // ����ı�ǩ
    public float movementDuration = 1f; // �ƶ�����ʱ��

    //private bool allowClicking = true; // �����Ƿ�����������

    public GameObject TypingGame;
    public GameObject Texts;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    void Start()
    {
        // �����������ԭʼλ�ú���ת
        originalPosition = transform.position;
        originalRotation = transform.rotation;

    }
    void Update()
    {
        // ������������
        if (Input.GetMouseButtonDown(0) && Click.allowClicking)
        {
            // ����һ�����߼���Ƿ�����������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // ����������ָ����ǩ�����壬���ƶ��������Ŀ��λ�ò�������ת
                if (hit.collider.CompareTag(targetTag))
                {
                    //MoveCamera(targetPosition, targetRotation);
                    StartCoroutine(MoveCameraSmoothly(targetPosition, targetRotation, movementDuration));

                    Invoke("DelayedOpen", 1.1f);
                    Click.allowClicking = false;

                    GameObject.Find("SdM_UI").GetComponent<SdM_ui>().Button();

                    Player.SceneNum = 4;
                }
            }
        }

        //����ʵ����Ϸ
        if(CanOpenGame == true)
        {
            StartCoroutine(MoveCameraSmoothly(targetPosition2, targetRotation2, movementDuration2));
            CanOpenGame = false;
        }

        if(CanCloseGame == true)
        {
            StartCoroutine(MoveCameraSmoothly(targetPosition, targetRotation, movementDuration2));
            CanCloseGame = false;
        }
    }

    IEnumerator MoveCameraSmoothly(Vector3 targetPosition, Vector3 targetRotation, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;
        Quaternion startingRotation = transform.rotation;

        while (elapsedTime < duration)
        {
            // ���㵱ǰ��λ�ú���ת
            float t = Mathf.SmoothStep(0f, 1f, elapsedTime / duration);
            transform.position = Vector3.Lerp(startingPosition, targetPosition, t);
            transform.rotation = Quaternion.Slerp(startingRotation, Quaternion.Euler(targetRotation), t);

            // �����Ѿ�������ʱ��
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ȷ������λ�ú���ת�Ǿ�ȷ��
        transform.position = targetPosition;
        transform.rotation = Quaternion.Euler(targetRotation);

    }

    public void DelayedOpen()
    {
        TypingGame.SetActive(true);
        Texts.SetActive(false);
    }

    public void ClickRecovery()
    {
        Click.allowClicking = true;
    }

    public void CanOpen()
    {
        CanOpenGame = true;
    }

    public void CanClose()
    {
        CanCloseGame = true;
    }
}
