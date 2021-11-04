using System;
using UnityEngine;

public class Turret : MonoBehaviour {

    private const float _RANGE = 15f;
    private const float _TURN_SPEED = 10f;
    private const float _FIRE_RATE = 1f;
    private const string _ENEMY_TAG = "Enemy";

    private float m_FireCountdown; // <

    private Transform m_Target;

    [Header("References")]
    [SerializeField] private Transform partToRotate;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    
    private void Start() {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    
    private void Update() {
        if (m_Target == null) return;

        Vector3 direction = m_Target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, _TURN_SPEED * Time.deltaTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f).normalized;

        if (m_FireCountdown <= 0f) {            // <
            Shoot();
            m_FireCountdown = 1f / _FIRE_RATE;
        }

        m_FireCountdown -= Time.deltaTime; // ^

    }
    
    private void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_ENEMY_TAG);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                 shortestDistance = distanceToEnemy;
                 nearestEnemy = enemy; 
            }
        }

        if (nearestEnemy != null && shortestDistance <= _RANGE) {
            m_Target = nearestEnemy.transform;
        } else {
            m_Target = null;
        }
    }

    private void Shoot() {
        GameObject bulletGameObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        if (bullet != null) bullet.Seek(m_Target);

    }

    private void OnDrawGizmosSelected() { 
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _RANGE);
    }
}
