using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;    

    private GameObject _someEnemy;

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Enemy") != null) 
            _someEnemy = GameObject.FindGameObjectWithTag("Enemy");
        transform.position = Vector3.MoveTowards(transform.position, _someEnemy.transform.position, Time.deltaTime * _bulletSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Enemy>(out Enemy enemy))
            Destroy(gameObject);    
    } 
}
