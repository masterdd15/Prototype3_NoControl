using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioPlayer : MonoBehaviour
{

    public AudioSource myAudio;

    public AudioClip introClip;
    public AudioClip startTimer;
    public AudioClip waitLonger;

    public GameObject backgroundMusic;

    //This is were our timer is set
    public float timer;
    public TextMeshProUGUI timerText;
    public GameObject timerObject;

    //Bools to track our states
    private bool isCounting;
    private bool isReseting;

    //We need the value of the timer to keep increasing
    float highValue;
    float stopTimer;

    //The Two Cameras
    public GameObject camera1;
    public GameObject camera2;
    
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        StartCoroutine(PlayIntro());
        timer = 20f;
        highValue = 100f;
        stopTimer = 10f;
        isCounting = false;
        timerObject.SetActive(false);
        backgroundMusic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 10f)
        {
            StartCoroutine(ResetTimer());
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
        if (isReseting)
        {
            backgroundMusic.SetActive(false);
        }
        else
        {
            backgroundMusic.SetActive(true);
        }
        timer -= Time.deltaTime;
        timerText.text = timer.ToString();
    }

    IEnumerator ResetTimer()
    {
        isReseting = true;
        myAudio.clip = waitLonger;
        myAudio.Play();
        float newTime = Random.Range(30f, highValue);
        timer = newTime;
        yield return new WaitForSeconds(myAudio.clip.length);
        if(camera1.activeSelf) //We need to turn on camera 2
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
        else
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
        highValue = highValue * 2;
        stopTimer = Random.Range(2f, 10f);
        isReseting = false;
    }
}
