using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour   
{
    public Animator anim;
    public void PlayAnimation(Animation animation, string animationName)
    {
        anim.Play(animationName);
    }
}
