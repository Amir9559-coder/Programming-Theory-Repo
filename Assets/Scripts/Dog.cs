using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : PlayerController
{
    private float speed = 10;
    private float rotationSpeed = 150;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(speed, rotationSpeed);
        ControllAnimation(playerAnim);
        Boundary();
    }
    protected override void Boundary()
    {
        int zBound = 12;
        int xBound = 12;
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        else if(transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if(transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Dog"))
        {
            if(GameManager.instance.isGameOver == false)
            {
                GameManager.instance.scoreInt += 10;
                Destroy(other.gameObject);
            }
        }
        else
        {
            if(GameManager.instance.isGameOver == false)
            {
                GameManager.instance.healthInt--;
                Destroy(other.gameObject);
            }
        }
    }
}
