using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerMGPF : MonoBehaviour
{
    public GameObject destinationPrefab;
    public NavMeshAgent navMeshAgent;
    public Transform cameraMetaGame;

    public GameObject cowok, cewek;
    public AnimatorKarakter animatorKarakter;


    RaycastHit hit;
    string conditionAnimasi;

    //Anti typo
    [HideInInspector]
    public string 
        _Idle = "Idle", 
        _Walk = "Walk", 
        _Tegak = "Tegak", 
        _Interaksi = "Interaksi", 
        _Senang = "Senang", 
        _Sedih = "Sedih";


    private void Start()
    {
        LoadData();

    }
    void Update()
    {
        if (navMeshAgent == null) return;

        if (navMeshAgent.remainingDistance == 0)
        {

        }
        else if (navMeshAgent.remainingDistance < 0.1f)
        {
            DestroyDestination();
        }

        //Animasi
        if (navMeshAgent.remainingDistance == 0 && conditionAnimasi != "Idle")
        {
            conditionAnimasi = "Idle";
            print("Idle");
            animatorKarakter.animator.SetBool("Walk", false);

        }
        else if (navMeshAgent.remainingDistance > 0.1f && conditionAnimasi != "Walk")
        {
            conditionAnimasi = "Walk";
            print("Sedang jalan");
            animatorKarakter.animator.SetBool("Walk", true);
        }

    }
    public void MouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DestroyDestination();
        }
    }
    public void MouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                navMeshAgent.SetDestination(hit.point);

                SpawndDestination();
            }
        }
    }

    void SpawndDestination()
    {
        Instantiate(destinationPrefab, hit.point + new Vector3(0, 0, 0), Quaternion.identity);
    }
    void DestroyDestination()
    {
        if (GameObject.FindObjectOfType<Destination>() != null)
        {
            GameObject distinationObject = GameObject.FindObjectOfType<Destination>().gameObject;
            Destroy(distinationObject);
        }

    }

    //Load save an
    public void LoadData()
    {
        //Ambil data jenis kelamin
        if (SaveManager.instance.GameSave.karakter == "Cowok")
        {
            cowok.SetActive(true);
            cewek.SetActive(false);
            animatorKarakter.animator = cowok.GetComponent<Animator>();
        }
        else
        {
            cowok.SetActive(false);
            cewek.SetActive(true);
            animatorKarakter.animator = cewek.GetComponent<Animator>();
        }

        //PosisiPlayer
        navMeshAgent.enabled = false;
        transform.position = SaveManager.instance.GameSave.posisiPlayer;
        cameraMetaGame.position = transform.position + cameraMetaGame.gameObject.GetComponent<CameraFollow>().offset;
        navMeshAgent.enabled = true;
    }

}
