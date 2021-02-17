using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("E_bound"))
        {
            MoveRight = !MoveRight;
        }
    }
}
