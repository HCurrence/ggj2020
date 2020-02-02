using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Manager<SoundManager> {

    public AudioClip[] Sounds;
    public AudioSource audio;

    void Awake() {
        audio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playRandomMusic();

    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            playRandomMusic();
        }
    }

    public void PlayMusic(string soundName) {
        audio.clip = Sounds.Find(s => s.name == soundName);
        audio.Play();
    }

    public void PlaySound(string soundName) {
        Sounds.Find(s => s.name == soundName).Play();
    }

    private void playRandomMusic()
    {
        AudioClip clip = Sounds[Random.Range(0, 4)] as AudioClip;
        PlayMusic(clip.name);
    }
}
