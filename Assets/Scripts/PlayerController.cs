using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    float horizontal;
    float vertical;
    protected AudioSource audioPlayer;
    [SerializeField] FixedJoystick joyStick;
    [SerializeField] Rigidbody playerRb;
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
            
            //for JOYSTICK:
            playerRb.velocity = new Vector3(joyStick.Horizontal * speed, playerRb.velocity.y, joyStick.Vertical * speed);
            if(joyStick.Horizontal !=0 || joyStick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(playerRb.velocity);
                
            }
            
        }
    }
    protected abstract void Boundary();
    protected void ControllAnimation(Animator playerAnim)
    {
        if(GameManager.instance.isGameOver == true)
        {
            playerAnim.SetFloat("Speed_f", 0.0f);
            playerRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationZ;
        }
        else if(joyStick.Horizontal != 0 || joyStick.Vertical !=0)
        {
            playerAnim.SetFloat("Speed_f", 0.5f);
        }
        
        else
        {
            playerAnim.SetFloat("Speed_f", 0.0f);
        }
    }
}
