using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerMGPF : MonoBehaviour
{
    public static PlayerControllerMGPF instance;

    public bool useDisplay;
    public bool clickUI;

    public GameObject destinationPrefab;
    public NavMeshAgent navMeshAgent;
    public Transform cameraMetaGame;

    public GameObject cowok, cewek;
    public AnimatorKarakter animatorKarakter;

    public LineRenderer displayRute;




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

    private void Awake()
    {
        instance = this;
    }

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

        if (navMeshAgent.hasPath)
        {
            DisplayRute();
            if (useDisplay)
            {
                //DisplayRute();
            }
        }
        else
        {
            useDisplay = false;
        }



        //Animasi
        if (navMeshAgent.remainingDistance == 0 && conditionAnimasi != "Idle")
        {
            conditionAnimasi = "Idle";
            animatorKarakter.animator.SetBool("Walk", false);

        }
        else if (navMeshAgent.remainingDistance > 0.1f && conditionAnimasi != "Walk")
        {
            conditionAnimasi = "Walk";
            animatorKarakter.animator.SetBool("Walk", true);
        }

    }
    public void MouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DestroyDestination();

            useDisplay = false;
        }

        //Set display rute
        displayRute.positionCount = 0;
    }
    public void MouseUp()
    {
        if (clickUI) return;

        if (Input.GetMouseButtonUp(0))
        {

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                navMeshAgent.SetDestination(hit.point);

                SpawndDestination();

                //Jarak nongol display rute
                if (Vector3.Distance(transform.position, navMeshAgent.destination) > 5)
                {
                    useDisplay = true;
                }
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

    //Tampilan rute
    void DisplayRute()
    {
        displayRute.positionCount = navMeshAgent.path.corners.Length;
        displayRute.SetPosition(0, transform.position);

        if (navMeshAgent.path.corners.Length < 2)
        {
            return;
        }

        for (int i = 0; i < navMeshAgent.path.corners.Length; i++)
        {
            var corners = navMeshAgent.path.corners[i];
            Vector3 pointPosition = new Vector3(corners.x, corners.y + 0.1f, corners.z);
            displayRute.SetPosition(i, pointPosition);
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
