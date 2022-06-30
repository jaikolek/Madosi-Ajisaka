using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stone : MonoBehaviour
{
    [SerializeField] private Text letterHana;
    [SerializeField] private Text letterTranslate;
    [SerializeField] private GameObject objectPanel;
    [SerializeField] private GameObject thisObject;


    [SerializeField] private String[] letter;

    private void Start()
    {
        objectPanel.SetActive(false);
    }

    public void setText()
    {
        letterHana.text = letter[0];
        letterTranslate.text = letter[1];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectPanel.SetActive(true);
            thisObject.SetActive(false);
            setText();
            TaskList.stoneCountTask++;
        }
    }


}
