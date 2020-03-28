using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{

    public List<Transform> EnemyTransform;

    public bool EnemysAttacking = false;

    public static int attackerIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyTransform.Count > 0)
        {
            if (EnemysAttacking == true)
            {
                if (EnemyTransform.Count > 0)
                {

                    if (attackerIndex >= EnemyTransform.Count)
                    {

                        attackerIndex = 0;

                    }



                    if (EnemyTransform[attackerIndex] != null)
                    {
                        EnemyTransform[attackerIndex].gameObject.GetComponent<NavMesh>().Attacking = true;
                    }
                    else
                    {
                        attackerIndex += 1;
                    }
                }
            }
            
            

            if (EnemyTransform[0] == null)
            {
                EnemyTransform.Clear();

                foreach (Transform child in transform)
                {
                    EnemyTransform.Add(child.transform);
                }
            }
        }
        


            
    }

    void AddEnemys()
    {
        foreach (Transform child in transform)
        {
            EnemyTransform.Add(child.transform);
        }
    }
    void RemoveEnemys()
    {
        EnemyTransform.Clear();
    }

}
