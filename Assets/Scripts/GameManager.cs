using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : Manager<GameManager> {

    public string Name;
    public Random Rand;

    public GameObject[] LoginObjects;
    public Button DefaultButton;
    public TextMeshProUGUI WelcomeText;

    static int hash_djb2(string s) {
        uint hash = 5381;
        foreach (var c in s) {
            hash = (hash << 5) + hash + c;
        }
        return (int)hash;
    }

    public void Login(string n) {
        if (string.IsNullOrWhiteSpace(n) || n.Length < 3)
            return;

        Name = n;

        // generate all the random stuff here using the inputted name as a random seed
        using (var r = new WithRandomSeed(hash_djb2(Name))) {
            WorkManager.Inst.generateWorkers(12);
            WorkManager.Inst.generateJobs(4);
        }

        // setup computer
        LoginObjects.ForEach(go => go.SetActive(false));
        DefaultButton.OnPointerClick(new PointerEventData(EventSystem.current));
        DefaultButton.Select();
        WelcomeText.text = WelcomeText.text.Replace("{}", Name);
    }
}
