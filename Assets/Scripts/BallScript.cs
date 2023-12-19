using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] GameObject livesUI;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int lives;
    [SerializeField] int score;
    [SerializeField] GameManager gm;
    [SerializeField] BlockPool bp;
    [SerializeField] float speed;
    [SerializeField] float speedInc;
    [SerializeField] Vector2 startPos;
    [SerializeField] Color baseColor;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private int curLives;
    private bool isFuckingImmortal;
    void Start()
    {
        transform.position = startPos;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.velocity = new Vector2(0, -1);
        sr.color = baseColor;
        score = 0;
        curLives = lives;
        isFuckingImmortal = false;
    }

    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    void Update()
    {
        livesUI.GetComponent<TextMeshProUGUI>().text = "" + curLives;
        livesUI.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        scoreText.text = "Score: " + score;

        if (!sr.isVisible)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPos;
        rb.velocity = Vector2.zero;
        StartCoroutine("invFrames");
    }

    IEnumerator invFrames()
    {
        yield return new WaitForSeconds(2);
        rb.velocity = new Vector2(0, -1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (gm.isGameActive)
        {
            if (col.gameObject.name == "Block")
            {
                speed += speedInc;
                score += 100 + (50 * curLives);
                Destroy(col.gameObject);
                gm.spawnPowerup(col.transform.position);
                bp.blocks.Remove(col.gameObject);
                if (bp.blocks.Count == 0)
                {
                    gm.WonGame();
                }
            }
            else if (col.gameObject.CompareTag("Death") && !isFuckingImmortal)
            {
                curLives--;
                if (curLives <= 0)
                {
                    gm.EndGame();
                }
                else
                {
                    Respawn();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (gm.isGameActive)
        {
            if (col.gameObject.GetComponent<PowerupScript>() != null)
            {
                score += 300;
                col.gameObject.GetComponent<PowerupScript>().Activate();
            }
        }
    }

    public IEnumerator GodBall()
    {
        speed += 15;
        sr.color = Color.yellow;
        isFuckingImmortal = true;
        yield return new WaitForSeconds(5);
        speed -= 15;
        sr.color = baseColor;
        isFuckingImmortal = false;
    }
}
