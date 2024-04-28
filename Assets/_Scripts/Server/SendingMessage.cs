using UnityEngine;

public class SendingMessage
{
    
    public void SendMessage(Friend friend, string message)
    {
        // Code to send message to the specified friend
        Debug.Log("Sending message to " + friend.Name + ": " + message);
        
    }
}
