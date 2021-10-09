using DG.Tweening;
using Hexagon.Component;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class CameraRotation : MonoBehaviour
{
    [Inject] private HexagonalLoopGenerator hexagonalLoopGenerator;
    [Inject] private TurnsController turnsController;
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

        if (Input.GetMouseButton(0)) {

            yaw += speedHorizontal * -Input.GetAxis("Mouse X");
            //pitch += speedVertical * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yaw, transform.eulerAngles.z);

        }
    }


    public void DoLookAt(Transform lookTransform) {
        transform.DOLookAt(lookTransform.position, 0.2f);
    }

    public void DoLookAtFirstHex() {
        DoLookAt(hexagonalLoopGenerator.Loop.FirstOrDefault().gameObject.transform);
    }
    public void DoLookAtCurrentPlayer() {
        transform.DOLookAt(turnsController.current.transform.position, 0.2f).OnComplete(() => yaw = transform.eulerAngles.y);
    }
}
