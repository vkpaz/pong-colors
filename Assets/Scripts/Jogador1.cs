using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 movement;
    public int startArea;
    public float speed;

    private Touch touch;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
            Debug.Log(pos);
            if (pos.x < startArea)
            {
                Debug.Log("J1");
                rb.MovePosition(new Vector2(-8, pos.y * Time.fixedDeltaTime * speed));
            }
        }
    }
}
