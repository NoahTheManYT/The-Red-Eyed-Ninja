using UnityEngine;

public class Alarm : MonoBehaviour
{
    public GameObject door;  // drag the door object into this field in the inspector
    public GameObject powerSource;  // drag the power source object into this field in the inspector
    public bool doorIsLocked = true;

    void Update()
    {
        if (powerSource.activeInHierarchy && Input.GetKeyDown(KeyCode.E))  // check if the power source is active and the player presses the "E" key
        {
            doorIsLocked = false;  // unlock the door
        }

        if (doorIsLocked)  // check if the door is locked
        {
            door.GetComponent<BoxCollider2D>().enabled = false;  // disable the door's collider
        }
        else
        {
            door.GetComponent<BoxCollider2D>().enabled = true;  // enable the door's collider
        }
    }
}
