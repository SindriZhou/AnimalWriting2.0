using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class oneUser : MonoBehaviour
{
    public GameObject oneFriend;

    public string userName, Intro;
    public Sprite userImage;

    public GameObject Add, Sent;

    public static bool canAdd = true;
    public static string Name = "Name";
    public static Sprite Image;

    void Start()
    {
        transform.Find("Name").GetComponent<TextMeshProUGUI>().text = userName;
        transform.Find("Intro").GetComponent<TextMeshProUGUI>().text = Intro;
        transform.Find("userImage").GetComponent<Image>().sprite = userImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RequestSent()
    {
        Add.SetActive(false);
        Sent.SetActive(true);

        if(canAdd == true)
        {
            canAdd = false;
            Name = userName;
            Image = userImage;
           // Friends_Side.SetActive(true);
            oneFriend.GetComponent<oneFriend>().SetFriend(userName,userImage);
            GameObject.Find("SdM_UI").GetComponent<SdM_ui>().AddFriend();
        }
    }
}
