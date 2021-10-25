using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource audioSource;
    public Slider slider;
    private float musicVolume = 1f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = slider.value;
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;
    }
}
