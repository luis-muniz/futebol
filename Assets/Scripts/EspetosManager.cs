using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspetosManager : MonoBehaviour
{
    [SerializeField]private SliderJoint2D espeto;
    private JointMotor2D motor;

    void Start()
    {
        this.espeto = GetComponent<SliderJoint2D>();
        this.motor = espeto.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if(espeto.limitState == JointLimitState2D.UpperLimit)
        {
            this.motor.motorSpeed = Random.Range(-1,-3);
            this.espeto.motor = this.motor;
        }

        if (espeto.limitState == JointLimitState2D.LowerLimit)
        {
            this.motor.motorSpeed = Random.Range(1,3);
            this.espeto.motor = this.motor;
        }
    }
}
