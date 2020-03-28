using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroy : MonoBehaviour
{
    public TargetTag targetTag;
    public TargetTag targetTag2;

    public bool Trigger;
    public bool TriggerChild;
    public bool Contact;
    public bool DeleteParent;
    public bool GiveScore;
    public int ScoreValue;


    private void OnCollisionEnter(Collision other)
    {
        if (Contact == true)
        {
            if (other.gameObject.tag == targetTag.ToString())
            {
                Destroy(gameObject);

                if (GiveScore == true)
                {
                    GameObject.Find("ScoreManger").GetComponent<ScoreManager>().AddToScore(ScoreValue);
                }
            }
        }

        if (DeleteParent == true)
        {
            Destroy(transform.parent.gameObject);

            if (GiveScore == true)
            {
                GameObject.Find("ScoreManger").GetComponent<ScoreManager>().AddToScore(ScoreValue);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag.ToString())
        {
            if (Trigger == true)
            {
                Destroy(gameObject);

                if (GiveScore == true)
                {
                    GameObject.Find("ScoreManger").GetComponent<ScoreManager>().AddToScore(ScoreValue);
                }
            }

            if (TriggerChild == true)
            {
                if (other.gameObject.tag == targetTag2.ToString())
                {
                    Destroy(gameObject);

                    if (GiveScore == true)
                    {
                        GameObject.Find("ScoreManger").GetComponent<ScoreManager>().AddToScore(ScoreValue);
                    }
                }

            }

            if (DeleteParent == true)
            {
                Destroy(transform.parent.gameObject);

                if (GiveScore == true)
                {
                    GameObject.Find("ScoreManger").GetComponent<ScoreManager>().AddToScore(ScoreValue);
                }
            }

        }



    }

}
