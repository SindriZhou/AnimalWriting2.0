using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEditor.Animations;

public class Click_Mailbox : MonoBehaviour
{
    public Vector3 targetPosition01 = new Vector3(1, 2, 1); // 要移动到的目标位置
    public Vector3 targetRotation01 = new Vector3(2, 1, 1); // 要设置的旋转值
    public string targetTag = "Mailbox"; // 物体的标签
    public float movementDuration = 1f; // 移动持续时间

    //private bool allowClicking = true; // 控制是否允许点击物体

    int Times = 0;
    public GameObject mail1, mail2, newMail;
    public Animator MailAnim;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    void Start()
    {
        // 保存摄像机的原始位置和旋转
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
    void Update()
    {
        // 检测鼠标左键点击
        if (Input.GetMouseButtonDown(0) && Click.allowClicking)
        {
            // 发射一条射线检测是否点击到了物体
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
