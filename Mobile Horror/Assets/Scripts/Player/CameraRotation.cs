using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class CameraRotation : MonoBehaviour, IDragHandler, IEndDragHandler
{ 
    private int TouchId = 0;
    private bool _pressed = false;
    private bool MobileDevice = true;
    private CinemachinePOV _virtualCameraPov;
   
    [SerializeField] private Vector2 _sensetivity;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Canvas _canvas;

    private void Start()
    {
        _virtualCameraPov = _virtualCamera.GetCinemachineComponent<CinemachinePOV>();

        if (MobileDevice)
        {
            SetInputAxisMaxSpeed(new Vector2(_sensetivity.x, _sensetivity.y));
            SetInputAxisesNames(null, null);    
        }
        else
            SetInputAxisesNames("Mouse X", "Mouse Y");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject == gameObject)
        {
            _canvas.sortingLayerID = 2;
            TouchId = eventData.pointerId;
            _pressed = true;
            if (Input.GetTouch(eventData.pointerId).phase == TouchPhase.Moved)
            {
                SetInputAxisesValue(new Vector2(eventData.delta.x, eventData.delta.y));
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvas.sortingLayerID = 0;
        _pressed = false;
        SetInputAxisesValue(new Vector2(0, 0));
    }

    private void Update()
    {
        if (_pressed)
        {
            if (Input.GetTouch(TouchId).phase == TouchPhase.Stationary)
            {
                SetInputAxisesValue(new Vector2(0, 0));
            }
        }  
    }
   

    private void SetInputAxisesValue(Vector2 value)
    {
        _virtualCameraPov.m_HorizontalAxis.m_InputAxisValue = value.x;
        _virtualCameraPov.m_VerticalAxis.m_InputAxisValue = value.y;
    }

    private void SetInputAxisesNames(string horizontal, string vertical)
    {
        _virtualCameraPov.m_HorizontalAxis.m_InputAxisName = horizontal;
        _virtualCameraPov.m_VerticalAxis.m_InputAxisName = vertical;
    }

    private void SetInputAxisMaxSpeed(Vector2 value)
    {
        _virtualCameraPov.m_HorizontalAxis.m_MaxSpeed = value.x;
        _virtualCameraPov.m_VerticalAxis.m_MaxSpeed = value.y;
    }

 
}
