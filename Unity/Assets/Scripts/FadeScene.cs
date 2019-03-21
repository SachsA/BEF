using UnityEngine;

public class FadeScene : MonoBehaviour
{
    public Animator anim;

    public void FadeToLevel()
    {
        anim.SetTrigger("FadeOut");
    }
}