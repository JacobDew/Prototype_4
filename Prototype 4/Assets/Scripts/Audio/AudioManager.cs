using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public Text m_VolumeText;
    public float m_fVolumeLevel;

    public GameObject slider;

    // Use this for initialization
    void Awake()
    {

        m_fVolumeLevel = 0.2f;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = slider.GetComponent<Slider>().value;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    void Start()
    {
        Play("BackgroundMusic");
    }

    // Update is called once per frame
    void Update()
    {
        m_VolumeText.text = ((int)(slider.GetComponent<Slider>().value * 100.0f)).ToString();

        AudioListener.volume = slider.GetComponent<Slider>().value;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        s.source.Play();

    }
}
