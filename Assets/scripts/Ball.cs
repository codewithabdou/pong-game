using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float startSpeed = 10f;
    private float extraSpeed = 0.25f;
    private float maxExstraSpeed = 15f;
    public ScoreManager scoreManager;
    private bool player1PlaysFirst = true;

    private int hitCounter = 0;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
       
    }

    void RestartBall()
    {
        body.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }

    IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1);
        if(player1PlaysFirst) moveBall(new Vector2(-1, 0));
        else moveBall(new Vector2(1, 0));
    }

    void moveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float ballSpeed = startSpeed + extraSpeed * hitCounter;
        print("ball speed" + ballSpeed);
        body.velocity = ballSpeed * direction;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Rocket1") || collision.gameObject.CompareTag("Rocket2"))
        {
            Bounce(collision);
        }

        if(collision.gameObject.CompareTag("leftBorder") || collision.gameObject.CompareTag("rightBorder"))
        {
            if (collision.gameObject.CompareTag("leftBorder"))
            {
                player1PlaysFirst = false;
                StartCoroutine(Launch());
                scoreManager.IncreasePlayer2Score();
            }
            else
            {
                player1PlaysFirst = true;
                StartCoroutine(Launch());
                scoreManager.IncreasePlayer1Score();

            }

        }

    }

    private void Bounce(Collision2D collision)
    {
        Vector3 RocketPos = collision.transform.position;
        float rocketHeight = collision.collider.bounds.size.y;
        if(!(startSpeed + extraSpeed * (hitCounter+1)>maxExstraSpeed)) hitCounter++;

        if (collision.gameObject.CompareTag("Rocket1"))
        {
            moveBall(new Vector2(1, (transform.position.y - RocketPos.y) / rocketHeight));
        }

        if (collision.gameObject.CompareTag("Rocket2"))
        {
            moveBall(new Vector2(-1, (transform.position.y - RocketPos.y) / rocketHeight));
        }

    }

}
