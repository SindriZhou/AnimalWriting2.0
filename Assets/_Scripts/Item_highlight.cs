using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_highlight : MonoBehaviour
{
    public Material highlightMaterial; // ��������
    private Material originalMaterial; // ԭʼ����

    void Start()
    {
        // ���������ԭʼ����
        originalMaterial = GetComponent<Renderer>().material;
    }

    void OnMouseEnter()
    {
        if (Click.allowClicking == true)
        {
            // �����ͣʱ��������Ĳ�������Ϊ��������
            GetComponent<Renderer>().material = highlightMaterial;
        }
    }

    void OnMouseExit()
    {
        // ����뿪ʱ��������Ĳ��ʻָ�Ϊԭʼ����
        GetComponent<Renderer>().material = originalMaterial;
    }

    private void Update()
    {
        if (Click.allowClicking == false)
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }
}
