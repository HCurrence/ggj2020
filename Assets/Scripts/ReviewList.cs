using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReviewList : MonoBehaviour {

    public GameObject ReviewItemPrefab;

    readonly List<ReviewItem> reviewItems = new List<ReviewItem>(10);

    void Update() {
        var render = reviewItems.Count != GameManager.Inst.prevJobs.Count;
        for (int i = 0; !render && i < reviewItems.Count; i++) {
            render |= reviewItems[i].Review != GameManager.Inst.prevJobs.Values2[i];
        }
        if (render) {
            RenderReviews();
        }
    }

    public void RenderReviews() {
        foreach (var item in reviewItems) {
            Destroy(item.gameObject);
        }
        reviewItems.Clear();
        for (var i = 0; i < GameManager.Inst.prevJobs.Count; i++) {
            var reviewItem = Instantiate(ReviewItemPrefab, transform);
            reviewItem.GetComponent<ReviewItem>().Review = GameManager.Inst.prevJobs.Values2[i];
            reviewItems.Add(reviewItem.GetComponent<ReviewItem>());
        }
    }
}
