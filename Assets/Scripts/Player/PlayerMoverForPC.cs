using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverForPC : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            _player.transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            _player.transform.Translate(Vector3.back * _speed * Time.deltaTime);
            
        if (Input.GetKey(KeyCode.D))
            _player.transform.Translate(Vector3.right * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            _player.transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
