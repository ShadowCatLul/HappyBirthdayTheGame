using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerPick : MonoBehaviour
{

    public Camera cam;

    private GameObject heldObj;
    public GameObject player;
    private Rigidbody heldObjRb;

    public Transform holdPos;
    
    public float pickUpRange;
    
    public float throwForce = 500f;
    private int LayerNumber;
    private void Start()
    {
        LayerNumber = LayerMask.NameToLayer("Holding");
    }

    private void Update()
    {
        if (heldObj == null)
            if (Input.GetKey(KeyCode.E))
            {
                Ray r = new Ray(cam.transform.position, cam.transform.forward * pickUpRange*Time.deltaTime);
                Debug.DrawRay(cam.transform.position, cam.transform.forward * pickUpRange*Time.deltaTime, Color.blue);
                Debug.Log(heldObj);

                    if (Physics.Raycast(r, out RaycastHit hitInfo, pickUpRange))
                    {

                        if (hitInfo.transform.gameObject.CompareTag("Pickable"))
                        {
                            Debug.Log("BeforePick");
                            PickUpObject(hitInfo.transform.gameObject);
                        }
                    }
            }

        if (heldObj != null) 
        {
            MoveObject(); 
            
            if (Input.GetKeyDown(KeyCode.Mouse0)) 
            { 
               
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

        }
    }

    void MoveObject()
    {
        //keep object position the same as the holdPosition position
        heldObj.transform.position = holdPos.transform.position;
    }

    void ThrowObject()
    {
        heldObj.layer = 0;
        heldObjRb.isKinematic = false; 
        heldObj.transform.parent = null;
        heldObjRb.AddForce(player.transform.forward * throwForce);
        heldObj = null;
    }
   

}

