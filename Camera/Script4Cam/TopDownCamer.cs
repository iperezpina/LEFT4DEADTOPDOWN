using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class TopDownCamer : MonoBehaviour
{
    public Transform m_Target;
    public float m_height = 10f;
    public float m_Distance = 20f;
    public float m_Angle = 45f;
    public float m_SmoothSpeed = 0.5f;

    private Vector3 refVolocity;
    // Start is called before the first frame update
    void Start()
    {
        HandleCamera();    
    }

    // Update is called once per frame
    void Update()
    {
        HandleCamera();
    }



    protected virtual void HandleCamera()
    {
        if (!m_Target)
        {
            return;
        }
       
        Vector3 worldPostion = (Vector3.forward * -m_Distance) +(Vector3.up * m_height);
        //Debug.DrawLine(m_Target.position, worldPostion, Color.red);



        Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPostion;
        
        Vector3 flatTargetPos = m_Target.position;
        flatTargetPos.y = 0f;
        Vector3 finalPostion = flatTargetPos + rotatedVector;

        transform.position = Vector3.SmoothDamp(transform.position, finalPostion, ref refVolocity, m_SmoothSpeed);
        transform.LookAt(flatTargetPos);
        
    }


}
