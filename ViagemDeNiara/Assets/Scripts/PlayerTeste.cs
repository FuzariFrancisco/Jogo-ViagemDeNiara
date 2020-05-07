using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeste : MonoBehaviour
{
    public float velocidade, forcaPulo;
    public Rigidbody2D corpoPlayer;
    private bool groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetButtonDown("Jump") && groundCheck == true)
        {
            groundCheck = false;
            corpoPlayer.AddForce(new Vector2(0, forcaPulo));
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TagChao"))
        {
            groundCheck = true;
        }
    }
}
