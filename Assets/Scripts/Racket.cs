using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {
    private int Maxsize = 0;
    public int MaxSizePickup = 1;
    void Start ()
    {
    }
    //Movement Speed
    public float speed = 150;

    // Update is called once per frame
    void FixedUpdate ()
    {
        // Get Horizontal Input
        float h = Input.GetAxisRaw("Horizontal");

        //Set Velocity(Movement direction * speed)
        GetComponent<Rigidbody2D>().velocity = new Vector2(1,0) * h * speed;
	}
    
    public void BigRacket()
    {
        if (Maxsize < MaxSizePickup)
        {
            transform.localScale += new Vector3(0.5F, 0, 0);
            Maxsize += 1;
        }
    }
}
