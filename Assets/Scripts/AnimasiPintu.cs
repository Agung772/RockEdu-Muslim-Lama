using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiPintu : MonoBehaviour
{
    Animator animator;
    Transform player;

    public string condition;
    float time;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (time < 1)
        {
            time += Time.deltaTime;
        }


        if (Vector3.Distance(transform.position, player.position) < 4.5f && condition != "open")
        {
            condition = "open";
            animator.SetBool("Start", true);

            AudioManager.instance.BukaPintu();
        }
        else if (Vector3.Distance(transform.position, player.position) > 4.5f && condition != "tutup")
        {
            condition = "tutup";
            animator.SetBool("Start", false);

            if (time >= 1)
            {
                AudioManager.instance.TutupPintu();
            }

        }
    }
}
