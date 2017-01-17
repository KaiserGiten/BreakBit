using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    int PowerupPre;
    public GameObject PowerUp;
    public GameObject PowerUp2;
    public GameObject Explosion;
    public int Drop_Chance = 10;
    private Game othergame;
    void Start()
    {
        GameObject game = GameObject.FindWithTag("Game");
        othergame = game.GetComponent<Game>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        othergame.PlayAudio();
        Destroy(gameObject);
        Instantiate(Explosion, transform.position, transform.rotation);
        PowerupPre = Random.Range(0, Drop_Chance);
        if (PowerupPre == 0)
        {
            Instantiate(PowerUp, transform.position, transform.rotation);
        }
        if (PowerupPre == 1)
        {
            Instantiate(PowerUp2, transform.position, transform.rotation);
        }
        othergame.AddScore();
    }
}
