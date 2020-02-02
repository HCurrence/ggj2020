using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobItem : MonoBehaviour {

    public Job Job;

    TextMeshProUGUI description;

    void Awake() {
        description = transform.Find("Description").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        description.text = Job.getDescription();
    }
    
}
