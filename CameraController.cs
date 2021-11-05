using System;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    private const float _PAN_SPEED = 30f;
    private const float _PAN_BORDER_THICKNESS = 10f;
    private const float _SCROLL_SPEED = 20f;
    private const float _MIN_Y = 10f;
    private const float _MAX_Y = 100f;
    private bool m_DoMovement = true;

    private void Start() {
        transform.position = new Vector3(-10f, 100f, -50f);
        transform.rotation = Quaternion.Euler(70f, 0f, 0f);
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) m_DoMovement = !m_DoMovement;
        if (!m_DoMovement) return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - _PAN_BORDER_THICKNESS) 
            transform.Translate(Vector3.forward * _PAN_SPEED * Time.deltaTime, Space.World);
        if (Input.GetKey("s") || Input.mousePosition.y <= _PAN_BORDER_THICKNESS) 
            transform.Translate(Vector3.back * _PAN_SPEED * Time.deltaTime, Space.World);
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - _PAN_BORDER_THICKNESS) 
            transform.Translate(Vector3.right * _PAN_SPEED * Time.deltaTime, Space.World);
        if (Input.GetKey("a") || Input.mousePosition.x <= _PAN_BORDER_THICKNESS) 
            transform.Translate(Vector3.left * _PAN_SPEED * Time.deltaTime, Space.World);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        
        position.y -= scroll * 10 * _SCROLL_SPEED * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, _MIN_Y, _MAX_Y);
        transform.position = position;
    }
} 
