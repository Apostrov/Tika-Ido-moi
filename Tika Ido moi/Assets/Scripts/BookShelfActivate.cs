using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfActivate : MonoBehaviour
{
    public bool shelfSaw = false;
    public GameObject door;
    
    private bool _showGUI = false;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnGUI()
    {
        if (_showGUI && !shelfSaw)
        {
            GUI.Label(new Rect(40, 20, 255, 50), "Press E to see the hidden path");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _showGUI = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        _showGUI = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!shelfSaw)
            {
                _audio.Play();
                door.GetComponent<DoorOpen>().OpenDoor();
            }
            shelfSaw = true;
        }
    }
}
