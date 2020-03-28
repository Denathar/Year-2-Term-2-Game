using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public string itemName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerInventory invetoryReference = 
                other.gameObject.GetComponent<PlayerInventory>();

            //Error checking
            if (invetoryReference == null)
            {
                return;
            }

            invetoryReference.InventoryList.Add(itemName);


            Invoke("Destroy", 1);
            

        }
    }

    void Destroy()
    {
        Destroy(gameObject);
        CancelInvoke();
    }


}
