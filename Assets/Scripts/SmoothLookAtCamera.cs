using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLookAtCamera : MonoBehaviour
{

  // script to move the individual letter gameobjects to follow the camera position

  // TODO add in a limitation so that the letters only move if the camera is within a certain number of degress , this will prevent the rotations from updating if the camera goes too far
  
        //TODO ensure that there is a pre defined start orientation


    public Transform TargetTransform;

    public Transform[] ObjectsToRotate;

    
    private float speed = 25f; //speed is in degrees per second



    // idea - cache the positions of the transforms at start or awake, before they come forward....
    // then return to those positions if the transforms decend below the occlusion plane

    public void StartPositions()
    {
        foreach (Transform T in ObjectsToRotate)
        {
            T.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


    private void LateUpdate()
    {
                   //Vector3 direction = (TargetTransform.position - transform.position).normalized;
                   //Quaternion lookRotation = Quaternion.LookRotation(direction);
                   //transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * speed);

        foreach (Transform T in ObjectsToRotate)
        {
            Vector3 direction = (TargetTransform.position - T.transform.position).normalized;

            // Lookrotation has an overload argument for verctor3.up , I need to tell LookRotation which direction "up" is and somehow get this info from the AR image
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            T.transform.rotation = Quaternion.RotateTowards(T.transform.rotation, lookRotation, Time.deltaTime * speed);
        }
    }



}









