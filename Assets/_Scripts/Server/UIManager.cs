using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_InputField friendNameInput;
    public FriendManager friendsManager;
    public ScrollRect scrollRect; // Reference to the ScrollRect component
    public GameObject friendListItemPrefab; // Prefab for the friend list item

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

        UpdateFriendsListUI(); // Call the method to update the UI with the new list
    }

    // Method to update the UI with the list of friends
    private void UpdateFriendsListUI()
    {
        // Clear existing list items
        foreach (Transform child in scrollRect.content.transform)
        {
            Destroy(child.gameObject);
        }

        List<Friend> friendsList = friendsManager.GetFriendsList();

        // Create new list items for each friend
        foreach (Friend friend in friendsList)
        {
            GameObject listItem = Instantiate(friendListItemPrefab, scrollRect.content.transform);
            Text listItemText = listItem.GetComponentInChildren<Text>();
            listItemText.text = "Name: " + friend.Name + ", ID: " + friend.ID;
        }
    }
}
