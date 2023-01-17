using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float range = 3f; // The range at which the player can interact with the pickup
    public GameObject pickupPrompt; // The UI element that appears when the player is in range
    public GameObject interactionPrompt; // The UI element that appears when the player can interact with the pickup
    public GameObject interactionObject; // The object that the player interacts with

    private bool inRange = false; // Whether the player is currently in range of the pickup
    private bool interacting = false; // Whether the player is currently interacting with the pickup
    private Animator animator; // The animator component of the interaction object

    void Start()
    {
        animator = interactionObject.GetComponent<Animator>();
    }

    void Update()
    {
        // Create a ray from the center of the screen to the front
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Check if the ray hits the pickup collider
        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                inRange = true;
                pickupPrompt.SetActive(true); // Show the pickup prompt

                if (Input.GetKeyDown(KeyCode.E) && !interacting)
                {
                    StartInteraction();
                }
            }
        }
        else
        {
            inRange = false;
            pickupPrompt.SetActive(false); // Hide the pickup prompt
            StopInteraction();
        }

        if (interacting)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }

    void StartInteraction()
    {
        interacting = true;
        interactionPrompt.SetActive(true);
        animator.SetBool("IsOpen", true);
    }

    void StopInteraction()
    {
        interacting = false;
        interactionPrompt.SetActive(false);
        animator.SetBool("IsOpen", false);
    }

    void Interact()
    {
        // Code to handle interaction logic
        Debug.Log("Interacted with " + gameObject.name);
        StopInteraction();
        Destroy(gameObject);
    }
}
