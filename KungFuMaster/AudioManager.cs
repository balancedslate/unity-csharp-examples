using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip punchNoise;
    public AudioClip kickNoise;
    public AudioClip deathNoise;
    public AudioClip jumpNoise;
    public AudioClip walkNoise;

    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            audiosource.PlayOneShot(punchNoise);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            audiosource.PlayOneShot(kickNoise);
        }
        
    }
}
