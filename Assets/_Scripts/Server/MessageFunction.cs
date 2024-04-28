using Google.Protobuf.WellKnownTypes;
using UnityEngine;
using UnityEngine.UI;

public class MessageFunction : MonoBehaviour
{
    public InputField friendNameInput2;
    public InputField messageInput2;

    public Text debugText;
    public void SendMessageToFriend()
    {
        string message = messageInput2.text;
        string name = friendNameInput2.text;
        Message(name, message);
    }

    public void Message(string name, string message)
    {
        debugText.text = "";// 清空文本内容
        Debug.Log("Sending message to " + name + ": " + message);
        debugText.text += "Sending message to " + name + ": " + message + "\n";
    }

}
