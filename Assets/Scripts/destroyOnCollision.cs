using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnCollision : MonoBehaviour
{

    public GameObject ball;
    public int hitPoints = 1;
    string ballName;

    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {

        if(ball != null)
        {
            ballName = ball.gameObject.name;
        }
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ballName)
        {
            hitPoints = hitPoints - 1;

            if (hitPoints <= 0)
            {
                if (destroyEffect != null)
                {
                    Instantiate(destroyEffect, transform.position, Quaternion.identity);
                }

                gameObject.SetActive(false);
            }
            

        }
    }

}
