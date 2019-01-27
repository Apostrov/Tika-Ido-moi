using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavnoScript : MonoBehaviour
{
    public GameObject hero;
    public bool isTake = false;
    private bool _showGUI = false;
    private bool hasStones = false;
    public int ID;
    private SpriteRenderer _spriteRenderer;
    private GameObject[] _gameObjectsBin;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameObjectsBin = GameObject.FindGameObjectsWithTag("specBin");
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
            if (isTake)
            {
                if (hero.GetComponent<HeroInput>().TakeStone())
                {
                    if (hero.GetComponent<HeroInput>().GiveId(ID))
                    {
                        _spriteRenderer.color = Color.green;
                    }
                    else
                    {
                        foreach (var obj in _gameObjectsBin)
                        {
                            obj.GetComponent<SpriteRenderer>().color = Color.red;
                        }
                    }
                }
                else
                {
                    hasStones = false;
                }
            }
            else
            {
                hero.GetComponent<HeroInput>().AddStone();
                hasStones = true;
            }
            
        }
    }

    private void OnGUI()
    {
        GUIStyle ms = new GUIStyle(GUI.skin.label);
        ms.fontSize = 32;
        if (_showGUI)
        {
            if (isTake)
            {
                GUI.Label(new Rect(40, 20, 1000, 500), "Press E to GIVE one stone!", ms);
            }
            else
            {
                if (hasStones)
                {
                    GUI.Label(new Rect(40, 20, 1000, 500), "You already have ritual stones!", ms);
                }
                else
                {
                    GUI.Label(new Rect(40, 20, 1000, 500), "Press E to get ritual stones!", ms);
                }
                
            }
            
            
            
        }
    }
    
}
