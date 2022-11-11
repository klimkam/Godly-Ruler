using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerSizeOfCamera : MonoBehaviour
{
    [SerializeField] private Vector2 _bordersForCamera = new Vector2(3,6);
    [SerializeField] private Camera _mainCamera;
    private void Update()
    {
        float scrolling = Input.GetAxis("Mouse ScrollWheel");
        if (scrolling > 0 && _mainCamera.orthographicSize <= _bordersForCamera.y)
        {
            _mainCamera.orthographicSize++;
        }
        if (scrolling < 0 && _mainCamera.orthographicSize >= _bordersForCamera.x)
        {
            _mainCamera.orthographicSize--;
        }

    }
}
