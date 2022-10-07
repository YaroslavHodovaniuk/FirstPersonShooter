using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject _ricochetBulletPrefab;

    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _bulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            int chanceSkill = Random.Range(1, _player.GetHealth());

            if (chanceSkill >= 70 && chanceSkill <= 100)
                Destroy(gameObject);

            else if (chanceSkill >= 1 && chanceSkill <= 30)
            {
                GameObject ricochetBullet = Instantiate(_ricochetBulletPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
