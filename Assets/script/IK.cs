using UnityEngine;
using UnityEngine.Animations.Rigging;
using System.Collections;  

public class IK : MonoBehaviour
{
    public Rig rig;
    public Transform handTarget;
    public Transform handBone;
    public Animator animator;

    public string reachTriggerName = "ReachingOut"; 

    private bool hasActivated = false;

    void Start()
    {
        rig.weight = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasActivated)
        {
            hasActivated = true;
            StartCoroutine(PlayReachAnimationAndActivateIK());
        }
    }

    IEnumerator PlayReachAnimationAndActivateIK()
    {
        animator.ResetTrigger(reachTriggerName); 
        animator.SetTrigger(reachTriggerName);  

  
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        rig.weight = 1f;
    }
}
