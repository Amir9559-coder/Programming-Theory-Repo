using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForward : MonoBehaviour
{
    private float speed = 10;
    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }
    void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    //MovingForward script just attached to foods so easly i can code Boundaries for foods here.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bound"))
        {
            Destroy(gameObject);
        }
    }
}
