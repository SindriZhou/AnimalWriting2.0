using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Level : MonoBehaviour
{
    public Vector3 targetPosition01 = new Vector3(1, 2, 1); // Ҫ�ƶ�����Ŀ��λ��
    public Vector3 targetRotation01 = new Vector3(2, 1, 1); // Ҫ���õ���תֵ
    public string targetTag = "Bed"; // ����ı�ǩ
    public float movementDuration = 1f; // �ƶ�����ʱ��

    //private bool allowClicking = true; // �����Ƿ�����������

    public GameObject LevelMode;
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
                    StartCoroutine(MoveCameraSmoothly(targetPosition01, targetRotation01, movementDuration));

                    Invoke("DelayedOpen", 1.1f);
                    //Click.allowClicking = false;
                    Click.allowClicking = false;
                }
            }
        }

        // ��� ESC �������¼�
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    // ���� ESC ��ʱ�ص�ԭ���������λ��
        //    MoveCameraBack();
        //}
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
        LevelMode.SetActive(true);
        Texts.SetActive(false);
    }

    public void MoveCameraBack()
    {
        // �ص�ԭ���������λ�ú���ת
        StartCoroutine(MoveCameraSmoothly(originalPosition, originalRotation.eulerAngles, movementDuration));
        LevelMode.SetActive(false);
        //allowClicking = true;
        Texts.SetActive(true);
    }
}
