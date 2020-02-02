using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AssignList : MonoBehaviour {

    public GameObject AssignItemPrefab;

    readonly List<AssignItem> AssignItems = new List<AssignItem>(10);

    void Update() {
        var render = AssignItems.Count != WorkManager.Inst.orders.Count;
        for (int i = 0; !render && i < AssignItems.Count; i++) {
            render |= AssignItems[i].Job != WorkManager.Inst.orders[i];
        }
        if (render) {
            RenderJobs();
        }
    }

    public void RenderJobs() {
        foreach (var item in AssignItems) {
            Destroy(item.gameObject);
        }
        AssignItems.Clear();
        for (var i = 0; i < WorkManager.Inst.orders.Count; i++) {
            var assignItem = Instantiate(AssignItemPrefab, transform);
            assignItem.GetComponent<AssignItem>().Job = WorkManager.Inst.orders[i];
            AssignItems.Add(assignItem.GetComponent<AssignItem>());
        }
    }
}
