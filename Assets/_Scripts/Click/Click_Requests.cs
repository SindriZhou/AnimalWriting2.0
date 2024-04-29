using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Requests : MonoBehaviour
{
    public Vector3 targetPosition02 = new Vector3(1, 2, 1); // Ҫ�ƶ�����Ŀ��λ��
    public Vector3 targetRotation02 = new Vector3(2, 1, 1); // Ҫ���õ���תֵ
    public string targetTag = "Bookshelf"; // ����ı�ǩ
    public float movementDuration = 1f; // �ƶ�����ʱ��

    //private bool allowClicking = true; // �����Ƿ�����������

    public GameObject RequestMode;
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
                    StartCoroutine(MoveCameraSmoothly(targetPosition02, targetRotation02, movementDuration));

                    Invoke("DelayedOpen", 1.1f);
                    Click.allowClicking = false;
                }
            }
        }
        //// ��� ESC �������¼�
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
        RequestMode.SetActive(true);
        Texts.SetActive(false);
    }
    public void MoveCameraBack()
    {
        // �ص�ԭ���������λ�ú���ת
        StartCoroutine(MoveCameraSmoothly(originalPosition, originalRotation.eulerAngles, movementDuration));
        RequestMode.SetActive(false);
        Click.allowClicking = true;
        Texts.SetActive(true);
    }
}
