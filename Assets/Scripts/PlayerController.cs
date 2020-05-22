using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string playerControl;
    [SerializeField]
    private float power, speed;
    [SerializeField]
    private List<float> lowerLimit, upperLimit;
    private float move, nextPost;
    [SerializeField]
    private KeyCode powerUp;
    private bool isScale;
    private Vector3 defaultScale;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = gameObject.transform.localScale;
        isScale = false;
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis(playerControl) * speed * Time.deltaTime;
        nextPost = transform.position.z + move;

        if (!isScale && nextPost > upperLimit[0])
        {
            move = 0;
        }

        if (isScale && nextPost > upperLimit[1])
        {
            move = 0;
        }

        if (!isScale && nextPost < lowerLimit[0])
        {
            move = 0;
        }

        if (isScale && nextPost < lowerLimit[1])
        {
            move = 0;
        }

        //power up boos player 1
        if (Input.GetKeyUp(powerUp) && !isScale && gm.GetScaleP1() > 0  && playerControl == "Player1Control")
        {
            gm.ReduceScaleP1(1);
            PaddleScale();
            StartCoroutine(ITimeUp(10));
        }

        //power up boos player 2
        if (Input.GetKeyUp(powerUp) && !isScale && gm.GetScaleP2() > 0 && playerControl == "Player2Control")
        {
            gm.ReduceScaleP2(1);
            PaddleScale();
            StartCoroutine(ITimeUp(10));
        }

        transform.Translate(0f, 0f, move);      
    }

    private void PaddleScale()
    {
        isScale = true;
        gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, new Vector3(1f, 1f, 3f));
    }

    private void DefaultScale()
    {
        isScale = false;
        gameObject.transform.localScale = Vector3.Scale(new Vector3(1f, 1f, 1f), defaultScale);
    }

    //waktu power up raket 10 second
    private IEnumerator ITimeUp(float second)
    {
        yield return new WaitForSeconds(second);
        DefaultScale();
    }
}
