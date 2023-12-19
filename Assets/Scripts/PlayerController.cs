using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    [SerializeField] GameManager gm;
    [SerializeField] Vector3 baseSize;
    [SerializeField] float baseSpeed;
    [SerializeField] float maxX;
    private Rigidbody2D rb;

    void Start()
    {
        speed = baseSpeed;
        transform.localScale = baseSize;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(x, 0);

        if (gm.isGameActive)
        {
            rb.velocity = movement * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public IEnumerator WaitOutPower(float time)
    {
        yield return new WaitForSeconds(time);
        speed = baseSpeed;
        transform.localScale = baseSize;
    }
}
