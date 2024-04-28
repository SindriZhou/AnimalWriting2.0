using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendManager : MonoBehaviour
{
    private List<Friend> friendsList = new List<Friend>();

    public void AddFriend(Friend friend)
    {
        friendsList.Add(friend);
    }

    public void RemoveFriend(Friend friend)
    {
        friendsList.Remove(friend);
    }

    public List<Friend> GetFriendsList()
    {
        return friendsList;
    }
}
