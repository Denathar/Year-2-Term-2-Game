using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackActivation : MonoBehaviour
{
    public GameObject Enemys;
    public TargetTag targetTag;
    public TargetTag targetTag2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString() || other.gameObject.tag == targetTag2.ToString())
        {
            Enemys.GetComponent<EnemyAttackBehaviour>().EnemysAttacking = true;
        }
        
    }
}
