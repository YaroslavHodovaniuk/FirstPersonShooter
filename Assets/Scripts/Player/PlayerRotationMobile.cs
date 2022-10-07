using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRotationMobile : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform _player;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _sensivity;

    private float _moveHorizontal;
    private float _moveVertical;


    public void OnDrag(PointerEventData eventData)
    {
        _moveHorizontal += eventData.delta.x * _sensivity;
        _moveVertical -= eventData.delta.y * _sensivity;

        _playerCamera.transform.rotation = Quaternion.Euler(_moveVertical, _moveHorizontal, 0f);
        _player.rotation = Quaternion.Euler(0f, _moveHorizontal, 0f);
    }

}
