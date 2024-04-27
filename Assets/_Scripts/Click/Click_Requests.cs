using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Requests : MonoBehaviour
{
    public Vector3 targetPosition02 = new Vector3(1, 2, 1); // 要移动到的目标位置
    public Vector3 targetRotation02 = new Vector3(2, 1, 1); // 要设置的旋转值
    public string targetTag = "Bookshelf"; // 物体的标签
    public float movementDuration = 1f; // 移动持续时间

    private bool allowClicking = true; // 控制是否允许点击物体

    public GameObject RequestMode;
    public GameObject Texts;

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
                    StartCoroutine(MoveCameraSmoothly(targetPosition02, targetRotation02, movementDuration));

                    Invoke("DelayedOpen", 1.1f);
                    allowClicking = false;
                }
            }
        }
        // 检测 ESC 键按下事件
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 按下 ESC 键时回到原来的摄像机位置
            MoveCameraBack();
        }
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
        RequestMode.SetActive(true);
        Texts.SetActive(false);
    }
    public void MoveCameraBack()
    {
        // 回到原来的摄像机位置和旋转
        StartCoroutine(MoveCameraSmoothly(originalPosition, originalRotation.eulerAngles, movementDuration));
        RequestMode.SetActive(false);
        allowClicking = true;
        Texts.SetActive(true);
    }
}
