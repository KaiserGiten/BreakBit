using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        multiPowerup multipowerup = other.GetComponent<multiPowerup>();
        if(multipowerup)
        {
            multipowerup.Die();
        }
        BallScript ballScript = other.GetComponent<BallScript>();
        if(ballScript)
        {
            //ballScript.StartBall();
            ballScript.Die();
        }
        bigPadlescirpt bigpadle = other.GetComponent<bigPadlescirpt>();
        if(bigpadle)
        {
            bigpadle.Die();
        }
    }
}
