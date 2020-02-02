using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkerItem : MonoBehaviour {

    public Worker Worker;

    Picture picture;
    SkillBar skillPhys;
    SkillBar skillTech;
    SkillBar skillTrade;

    TextMeshProUGUI workerName;
    TextMeshProUGUI workerProfession;
    string professionText;

    void Awake() {
        workerName = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        workerProfession = transform.Find("Profession").GetComponent<TextMeshProUGUI>();
        professionText = workerProfession.text;
        picture = transform.Find("Picture").GetComponent<Picture>();
        skillPhys = transform.Find("SkillBarPhys").GetComponent<SkillBar>();
        skillTech = transform.Find("SkillBarTech").GetComponent<SkillBar>();
        skillTrade = transform.Find("SkillBarTrade").GetComponent<SkillBar>();
    }

    void Update() {
        workerName.text = Worker.name;
        workerProfession.text = professionText.Replace("{}", Worker.profession.ToString().Replace("_", " "));
        picture.Worker = Worker;
        skillPhys.Value = Worker.strength;
        skillTech.Value = Worker.tech_knowledge;
        skillTrade.Value = Worker.trade_knowledge;
    }

}
