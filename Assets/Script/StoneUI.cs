using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneUI : MonoBehaviour
{
    [SerializeField] private AudioSource soundButton;
    [SerializeField] private GameObject thisObject;

    public void resume_button_clicked()
    {
        soundButton.PlayOneShot(soundButton.clip);
        thisObject.SetActive(false);
    }
}
