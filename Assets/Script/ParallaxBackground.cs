using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    // Editor confirm
    [SerializeField] private bool Infinite_Horizontal;
    [SerializeField] private bool Infinite_Vertical;

    // variable
    [SerializeField] private Vector2 Parallax_Effect_Multiplier;
    private Transform Camera_Transform;
    private Vector3 Last_Camera_Position;
    private float Texture_Unit_Size_x;
    private float Texture_Unit_Size_y;

    void Start()
    {
        Camera_Transform = Camera.main.transform;
        Last_Camera_Position = Camera_Transform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        Texture_Unit_Size_x = texture.width / sprite.pixelsPerUnit;
        Texture_Unit_Size_y = texture.height / sprite.pixelsPerUnit;
    }

    void LateUpdate()
    {
        Vector3 Delta_Movement = Camera_Transform.position - Last_Camera_Position;
        transform.position += new Vector3(Delta_Movement.x * Parallax_Effect_Multiplier.x, Delta_Movement.y * Parallax_Effect_Multiplier.y);
        Last_Camera_Position = Camera_Transform.position;

        if (Infinite_Horizontal)
        {
            if (Mathf.Abs(Camera_Transform.position.x - transform.position.x) >= Texture_Unit_Size_x)
            {
                float Offset_Position_x = (Camera_Transform.position.x - transform.position.x) % Texture_Unit_Size_x;
                transform.position = new Vector3(Camera_Transform.position.x + Offset_Position_x, transform.position.y);
            }
        }

        if (Infinite_Vertical)
        {
            if (Mathf.Abs(Camera_Transform.position.y - transform.position.y) >= Texture_Unit_Size_y)
            {
                float Offset_Position_y = (Camera_Transform.position.y - transform.position.y) % Texture_Unit_Size_y;
                transform.position = new Vector3(Camera_Transform.position.x, transform.position.y + Offset_Position_y);
            }
        }
    }
}
