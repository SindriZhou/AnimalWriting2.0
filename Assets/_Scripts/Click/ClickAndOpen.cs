using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Fungus;

public class ClickAndOpen : MonoBehaviour
{
    public GameObject A;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            else
            {
                // ����һ�����߼���Ƿ�����������
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // ����������ָ����ǩ�����壬���ƶ��������Ŀ��λ�ò�������ת
                    if (hit.collider.CompareTag("Intro"))
                    {
                        //MoveCamera(targetPosition, targetRotation);
                        A.SetActive(true);
                        Flowchart.BroadcastFungusMessage("Intro");
                        Click.allowClicking = false;
                    }
                }
            }
        }
    }
}
