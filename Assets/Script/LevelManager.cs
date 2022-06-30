using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //[SerializeField] private CameraMovement mainCamera;
    [SerializeField] private GameObject[] panelLevel;
    [SerializeField] private GameObject homeButton;
    [SerializeField] private Level level;
    [SerializeField] private AudioSource backsound;

    private void Start()
    {
        TaskList.setDefaultCount();
        for (int i = 0; i < panelLevel.Length; i++) panelLevel[i].SetActive(false);
        backsound.Play();
        Time.timeScale = 1f;
    }

    // Debug.Log(TaskList.stone + " : " + TaskList.relic);

    //  level
    public void level1_button_clicked()
    {
        TaskList.stone = 5;
        TaskList.relic = 2;
        TaskList.index = 2;
        level.setLevel(1);
        level.setText();
        level.buttonSound.PlayOneShot(level.buttonSound.clip);
        homeButton.SetActive(false);
        panelLevel[0].SetActive(true);
    }

    public void level2_button_clicked()
    {
        TaskList.stone = 6;
        TaskList.relic = 2;
        TaskList.index = 3;
        level.setLevel(2);
        level.setText();
        level.buttonSound.PlayOneShot(level.buttonSound.clip);
        homeButton.SetActive(false);
        panelLevel[1].SetActive(true);
    }

    public void level3_button_clicked()
    {
        TaskList.stone = 7;
        TaskList.relic = 3;
        TaskList.index = 4;
        level.setLevel(3);
        level.setText();
        level.buttonSound.PlayOneShot(level.buttonSound.clip);
        panelLevel[1].SetActive(true);
        homeButton.SetActive(false);
    }

    public void level4_button_clicked()
    {
        TaskList.stone = 8;
        TaskList.relic = 4;
        TaskList.index = 5;
        level.setLevel(4);
        level.setText();
        level.buttonSound.PlayOneShot(level.buttonSound.clip);
        panelLevel[1].SetActive(true);
        homeButton.SetActive(false);
    }

    //  inside level
    public void back_button_clicked()
    {
        level.buttonSound.PlayOneShot(level.buttonSound.clip);
        panelLevel[0].SetActive(false);
        homeButton.SetActive(true);
    }

    //  main menu
    public void Levelmenu_button_clicked()
    {
        level.buttonSound.PlayOneShot(level.buttonSound.clip);
        SceneManager.LoadScene(0);
    }

}