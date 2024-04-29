using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEditor.Animations;

public class Click_Mailbox : MonoBehaviour
{
    public Vector3 targetPosition01 = new Vector3(1, 2, 1); // Ҫ�ƶ�����Ŀ��λ��
    public Vector3 targetRotation01 = new Vector3(2, 1, 1); // Ҫ���õ���תֵ
    public string targetTag = "Mailbox"; // ����ı�ǩ
    public float movementDuration = 1f; // �ƶ�����ʱ��

    //private bool allowClicking = true; // �����Ƿ�����������

    int Times = 0;
    public GameObject mail1, mail2, newMail;
    public Animator MailAnim;

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
                if (hit.collider.CompareTag(targetTag))
                {
                    if (GameObject.Find("Flowchart").GetComponent<Flowchart>().GetIntegerVariable("MailTimes") == 1)
                    {
                        mail1.SetActive(true);
                    }
                    if (GameObject.Find("Flowchart").GetComponent<Flowchart>().GetIntegerVariable("MailTimes") == 2)
                    {
                        mail2.SetActive(true);
                        newMail.SetActive(false);
                    }

                    MailRead();

                    Click.allowClicking = false;
                }
            }
        }
    }

    public void NewMail()
    {
        MailAnim.SetTrigger("New");
    }

    public void MailRead()
    {
        MailAnim.SetTrigger("Close");
    }
}
