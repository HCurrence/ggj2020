using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour {

    public static readonly List<Panel> AllInScene = new List<Panel>(5);

    public Color MainColor = Color.white;
    public string Title = "";
    public GameObject Hider;

    Image background;
    TextMeshProUGUI title;

    void Awake() {
        AllInScene.Add(this);

        background = transform.GetComponent<Image>();
        title = transform.Find("Title").GetComponent<TextMeshProUGUI>();
    }

    void OnDestroy() {
        AllInScene.Remove(this);
    }

    void Update() {
        background.color = MainColor;
        title.text = Title;
    }

    public void Show() {
        Hider.SetActive(true);
        gameObject.SetActive(true);
        StartCoroutine(DoShow());
    }

    IEnumerator DoShow() {
        foreach (var panel in AllInScene) {
            if (panel != this) 
                panel.gameObject.SetActive(false);
        }
        yield return null;
        yield return null;
        Hider.SetActive(false);
    }
}
