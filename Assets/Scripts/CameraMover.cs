using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _cameraUp;
    [SerializeField] private float _cameraForward;

    private void Update()
    {
        _cameraTransform.position = new Vector3(_playerTransform.position.x, _playerTransform.position.y + _cameraUp, _playerTransform.position.z + _cameraForward);   
    }
}
