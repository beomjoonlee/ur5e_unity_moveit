using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummitController : MonoBehaviour
{
    private Rigidbody PlayerRigidbody;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        PlayerRigidbody.velocity = newVelocity;
    }
}
