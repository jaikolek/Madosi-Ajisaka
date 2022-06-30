using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    [SerializeField] private Question[] question;
    [SerializeField] private Task task;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < question.Length; i++)
            {
                if (task.checkTaskClear())
                {
                    Time.timeScale = 0f;
                    task.stopBacksound();
                    task.activeWinPanel();
                }
            }
        }
    }
}
