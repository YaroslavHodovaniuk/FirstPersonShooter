using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _takedDamage;
    [SerializeField] protected int _givePower;

    protected Player _player;

    private PowerDisplay _powerDisplay;
    private HealthDisplay _healthDisplay;
    private NumberKills _numKills;


    private void Start()
    {
        _numKills = FindObjectOfType<NumberKills>();
        _player = FindObjectOfType<Player>();
        _powerDisplay = FindObjectOfType<PowerDisplay>();
        _healthDisplay = FindObjectOfType<HealthDisplay>();
    }
    protected void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    protected void ApplyDamageFromeRicochet(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            int upHPorPower = Random.Range(0, 1);

            if (upHPorPower == 1)
                _player.TryToTakeHealth(50);
            else
                _player.TryToTakePower(20);

            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        _numKills.PlusOneDead();
        _player.TryToTakePower(_givePower);
        _powerDisplay.OnPowerChanged(_player.GetPower());
        _healthDisplay.OnHealthChanged(_player.GetHealth());
    }

    protected abstract void UseSkill();

}
