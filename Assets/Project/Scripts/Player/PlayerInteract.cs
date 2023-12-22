using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface IInteractable
{ 
    public void Interact();
}
public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public float InteractorRange=10;


    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    private void Interact()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * InteractorRange*Time.deltaTime, Color.blue);
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray r = new Ray(cam.transform.position, cam.transform.forward * InteractorRange*Time.deltaTime);
            Debug.DrawRay(cam.transform.position, cam.transform.forward * InteractorRange*Time.deltaTime, Color.green);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractorRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        } 
    }
    
    
    
}
