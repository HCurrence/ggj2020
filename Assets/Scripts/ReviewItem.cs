using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReviewItem : MonoBehaviour {

    public CustomerReview Review;
    public GameObject[] Stars;

    TextMeshProUGUI name;
    TextMeshProUGUI description;

    void Awake() {
        name = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        description = transform.Find("Description").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        name.text = Review.speaker_name;
        description.text = Review.sentences_joined;
        for (int i = 0; i < Stars.Length; i++) {
            Stars[i].SetActive(i < Review.review_stars);
        }
    }
    
}
