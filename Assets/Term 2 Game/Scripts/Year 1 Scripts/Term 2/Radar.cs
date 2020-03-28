using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Radar : MonoBehaviour
{
    public TargetTag targetTag;
    public TargetTag targetTag2;

    public Transform Target;

    public SphereCollider Detection;

    public float MaxDetection;
    public float MinDetection;

    public float DetectionSpeed;


    public float detectTimer = 1f;

    public bool DetectOn = false;

    public bool PulseOn;

    public string TagTarget;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<SphereCollider>() != null)
        {
            Detection = GetComponent<SphereCollider>();
        }


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

        if (PulseOn == true)
        {
            if (DetectOn == true)
            {
                GetComponent<SphereCollider>().radius += DetectionSpeed;

            }

            if (GetComponent<SphereCollider>().radius >= MaxDetection)
            {
                DetectOn = false;

                GetComponent<SphereCollider>().radius = MinDetection;

                Enemys.Clear();
            }
        }

        if (Enemys[0] != null)
        {
 
            Target = (Enemys[0].transform);

            SendMessageUpwards("RadarInput", Target);

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
            if (gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
            {

                gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;

            }

            Enemys.Add(other.gameObject.transform);
        }

        else if (Target = null)
        {
            

            if (gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
            {
                gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            }

        }
    }

}

