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
        GUIStyle ms = new GUIStyle(GUI.skin.label);
        ms.fontSize = 32;
        if (_showGUI)
        {
            if (shelfSaw)
            {
                GUI.Label(new Rect(40, 20, 10000, 5000), "Some door opened", ms);
            }
            else
            {
                GUI.Label(new Rect(40, 20, 10000, 5000), "Press E to see the hidden path", ms);
            }
            
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
