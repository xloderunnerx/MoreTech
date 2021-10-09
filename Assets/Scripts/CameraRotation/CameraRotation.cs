using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public float speedHorizontal = 2.0f;
    public float speedVertical = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        this.MoveCamera();
    }

    private void MoveCamera()
    {

        if (Input.GetMouseButton(0))
        {

            yaw += speedHorizontal * Input.GetAxis("Mouse X");
            //pitch += speedVertical * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yaw, transform.eulerAngles.z);

        }

    }

    public void DoLookAt(Transform lookTransform) {
        transform.DOLookAt(lookTransform.position, 0.2f);
    }
}
