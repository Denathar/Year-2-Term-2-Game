using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    public GameObject WolfAttackCollider;
    public Animator WolfAinmtor;
    public GameObject Behaviour;

    public Transform AiMoveTargets;
    public Transform AiAttackTargets;

    public List<Transform> MoveTargets;
    public List<Transform> AttackTargets;

    public int MoveDestPoint = 0;
    public int AttackDestPoint = 0;

    private NavMeshAgent myNavMeshAgent;

    public bool Attacking = false;

    public string AiMoveTargetsObject;
    public string AiAttackTargetsObject;


    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();


        AiMoveTargets = GameObject.Find(AiMoveTargetsObject).transform;
        AiAttackTargets = GameObject.Find(AiAttackTargetsObject).transform;
        Behaviour = GameObject.Find("Enemys");
        

        foreach (Transform child in AiMoveTargets)
        {
            MoveTargets.Add(child.transform);
        }
        foreach (Transform child in AiAttackTargets)
        {
            AttackTargets.Add(child.transform);
        }
        MoveDestPoint = Random.Range(0, MoveTargets.Count);

    }

    // Update is called once per frame
    void Update()
    {
        WolfAinmtor.SetBool("Attacking", Attacking);

        if (Attacking == false)
        {
            myNavMeshAgent.speed = 1;
            WolfAttackCollider.SetActive(false);
            

            if (MoveTargets != null)
            {
                if (myNavMeshAgent.enabled == true)
                {
                    myNavMeshAgent.destination = MoveTargets[MoveDestPoint].position;
                }
            }
            if (!myNavMeshAgent.pathPending && myNavMeshAgent.remainingDistance < 0.5f)
            {
                MoveDestPoint = Random.Range(0, MoveTargets.Count);
            }  
        }
        else
        {
            myNavMeshAgent.speed = 4;

            if (AttackTargets != null)
            {
                if (myNavMeshAgent.enabled == true)
                {
                    myNavMeshAgent.destination = AttackTargets[AttackDestPoint].position;
                }

            }

            if (!myNavMeshAgent.pathPending && myNavMeshAgent.remainingDistance < 0.5f)
            {
                AttackDestPoint = AttackDestPoint + 1;
                WolfAttackCollider.SetActive(true);
            }

            if (AttackDestPoint == AttackTargets.Count)
            {
                AttackDestPoint = 0;
                Attacking = false;
                EnemyAttackBehaviour.attackerIndex += 1;
    

                
            }

            
        }





    }


  

}

