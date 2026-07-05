using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Levelstart : MonoBehaviour
{
    [SerializeField] 
    CinemachineCamera camera1;
    [SerializeField]
    CinemachineCamera camera2;
    [SerializeField] 
    GameObject pest;
    [SerializeField] 
    LyraVeyne Player;
    [SerializeField]
    RatQuest RatQuest;
    [SerializeField]
    int MinPests = 5;
    [SerializeField]
    int MaxPests = 25;
    void Start()
    {
        Ratrandomizer();
        camera1.Priority = 10;
        camera2.Priority = 0;
        Player.Quest_Rats = RatQuest.TotalRatsToCapture;
    }

    public void Ratrandomizer()
    {
         Vector3 minPosition = new Vector3(-12f, 0f, -12f);
         Vector3 maxPosition = new Vector3(12f, 0f, 12f);

        int randomPestCount = Random.Range(MinPests, MaxPests);
        RatQuest.TotalRatsToCapture = randomPestCount;



        for (int i = 0;i < randomPestCount; i++)
        {
            Player.Quest_Rats += 1; 
            Vector3 randomPos = new Vector3(
                Random.Range(-12f, 12f),
                Random.Range(0, 0),
                Random.Range(-12f, 12)
            );

            Instantiate(pest, randomPos, Quaternion.identity);
        }
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Pest");

        Debug.Log($"Randomized positions for  {objects.Length} pests .");
        
    }


        
    
}
