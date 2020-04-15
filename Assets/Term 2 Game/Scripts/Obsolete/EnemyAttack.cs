using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public TargetTag targetTag;
    public Animator AttackAnim;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            AttackAnim.enabled = true;
            AttackAnim.Play("Enemy Attack");
        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            AttackAnim.enabled = false;
            AttackAnim.Play("Enemy Nutral");
        }
    }
}
