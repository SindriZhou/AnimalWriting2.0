using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_highlight : MonoBehaviour
{
    public Material highlightMaterial; // 高亮材质
    private Material originalMaterial; // 原始材质

    void Start()
    {
        // 保存物体的原始材质
        originalMaterial = GetComponent<Renderer>().material;
    }

    void OnMouseEnter()
    {
        // 鼠标悬停时，将物体的材质设置为高亮材质
        GetComponent<Renderer>().material = highlightMaterial;
    }

    void OnMouseExit()
    {
        // 鼠标离开时，将物体的材质恢复为原始材质
        GetComponent<Renderer>().material = originalMaterial;
    }
}
