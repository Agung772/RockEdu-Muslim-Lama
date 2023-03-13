using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurufController : MonoBehaviour
{
    public string codeHuruf;
    public bool hurufAktif = true;

    [Space]
    public bool use;
    public bool click;
    public bool back;
    public Text hurufText;
    Vector3 mousePosition, savePosisi;

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
    }

    private void Update()
    {
        if (!hurufAktif) return;

        if (back)
        {
            GetComponent<BoxCollider>().isTrigger = true;
            GetComponent<Rigidbody>().useGravity = false;
            transform.position = Vector3.Lerp(transform.position, savePosisi, 5 * Time.deltaTime);

            if (Vector3.Distance(transform.position, savePosisi) < 0.1)
            {
                back = false;
                GetComponent<BoxCollider>().isTrigger = false;
                GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        if (!hurufAktif) return;

        click = true;
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        if (!hurufAktif) return;

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void OnMouseUp()
    {
        if (!hurufAktif) return;

        click = false;
    }

    float timeForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hurufAktif) return;

        if (collision.collider.GetComponent<HurufController>())
        {
            timeForce = 0;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (!hurufAktif) return;

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

        }
    }
}
