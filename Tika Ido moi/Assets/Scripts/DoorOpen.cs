using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private bool _showGUI;
    private Animator _animator;
    private BoxCollider _boxCollider;
    public GameObject hero;
    
    private void Start()
    {
        _showGUI = false;
        _animator = GetComponentInChildren<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
    }
    private void OnGUI()
    {
        if (_showGUI)
        {
            GUI.Label(new Rect(40, 20, 255, 50), "Press E to open door");
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
            _animator.SetBool("Open", !_animator.GetBool("Open"));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.GetType());
        _showGUI = false;
    }

    private void changeColider()
    {
        _boxCollider.enabled = !_animator.GetBool("Open");
    }
}
