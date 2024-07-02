using System;
using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PhotonChatManager : MonoBehaviour, IChatClientListener
{
    [SerializeField] private TextMeshProUGUI connectText;
    ChatClient chatClient;
    private bool isConnected;

    private void Update()
    {
        if(isConnected)
        {
            chatClient.Service();
        }
    }
    

    public void ChatConnectOnClick()
    {
        connectText.text = "Connecting...";
        isConnected = true;
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat,
            PhotonNetwork.AppVersion, new AuthenticationValues("123"));
    }

    public void ChatDisconnectedOnClick()
    {
        chatClient.Unsubscribe(new string[] { "RegionChannel" });
        chatClient.Disconnect();
    }

    public void DebugReturn(DebugLevel level, string message) {  }

    public void OnDisconnected()
    {
        isConnected = false;
        connectText.text = "Disconnected";
    }

    public void OnConnected()
    {
        connectText.text = "Connected";
        chatClient.Subscribe("RegionChannel" ,0,-1, new ChannelCreationOptions() { PublishSubscribers = true});
        chatClient.SetOnlineStatus(ChatUserStatus.Online);
    }

    public void OnChatStateChange(ChatState state) {  }

    public void OnGetMessages(string channelName, string[] senders, object[] messages) {  }

    public void OnPrivateMessage(string sender, object message, string channelName) {  }

    public void OnSubscribed(string[] channels, bool[] results) {  }

    public void OnUnsubscribed(string[] channels) {  }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message) {  }

    public void OnUserSubscribed(string channel, string user) {  }

    public void OnUserUnsubscribed(string channel, string user) {  }
}
