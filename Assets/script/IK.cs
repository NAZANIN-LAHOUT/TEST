using UnityEngine;
using UnityEngine.Animations.Rigging;
using System.Collections;  // اضافه کردن فضای نام برای IEnumerator

public class IK : MonoBehaviour
{
    public Rig rig;
    public Transform handTarget;
    public Transform handBone;
    public Animator animator;

    public string reachTriggerName = "ReachingOut"; // باید تو Animator یه trigger همین اسم داشته باشی

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
        animator.ResetTrigger(reachTriggerName); // اگه تریگر قبلاً زده شده بود، ریستش کن
        animator.SetTrigger(reachTriggerName);   // فقط همین انیمیشن اجرا میشه

        // صبر کن تا انیمیشن به پایان برسد
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        // حالا که انیمیشن تمام شد، IK فعال می‌شود
        rig.weight = 1f;
    }
}
