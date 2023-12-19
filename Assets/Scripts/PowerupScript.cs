using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    [SerializeField] float increasedSpeed;
    [SerializeField] Vector3 biggerSize;
    [SerializeField] int index;
    [SerializeField] PlayerController pc;
    [SerializeField] BallScript bs;

    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        bs = GameObject.Find("Ball").GetComponent<BallScript>();
    }
    public void Activate()
    {
        switch (index)
        {
            case 1:
                pc.speed = increasedSpeed;
                pc.StartCoroutine("WaitOutPower", 5);
                break;
            case 2:
                pc.transform.localScale = biggerSize;
                pc.StartCoroutine("WaitOutPower", 5);
                break;
            case 3:
                bs.StartCoroutine("GodBall");
                break;
        }
        Destroy(gameObject);
    }

}
