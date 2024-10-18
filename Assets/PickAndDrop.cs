using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndDrop : MonoBehaviour
{   
    public GameObject Camera;
    public float distance = 5;
    public bool canPickUp = false;
    public GameObject currentItem = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, distance))
            {
                if (hit.transform.tag == "Track")
                {
                    canPickUp = false;
                    currentItem.GetComponent<Rigidbody>().isKinematic = false;
                    currentItem.GetComponent<Collider>().isTrigger = false;
                    currentItem.transform.parent = null;
                    currentItem.transform.position = new Vector3(2.2f, 5f, -18f);
                    currentItem = null;
                }
                PickUp(hit.transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Drop();
        }
    }
    public void PickUp(Transform hit)
    {
        if (hit.tag == "Items")
        {
            if (canPickUp) Drop();
            currentItem = hit.gameObject;
            currentItem.GetComponent<Rigidbody>().isKinematic = true;
            currentItem.GetComponent<Collider>().isTrigger = true;
            currentItem.transform.parent = transform;
            currentItem.transform.localPosition = Vector3.zero;
            currentItem.transform.localEulerAngles = new Vector3(140f, 0, -30f);
            canPickUp = true;    
        }
        
       
    }
    void Drop()
    {
        canPickUp = false;
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem.GetComponent<Collider>().isTrigger = false;
        currentItem.transform.parent = null;
        currentItem = null;
        
    }
}
