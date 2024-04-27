using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class oneFriend : MonoBehaviour
{
    public string friendName;
    public Sprite friendImage;

    public TextMeshProUGUI Name,chatName;
    public Image Image, chatImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFriend(string userName,Sprite userImage)
    {
        Name.text = friendName = userName;
        Image.sprite = chatImage.sprite = friendImage = userImage;
    }

    public void chatWindowInfo()
    {
        chatName.text = friendName;
        chatImage.sprite = friendImage;
    }
}
