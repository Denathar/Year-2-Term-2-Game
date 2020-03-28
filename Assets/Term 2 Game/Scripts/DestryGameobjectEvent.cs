using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryGameobjectEvent : MonoBehaviour
{

    public void GameObjectDestroy()
    {
        Destroy(gameObject);
    }
}
