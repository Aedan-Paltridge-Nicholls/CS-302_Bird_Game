using Unity.Cinemachine;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;




public class TalkRay : MonoBehaviour
{   
    [SerializeField] 
    CharacterController Player;


    [SerializeField]
    CinemachineCamera FreeCamera;
    [SerializeField]
    CinemachineCamera DialogCamera;
    [SerializeField]
    LyraVeyne PlayerScript;
    [SerializeField]
    Text Dialog;
    [SerializeField]
    UIDocument uIDocument;

    UIDocument DialogUI;
    private bool Talking = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        Random.Range(0, 100);
        PlayerScript.Captured_Rats = 0;
        DialogUI = DialogCamera.GetComponent<UIDocument>();
        DialogUI.enabled = false;

        //  NpcCapsule = GetComponent<CapsuleCollider>();
    }
    public void TalkCast()
    {
        Ray TalkRay = new Ray(Player.transform.position, Player.transform.forward);
        Debug.DrawRay(TalkRay.origin, TalkRay.direction * 2, Color.red, 1f);
        RaycastHit TalkHitData;
        
        if (Physics.Raycast(TalkRay, out TalkHitData, 2f))
        {
            if (TalkHitData.collider.CompareTag("Npc"))
            {

                Collider NpcCollider = TalkHitData.collider; 
                Animator NpcAnimator = NpcCollider.GetComponentInParent<Animator>();    
                
                if (NpcAnimator.GetBool("IsTalking") == false)
                {
                    Dialog.SetText(Dialog.Quest);
                    NpcAnimator.SetBool("IsTalking", true);
                    Player.transform.LookAt(NpcCollider.transform);
                    NpcCollider.transform.LookAt(Player.transform);
                    Player.GetComponentInParent<FirePlayerMovement>().enabled = false;
                    PlayerScript.IsTalking = true;
                    Talking = true;
                    FreeCamera.Priority = 0;
                    DialogCamera.Prioritize();
                    DialogUI.enabled = true;
                    InputSystem.LoadLayout("UI");
                   
                }
            }
            if (TalkHitData.collider.CompareTag("Takahe"))
            {
                Dialog.SetText(Dialog.TakaheInfo);
                Player.GetComponentInParent<FirePlayerMovement>().enabled = false;
                PlayerScript.IsTalking = true;
                Talking = true;
                FreeCamera.Priority = 0;
                DialogCamera.Prioritize();
                DialogUI.enabled = true;
                InputSystem.LoadLayout("UI");
            }
        }
        

        

    }
    public void Ratray()
    {
        Ray RatRay = new Ray(Player.transform.position, Player.transform.forward);
        Debug.DrawRay(RatRay.origin, RatRay.direction * 2, Color.red, 1f);
        RaycastHit PestHitData;
        Debug.Log("Rat Cast");

        if (Physics.Raycast(RatRay, out PestHitData, 2f))
        {
            GameObject ObjPest = PestHitData.collider.gameObject;
            if (PestHitData.collider.CompareTag("Pest"))
            {
                Destroy(ObjPest);
                PlayerScript.Captured_Rats += 1;
                if (PlayerScript.Captured_Rats >= 5)
                {
                    uIDocument.enabled = true;

                }
            }
        }
    }
    public void EndTalk()
    {
        FreeCamera.Prioritize();
        DialogCamera.Priority = 0;
        DialogCamera.enabled = false;
        DialogUI.enabled = false;
        Talking = false;
        Player.GetComponentInParent<FirePlayerMovement>().enabled = true;
        InputSystem.LoadLayout("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Interact"))
        {
            Debug.Log("Talk Cast");
            TalkCast();
        }
        if (Input.GetButton("EndDialog") && Talking == true)
        {
            EndTalk();
        }
        if (Input.GetButton("Attack")) { Ratray(); }

        if (PlayerScript.IsTalking == false && Talking == true)
        {
             EndTalk();
        }
    }
}
