using UnityEngine;
using System.Collections;

public class bigPadlescirpt : MonoBehaviour {
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "racket")
        {
            Racket racket = other.GetComponent<Racket>();
            if(racket)
            {
                Destroy(gameObject);
                racket.BigRacket();
            }
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}