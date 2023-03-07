using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDeathSpellingBee : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<HurufController>())
        {
            collision.transform.position = Vector3.up * 5;
            collision.rigidbody.velocity = Vector3.zero;
            collision.rigidbody.angularVelocity = Vector3.zero;
            print("Huruf keluar layar");
        }
    }
}
