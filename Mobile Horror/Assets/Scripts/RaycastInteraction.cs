using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
   public static T ThrowRaycast<T>(Transform begin, Vector3 direction, float range) where T : class
   {
        RaycastHit hit;
        if(Physics.Raycast(begin.position, direction, out hit, range))
        {
            if(hit.collider != null && hit.collider.TryGetComponent<T>(out T component))
            {
                return component;
            }
        }
        return null;
    }
}
