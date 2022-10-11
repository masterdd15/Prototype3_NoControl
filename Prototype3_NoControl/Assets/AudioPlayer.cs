using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public AudioSource myAudio;

    public AudioClip introClip;
    public AudioClip startTimer;

    
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayIntro()
    {
        myAudio.clip = introClip;
        myAudio.Play();
        yield return new WaitForSeconds(myAudio.clip.length);
        myAudio.clip = startTimer;
        myAudio.Play();
    }
}
