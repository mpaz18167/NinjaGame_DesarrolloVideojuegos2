using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Target;
    private Vector3 TargetPos;

    public float HaciaAdelante;
    public float Smoothing;

    private void Start()
    {
        
    }

    private void Update()
    {
        TargetPos = new Vector3(Target.transform.position.x + 5,Target.transform.position.y+3, transform.position.z);

        if (Target.transform.localScale.x ==1)//DERECHA
        {
            TargetPos = new Vector3(TargetPos.x + HaciaAdelante, TargetPos.y, transform.position.z);
        }

        if (Target.transform.localScale.x == -1)//IZQUIERDA
        {
            TargetPos = new Vector3(TargetPos.x - HaciaAdelante, TargetPos.y, transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position,TargetPos,Smoothing*Time.deltaTime);

    }


}
