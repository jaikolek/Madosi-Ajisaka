using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectQuestion : MonoBehaviour
{
    [SerializeField] private GameObject thisQuest;

    //  question
    [SerializeField] private Question question;
    [SerializeField] private GameObject questionUI;

    void Start()
    {
        question.execute();
    }

    public void checkComplete()
    {
        if (question.get_answered())
        {
            questionUI.SetActive(false);
            thisQuest.SetActive(false);
        }
    }

    // question
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            questionUI.SetActive(true);
        }
    }
}
