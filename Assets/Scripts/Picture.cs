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

    void Awake() {
        Base = transform.Find("Base").GetComponent<Image>();
        Hair = transform.Find("Hair").GetComponent<Image>();
        Clothes = transform.Find("Clothes").GetComponent<Image>();
        Accessory = transform.Find("Accessory").GetComponent<Image>();
    }

    void Update() {
        Base.color = Worker.SkinColor;
        Hair.sprite = Worker.Hair;
        Hair.color = Worker.HairColor;
        Clothes.sprite = Worker.Clothes;
        Clothes.color = Worker.ClothesColor;
        Accessory.sprite = Worker.Accessory;
    }

}
