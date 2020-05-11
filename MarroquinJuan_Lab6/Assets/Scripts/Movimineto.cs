using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimineto : MonoBehaviour
{
    private Rigidbody2D Rgb2d;
    public float velocidadCaminar = 5;
    public float velocidadSalto = 5;
    private bool powerUp;
    // Start is called before the first frame update
    void Start()
    {
        Rgb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Jump")))
        {
            jump();
        }
        Vector3 newScale = transform.localScale;
        if(Input.GetAxis("Horizontal")> 0.0f){
            newScale.x = -1.0f;
        }
        else if(Input.GetAxis("Horizontal") < 0.0f){
             newScale.x = 1.0f;
        } 
        transform.localScale = newScale;
    }
    private void FixedUpdate()
    {
        if(Rgb2d){
            Rgb2d.AddForce(new Vector2(Input.GetAxis("Horizontal")* velocidadCaminar ,0));
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // para coger el hongo
        if(other.CompareTag("PowerUp"))
        {
            powerUp = true;
            Destroy(other.gameObject);
        }
        // para matar al enemigo
        {
         if (other.gameObject.CompareTag("Malo")) 
         {
             if (powerUp)
             {
                 Destroy(other.gameObject);
             }
            else
            {
                Destroy(gameObject);
            }
        }
    }

        
    }
    void jump()
    {
        if(Rgb2d)
        {
            if(Mathf.Abs(Rgb2d.velocity.y)< 0.05f)
            {
                Rgb2d.AddForce(new Vector2(0,velocidadSalto), ForceMode2D.Impulse);
            }
        }

    }
}
