using UnityEngine;

public class ChangingWeather : MonoBehaviour {

    private const float _START_VALUE = 60f;
    private const float _SPEED = 1f;
    private float m_Rotation;
    
    private void Awake() {
        transform.rotation = Quaternion.Euler(_START_VALUE, 0, 0);
        m_Rotation = _START_VALUE;
    }

    private void Update() {
        transform.rotation = Quaternion.Euler(Rotation(), 0, 0);
    }

    private float Rotation() {
        m_Rotation += _SPEED * Time.deltaTime;
        if (m_Rotation >= 360f) m_Rotation -= 360f;
        return m_Rotation;
    }
}
