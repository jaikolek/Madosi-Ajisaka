using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Game object
    public GameObject Menu_Panel_Main;
    public GameObject Menu_Panel_Credits;
    public GameObject Menu_how_To_Play;

    // sound
    public AudioSource Button_Sound_1;
    public AudioSource Main_Menu_Sound_1;
    // private float Main_Menu_Sound_Volume = 1f;

    // Start
    void Start()
    {
        Menu_Panel_Main.SetActive(true);
        Menu_Panel_Credits.SetActive(false);
        Menu_how_To_Play.SetActive(false);

        Main_Menu_Sound_1.Play();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
       // Main_Menu_Sound_1.volume = Main_Menu_Sound_Volume;
    }

    // Method for Button
    public void Start_button_clicked()
    {
        Button_Sound_1.PlayOneShot(Button_Sound_1.clip);
        Menu_Panel_Main.SetActive(false);
        Menu_Panel_Credits.SetActive(false);
        Menu_how_To_Play.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void How_to_play_button_clicked()
    {
        Button_Sound_1.PlayOneShot(Button_Sound_1.clip);
        Menu_Panel_Main.SetActive(false);
        Menu_how_To_Play.SetActive(true);
        Menu_Panel_Credits.SetActive(false);
    }

    public void Credits_button_clicked()
    {
        Button_Sound_1.PlayOneShot(Button_Sound_1.clip);
        Menu_Panel_Main.SetActive(false);
        Menu_Panel_Credits.SetActive(true);
        Menu_how_To_Play.SetActive(false);
    }

    public void Back_button_clicked()
    {
        Button_Sound_1.PlayOneShot(Button_Sound_1.clip);
        Menu_Panel_Main.SetActive(true); 
        Menu_Panel_Credits.SetActive(false);
        Menu_how_To_Play.SetActive(false);
    }
}
