using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    public float speed;
    public int score;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            score++;
        }
        else if (collision.gameObject.tag == "Object")
        {
            score = 0;
        }
    }
}

