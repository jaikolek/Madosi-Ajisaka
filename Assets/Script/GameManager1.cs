using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    //  Time.timeScale = 0f; = stop time in game
    //  game object
    [SerializeField] private Player player;
    [SerializeField] private Relic[] listQuestion;
    [SerializeField] private Task task;
    [SerializeField] private Gate gate;
    [SerializeField] private Stone[] stone;

    void Start()
    {
        Time.timeScale = 1f;
        TaskList.setDefaultCount();
    }

    void Update()
    {
        //player.Move_by_keyboard();
        task.execute();
        player.Move_by_UI();
        player.Check_in_ground();

        for (int i = 0; i < listQuestion.Length; i++) listQuestion[i].flashback();
    }
}
