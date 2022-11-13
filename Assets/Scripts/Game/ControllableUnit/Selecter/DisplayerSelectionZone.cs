using UnityEngine;

public class DisplayerSelectionZone : MonoBehaviour
{
    [SerializeField] private SelecterControllableUnit _selecterControllableUnit;
    [SerializeField] private GameObject _selectionArea;
    [SerializeField] private Camera _camera;
    private Vector3 _startPosition;
    private void Awake()
    {
        _selecterControllableUnit.OnSetStartPostion += TurnOnSelectionArea;
        _selectionArea.SetActive(false);
    }
    private void TurnOnSelectionArea(Vector3 startPosition)
    {
        _startPosition = startPosition;
        StretchZone();
        _selectionArea.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _selectionArea.SetActive(false);
            _selectionArea.transform.localScale = Vector2.zero;
        }
        if (Input.GetMouseButton(0))
        {
            StretchZone();
        }
    }
    private void StretchZone()
    {
        Vector2 currentMousePosition = _camera.GetMouseWorldPosition();
        Vector2 lowerLeftPosition = new Vector2(Mathf.Min(_startPosition.x, currentMousePosition.x), Mathf.Min(_startPosition.y, currentMousePosition.y));
        Vector2 upperRightPosition = new Vector2(Mathf.Max(_startPosition.x, currentMousePosition.x), Mathf.Max(_startPosition.y, currentMousePosition.y));
        _selectionArea.transform.position = lowerLeftPosition;
        _selectionArea.transform.localScale = upperRightPosition - lowerLeftPosition;
    }
    private void OnDisable()
    {
        _selecterControllableUnit.OnSetStartPostion -= TurnOnSelectionArea;
    }
}
