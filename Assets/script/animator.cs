using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator : MonoBehaviour
{
    Animator anima;

    private void Awake()
    {
        anima = GetComponent<Animator>();
    }

    void Update()
    {
        bool isWalking = Input.GetKey(KeyCode.W);
        bool isWalkingBack = Input.GetKey(KeyCode.S);
        bool isWalkingLeft = Input.GetKey(KeyCode.A);
        bool isWalkingRight = Input.GetKey(KeyCode.D);

        anima.SetBool("walk", isWalking);
        anima.SetBool("walkback", isWalkingBack);
        anima.SetBool("leftwalk", isWalkingLeft);
        anima.SetBool("rightwalk", isWalkingRight);

        
        bool isIdle = !isWalking && !isWalkingBack && !isWalkingLeft && !isWalkingRight;
        anima.SetBool("idle", isIdle);
    }
}
