using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHold : MonoBehaviour
{
    public Transform Hand;
    public bool Right;
    public bool Left;
    public Transform handHoldL;
    public Transform handHoldR;
   
    void Update()
    {
        if (Left == true)
        {
            if (handHoldL != null)
            {
                handHoldL.position = Hand.position;
                handHoldL.LookAt(handHoldR);
            }
        }
        if (Right == true)
        {
            if (handHoldR != null)
            {
                handHoldR.position = Hand.position;
                handHoldR.LookAt(handHoldL);
            }
        }
        

        

        
        
    }
}
