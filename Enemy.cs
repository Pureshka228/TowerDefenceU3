using UnityEngine;

public class Enemy : MonoBehaviour {

    private const float _SPEED = 8f;
    private int m_WavepointIndex;

    private Transform m_Target;

    private void Start() {
        m_Target = Waypoints.Points[0];
    }

    private void Update() {
        MoveByPoints();
    }

    private void MoveByPoints() {
        Vector3 direction = m_Target.position - transform.position;
        transform.Translate(direction.normalized * _SPEED * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, m_Target.position) <= 0.4f) {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint() {
        if (m_WavepointIndex >= Waypoints.Points.Length - 1) {
            Destroy(gameObject);
            return;
        }
        
        m_WavepointIndex++;
        m_Target = Waypoints.Points[m_WavepointIndex];
    }
}