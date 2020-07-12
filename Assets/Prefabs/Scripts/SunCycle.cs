using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCycle : MonoBehaviour
{
    [SerializeField] float speed = 0.3f;
    

   
    void Update()
    {
        this.transform.Rotate(0, this.transform.rotation.y + speed * Time.deltaTime,0);
    }
}
