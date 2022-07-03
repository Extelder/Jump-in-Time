using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UIDetectiveRoom : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _timeTextRoomNameShow;
    
    private void OnEnable()
    {
        RatDetectiveThiefPlaceState.OnDetectiveRoom += ShowRoomName;
    }

    private void OnDisable()
    {
        RatDetectiveThiefPlaceState.OnDetectiveRoom -= ShowRoomName;
    }

    private async void ShowRoomName(string value)
    {
        _text.text = value;
    }
}
