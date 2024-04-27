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
                // 发射一条射线检测是否点击到了物体
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // 如果点击到了指定标签的物体，则移动摄像机到目标位置并设置旋转
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
