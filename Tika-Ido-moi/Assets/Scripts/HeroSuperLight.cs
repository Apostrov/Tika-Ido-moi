using UnityEngine;

public class HeroSuperLight : MonoBehaviour
{
    private Light _pointLight;
    public float minLightRange = 10f;
    public float decreasingLigntSpeed = 10f;
    void Start()
    {
        _pointLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _pointLight.range = 25;
        }

        if (_pointLight.range > minLightRange)
        {
            _pointLight.range =
                Mathf.SmoothStep(_pointLight.range, minLightRange, decreasingLigntSpeed * Time.deltaTime);
        }
        
    }
    
}
