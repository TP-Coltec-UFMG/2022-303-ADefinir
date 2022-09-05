using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulo : MonoBehaviour
{
    public Rigidbody2D penduloRb;
    public float rangerDaDireita;
    public float rangerDaEsquerda;
    public float limitadorV;

    void Start()
    {
        penduloRb.angularVelocity = limitadorV;
    }


    void Update()
    {
        empurrar();
    }
    public void empurrar()
    {
        if(transform.rotation.z > 0 && transform.rotation.z < rangerDaDireita && (penduloRb.angularVelocity > 0) && 
            penduloRb.angularVelocity < limitadorV)
        {
            penduloRb.angularVelocity = limitadorV;
        }
        else if(transform.rotation.z < 0 && transform.rotation.z > rangerDaDireita && (penduloRb.angularVelocity < 0) 
            && penduloRb.angularVelocity > limitadorV * -1)
        {
            penduloRb.angularVelocity = limitadorV * -1;
        }


    }
}
