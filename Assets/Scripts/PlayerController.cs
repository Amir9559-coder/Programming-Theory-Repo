using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected void MovePlayer(float speed , float rotationSpeed)
    {
        if(GameManager.instance.isGameOver == false)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * Time.deltaTime * vertical * speed);
            transform.Rotate(Vector3.up * Time.deltaTime * horizontal * rotationSpeed);
        }
    }
    protected abstract void Boundary();
    protected void ControllAnimation(Animator playerAnim)
    {
        if(horizontal == 0 && vertical == 0)
        {
            playerAnim.SetFloat("Speed_f", 0.0f);
        }
        else
        {
            playerAnim.SetFloat("Speed_f", 0.5f);
        }
    }
}
