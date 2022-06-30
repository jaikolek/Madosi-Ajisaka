using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //  Variable 
    [SerializeField] private float Movement_Speed = 10f;
    [SerializeField] private float Jump_Power = 15f;
    [SerializeField] private int Double_Jump = 0;
    [SerializeField] private float Jump_hit;
    private int Jump_Count = 0;

    private float Movement_x;
    private float Jump_Cooldown;
    private bool Is_Ground = true;
    private bool Move_Right;
    private bool Move_Left;

    //  Component
    public LayerMask Ground_Layer;
    public Rigidbody2D Player_Rigidbody;
    public Transform Feet;
    public Animator Player_Animator;

    private void Start()
    {
        Move_Right = false;
        Move_Left = false;
    }

    // Move by keyboard
    public void Move_by_keyboard()
    {
        // Move
        Player_move_keyboard();

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        Player_Animator.SetFloat("Velocity_y", Player_Rigidbody.velocity.y);
    }

    public void Move_by_UI()
    {
        Player_move_UI();
        Player_Rigidbody.velocity = new Vector2(Movement_x, Player_Rigidbody.velocity.y);
    }

    // Move by UI
    public void Jump_button_clicked()
    {
        Jump();
    }

    public void Button_left_down()
    {
        Move_Left = true;
    }

    public void Button_left_up()
    {
        Move_Left = false;
    }

    public void Button_right_down()
    {
        Move_Right = true;
    }

    public void Button_right_up()
    {
        Move_Right = false;
    }

    // move and animation method
    private void Player_move_keyboard()
    {
        Movement_x = Input.GetAxisRaw("Horizontal");
        Player_Rigidbody.velocity = new Vector2(Movement_x * Movement_Speed, Player_Rigidbody.velocity.y);
        Flip_sprite();
        Player_Animator.SetFloat("Velocity_x", Mathf.Abs(Player_Rigidbody.velocity.x));
    }
    private void Player_move_UI()
    {
        if (Move_Left)
        {
            Movement_x = -Movement_Speed;
        }
        else if (Move_Right)
        {
            Movement_x = Movement_Speed;
        }
        else
        {
            Movement_x = 0;
        }

        Flip_sprite();
        Player_Animator.SetFloat("Velocity_x", Mathf.Abs(Player_Rigidbody.velocity.x));
    }

    private void Flip_sprite()
    {
        if (!Mathf.Approximately(0, Movement_x))
        {
            transform.rotation = Movement_x > 0 ? Quaternion.Euler(0, 0, 0) : Quaternion.identity;
            transform.rotation = Movement_x < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }

    private void Jump()
    {
        if (Is_Ground || Jump_Count < Double_Jump)
        {
            Player_Rigidbody.velocity = new Vector2(Player_Rigidbody.velocity.x, Jump_Power);
            Jump_Count++;
        }
    }

    public void Check_in_ground()
    {
        if (Physics2D.OverlapCircle(Feet.position, Jump_hit, Ground_Layer))
        {
            Is_Ground = true;
            Jump_Count = 0;
            Jump_Cooldown = Time.time + 0.2f;
        }
        else if (Time.time < Jump_Cooldown)
        {
            Is_Ground = true;
        }
        else
        {
            Is_Ground = false;
        }
        Player_Animator.SetBool("Jump", !Is_Ground);
    }
}
