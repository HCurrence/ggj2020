using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobList : MonoBehaviour {

    public GameObject JobItemPrefab;

    readonly List<JobItem> jobItems = new List<JobItem>(10);

    void Update() {
        var render = jobItems.Count != WorkManager.Inst.orders.Count;
        for (int i = 0; !render && i < jobItems.Count; i++) {
            render |= jobItems[i].Job != WorkManager.Inst.orders[i];
        }
        if (render) {
            RenderJobs();
        }
    }

    public void RenderJobs() {
        foreach (var item in jobItems) {
            Destroy(item.gameObject);
        }
        jobItems.Clear();
        for (var i = 0; i < WorkManager.Inst.orders.Count; i++) {
            var jobItem = Instantiate(JobItemPrefab, transform);
            jobItem.GetComponent<JobItem>().Job = WorkManager.Inst.orders[i];
            jobItems.Add(jobItem.GetComponent<JobItem>());
        }
    }
}
