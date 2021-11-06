using System;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    private const float _PAN_BORDER_THICKNESS = 10f;
    private const float _MIN_Y = 10f;
    private const float _MAX_Y = 100f;
    
    private float m_PanSpeed = 30f;
    private float m_ScrollSpeed = 20f;
    private bool m_DoMovement = true;

    private Vector3 m_PanInput;
    private Vector3 m_PanVelocity;

    private void Start() {
        transform.position = new Vector3(-10f, 100f, -50f);
        transform.rotation = Quaternion.Euler(70f, 0f, 0f);
    }

    private void Update() {
        CameraMovementAndScrolling();
    }

    private void CameraMovementAndScrolling() {
        
        if (Input.GetKeyDown(KeyCode.Escape)) m_DoMovement = !m_DoMovement;
        if (!m_DoMovement) return;
        
        // CAMERA MOVEMENT
        m_PanInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        m_PanVelocity = m_PanInput.normalized * m_PanSpeed;
        transform.position += m_PanVelocity * Time.deltaTime;
        
        // SCROLLING
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        
        position.y -= scroll * 10 * m_ScrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, _MIN_Y, _MAX_Y);
        transform.position = position;
    }
} 
