using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 direction;

    public AudioClip onHitWall;
    public AudioClip onHitPlayer;

    public ParticleSystem collParticleSystem;

    AudioSource audioSource;
    public TrailRenderer tr;
    public float speed;

    [HideInInspector]
    public float currentSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = speed;

        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        tr = GetComponent<TrailRenderer>();

        do
        {
            direction = new Vector2(1, Random.Range(-2.0f, 2.0f));
        } while (Mathf.Abs(direction.y) < 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        collParticleSystem.Play();
        if (coll.gameObject.GetComponent<Jogador>())
        {
            audioSource.clip = onHitPlayer;

            direction.x = direction.x * -1;
            currentSpeed *= 1.3f;
        }
        else
        {
            audioSource.clip = onHitWall;
            direction.y = direction.y * -1;
        }
        audioSource.Play();
    }
}
