using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : Enemy
{
    [SerializeField] private float _secondsBetweenShoot;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject _enemyBulletPrefab;

    private float _elapsedTime = 0;

    protected override void UseSkill()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _secondsBetweenShoot)
        {
            GameObject spawnedBullet = Instantiate(_enemyBulletPrefab, transform.position, Quaternion.identity);
            _elapsedTime = 0;
        }
    }

    private void Update()
    {
        UseSkill();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<Bullet>(out Bullet bullet))
            ApplyDamage(_takedDamage);

        if (collision.collider.TryGetComponent<RicochetBullet>(out RicochetBullet ricochetBullet))
            ApplyDamageFromeRicochet(_takedDamage);
    }
}
