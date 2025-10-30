using UnityEngine;

public class ProjectorToggle : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.speed = 1;
    }


    void ProjectorAnimationPlay()
    {
        animator.speed = 1;
    }
    void ProjectorAnimationPause()
    {
        animator.speed = 0;
    }
}
