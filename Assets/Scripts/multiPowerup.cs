using UnityEngine;
using System.Collections;

public class multiPowerup : MonoBehaviour
{

    public GameObject balls;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "racket")
        {
            Destroy(gameObject);
            GameObject pos = GameObject.FindWithTag("ball");
            Instantiate(balls, pos.GetComponent<Transform>().position, transform.rotation);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
