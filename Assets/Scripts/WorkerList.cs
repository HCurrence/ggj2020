using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkerList : MonoBehaviour {

    public GameObject WorkerItemPrefab;

    readonly List<WorkerItem> workerItems = new List<WorkerItem>(10);

    void Update() {
        var render = workerItems.Count != WorkManager.Inst.available_workers.Count;
        for (int i = 0; !render && i < workerItems.Count; i++) {
            render |= workerItems[i].Worker != WorkManager.Inst.available_workers[i];
        }
        if (render) {
            RenderWorkers();
        }
    }

    public void RenderWorkers() {
        foreach (var item in workerItems) {
            Destroy(item.gameObject);
        }
        workerItems.Clear();
        for (var i = 0; i < WorkManager.Inst.available_workers.Count; i++) {
            var workerItem = Instantiate(WorkerItemPrefab, transform);
            workerItem.GetComponent<WorkerItem>().Worker = WorkManager.Inst.available_workers[i];
            workerItems.Add(workerItem.GetComponent<WorkerItem>());
        }
    }
}
