using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    private float m_TimeBetweenWaves = 8f;
    private float m_Countdown = 5f;
    private int m_WaveNumber;

    [Header("References")]
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Text waveCountdownText;

    private void Update() {
        
        if (m_Countdown <= 0f) {
            StartCoroutine(SpawnWave());
            m_Countdown = m_TimeBetweenWaves;
        }

        m_Countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(m_Countdown).ToString();

    }

    private IEnumerator SpawnWave() {  

        for (int i = 0; i <= m_WaveNumber; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
        m_WaveNumber++;
    }
    
    private void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}