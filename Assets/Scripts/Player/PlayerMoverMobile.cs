using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMoverMobile : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;

    private void FixedUpdate()
    {
        if (_joystick.Direction.y > 0)
            _player.transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        if (_joystick.Direction.y < 0)
            _player.transform.Translate(Vector3.back * _speed * Time.deltaTime);

        if (_joystick.Direction.x > 0)
            _player.transform.Translate(Vector3.right * _speed * Time.deltaTime);

        if (_joystick.Direction.x < 0)
            _player.transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
