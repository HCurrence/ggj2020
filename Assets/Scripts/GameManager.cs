using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : Manager<GameManager> {

    public string Name;
    public Random Rand;

    public GameObject[] LoginObjects;
    public Button DefaultButton;

    static int hash_djb2(string s) {
        uint hash = 5381;
        foreach (var c in s) {
            hash = (hash << 5) + hash + c;
        }
        return (int)hash;
    }

    public void Login(string n) {
        Name = n;

        // generate all the random stuff here using the inputted name as a random seed
        using (var r = new WithRandomSeed(hash_djb2(Name))) {
            for (int i = 0; i < 5; i++) {
                Debug.Log("Random name = " + NameGenerator.Inst.GetRandomFirstName() + " " + NameGenerator.Inst.GetRandomLastName());
            }
        }

        // setup computer
        LoginObjects.ForEach(go => go.SetActive(false));
        DefaultButton.OnPointerClick(new PointerEventData(EventSystem.current));
        DefaultButton.Select();
    }
}
