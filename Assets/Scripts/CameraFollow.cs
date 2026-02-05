using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed = 5f;
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        if (_target == null) return;

        Vector3 desiredPostition = new Vector3(_target.position.x, _target.position.y,
            -10) + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, 
            desiredPostition, _smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

}
