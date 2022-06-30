using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Relic : MonoBehaviour
{
    //private bool donePlaying = false;
    [SerializeField] private AudioSource backsound;
    [SerializeField] private GameObject relic;

    //  question
    [SerializeField] private Question question;
    [SerializeField] private GameObject questionUI;

    [SerializeField] private bool isSpecialRelic = false;
    private bool isEnter = false;
    private bool canEnter = true;

    private void Start()
    {
        question.execute();
        questionUI.SetActive(false);
        relic.SetActive(true);
    }

    public void flashback()
    {
        if (isSpecialRelic && question.get_answered() && question.get_videoTrigger())
        {
            backsound.Pause();
            question.setActiveVideo();
            //videoFlashback.SetActive(true);
            question.setPlayVideo();
            //video.Play();
            StartCoroutine(finished(question.getLengthVideo()));
            question.set_videoTrigger(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isEnter = true;
            //Debug.Log("interaction " + PlayerUI.interaction + " | enter:" + isEnter);
            if (PlayerUI.interaction && isEnter && canEnter)
            {
                questionUI.SetActive(true);
                canEnter = false;
            } 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Out");
            isEnter = false;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerUI.interaction = false;
        }
    }

    IEnumerator finished(double time)
    {
        yield return new WaitForSeconds((float)time);
        question.setDeactiveVideo();
        //videoFlashback.SetActive(false);
        backsound.Play();
        PlayerUI.interaction = false;
    }
}
