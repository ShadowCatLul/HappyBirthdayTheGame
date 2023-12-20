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
    void FixedUpdate()
    {
        Invoke(nameof(Interact),1);
    }

    private void Interact()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Ray r = new Ray(cam.transform.position, cam.transform.forward * InteractorRange);
            Debug.DrawRay(cam.transform.position, cam.transform.forward * InteractorRange, Color.blue);
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
