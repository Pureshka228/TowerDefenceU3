using System;
using UnityEditor;
using UnityEngine;

public class Node : MonoBehaviour {
    
    private GameObject m_StandartTurret;
    private Renderer m_Renderer;
    private Vector3 m_PositionOffset;
    private Color m_StartColor;
    private Color m_HoverColor;

    private void Start() {
        m_Renderer = GetComponent<Renderer>();
        m_StartColor = m_Renderer.material.color;
        m_HoverColor = new Color(0.4f, 0.4f, 0.4f, 1f);

        m_PositionOffset = new Vector3(0f, 0.5f, 0f);
    }

    private void OnMouseDown() {
        if (m_StandartTurret != null) {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        m_StandartTurret = Instantiate(turretToBuild, transform.position + m_PositionOffset, transform.rotation);
    }

    private void OnMouseEnter() {
        m_Renderer.material.color = m_HoverColor;
    }

    private void OnMouseExit() {
        m_Renderer.material.color = m_StartColor;
    }
    
}
