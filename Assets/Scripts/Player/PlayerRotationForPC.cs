using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerRotationForPC : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _sensivity;

    private float _mouseHorizontal;
    private float _mouseVertical;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        _mouseHorizontal += Input.GetAxis("Mouse X") * _sensivity;
        _mouseVertical += -Input.GetAxis("Mouse Y") * _sensivity;

        _playerTransform.rotation = Quaternion.Euler(0f, _mouseHorizontal, 0f);
        _playerCamera.transform.rotation = Quaternion.Euler(_mouseVertical, _mouseHorizontal, 0f);
    }

}
