using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private bool _showGUI;
    private Animator _animator;
    private BoxCollider _boxCollider;
    private ManySongs _manySongs;
    
    // public GameObject hero;
    public bool isClosed = false;
    
    private void Start()
    {
        _showGUI = false;
        _animator = GetComponentInChildren<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
        _manySongs = GetComponent<ManySongs>();
    }
    private void OnGUI()
    {
        if (_showGUI)
        {
            GUIStyle ms = new GUIStyle(GUI.skin.label);
            ms.fontSize = 32;
            GUI.Label(new Rect(40, 20, 1000, 500), "Press E to open door", ms);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _showGUI = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isClosed)
            {
                _manySongs.playSound();
            }
            else
            {
                _animator.SetBool("Open", !_animator.GetBool("Open"));
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _showGUI = false;
    }

    private void changeColider()
    {
        _boxCollider.enabled = !_animator.GetBool("Open");
    }

    public void OpenDoor()
    {
        isClosed = false;
    }
}
