using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;

    public float turnSmoothtime = 0.1f;
    float turnsmothvelocity;

    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;
        if (direccion.magnitude >= 0.1f)
        {
            float targetangle = Mathf.Atan2(direccion.x, direccion.z)* Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmothvelocity, turnSmoothtime);
            Vector3 movedir = Quaternion.Euler(0f, targetangle,0f)*Vector3.forward;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(movedir.normalized*speed*Time.deltaTime);
        }
    }
}
