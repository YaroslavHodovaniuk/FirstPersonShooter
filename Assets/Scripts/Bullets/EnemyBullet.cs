using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    private GameObject _player;
    private Player _playerScript;
    private bool _teleported = false;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerScript = _player.GetComponent<Player>();
    }
    void Update()
    {
        _teleported = _playerScript.GetTeleport();
        if( _teleported )
            transform.position = Vector3.MoveTowards(transform.position, _playerScript.PositionBeforeTeleport(), _bulletSpeed * Time.deltaTime);
        else
            FlyToPlayer();
    }

    private void FlyToPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, _player.transform.position, Time.deltaTime * _bulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }

}
