using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trigger : MonoBehaviour
{
    private string triggerName;
    private delegate void PlayerScore(int score);
    private event PlayerScore addScore;
    private GameManager gm;
    private BallController ballController;

    void Start()
    {
        triggerName = this.gameObject.name;
        ballController = FindObjectOfType<BallController>();
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider col)
    {
        //check trigger for add player 1 score
        if (col.gameObject.tag == "Ball" && triggerName == "RightTrigger")
        {
            Destroy(col.gameObject);
            StartCoroutine(SpawnBallDelay(2));
            addScore += AddP1;
            addScore(1);
            addScore -= AddP1;
            gm.TouchCountP1(1);
        }

        //check trigger for add player 2 score
        if (col.gameObject.tag == "Ball" && triggerName == "LeftTrigger")
        {
            Destroy(col.gameObject);
            StartCoroutine(SpawnBallDelay(2));
            addScore += AddP2;
            addScore(1);
            addScore -= AddP2;
            gm.TouchCountP2(1);
        }
    }

    private IEnumerator SpawnBallDelay(float second)
    {
        yield return new WaitForSeconds(second);
        ballController.SpawnBall();
    }

    private void AddP1(int value)
    {
        gm.AddScoreP1(value);
    }

    private void AddP2(int value)
    {
        gm.AddScoreP2(value);
    }

    
}
