using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField friendNameInput;
    public FriendManager friendsManager;

    public Text debugText;

    public void AddFriend()
    {
        if (friendNameInput == null)
        {
            Debug.LogError("Friend Name Input Field is not assigned.");
            return;
        }

        string friendName = friendNameInput.text;
        if (string.IsNullOrEmpty(friendName))
        {
            Debug.LogError("Friend Name is empty.");
            return;
        }

        if (friendsManager == null)
        {
            Debug.LogError("Friends Manager is not assigned.");
            return;
        }

        Friend newFriend = new Friend { Name = friendName, ID = Random.Range(1000, 9999) };
        friendsManager.AddFriend(newFriend);
        Debug.Log("Added friend: " + friendName);
        List<Friend> friendsList = friendsManager.GetFriendsList();

        

        friendsList.ForEach(friend =>
        {
            debugText.text = "";// 清空文本内容
            Debug.Log("Friend Name: " + friend.Name + ", ID: " + friend.ID);
            debugText.text += "Friend Name: " + friend.Name + ", ID: " + friend.ID + "\n";
        });
    }
}



