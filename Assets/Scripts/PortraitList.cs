using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PortraitList : MonoBehaviour {

    public GameObject PicturePrefab;

    readonly List<Picture> pictures = new List<Picture>(10);

    void Update() {
        var works = WorkManager.Inst.available_workers;
        var render = pictures.Count != works.Count;
        for (int i = 0; !render && i < pictures.Count; i++) {
            render |= pictures[i].Worker != works[i];
        }
        if (render) {
            RenderWorkers();
        }
    }

    public void RenderWorkers() {
        foreach (var item in pictures) {
            Destroy(item.gameObject);
        }
        pictures.Clear();
        var works = WorkManager.Inst.available_workers;
        for (var i = 0; i < works.Count; i++) {
            var picture = Instantiate(PicturePrefab, transform);
            picture.GetComponent<Picture>().Worker = works[i];
            pictures.Add(picture.GetComponent<Picture>());
        }
    }
}
