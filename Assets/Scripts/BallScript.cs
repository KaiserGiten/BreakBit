using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public float speed = 150.0f;
    public float maxSpeed = 250.0f;
    public float speedBoost = 2.0f;
    public GameObject Explosion;
    private Vector2 StartLocation;
	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        StartLocation = transform.position;
	}

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWitdh)
    {
        return ((ballPos.x - racketPos.x) / racketWitdh) * 2;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (speed < maxSpeed)
        {
            speed += speedBoost;
        }
        //System.Threading.Thread.Sleep(0015);
        if (col.gameObject.name == "racket")
        {
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * (speed);
        }
    }
    public void Die()
    {
        
        Destroy(gameObject);
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }
    public void StartBall()
    {
        transform.position = StartLocation;
    }
}
