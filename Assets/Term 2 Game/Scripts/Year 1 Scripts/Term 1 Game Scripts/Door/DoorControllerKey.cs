using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerKey : MonoBehaviour
{
    public bool islocked;
    public Animator animator;
    bool isOpen;
    bool interactable = false;
    public string key;
    HUD hud;
    public string Lockmessage;
    public string Unlockmessage;
    public AudioSource Open;
    public AudioSource Close;


    private void OnTriggerEnter(Collider other)
    {
        interactable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        interactable = false;
    }

    // Use this for initialization
    void Start ()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(interactable == true && Input.GetKeyDown("e"))
        {
            

            if(islocked)
            {
                PlayerInventory inventoryReferance =
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

                if (inventoryReferance.InventoryList.Contains(key))
                {
                    islocked = false;
                    Open.Play();
                    hud.ClearToolTip();
                    hud.SetToolTip(Unlockmessage);
                }
                else
                {
                    hud.ClearToolTip();
                    hud.SetToolTip(Lockmessage);
                    return;
                }
              

            }

            hud.ClearToolTip();
            hud.SetToolTip(Unlockmessage);
            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);
            Close.Play();

        }
	}
}
