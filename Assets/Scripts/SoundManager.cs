using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Manager<SoundManager> {

    public AudioClip[] Sounds;
    AudioSource audio;

    void Awake() {
        audio = GetComponent<AudioSource>();
    }

    public void PlayMusic(string soundName) {
        audio.clip = Sounds.Find(s => s.name == soundName);
        audio.Play();
    }

    public void PlaySound(string soundName) {
        Sounds.Find(s => s.name == soundName)?.Play();
    }
}
