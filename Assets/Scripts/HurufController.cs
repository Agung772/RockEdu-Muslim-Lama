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
            Destroy(GetComponent<HurufController>());
        }
    }

    private void Start()
    {
        savePosisi = transform.position;
    }

    private void Update()
    {
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
        click = true;
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void OnMouseUp()
    {
        click = false;
    }

    float timeForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<HurufController>())
        {
            timeForce = 0;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.GetComponent<HurufController>())
        {
            timeForce += Time.deltaTime;
            if (timeForce > 1)
            {
                GetComponent<BoxCollider>().isTrigger = true;
            }

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<HurufController>())
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(0.5f);
                GetComponent<BoxCollider>().isTrigger = false;
            }

        }
    }
}
