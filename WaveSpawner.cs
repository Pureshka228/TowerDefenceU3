using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    private const float _TIME_BETWEEN_WAVES = 8f;
    private float m_Countdown = 2f;
    private int m_WaveNumber;

    [Header("References")]
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;

    private void Update() {
        
        if (m_Countdown <= 0f) {
            StartCoroutine(SpawnWave());
            m_Countdown = _TIME_BETWEEN_WAVES;
        }

        m_Countdown -= Time.deltaTime;

    }

    private IEnumerator SpawnWave() {  

        for (int i = 0; i < m_WaveNumber; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
        m_WaveNumber++;
    }
     
    private void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}