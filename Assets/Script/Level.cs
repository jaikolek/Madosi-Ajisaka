using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private int level = 0;
    [SerializeField] private Text text;
    [SerializeField] private Text stone;
    [SerializeField] private Text relic;
    [SerializeField] private GameObject thisObject;
    [SerializeField] private GameObject homeButton;

    //  sound
    public AudioSource buttonSound;

    public void setText()
    {
        text.text = "Level " + level;
        stone.text = "0/" + TaskList.stone;
        relic.text = "0/" + TaskList.relic;
    }

    public void setLevel(int i)
    {
        level = i;
    }

    public int getLevel()
    {
        return level;
    }

    public void start_button_clicked()
    {
        buttonSound.PlayOneShot(buttonSound.clip);
        thisObject.SetActive(false);
        SceneManager.LoadScene(TaskList.index);
    }
    
    public void back_button_clicked()
    {
        buttonSound.PlayOneShot(buttonSound.clip);
        thisObject.SetActive(false);
        homeButton.SetActive(true);
    }
}
