using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;

    private void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, m_Camera.transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
