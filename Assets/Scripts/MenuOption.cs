using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuOption : MonoBehaviour {
    
    public Panel ConnectedPanel;

    Image background;
    TextMeshProUGUI text;

    void Awake() {
        background = transform.GetComponent<Image>();
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();

        GetComponent<Button>().onClick.AddListener(() => ConnectedPanel.Show());
    }

    void Update() {
        ConnectedPanel.MainColor = background.color;
        ConnectedPanel.Title = text.text;
    }
}