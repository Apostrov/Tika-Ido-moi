using UnityEngine;

public class HeroSuperLight : MonoBehaviour
{
    public GameObject blackHole;
    public float decreasingSpeed = 10f;
    private Vector3 _orginScale = new Vector3(1f, 1f, 1f);
    
    void Start()
    {
        _orginScale = blackHole.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
        
        if (blackHole.transform.localScale.x > _orginScale.x)
        {
            var speed = 1 / decreasingSpeed * Time.deltaTime;
            blackHole.transform.localScale -= new Vector3(speed, speed, 0);
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            blackHole.transform.localScale += new Vector3(0.5f, 0.5f, 0);
        }
    }
    
}