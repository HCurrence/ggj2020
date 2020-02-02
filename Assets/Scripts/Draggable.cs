using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum DragType {
    None,
    Assign,
}
public class Draggable : MonoBehaviour, IPointerClickHandler {

    public static Draggable Dragging;

    public DragType Type;
    public AssignItem AssignItem;
    [Range(1, 3)]
    public int AssignNum = 1;

    public float OutlineFlashSpeed = 3;
    public Vector2 OutlineFlashValues = new Vector2(0.4f, 1f);

    RectTransform rt;
    Outline outline;

    void Awake() {
        rt = GetComponent<RectTransform>();
        outline = GetComponent<Outline>();
    }

    void Update() {
        if (Dragging == this || assignShouldFlash()) {
            outline.effectColor = outline.effectColor.withAlpha(Mathf.Lerp(OutlineFlashValues.x, OutlineFlashValues.y, (Mathf.Sin(Time.realtimeSinceStartup * OutlineFlashSpeed) + 1) / 2));
        } else {
            outline.effectColor = outline.effectColor.withAlpha(0);
        }
    }

    bool assignShouldFlash() {
        if (AssignItem == null) {
            return false;
        }
        var workerNull = AssignNum == 1
                ? string.IsNullOrWhiteSpace(AssignItem.Worker1.name)
                : AssignNum == 2
                    ? string.IsNullOrWhiteSpace(AssignItem.Worker2.name)
                    : string.IsNullOrWhiteSpace(AssignItem.Worker3.name)
                    ;
        return Dragging != null && Type == DragType.Assign && workerNull;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (Dragging == this) {
            Dragging = null;
        } else if (Type == DragType.Assign) {
            var oldWorker = AssignNum == 1
                    ? AssignItem.Worker1
                    : AssignNum == 2
                        ? AssignItem.Worker2
                        : AssignItem.Worker3
                        ;
            var newWorker = Dragging?.GetComponent<Picture>().Worker;
            if (!WorkManager.Inst.available_workers.Contains(newWorker)) {
                newWorker = null;
            }

            if (!string.IsNullOrWhiteSpace(oldWorker?.name)) {
                WorkManager.Inst.unavailable_workers.Remove(oldWorker);
                if (AssignNum == 1) {
                    AssignItem.Worker1 = null;
                } else if (AssignNum == 2) {
                    AssignItem.Worker2 = null;
                } else if (AssignNum == 3) {
                    AssignItem.Worker3 = null;
                }
            }
            if (!string.IsNullOrWhiteSpace(newWorker?.name)) {
                WorkManager.Inst.unavailable_workers.Add(newWorker);
                if (AssignNum == 1) {
                    AssignItem.Worker1 = newWorker;
                } else if (AssignNum == 2) {
                    AssignItem.Worker2 = newWorker;
                } else if (AssignNum == 3) {
                    AssignItem.Worker3 = newWorker;
                }
            }

            Dragging = null;
        } else if (Dragging == null) {
            Dragging = this;
        }
    }
}
