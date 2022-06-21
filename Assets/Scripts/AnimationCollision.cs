using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCollision : MonoBehaviour
{
    Animator animator;
    public AnimationClip animationClip;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.Play(animationClip.name, -1,0f);
    }
}
