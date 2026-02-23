using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Color _gizmoColor = Color.green;
    [SerializeField] private float _gizmoSize = 0.5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawWireSphere(transform.position, _gizmoSize);
        //Gizmos.DrawSphere(transform.position, _gizmoSize);
    }
}
