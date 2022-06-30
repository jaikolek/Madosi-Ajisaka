using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Task : MonoBehaviour
{
    [SerializeField] private int timer;
    [SerializeField] private AudioSource backsound;

    [SerializeField] private Text showRelic;
    [SerializeField] private Text showStone;
    [SerializeField] private Text showTime;

    //  win lose
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    
    //  timer
    private bool timeOut = false;
    private bool gameOver = false;
    private bool taskClear = false;
    private int minute, second;

    private void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        taskClear = false;

        minute = timer / 60;
        second = timer % 60;

        setTime();
        setTask();
    }

    //  Gate
    public void activeWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void playBacksound()
    {
        backsound.Play();
    }

    public void stopBacksound()
    {
        backsound.Stop();
    }

    public void execute()
    {
        if (!timeOut && timer >= 0)
        {
            StartCoroutine(timeLeft());
        }

        checkWinLose();
        setTask();
    }

    public void setTask()
    {
        showStone.text = "Stone: " + TaskList.stoneCountTask + "/" + TaskList.stone;
        showRelic.text = "Relic: " + TaskList.relicCountTask + "/" + TaskList.relic;
    }

    public void checkWinLose()
    {
        if (timer >= 0)
        {
            if (TaskList.stoneCountTask == TaskList.stone && TaskList.relicCountTask == TaskList.relic)
            {
                taskClear = true;
            }
            gameOver = false;
        }
        else if (timer < 0)
        {
            Time.timeScale = 0f;
            backsound.Stop();
            losePanel.SetActive(true);
            gameOver = true;
        }
    }

    // return bool
    public bool checkGameOver() { return gameOver; }

    public bool checkTaskClear() { return taskClear; }

    IEnumerator timeLeft()
    {
        minute = timer / 60;
        second = timer % 60;
        timeOut = true;
        yield return new WaitForSeconds(1);
        timer -= 1;
        setTime();
        timeOut = false;
    }

    private void setTime()
    {
        if (minute < 10 && second < 10)
        {
            showTime.text = "Time: 0" + minute + ":0" + second;
        }
        else if (minute < 10 && second >= 10)
        {
            showTime.text = "Time: 0" + minute + ":" + second;
        }
        else if (minute >= 10 && second < 10)
        {
            showTime.text = "Time: " + minute + ":0" + second;
        }
    }

    //  button function for win lose
    public void win_map_button_clicked()
    {
        winPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void win_restart_button_clicked()
    {
        winPanel.SetActive(false);
        SceneManager.LoadScene(TaskList.index);
    }

    public void win_home_button_clicked()
    {
        winPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }   
    
    public void lose_restart_button_clicked()
    {
        losePanel.SetActive(false);
        SceneManager.LoadScene(TaskList.index);
    }

    public void lose_map_button_clicked()
    {
        losePanel.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
