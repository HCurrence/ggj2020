using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Picture : MonoBehaviour {

    public Worker Worker;

    Image Base;
    Image Hair;
    Image Clothes;
    Image Accessory;
    TextMeshProUGUI Name;

    void Awake() {
        Base = transform.Find("Base").GetComponent<Image>();
        Hair = transform.Find("Hair").GetComponent<Image>();
        Clothes = transform.Find("Clothes").GetComponent<Image>();
        Accessory = transform.Find("Accessory").GetComponent<Image>();
        Name = transform.Find("Name")?.GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        Base.color = Worker?.SkinColor ?? Color.white;
        Hair.sprite = Worker?.Hair;
        Hair.color = Worker?.HairColor ?? Color.white;
        Clothes.sprite = Worker?.Clothes;
        Clothes.color = Worker?.ClothesColor ?? Color.white;
        Accessory.sprite = Worker?.Accessory;
        if (Name) {
            Name.text = Worker?.name ?? "";
        }
    }

}
