using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private float interactDistance = 5.0f;

    private bool canInteract;

    private GameObject interactingGameObject;
    private string interactingObjectName;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("search", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            if (interactingObjectName == TagManager.lilin)
            {
                Inventory.inventory.AddItem(interactingObjectName);
                clearData();
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            if (interactingObjectName == TagManager.key)
            {
                Inventory.inventory.AddItem(interactingObjectName);
                clearData();
                return;
            }
        }
    }

    private void search()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Interactable") && hit.distance <= interactDistance)
        {
            canInteract = true;

                interactingObjectName = hit.collider.tag;
                interactingGameObject = hit.transform.gameObject;
        }
        else
        {
            canInteract = false;
            resetData();
        }
        //Debug.Log("Searching...");
    }

    void resetData ()
    {
        if (interactingGameObject == null) return;

        interactingObjectName = null;
        interactingGameObject = null;
    }

    void clearData()
    {
        if (interactingGameObject != null)
        {
            Destroy(interactingGameObject);
        }
        interactingGameObject = null;
        interactingObjectName = null;
    }
}
