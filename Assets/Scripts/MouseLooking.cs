using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooking : MonoBehaviour {

    public AnimationCurve ScreenToPosX = AnimationCurve.Linear(0, 0, 1, 1);
    public AnimationCurve ScreenToPosY = AnimationCurve.Linear(0, 0, 1, 1);
    [Range(0f, 0.25f)]
    public float LerpSpeed = 0.1f;

    new Camera camera;

    void Awake() {
        camera = GetComponent<Camera>();
    }

    void Update() {
        var mousePos = camera.ScreenToViewportPoint(Input.mousePosition);
        var desiredPos = new Vector2(ScreenToPosX.Evaluate(mousePos.x), ScreenToPosY.Evaluate(mousePos.y));
        transform.position = Vector2.Lerp(transform.position, desiredPos, LerpSpeed).to3(transform.position.z);
    }
}