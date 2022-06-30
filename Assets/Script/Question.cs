using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Question : MonoBehaviour
{
    //  constant variable
    private const String answer_null = "null";
    private const String answer_false = "false";

    //  video
    [SerializeField] private VideoPlayer video;
    [SerializeField] private GameObject videoFlashback;

    //  variable
    [SerializeField] private GameObject thisQuestion;
    [SerializeField] private AudioSource button;
    public Text question;
    public Text[] answer;
    public String[] question_;
    public String[] input;
    private String answer_;
    
    [SerializeField] private bool answered = false;
    [SerializeField] private bool videoTrigger = false;

    private void Start()
    {
        videoFlashback.SetActive(false);
    }

    public void execute()
    {
        question.text = question_[0];

        for (int i = 0; i < input.Length; i++)
        {
            answer[i].text = input[i];
        }
    }

    public String getQuestion()
    {
        return question_[1];
    }

    //  true answer in question_[1]
    public void true_button_clicked()
    {
        TaskList.relicCountTask++;
        button.PlayOneShot(button.clip);
        answer_ = question_[1];
        answered = true;
        videoTrigger = true;
        thisQuestion.SetActive(false);
    }

    public void false_button_clicked()
    {
        button.PlayOneShot(button.clip);
        answer_ = answer_false;
        answered = false;
    }

    //  bool setter getter
    public bool get_answered() { return answered; }

    public void set_answered(bool a) { answered = a; }

    public bool get_videoTrigger() { return videoTrigger; }

    public void set_videoTrigger(bool a) { videoTrigger = a; }

    //  video handler
    public void setActiveVideo()
    {
        videoFlashback.SetActive(true);
    }

    public void setDeactiveVideo()
    {
        videoFlashback.SetActive(false);
    }

    public void setPlayVideo()
    {
        video.Play();
    }

    public void setStopVideo()
    {
        video.Stop();
    }

    public void setPauseVideo()
    {
        video.Pause();
    }

    public double getLengthVideo()
    {
        return video.length;
    }
}
