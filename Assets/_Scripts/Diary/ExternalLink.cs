using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ExternalLink : MonoBehaviour, IPointerClickHandler
{
    // �ⲿ���ӵ�URL
    public string url;

    // ���ⲿ����
    public void OnPointerClick(PointerEventData eventData)
    {
        // ����Ƿ���ָ��������
        if (!string.IsNullOrEmpty(url))
        {
            // ��Ĭ��������д�����
            Application.OpenURL(url);
        }
    }
}
