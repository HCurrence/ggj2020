using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour {
    
    [Range(1, 5)]
    public int Value = 3;
    public float LeftPos;
    public float RightPos;

    RectTransform dot;

    void Awake() {
        dot = transform.Find("Scale/Dot").GetComponent<RectTransform>();
    }

    void Update() {
        dot.anchoredPosition = dot.anchoredPosition.withX(Mathf.Lerp(LeftPos, RightPos, (Value - 1) / 4f));
    }

}
