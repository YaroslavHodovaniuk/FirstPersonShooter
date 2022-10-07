using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class RedEnemy : Enemy
{
    [SerializeField] private float _speedFly;

    private Vector3 _target;
    private bool _onTarget = false;

    private void Awake()
    {
        _target = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }

    protected override void UseSkill()
    {
        if (!_onTarget && transform.position != _target)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, _speedFly * Time.deltaTime);
        }
        else _onTarget = true;

        StartCoroutine("FlyToPlayer");
    }

    private void Update()
    {
        UseSkill();
    }

    private IEnumerator FlyToPlayer()
    {
        yield return new WaitForSeconds(3);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speedFly * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Bullet>(out Bullet bullet))
            ApplyDamage(_takedDamage);

        if (collision.collider.TryGetComponent<RicochetBullet>(out RicochetBullet ricochetBullet))
            ApplyDamageFromeRicochet(_takedDamage);

        if (collision.collider.TryGetComponent<Player>(out Player player))
            Destroy(gameObject);
        
    }
}
