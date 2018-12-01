using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{

    [SerializeField]
    float dashForce;
    [SerializeField]
    float durationVar = 0.1f;
    float dashDuration = 0.1f;
    [SerializeField]
    float varCD;
    float dashCoolDown = 5f;
    [SerializeField]
    bool canDash;
    Rigidbody2D playerRb;
    CharacterController2D playerController;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<CharacterController2D>();
        varCD = dashCoolDown;
        durationVar = dashDuration;
        canDash = true;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E) && canDash)
        {
            if (playerController.m_FacingRight == true)
            {
                playerRb.AddForce(transform.right * dashForce);
            }
            else
            {
                playerRb.AddForce(-transform.right * dashForce);
            }
            durationVar -= Time.deltaTime;
            if (durationVar < 0)
            {
                canDash = false;
                durationVar = dashDuration;
            }
        }

        if (canDash == false)
        {
            varCD -= Time.deltaTime;
            if (varCD <= 0)
            {
                canDash = true;
                varCD = dashCoolDown;

            }
        }
    }
}
