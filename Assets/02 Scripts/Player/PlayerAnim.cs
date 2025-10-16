using UnityEngine;

public static class AnimID
{
    public static readonly int idle = Animator.StringToHash("PlayerIdle");
    public static readonly int jump = Animator.StringToHash("PlayerJump");
    public static readonly int transition = Animator.StringToHash("PlayerTransition");
    public static readonly int death = Animator.StringToHash("PlayerDeath");
}

public class PlayerAnim : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnim(int id)
    {
        anim.Play(id);
    }
    public void CrossFadeAnim(int id, float fadeTime)
    {
        anim.CrossFade(id, fadeTime);
    }

}
