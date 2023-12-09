using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private int speed = 12;
    [SerializeField] private int speedIncrement = 1;
    [SerializeField] private float timer = 5f;
    private float fixedTimer;
    private Rigidbody2D rb;

    public int Speed { get => speed; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fixedTimer = timer;
    }

    void FixedUpdate()
    {
        // move every frame
        transform.position += new Vector3(speed * 0.01f, 0, 0);

        // increase speed by [speedIncrement] every [timer] seconds
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            speed += speedIncrement;
            timer = fixedTimer;
        }
    }
}
