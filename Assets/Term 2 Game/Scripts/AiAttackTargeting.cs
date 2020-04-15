using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackTargeting : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public int AttackingPoint;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Player.transform.position.x, gameObject.transform.position.y, Player.transform.position.z);

        

        AttackingPoint = Enemy.GetComponent<NavMesh>().AttackDestPoint;

        if (AttackingPoint == 0)
        {
            transform.LookAt(Enemy.transform);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

        
    }
}
