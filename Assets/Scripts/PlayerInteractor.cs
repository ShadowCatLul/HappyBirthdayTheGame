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
    private int LayerNumber;
    public Camera cam;
    public float InteractorRange;
    private bool canDrop = true;
    private GameObject heldObj;
    private Rigidbody heldObjRb;
    public float throwForce = 500f;
    public GameObject player;
    public Transform holdPos;
    private float rotationSensitivity = 1f;
    // Update is called once per frame
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
            if (Input.GetKey(KeyCode.E))
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

        if (heldObj != null) //if player is holding object
        {
            MoveObject(); 
            RotateObject();
            
            if (Input.GetKeyDown(KeyCode.Mouse0) &&
                canDrop == true) //Mous0 (leftclick) is used to throw, change this if you want another button to be used)
            { 
                StopClipping(); 
                ThrowObject();
            }

            if (Input.GetKeyDown(KeyCode.E) && canDrop == true)
            {
                DropObject();
            }
        }
        
    }
 void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            heldObj = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); //assign Rigidbody
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
            heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }
    void DropObject()
    {
        //re-enable collision with player
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0; //object assigned back to default layer
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; //unparent object
        heldObj = null; //undefine game object
    }
    void MoveObject()
    {
        //keep object position the same as the holdPosition position
        heldObj.transform.position =holdPos.transform.position;
    }
    void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))//hold R key to rotate, change this to whatever key you want
        {
            canDrop = false; //make sure throwing can't occur during rotating

            //disable player being able to look around
            //mouseLookScript.verticalSensitivity = 0f;
            //mouseLookScript.lateralSensitivity = 0f;

            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;
            //rotate the object depending on mouse X-Y Axis
            heldObj.transform.Rotate(Vector3.down, XaxisRotation);
            heldObj.transform.Rotate(Vector3.right, YaxisRotation);
        }
        else
        {
            //re-enable player being able to look around
            //mouseLookScript.verticalSensitivity = originalvalue;
            //mouseLookScript.lateralSensitivity = originalvalue;
            canDrop = true;
        }
    }
    void ThrowObject()
    {
        //same as drop function, but add force to object before undefining it
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
    }
    void StopClipping() //function only called when dropping/throwing
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); //distance from holdPos to the camera
        //have to use RaycastAll as object blocks raycast in center screen
        //RaycastAll returns array of all colliders hit within the cliprange
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        //if the array length is greater than 1, meaning it has hit more than just the object we are carrying
        if (hits.Length > 1)
        {
            //change object position to camera position 
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); //offset slightly downward to stop object dropping above player 
            //if your player is small, change the -0.5f to a smaller number (in magnitude) ie: -0.1f
        }
    }
    

}

