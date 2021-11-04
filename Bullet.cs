using UnityEngine;

public class Bullet : MonoBehaviour {

    private const float _SPEED = 70f;
    
    private Transform m_Target;

    [Header("References")]
    [SerializeField] private GameObject impactEffect;

    private void Update() {
        if (m_Target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = m_Target.position - transform.position;
        float distanceThisFrame = _SPEED * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }
        
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        
    }

    private void HitTarget() {
        GameObject effectInstanse = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstanse, 2f);
        Destroy(m_Target.gameObject);
        Destroy(gameObject);
    }
    
    public void Seek(Transform target) {
        m_Target = target;
    }
   
}
