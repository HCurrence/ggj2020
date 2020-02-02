using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobItem : MonoBehaviour {

    public Job Job;

    TextMeshProUGUI description;
    TextMeshProUGUI fromName;

    void Awake() {
        description = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        fromName = transform.Find("FromName").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        description.text = Job.getDescription();
        fromName.text = Job.getFrom();
    }
    
}
