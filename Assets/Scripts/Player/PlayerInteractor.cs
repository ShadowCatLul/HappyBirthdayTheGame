using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}


public class PlayerInteractor : MonoBehaviour
{
    

    public Camera cam;

    private GameObject heldObj;
    public GameObject player;
    private Rigidbody heldObjRb;

    public Transform holdPos;
    private float rotationSensitivity = 1f;
    public float InteractorRange;
    private bool canDrop = true;
    public float throwForce = 500f;
    private int LayerNumber;
    private void Start()
    {
        LayerNumber = LayerMask.NameToLayer("Holding");
    }

    void FixedUpdate()
    {
        Invoke(nameof(Interact),1);
    }

    private void Interact()
    {
        if (heldObj == null)
            if (Input.GetKeyDown(KeyCode.E))
            {
                Ray r = new Ray(cam.transform.position, cam.transform.forward * InteractorRange);
                Debug.DrawRay(cam.transform.position, cam.transform.forward * InteractorRange, Color.blue);
                Debug.Log(heldObj);

                    if (Physics.Raycast(r, out RaycastHit hitInfo, InteractorRange))
                    {
                        if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                        {
                            interactObj.Interact();
                        }

                        if (hitInfo.transform.gameObject.tag == "Pickable")
                        {
                            Debug.Log("BeforePick");
                            PickUpObject(hitInfo.transform.gameObject);
                        }
                    }
            }

        if (heldObj != null) 
        {
            MoveObject(); 
            
            if (Input.GetKeyDown(KeyCode.Mouse0) &&
                canDrop == true) 
            { 
                StopClipping(); 
                ThrowObject();
            }
            
        }
        
    }
 void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) 
        {
            heldObj = pickUpObj; 
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); 
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; 
            heldObj.layer = LayerNumber; 
            
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);

        }
    }

    void MoveObject()
    {
        //keep object position the same as the holdPosition position
        heldObj.transform.position =holdPos.transform.position;
    }

    void ThrowObject()
    {

        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
    }
    void StopClipping() 
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); 

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);

        if (hits.Length > 1)
        {
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); 
            
        }
    }
    

}

