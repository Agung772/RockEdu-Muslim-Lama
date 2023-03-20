using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiPintu : MonoBehaviour
{
    Animator animator;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 4.5f)
        {
            animator.SetBool("Start", true);
        }
        else
        {
            animator.SetBool("Start", false);
        }
    }
}
