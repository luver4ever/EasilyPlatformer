using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolower : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector2 _followOffset;
    [SerializeField] private Transform _player;
    [SerializeField] private float _cameraSpeed;

    private Vector2 _treshold;
    private Vector2 _difference;

    private void Start()
    {
        _treshold = CalculateTreshold();
    }
    private void FixedUpdate()
    {
        Vector2 follow = _player.position;

        _difference = CalculateDifference(follow);

        MoveCamera(_difference, follow);
    }
    private Vector2 CalculateDifference(Vector2 follow)
    {
        Vector2 difference = new Vector2(Vector2.Distance(transform.position.x * Vector2.right, follow.x * Vector2.right), Vector2.Distance(transform.position.y * Vector2.up, follow.y * Vector2.up));
        return difference;
    }
    private Vector2 CalculateTreshold()
    {
        Rect aspect = _camera.pixelRect;
        var cameraTreshold = new Vector2(_camera.orthographicSize * aspect.width / aspect.height, _camera.orthographicSize);

        cameraTreshold -= _followOffset;

        return cameraTreshold;
    }
    private void MoveCamera(Vector2 difference, Vector2 followObject)
    {
        Vector3 newPosition = transform.position;
        if (Mathf.Abs(difference.x) >= _treshold.x)
            newPosition.x = followObject.x;
        if (Mathf.Abs(difference.y) >= _treshold.y)
            newPosition.y = followObject.y;

        transform.position = Vector3.MoveTowards(transform.position, newPosition, _cameraSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 border = CalculateTreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2,  border.y * 2, 1));
    }

}
