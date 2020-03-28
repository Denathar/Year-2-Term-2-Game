using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public Transform player;
    //public float speed = 5.0f;
    //public float Originalspeed;

    //private Rigidbody myRigidBody;

    //bool isSlowed;
    //public float SlowDuration;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player").transform;

    //    myRigidBody = GetComponent<Rigidbody>();

    //    Originalspeed = speed;
    //}
    //private void FixedUpdate()
    //{
    //    LookAtPlayer();
    //    Move();
    //}
    //private void LookAtPlayer()
    //{
    //    Vector3 enemyToPlayer = player.position - transform.position;

    //    enemyToPlayer.y = 0.0f;

    //    Quaternion newRotation = Quaternion.LookRotation(enemyToPlayer);

    //    myRigidBody.MoveRotation(newRotation);
    //}
    //private void Move()
    //{
    //    Vector3 velocity = transform.forward * speed * Time.deltaTime;

    //    myRigidBody.MovePosition(myRigidBody.position + velocity);
    //}

    //void Update()
    //{

    //    if (isSlowed == true)
    //    {
    //        SlowDuration -= Time.deltaTime;
    //        if (SlowDuration < 0)
    //        {
    //            SlowEffectStop();
    //        }
    //    }
    //}
    //void SlowEffectDuration(int SlowDurationIn)
    //{
    //    SlowDuration = SlowDurationIn;
    //}
    //void SlowEffect(int amount)
    //{
    //    if (speed > 0)
    //    {
    //        speed = amount;
    //        isSlowed = true;
    //    }
        
    //}
    //void SlowEffectStop()
    //{
    //    speed = Originalspeed;
    //    isSlowed = false;
    //}
}
