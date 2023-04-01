using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurufController : MonoBehaviour
{
    public string codeHuruf;
    public bool hurufAktif = true;
    public float dist = 1.1f;

    [Space]
    public bool use;
    public bool click;
    public bool back;
    public Text hurufText;
    Vector3 mousePosition, savePosisi;

    public Transform[] hurufLain;

    private void Awake()
    {
        if (!hurufAktif)
        {
            Destroy(GetComponent<Rigidbody>());
            //Destroy(GetComponent<HurufController>());
        }
    }

    private void Start()
    {
        savePosisi = transform.position;

        HurufController[] count = FindObjectsOfType<HurufController>();
        hurufLain = new Transform[count.Length];
    }

    float start;
    private void Update()
    {
        if (start < 2)
        {
            start += Time.deltaTime;
        }

        if (!hurufAktif) return;

        if (back)
        {
            GetComponent<BoxCollider>().isTrigger = true;
            GetComponent<Rigidbody>().useGravity = false;
            transform.position = Vector3.Lerp(transform.position, savePosisi, 5 * Time.deltaTime);

            if (Vector3.Distance(transform.position, savePosisi) < 0.2f)
            {
                back = false;
                GetComponent<BoxCollider>().isTrigger = false;
                GetComponent<Rigidbody>().useGravity = true;
            }
        }

        CollisionNgestay(0);
        CollisionNgestay(1);
        CollisionNgestay(2);
        CollisionNgestay(3);

    }

    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        if (!hurufAktif || GameplaySpellingBee.instance.finis) return;

        click = true;
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        if (!hurufAktif || GameplaySpellingBee.instance.finis) return;

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void OnMouseUp()
    {
        if (!hurufAktif || GameplaySpellingBee.instance.finis) return;

        click = false;
    }

    float timeForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (!click && start >= 2)
        {
            AudioManager.instance.SfxHurufJatuhSB();
        }

        if (!hurufAktif) return;

        if (collision.collider.GetComponent<HurufController>())
        {
            timeForce = 0;

            //Set huruf lainnya
            for (int i = 0; i < hurufLain.Length; i++)
            {
                if (hurufLain[i] == null)
                {
                    hurufLain[i] = collision.collider.gameObject.transform;
                    break;
                }
            }
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        if (!hurufAktif) return;

        /*
        if (collision.collider.GetComponent<HurufController>())
        {
            timeForce += Time.deltaTime;
            if (timeForce > 1)
            {
                int random = Random.Range(1, 3);
                if (random == 1) GetComponent<Rigidbody>().velocity = new Vector3(-2, 7, 0);
                else GetComponent<Rigidbody>().velocity = new Vector3(2, 7, 0);

                GetComponent<BoxCollider>().isTrigger = true;

            }

        }
        */

        //Set huruf lainnya
        if (collision.collider.GetComponent<HurufController>())
        {

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!hurufAktif) return;

        if (collision.collider.GetComponent<HurufController>())
        {
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(0.5f);
                GetComponent<BoxCollider>().isTrigger = false;
            }

            //Set huruf lainnya
            for (int i = 0; i < hurufLain.Length; i++)
            {
                if (hurufLain[i] != null)
                {
                    hurufLain[i] = null;
                    break;
                }
            }

        }
    }

    void CollisionNgestay(int number)
    {
        if (hurufLain[number] != null)
        {
            if (Vector3.Distance(transform.position, hurufLain[number].position) < dist)
            {
                timeForce += Time.deltaTime;
                if (timeForce > 1)
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-3, 4), 7, 0);

                    GetComponent<BoxCollider>().isTrigger = true;

                }
                print(timeForce);
            }
        }
    }
}
