using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : Manager<GameManager> {

    public string Name;
    [Range(1, 5)]
    public int Day = 1;
    bool canFinish;
    public ListDict2<Job, double, CustomerReview> prevJobs = new ListDict2<Job, double, CustomerReview>(10);

    public GameObject[] LoginObjects;
    public Button DefaultButton;
    public TextMeshProUGUI WelcomeText;
    public SpriteRenderer FadeSprite;
    public GameObject DayButton;
    public RectTransform DayDot;
    public Vector2 DayDotPos = new Vector2(-30, 30);

    static int hash_djb2(string s) {
        uint hash = 5381;
        foreach (var c in s) {
            hash = (hash << 5) + hash + c;
        }
        return (int)hash;
    }

    public void Login(string n) {
        if (string.IsNullOrWhiteSpace(n) || n.Length < 3)
            return;

        Name = n;

        // generate all the random stuff here using the inputted name as a random seed
        using (var r = new WithRandomSeed(hash_djb2(Name))) {
            WorkManager.Inst.generateWorkers(12);
        }
        Day = 1;
        InitDay();

        // setup computer
        LoginObjects.ForEach(go => go.SetActive(false));
        WelcomeText.text = WelcomeText.text.Replace("{}", Name);

        canFinish = true;
    }

    public void InitDay() {

        //play rooster_crowing.wav
        SoundManager.Inst.PlaySound("rooster_crowing.wav");

        WorkManager.Inst.orders.Clear();
        if (Day != 5) {
            WorkManager.Inst.generateJobs(Mathf.RoundToInt(Mathf.Lerp(3, 5, Random.value)));
        } else {
            WorkManager.Inst.orders.Add(new Job(1, "The End! Thanks for playing!", "Haley & Pia & Momin", new List<WorkManager.Profession> { WorkManager.Profession.Archictect }, new [] { 5 }));
        }
        DefaultButton.OnPointerClick(new PointerEventData(EventSystem.current));
        DefaultButton.Select();

        DayDot.anchoredPosition = DayDot.anchoredPosition.withX(Mathf.Lerp(DayDotPos.x, DayDotPos.y, (Day - 1f) / 4f));
        if (Day == 5) {
            DayDot.gameObject.SetActive(false);
            DayButton.SetActive(false);
        }
    }

    public void FinishDay() {
        if (canFinish) {
            canFinish = false;
            StartCoroutine(DoFinishDay());
        }
    }

    IEnumerator DoFinishDay() {
        ClearDrag();
        // fade out
        FadeSprite.color = Color.black.withAlpha(0);
        FadeSprite.gameObject.SetActive(true);
        float t = 0;
        while (t < 2.6f) {
            t += Time.deltaTime;
            FadeSprite.color = Color.black.withAlpha(t / 2.6f);
            yield return null;
        }
        // do stuff
        foreach (var job in WorkManager.Inst.orders) {
            var val = job.completeJob();
            var review = new CustomerReview {speaker_name = job.getFrom()};
            review.generateReview(val);
            Debug.Log($"Day {Day} job from: {job.getFrom()}, score: {val}, review stars: {review.review_stars}");
            prevJobs.Add(job, val, review);
        }
        Day++;
        InitDay();
        // fade in
        t = 0;
        while (t < 2.6f) {
            t += Time.deltaTime;
            FadeSprite.color = Color.black.withAlpha(1 - (t / 2.6f));
            yield return null;
        }
        // start day
        canFinish = true;
    }

    public void ClearDrag() {
        Draggable.Dragging = null;
    }
}
