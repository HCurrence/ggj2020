using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AssignItem : MonoBehaviour {

    public Job Job;
    public Worker Worker1;
    public Worker Worker2;
    public Worker Worker3;

    Picture picture1;
    Picture picture2;
    Picture picture3;

    SkillBar skillPhys;
    SkillBar skillTech;
    SkillBar skillTrade;

    TextMeshProUGUI description;
    TextMeshProUGUI fromName;

    void Awake() {
        picture1 = transform.Find("Picture1").GetComponent<Picture>();
        picture2 = transform.Find("Picture2").GetComponent<Picture>();
        picture3 = transform.Find("Picture3").GetComponent<Picture>();
        skillPhys = transform.Find("SkillBarPhys").GetComponent<SkillBar>();
        skillTech = transform.Find("SkillBarTech").GetComponent<SkillBar>();
        skillTrade = transform.Find("SkillBarTrade").GetComponent<SkillBar>();
        description = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        fromName = transform.Find("FromName").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        description.text = Job.getDescription();
        fromName.text = Job.getFrom();

        picture1.Worker = Worker1;
        picture2.Worker = Worker2;
        picture3.Worker = Worker3;

        skillPhys.Value = Mathf.FloorToInt(((Worker1?.strength ?? 0) + (Worker2?.strength ?? 0) + (Worker3?.strength ?? 0)) / 2f);
        skillTech.Value = Mathf.FloorToInt(((Worker1?.tech_knowledge ?? 0) + (Worker2?.tech_knowledge ?? 0) + (Worker3?.tech_knowledge ?? 0)) / 2f);
        skillTrade.Value = Mathf.FloorToInt(((Worker1?.trade_knowledge ?? 0) + (Worker2?.trade_knowledge ?? 0) + (Worker3?.trade_knowledge ?? 0)) / 2f);
    }

}
