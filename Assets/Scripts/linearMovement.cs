using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linearMovement : MonoBehaviour
{
    //declaring a variable this variable is a Vector3 x y z 
    public Vector3 direction = new Vector3(1f, 0, 0);
    

    // Update is called once per frame
    void Update()
    {
        // this line translates the gameboject in a direction
        transform.Translate(direction * (Time.deltaTime));
        
    }
}
