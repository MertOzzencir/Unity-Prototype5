using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody rb;
    public static bool stopVelocityForAll=false;
    public static Vector2 difValues;
    public ParticleSystem explosion;
    Spawner spawner;
    public bool canLose;
    public bool canStopSpawn;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawner = FindAnyObjectByType<Spawner>();
        rb.AddForce(Vector3.up * RandomForce(difValues.x,difValues.y), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }

    private void Update()
    {
        if (stopVelocityForAll)
        {
            canStopSpawn = true;
            rb.velocity = Vector3.zero;
        }
    }
    public float RandomForce(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }
    int RandomTorque()
    {
        return UnityEngine.Random.Range(-15, 15);
    }
    private void OnMouseDown()
    {
        if(gameObject.tag == "Bad")
        {
            spawner.ShowGameOver();
            stopVelocity();
            ParticleSystem pS = Instantiate(explosion, transform.position, Quaternion.identity);
            pS.Play();
            Destroy(gameObject);
        }
        else
        {
            Spawner.instance.score++;
            ParticleSystem pS = Instantiate(explosion, transform.position, Quaternion.identity);
            pS.Play();
            Destroy(gameObject);
        }
      
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (canLose)
        {
            spawner.ShowGameOver();
            stopVelocity();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void stopVelocity()
    {
        stopVelocityForAll = true;
        Spawner.instance.canStop = true;
    }
}
