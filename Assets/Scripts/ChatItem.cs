using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatItem : MonoBehaviour {

    static string[] RESP = new[] {
        "Okay...",
        "Thanks",
        "Great, bye...",
        "Acknowledged",
        "I see",
        "Fascinating",
        "Oh really?",
        "Fine, I guess",
        "Ah...",
    };

    public Dialogue Chat;

    TextMeshProUGUI chat;
    Picture picture;

    void Awake() {
        chat = transform.Find("Chat").GetComponent<TextMeshProUGUI>();
        picture = transform.Find("PictureDraggable").GetComponent<Picture>();
        transform.Find("Button").Find("Text").GetComponent<TextMeshProUGUI>().text = RESP.Random();
    }

    void Update() {
        chat.text = Chat.sentences_joined;
        picture.Worker = Chat.worker;
    }

    public void Dimiss() {
        GameManager.Inst.Chats.Remove(Chat);
    }
}
