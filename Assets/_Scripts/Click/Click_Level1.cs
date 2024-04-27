using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using TMPro;

public class Click_Level1 : MonoBehaviour
{
    public GameObject OpenObject, OpenObject2;

    public TextMeshProUGUI Mail1, Mail2;

    public string targetTag1 = "Level1",targetTag2 = "mail2"; // 物体的标签

    public void SetText()
    {
        Mail1.text = $"Hello {Player.Name},\r\nI hope you are getting used to your new life! I don't know if you've been making new friends over at the Plaza, and if your home has gotten any prettier - but that's not why I'm writing to you...\r\n\r\nI've been busy these days with new travelers, and I'm enjoying helping everyone settle in, but it's always a bit tiring to do that all the time. Therefore, I'm hoping to give myself a break from work for a while and get back to a normal social life. I had a great time chatting with you last time, so I was wondering... Could you be my pen pal? You know, talk to me about what you've been up to, talk about your hobbies, your goals... Anything! and then I'll tell you some of my own. I have a feeling that our relationship won't end here!\r\n\r\n\t\t\t\t\t\t\t\t\tYour friendly,\r\n\t\t\t\t\t\t\t\t\tGuide";
        Mail2.text = $"Dear {Player.Name},\r\n\r\nThank you so much for writing back! I'm starting to feel like I'm gradually coming to life as well! Allow me to introduce myself once again - my name is Clover, the Traveler's Guide on Writing Animals Island! You can also find many talking animals like me on the island, who are residents of the island and good friends of mine! \r\n\r\nMy day job is this fulfilling job, but it's nice to find someone to hang out with once in a while! We'll have many more opportunities to chat like this in the future, and I hope we can share our own interesting stories with each other from time to time!\r\n\r\n\r\n\t\t\t\t\t\t\t\tYour Guide and Friend,\r\n\t\t\t\t\t\t\t\tClover";
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
                Debug.Log("Hit");

                // 如果点击到了指定标签的物体，则移动摄像机到目标位置并设置旋转
                if (hit.collider.CompareTag(targetTag1))
                {
                    OpenObject.SetActive(true);
                    GameObject.Find("SdM_UI").GetComponent<SdM_ui>().OpenChat();
                    Click.allowClicking = false;
                    GameObject.Find("Flowchart").GetComponent<Flowchart>().SendFungusMessage("Mail1");
                }

                if (hit.collider.CompareTag(targetTag2))
                {
                    GameObject.Find("SdM_UI").GetComponent<SdM_ui>().OpenChat();
                    OpenObject2.SetActive(true);
                    Click.allowClicking = false;
                }
            }
        }
    }
}
