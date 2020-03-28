using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBullet : MonoBehaviour
{
    public TargetTag targetTag;
    public TargetTag targetTag2;

    public Transform Target;

    public CapsuleCollider Detection;
    public float MaxDetection;
    public float DetectionSpeed;


    public float detectTimer = 1f;

    public bool DetectOn = false;


    private NavMeshAgent myNavMeshAgent;

    public string TagTarget;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<CapsuleCollider>() != null)
        {
            Detection = GetComponent<CapsuleCollider>();
        }

       

        myNavMeshAgent = GetComponent<NavMeshAgent>();
        //GetComponent<NavMeshAgent>().speed = 10;

        TagTarget = targetTag.ToString();

    }

    void Detect()
    {
        DetectOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("Detect", detectTimer, detectTimer);


        if (DetectOn == true)
        {
            GetComponent<CapsuleCollider>().radius += DetectionSpeed;

        }

        if (GetComponent<CapsuleCollider>().radius >= MaxDetection)
        {
            DetectOn = false;

            GetComponent<CapsuleCollider>().radius = 0;

            Enemys.Clear();
        }





        if (Enemys[0] != null)
        {
            if (myNavMeshAgent.enabled == true)
            {
                myNavMeshAgent.SetDestination(Enemys[0].position);


            }


        }

        if (Enemys[0] == null)
        {
            Enemys.RemoveAt(0);
        }



    }

    public List<Transform> Enemys;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString() || other.gameObject.tag == targetTag2.ToString())
        {
            

            Enemys.Add(other.gameObject.transform);

            gameObject.GetComponent<NavMeshAgent>().enabled = true;
        }

        else if (Target = null)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;

            

        }
    }

}

