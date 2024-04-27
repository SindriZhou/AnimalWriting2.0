using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Click_PlazaCenter : MonoBehaviour
{
    public Vector3 targetPosition01 = new Vector3(-8.25f, 4.26000023f, 27.0300007f); // 要移动到的目标位置
    public Vector3 targetRotation01 = new Vector3(20.757f, -31.497f, -0.05f); // 要设置的旋转值
    public string targetTag = "PlazaCenter"; // 物体的标签
    public float movementDuration = 1f; // 移动持续时间

    //private bool allowClicking = true; // 控制是否允许点击物体

    public GameObject centerWindow;
    //public GameObject Texts;

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
                // 如果点击到了指定标签的物体，则移动摄像机到目标位置并设置旋转
                if (hit.collider.CompareTag(targetTag))
                {
                    //MoveCamera(targetPosition, targetRotation);
                    StartCoroutine(MoveCameraSmoothly(targetPosition01, targetRotation01, movementDuration));

                    Invoke("DelayedOpen", 1.1f);
                    Click.allowClicking = false;

                    GameObject.Find("Flowchart").GetComponent<Flowchart>().SendFungusMessage("PlazaCenter");
                }
            }
        }

        //// 检测 ESC 键按下事件
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    // 按下 ESC 键时回到原来的摄像机位置
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
            // 计算当前的位置和旋转
            float t = Mathf.SmoothStep(0f, 1f, elapsedTime / duration);
            transform.position = Vector3.Lerp(startingPosition, targetPosition, t);
            transform.rotation = Quaternion.Slerp(startingRotation, Quaternion.Euler(targetRotation), t);

            // 更新已经经过的时间
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 确保最终位置和旋转是精确的
        transform.position = targetPosition;
        transform.rotation = Quaternion.Euler(targetRotation);
    }

    public void DelayedOpen()
    {
        centerWindow.SetActive(true);
    }

    public void MoveCameraBack()
    {
        // 回到原来的摄像机位置和旋转
        StartCoroutine(MoveCameraSmoothly(new Vector3(-0.860000014f, 10.7799997f, 15.4399996f), new Vector3(40.976f, -31.52f, -0.062f), movementDuration));
        //LevelMode.SetActive(false);
        Click.allowClicking = true;
        //Texts.SetActive(true);
        GameObject.Find("Flowchart").GetComponent<Flowchart>().SendFungusMessage("PlazaCenterBack");
    }
}
