using UnityEngine;

public class Debug_tests : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Resolution[] resolutions = Screen.resolutions;

        // Print the resolutions
        foreach (var res in resolutions)
        {
            float aspect = (float)res.width / res.height;

            // Check if it's approximately 16:9 (allowing small floating-point error)
            if (Mathf.Abs(aspect - (16f / 9f)) < 0.01f)
            {

                Debug.Log(res.width + "x" + res.height + " : " + res.refreshRateRatio);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
