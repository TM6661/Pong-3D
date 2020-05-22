using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public AudioClip soundFX;
    [HideInInspector]
    public AudioSource audioSource;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float power;
    [SerializeField]
    private GameObject ballPrefab;
    private Rigidbody rb;
    private Vector3 ballPosition;
    private GameManager gm;
    private bool isCrash;
    

    // Start is called before the first frame update
    void Start()
    {
        ballPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        float randomDirection = Random.Range(-10f, 10f);
        Vector3 direction = new Vector3(randomDirection, 0f, 0f).normalized;
        rb.AddForce(power * direction);
        isCrash = false;
        gm = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isCrash)
        {
            MoveBall();
        }

    }

    private void MoveBall()
    {
        rb.velocity = speed * (rb.velocity.normalized);
    }

    private void OnCollisionEnter(Collision col)
    {
        audioSource.PlayOneShot(soundFX);
        if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2")
        {
            isCrash = true;

            float angle = (transform.position.z - col.transform.position.z) * 2f;
            Vector3 direction = new Vector3(rb.velocity.x, 0f, angle).normalized;
            rb.velocity = new Vector3(0f, 0f, 0f);
            rb.AddForce(power * direction * 2f);
        }

        isCrash = false;
    }

    public void SpawnBall()
    {
        Instantiate(ballPrefab, ballPosition, Quaternion.identity);
    }
}
