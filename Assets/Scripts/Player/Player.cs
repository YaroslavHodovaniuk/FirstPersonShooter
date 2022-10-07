using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject _bulletPfefab;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Transform[] _teleportPoints;

    [SerializeField] private int _health = 100;
    [SerializeField] private int _power = 50;

    private bool _teleported = false;
    private int _maxHealth = 100;
    private int _maxPower = 100;
    private Vector3 _positionBeforeTeleport;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> PowerChanged;
    public event UnityAction Died;


    private void Start()
    {
        HealthChanged?.Invoke(_health);
        PowerChanged?.Invoke(_power);

    }

    private void ApplyDamage(int damage)
    {
        if (_health > 0)
        {
            if (_health - damage < 0)
            {
                _health = 0;
                Die();
            }
            else
            {
                _health -= damage;
            }
        }
        HealthChanged?.Invoke(_health);
    }

    private void SubtractPower(int power)
    {
        if (_power > 0)
        {
            if (_power - power < 0)
            {
                _power = 0;
            }
            else
            {
                _power -= power;
            }
        }
        PowerChanged?.Invoke(_power);
    }

    private void OnTriggerExit(Collider other)
    {
        Teleport();
    }

    private void Teleport()
    {
        _positionBeforeTeleport = transform.position;
        int randomPoint = Random.Range(1, _teleportPoints.Length);
        transform.position = new Vector3(_teleportPoints[randomPoint].position.x, transform.position.y, _teleportPoints[randomPoint].position.x);
        StartCoroutine("Teleported");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<EnemyBullet>(out EnemyBullet enemyBullet))
            SubtractPower(25);
        
        if (collision.collider.TryGetComponent<RedEnemy>(out RedEnemy redEnemy))
            ApplyDamage(15);
    }
    
    private void Die()
    {
        Died?.Invoke();
    }
    private IEnumerator Teleported()
    {
        _teleported = true;
        yield return new WaitForSeconds(3);
        _teleported = false;
    }

    public int GetHealth()
    {
        return _health;
    }

    public int GetPower()
    {
        return _power;
    }

    public bool GetTeleport()
    {
        return _teleported;
    }

    public Vector3 PositionBeforeTeleport()
    {
        return _positionBeforeTeleport;
    }

    public void TryToTakeHealth(int health)
    {
        if (health < _maxHealth)
        {
            if (_health + health > _maxHealth)
                _health = _maxHealth;
            else
                _health += health;
        }
    }

    public void TryToTakePower(int power)
    {
        if(power < _maxPower)
        {
            if (_power + power > _maxPower)
                _power = _maxPower;
            else
                _power += power;
        }
    }

    public void Shoot()
    {
        GameObject spawnedBullet = Instantiate(_bulletPfefab, _playerCamera.transform.position, _playerCamera.transform.rotation);
    }

    public void Ultimate()
    {
        List<Enemy> enemies = new List<Enemy>(FindObjectsOfType<Enemy>());
        if (_power == _maxPower)
        {
            _power -= _maxPower;

            for (int i = 0; i < enemies.Count; i++)
                enemies[i].Die();

            PowerChanged?.Invoke(_power);
        }
    }
}
