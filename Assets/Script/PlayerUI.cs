using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject Book;
    [SerializeField] private AudioSource Backsound;
    [SerializeField] private AudioSource Button_Sound_1;

    public static bool interaction = false;

    void Start()
    {
        Backsound.Play();
        Menu.SetActive(false);
        Pause.SetActive(false);
        Book.SetActive(false);
    }

    public void Pause_button_clicked()
    {
        Button_Sound_1.PlayOneShot(Button_Sound_1.clip);
        Backsound.Pause();
        Time.timeScale = 0f;
        Menu.SetActive(true);
        Pause.SetActive(true);
    }

    public void Resume_button_clicked()
    {
        Button_Sound_1.PlayOneShot(Button_Sound_1.clip);
        Backsound.Play();
        Time.timeScale = 1f;
        Menu.SetActive(false);
        Pause.SetActive(false);
    }

    public void Restart_button_clicked()
    {
        Button_Sound_1.PlayOneShot(Button_Sound_1.clip);
        SceneManager.LoadScene(TaskList.index);
    }

    public void Home_button_clicked()
    {
        Button_Sound_1.PlayOneShot(Button_Sound_1.clip);
        SceneManager.LoadScene(1);
    }

    // book
    public void Book_button_clicked()
    {
        Button_Sound_1.PlayOneShot(Button_Sound_1.clip);
        Menu.SetActive(true);
        Book.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Back_Book_Button_clicked()
    {
        Button_Sound_1.PlayOneShot(Button_Sound_1.clip);
        Menu.SetActive(false);
        Book.SetActive(false);
        Time.timeScale = 1f;
    }
    public void button_interaction_up()
    {
        interaction = false;
    }

    public void button_interaction_down()
    {
        interaction = true;
    }

    public void button_interaction_clicked()
    {
        interaction = true;
    }
}
