using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatList : MonoBehaviour {

    public GameObject ChatItemPrefab;

    readonly List<ChatItem> chatItems = new List<ChatItem>(10);

    void Update() {
        var render = chatItems.Count != GameManager.Inst.Chats.Count;
        for (int i = 0; !render && i < chatItems.Count; i++) {
            render |= chatItems[i].Chat != GameManager.Inst.Chats[i];
        }
        if (render) {
            RenderChats();
        }
    }

    public void RenderChats() {
        foreach (var item in chatItems) {
            Destroy(item.gameObject);
        }
        chatItems.Clear();
        for (var i = 0; i < GameManager.Inst.Chats.Count; i++) {
            var chatItem = Instantiate(ChatItemPrefab, transform);
            chatItem.GetComponent<ChatItem>().Chat = GameManager.Inst.Chats[i];
            chatItems.Add(chatItem.GetComponent<ChatItem>());
        }
    }
}
