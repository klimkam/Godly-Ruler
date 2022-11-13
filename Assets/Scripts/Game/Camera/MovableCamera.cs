using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MovableCamera : MonoBehaviour
{
    private int _sceenWidth;
    private int _sceenHeight;
    [SerializeField] private List<TupleOfKey> _tupleOfKeys = new List<TupleOfKey>();
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float speed;
    private readonly float _cameraZPosition = -10;
    private readonly float _maxBorderForMousePosition = 5;
    private void Start()
    {
        _sceenHeight = Screen.height;
        _sceenWidth = Screen.width;

    }
    private void Update()
    {
        Vector3 cameraPos = transform.position;
        if (Input.mousePosition.x < _maxBorderForMousePosition)
        {
            cameraPos.x += Move((int)PositivityOfCameraMovement.Negativity);
        }
        else if (Input.mousePosition.y < _maxBorderForMousePosition)
        {
            cameraPos.y += Move((int)PositivityOfCameraMovement.Negativity);
        }
        else if (Input.mousePosition.x > _sceenWidth - _maxBorderForMousePosition)
        {
            cameraPos.x += Move((int)PositivityOfCameraMovement.Positivity);
        }
        else if (Input.mousePosition.y > _sceenHeight - _maxBorderForMousePosition)
        {
            cameraPos.y += Move((int)PositivityOfCameraMovement.Positivity);
        }
        transform.position = cameraPos;
        MoveByKeyboard();
    }
    private void MoveByKeyboard()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizonal = Input.GetAxis("Horizontal");
        transform.position = new Vector3(horizonal * Move(1) + transform.position.x, vertical * Move(1) + transform.position.y, _cameraZPosition);
    }
    private float Move(int value)
    {
        return speed * value * Time.deltaTime;
    }
}
