using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ExternalLink : MonoBehaviour, IPointerClickHandler
{
    // 外部链接的URL
    public string url;

    // 打开外部链接
    public void OnPointerClick(PointerEventData eventData)
    {
        // 检查是否有指定的链接
        if (!string.IsNullOrEmpty(url))
        {
            // 在默认浏览器中打开链接
            Application.OpenURL(url);
        }
    }
}
