using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAmbiance : MonoBehaviour
{

    public AudioSource AudioSource;
    public AudioClip AudioClip;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!AudioSource.isPlaying)
        {
            AudioSource.PlayOneShot(AudioClip);
        }
    }
}
