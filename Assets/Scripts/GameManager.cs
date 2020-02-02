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
    public List<Dialogue> Chats = new List<Dialogue>(10);

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
        SoundManager.Inst.PlaySound("rooster_crowing.wav");

        WorkManager.Inst.unavailable_workers.Clear();
        WorkManager.Inst.orders.Clear();
        if (Day < 6) {
            WorkManager.Inst.generateJobs(Mathf.RoundToInt(Mathf.Lerp(3, 5, Random.value)));
        } else {
            WorkManager.Inst.orders.Add(new Job(1, "The End! Thanks for playing!", "Haley & Pia & Momin", new List<WorkManager.Profession> { WorkManager.Profession.Archictect }, new[] { 5 }));
        }

        Chats.Clear();
        // generate chats
        if (Day > 1 && Day < 6) {
            var amount = Mathf.RoundToInt(Random.value * 2 + 2);
            var used_workers = new List<Worker>(10);
            for (int i = 0; i < amount; i++) {
                Worker w1 = null;
                switch (Mathf.FloorToInt(Random.value * 10)) {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        w1 = WorkManager.Inst.all_workers.RandomWhere(w => !used_workers.Contains(w));
                        used_workers.Add(w1);
                        Chats.Add(DialogueScript.randomSickDayDialogue(w1));
                        WorkManager.Inst.unavailable_workers.Add(w1);
                        break;
                    case 5:
                    case 6:
                    case 7:
                        w1 = WorkManager.Inst.all_workers.RandomWhere(w => !used_workers.Contains(w));
                        used_workers.Add(w1);
                        Chats.Add(DialogueScript.randomVacationDialogue(w1));
                        WorkManager.Inst.unavailable_workers.Add(w1);
                        break;
                    case 8:
                    case 9:
                        w1 = WorkManager.Inst.all_workers.RandomWhere(w => !used_workers.Contains(w));
                        used_workers.Add(w1);
                        var w2 = WorkManager.Inst.all_workers.RandomWhere(w => !used_workers.Contains(w));
                        Chats.Add(DialogueScript.randomWorkerComplaintDialogue(w1, w2));
                        used_workers.Add(w2);
                        break;
                }
            }
        }

        DefaultButton.OnPointerClick(new PointerEventData(EventSystem.current));
        DefaultButton.Select();

        DayDot.anchoredPosition = DayDot.anchoredPosition.withX(Mathf.Lerp(DayDotPos.x, DayDotPos.y, (Day - 1f) / 4f));
        if (Day > 5) {
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
            var review = new CustomerReview { speaker_name = job.getFrom() };
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
