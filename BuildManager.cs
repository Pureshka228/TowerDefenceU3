using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager Instance;

    private GameObject m_TurretToBuild;

    [Header("References")]
    [SerializeField] private GameObject standartTurretPrefab;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        m_TurretToBuild = standartTurretPrefab;
    }

    public GameObject GetTurretToBuild() {
        return m_TurretToBuild;
    }

}
