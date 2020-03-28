using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NavMeshEnemy : MonoBehaviour
{
    public Transform Player;

    private NavMeshAgent myNavMeshAgent;

    private Rigidbody myRigidBody;

    public float EnemySpeed = 5.0f;

    public float EnemyAcceleration = 8.0f;


    public float Originalspeed;

    public bool isSlowed;

    public float SlowDuration;

    public Text Slowed;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;

        }
        

        myNavMeshAgent = GetComponent<NavMeshAgent>();

        myRigidBody = GetComponent<Rigidbody>();

        Originalspeed = EnemySpeed;

        GetComponent<NavMeshAgent>().speed = EnemySpeed;

        GetComponent<NavMeshAgent>().acceleration = EnemyAcceleration;
    }
    private void FixedUpdate()
    {
        LookAtPlayer();

        if (isSlowed == true)
        {
            Slowed.enabled = true;
            

        }
        if (isSlowed == false)
        {
            Slowed.enabled = false;
        }
    }

    

    private void LookAtPlayer()
    {
        if (Player != null)
        {
            Vector3 enemyToPlayer = Player.position - transform.position;

            enemyToPlayer.y = 0.0f;

            Quaternion newRotation = Quaternion.LookRotation(enemyToPlayer);

            myRigidBody.MoveRotation(newRotation);
        }
        

        
    }

    void Update()
    {
        if (Player != null)
        {
            if (myNavMeshAgent.enabled == true)
            {
                myNavMeshAgent.SetDestination(Player.position);
            }
        }

        if (isSlowed == true)
        {
            SlowDuration -= Time.deltaTime;
            if (SlowDuration < 0)
            {
                SlowEffectStop();
            }
        }
    }
    void SlowEffectDuration(int SlowDurationIn)
    {
        SlowDuration = SlowDurationIn;
    }
    void SlowEffect(int amount)
    {
        if (EnemySpeed > 0)
        {
            GetComponent<NavMeshAgent>().speed = amount;
            isSlowed = true;
        }

    }
    void SlowEffectStop()
    {
        GetComponent<NavMeshAgent>().speed = EnemySpeed;
        EnemySpeed = Originalspeed;
        isSlowed = false;
    }

    void lunge (float amount)
    {
        GetComponent<NavMeshAgent>().speed = amount;
        GetComponent<NavMeshAgent>().acceleration  = amount;
    }

    void lungeEnd()
    {
        GetComponent<NavMeshAgent>().speed = Originalspeed;
        GetComponent<NavMeshAgent>().acceleration = EnemyAcceleration;
    }
}
