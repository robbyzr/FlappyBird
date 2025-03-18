using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody2D rb;

    private Score score;

    private Vector2 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = FindAnyObjectByType<Score>();

        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //menerima input dari player
        if (Input.GetMouseButtonDown(0))
        {
           rb.velocity = Vector2.up * speed;
        }
        
    }

    private void FixedUpdate()
    {
        //mengatur rotasi objek berdasarkan kecepatan vertikal (Y)
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Flag"))
        {
            score.UpdateScore();
            GameManager.instance.Scoring();
        }
    }

    public void StartPos()
    {
        transform.position = initialPos;
        rb.velocity = Vector2.zero;
    }

}
