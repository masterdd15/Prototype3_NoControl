using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioPlayer : MonoBehaviour
{

    public AudioSource myAudio;

    public AudioClip introClip;
    public AudioClip startTimer;

    //This is were our timer is set
    public float timer;
    public TextMeshProUGUI timerText;
    public GameObject timerObject;

    //Bools to track our states
    private bool isCounting;

    
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        StartCoroutine(PlayIntro());
        timer = 20f;
        isCounting = false;
        timerObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 10f)
        {
            ResetTimer();
        }
        if (isCounting)
        {
            StartCountdown();
        }
    }

    IEnumerator PlayIntro()
    {
        myAudio.clip = introClip;
        myAudio.Play();
        yield return new WaitForSeconds(myAudio.clip.length);
        myAudio.clip = startTimer;
        myAudio.Play();
        yield return new WaitForSeconds(myAudio.clip.length);
        isCounting = true;
    }

    public void StartCountdown()
    {
        timerObject.SetActive(true);
        timer -= Time.deltaTime;
        timerText.text = timer.ToString();
    }

    public void ResetTimer()
    {
        float newTime = Random.Range(20f, 100f);
        timer = newTime;
    }
}
