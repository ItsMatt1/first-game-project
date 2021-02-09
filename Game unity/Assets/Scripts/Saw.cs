using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float Speed;
    public float moveTime;

    private bool dirRight = true;
    private float Timer;

    // Update is called once per frame
    void Update()
    {
        if(dirRight)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }

        Timer += Time.deltaTime;

        if(Timer >= moveTime)
        {
            dirRight = !dirRight;
            Timer = 0f;
        }
    }
}
