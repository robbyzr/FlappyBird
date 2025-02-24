using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed =1f;
    [SerializeField] private float rotationSpeed = 10f;
    private Rigidbody2D rb;

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //menerima input dari player
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * speed;
        }
    }

    private void FixedUpdate() 
    {
        //mengatur rotasi objek berdasarkan kecepatan vertikal (Y)
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    //jika bertabrakan dengan obstacle maka game over
    void OnCollisionEnter2D(Collision2D other) 
    {
        GameManager.instance.GameOver();
    }

}
