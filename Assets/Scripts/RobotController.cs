using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    public enum NamaMiniGame
    {
        ConnectingTheDot,
        SpellingBee,
        PilihanGanda,
        BenarSalah,
    }

    public NamaMiniGame namaMiniGame;


    public int targetWaypoint;

    public Animator animator;
    public Transform waypoint;
    public NavMeshAgent navMeshAgent;

    Transform player;
    public bool adaPlayer;
    bool lookPlayer;

    float timeAnim;

    public int scoreMinigame;

    private void Start()
    {
        for (int i = 0; i < waypoint.childCount; i++)
        {
            Destroy(waypoint.GetChild(i).GetComponent<MeshFilter>());
            Destroy(waypoint.GetChild(i).GetComponent<MeshRenderer>());
        }

        player = FindObjectOfType<PlayerControllerMGPF>().transform;

        //Load data minigame untuk score
        string namaScoreMinigame = "";

        if (namaMiniGame == NamaMiniGame.ConnectingTheDot) { namaScoreMinigame = SaveManager.instance.GameSave._ScoreConnectingTheDot; }
        else if (namaMiniGame == NamaMiniGame.SpellingBee) { namaScoreMinigame = SaveManager.instance.GameSave._ScoreSpellingBee; }
        else if (namaMiniGame == NamaMiniGame.PilihanGanda) { namaScoreMinigame = SaveManager.instance.GameSave._ScorePilihanGanda; }
        else if (namaMiniGame == NamaMiniGame.BenarSalah) { namaScoreMinigame = SaveManager.instance.GameSave._ScoreBenarSalah; }

        scoreMinigame = PlayerPrefs.GetInt(namaScoreMinigame + SaveManager.instance.GameSave.bab + SaveManager.instance.GameSave.codeSave);
    }
    private void Update()
    {
        //Ganti target waypoint
        if (Vector3.Distance(transform.position, waypoint.GetChild(targetWaypoint).transform.position) < 0.5f)
        {
            targetWaypoint++;

            if (targetWaypoint == waypoint.childCount)
            {
                targetWaypoint = 0;
            }
        }
        //Set target waypoint
        if (navMeshAgent.enabled) navMeshAgent.SetDestination(waypoint.GetChild(targetWaypoint).transform.position);

        //Jarak dengan player tercapai
        if (Vector3.Distance(transform.position, player.position) < 2 && !adaPlayer)
        {
            adaPlayer = true;

            navMeshAgent.enabled = false;
            navMeshAgent.speed = 0;

            lookPlayer = true;

            animator.SetTrigger("Nyapa");
        }
        //Jarak dengan player tidak tercapai
        else if (Vector3.Distance(transform.position, player.position) > 2 && adaPlayer)
        {
            adaPlayer = false;

            navMeshAgent.enabled = true;
            navMeshAgent.speed = 1.5f;

            lookPlayer = false;
        }

        //Look player ketika berhenti
        if (lookPlayer)
        {
            Quaternion rotTarget = Quaternion.LookRotation(player.transform.position - transform.position);
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 200 * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);

            timeAnim = 0;
        }
        //Animasi ketika player sedang jalan
        else
        {
            timeAnim += Time.deltaTime;
            if (timeAnim > 5)
            {
                timeAnim = 0;

                if (scoreMinigame >= 2)
                {
                    animator.SetTrigger("Senang");
                }
                else
                {
                    animator.SetTrigger("Sedih");
                }

            }
        }
    }
}
