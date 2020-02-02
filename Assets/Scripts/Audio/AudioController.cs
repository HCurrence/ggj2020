using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public Object[] songs = new AudioClip[5];

    void Awake()
    {
        songs = Resources.LoadAll("Audio/songs", typeof(AudioClip));
    }

    // Start is called before the first frame update
    void Start()
    {
        playRandomMusic();

    }

    // Update is called once per frame
    void Update()
    {
        if(!SoundManager.Inst.audio.isPlaying)
        {
            playRandomMusic();
        }
    }

    private void playRandomMusic()
    {
        AudioClip clip = songs[Random.Range(0, songs.Length)] as AudioClip;
        SoundManager.Inst.PlayMusic(clip.name);
    }
}
