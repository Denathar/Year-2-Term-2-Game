using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Event_Trigger : MonoBehaviour
{
    //public string targetTag;
    //public string eventType;
    public EventTypes _eventType;
    public TargetTag targetTag;

    List<Transform> Enemys;

    private void OnCollisionEnter(Collision collision)
    {
        // every object with tag
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag.ToString());
        foreach (GameObject go in targets)
        {
            EventListener e = go.GetComponent<EventListener>();
            e.SendMessage(_eventType.ToString());
        }

        EventListener targetListener = 
            GameObject.FindGameObjectWithTag(targetTag.ToString()).GetComponent<EventListener>();

        //targetListener.OnDestroyEvent(); Spesific Event
       
        //targetListener.SendMessage(_eventType.ToString()); single target with tag
    }
}
