using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera Camera;

    [SerializeField] private float distance;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        Camera = GetComponent<PlayerLookController>().Camera;   
    }

     private void Update()
    {
        PlayerRay();
    }

    private void PlayerRay()
    {
        PlayerUIManager.Instance.UpdateText(string.Empty);

        // create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(Camera.transform.position, Camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        //varibale to store collision information
        RaycastHit raycastHit;
        
        if(Physics.Raycast(ray, out raycastHit , distance , layerMask))
        {
      
            if (raycastHit.collider.GetComponent<Intractable>() != null)
            {
                Intractable intractable = raycastHit.collider.GetComponent<Intractable>();
                PlayerUIManager.Instance.UpdateText(intractable.promptMessage);

                if (InputManager.Instance.onFootActions.Interact.triggered)
                {
                    intractable.BaseIntract();
                }
            }
        }
    }
}
