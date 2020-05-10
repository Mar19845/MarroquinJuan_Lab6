using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimineto : MonoBehaviour
{
    private Rigidbody2D Rgb2d;
    public float num = 5;


    // Start is called before the first frame update
    void Start()
    {
        Rgb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newScale = transform.localScale;
        if(Input.GetAxis("Horizontal")> 0.0f){
            newScale.x = -5.0f;
        }
        else if(Input.GetAxis("Horizontal") < 0.0f){
             newScale.x = 5.0f;
        } 
    }
    private void FixedUpdate()
    {
        if(Rgb2d){
            Rgb2d.AddForce(new Vector2(Input.GetAxis("Horizontal")* num ,0));
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}
