using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(1, 2, 1); // Ҫ�ƶ�����Ŀ��λ��
    public Vector3 targetRotation = new Vector3(2, 1, 1); // Ҫ���õ���תֵ
    public string targetTag = "Desk"; // ����ı�ǩ
    public float movementDuration = 1f; // �ƶ�����ʱ��

    public static bool allowClicking = true; // �����Ƿ�����������

    public GameObject Texts;

    public GameObject DiaryIntro;
    public GameObject WriteDiary;
    public GameObject DiaryMode; 
    public GameObject TypingGame;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private Vector3 mapPosition = new Vector3(38, 16.43f, -4.75f);
    private Quaternion mapRotation = Quaternion.Euler(38.882f, -0.005f, -0.067f);
    void Start()
    {
        // �����������ԭʼλ�ú���ת
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // ��ȡ��ť���������ӵ���¼�����
        Button backButton = GetComponent<Button>();
        backButton.onClick.AddListener(MoveCameraBack);
    }
    void Update()
    {
        // ������������
        if (Input.GetMouseButtonDown(0) && allowClicking)
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

                    allowClicking = false;

                }
            }
        }

        // ��� ESC �������¼�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ���� ESC ��ʱ�ص�ԭ���������λ��
            MoveCameraBack();
        }
    }

    //void MoveCamera(Vector3 targetPosition, Vector3 targetRotation)
    //{
    //    // �����������λ��
    //    transform.position = targetPosition;

    //    // �������������ת
    //    transform.rotation = Quaternion.Euler(targetRotation);
    //}

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
        DiaryMode.SetActive(true);
        Texts.SetActive(false);
    }
    public void MoveCameraBack()
    {
        // �ص�ԭ���������λ�ú���ת
        StartCoroutine(MoveCameraSmoothly(new Vector3(2.6f, 6.2f, -9.9f), new Vector3(36, 341, 0), movementDuration));
        DiaryMode.SetActive(false);
        allowClicking = true;
        Texts.SetActive(true);
        Player.SceneNum = 2;
    }

    public void MoveCameraBackToMap()
    {
        // �ص�ԭ���������λ�ú���ת
        StartCoroutine(MoveCameraSmoothly(mapPosition, mapRotation.eulerAngles, movementDuration));
        TypingGame.SetActive(false);
        Texts.SetActive(true);
        allowClicking = true;
    }

    public void BackToIntro()
    {
        // �ص�ԭ���������λ�ú���ת
        WriteDiary.SetActive(false);
        DiaryIntro.SetActive(true);

    }

    public void CanClick()
    {
        allowClicking = true;
    }

    public void CantClick()
    {
        allowClicking = false;
    }
}
