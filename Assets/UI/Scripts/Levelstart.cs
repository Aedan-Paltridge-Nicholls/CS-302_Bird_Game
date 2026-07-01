using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Levelstart : MonoBehaviour
{
    public CinemachineCamera camera1;
    public CinemachineCamera camera2;

    void Start()
    {
        Ratrandomizer();
        camera1.Priority = 10;
        camera2.Priority = 0;
    }

    public void Ratrandomizer()
    {
         Vector3 minPosition = new Vector3(-12f, 0f, -12f);
         Vector3 maxPosition = new Vector3(12f, 0f, 12f);

      
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Pest");
        foreach (GameObject obj in objects)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-12f, 12f),
                Random.Range(0, 0),
                Random.Range(-12f, 12)
            );

            obj.transform.position = randomPos;
        }

        Debug.Log($"Randomized positions for  {objects.Length} pests .");
        
    }


        
    
}
