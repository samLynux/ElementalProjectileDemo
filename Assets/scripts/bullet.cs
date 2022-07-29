using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject explosion;
    public float speed = 1000f;

    Vector3 lastVelocity;

    public int hp = 3;

    public string element;


    Rigidbody2D rb;

    GameObject trail;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // rb.AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    public void launched()
    {
        if (element == "water")
        {
            trail = ObjectPool.SharedInstance.GetWaterTrailObject();
            if (trail != null)
            {
                trail.transform.position = transform.position;
                trail.transform.rotation = transform.rotation;
                trail.transform.parent = transform;
                trail.SetActive(true);
            }
        }


        hp = 3;
        rb.AddForce((transform.up + transform.right) * speed);
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        hp--;
        if (hp <= 0)
        {
            if (element == "water" && trail != null)
            {
                trail.GetComponent<explosion>().particleEvent();
                trail.transform.parent = null;
            }
            else if (element == "earth")
            {
                GameObject explosion = ObjectPool.SharedInstance.GetEarthExplosionObject();
                if (explosion != null)
                {
                    explosion.transform.position = transform.position;
                    explosion.transform.rotation = transform.rotation;
                    explosion.SetActive(true);
                    explosion.GetComponent<explosion>().particleEvent();
                }
            }

            gameObject.SetActive(false);
        }



        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);

        // rb.velocity = direction * Mathf.Max(speed, 0f);

        if (element != "earth")
        {
            rb.velocity = direction * Mathf.Max(speed, 0f);
        }
        else
        {
            rb.velocity = direction * Mathf.Max(speed / 2, 0f);
        }

        if (element == "fire")
        {
            GameObject explosion = ObjectPool.SharedInstance.GetFireExplosionObject();
            if (explosion != null)
            {
                explosion.transform.position = transform.position;
                explosion.transform.rotation = transform.rotation;
                explosion.SetActive(true);
                explosion.GetComponent<explosion>().particleEvent();
            }
        }
        else if (element == "water")
        {
            GameObject explosion = ObjectPool.SharedInstance.GetWaterExplosionObject();
            if (explosion != null)
            {
                explosion.transform.position = transform.position;
                explosion.transform.rotation = transform.rotation;
                explosion.SetActive(true);
                explosion.GetComponent<explosion>().particleEvent();
            }
        }




    }



}
