using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavnoScript : MonoBehaviour
{
    public GameObject hero;
    public bool isTake = false;
    private bool _showGUI = false;
    public int ID;

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
            if (isTake)
            {
                if (hero.GetComponent<HeroInput>().TakeStone())
                {
                    hero.GetComponent<HeroInput>().GiveId(ID);
                }
            }
            else
            {
                hero.GetComponent<HeroInput>().AddStone();
            }
            
        }
    }

    private void OnGUI()
    {
        if (_showGUI)
        {
            if (isTake)
            {
                GUI.Label(new Rect(40, 20, 255, 50), "Press E to TAKE one stone!");
            }
            else
            {
                GUI.Label(new Rect(40, 20, 255, 50), "Press E to get ONE STONE!");
            }
            
        }
    }
    
}
