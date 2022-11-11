using System.Collections.Generic;
using UnityEngine;
using System;
public class SelecterAngels : MonoBehaviour
{
    private Vector3 _startPosition;
    private readonly float _raduis = 0.8f;
    private List<Angel> _angels = new List<Angel>();
    [SerializeField] private Camera _camera;
    public event Action<Vector3> OnSetStartPostion;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _angels.ForEach(e => e.AngelBacklight.Disappear());
            _angels.Clear();
            _startPosition = _camera.GetMouseWorldPosition();
            OnSetStartPostion?.Invoke(_startPosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Collider2D[] collider2Ds = Physics2D.OverlapAreaAll(_startPosition, _camera.GetMouseWorldPosition());
            foreach (Collider2D collider2D in collider2Ds)
            {
                if(collider2D.TryGetComponent<Angel>(out Angel angel))
                {
                    _angels.Add(angel);
                    angel.AngelBacklight.Appear();
                }
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 moveToPosition = _camera.GetMouseWorldPosition();
            List<Vector2> targetPositionList = GetPositionListAround(moveToPosition,_raduis, _angels.Count);
            int indexOfTargetPosition = 0;
            int additionalvalueOfTargetPosition = 1;
            foreach (Angel angle in _angels)
            {
                angle.StartMoving(targetPositionList[indexOfTargetPosition]);
                indexOfTargetPosition = (indexOfTargetPosition+ additionalvalueOfTargetPosition) % targetPositionList.Count;
            }
        }
    }
    private List<Vector2> GetPositionListAround(Vector2 startPostion, float distance, int positionCount)
    {
        List<Vector2> positionList = new List<Vector2>();
        for(int i = 0; i< positionCount; i++)
        {
            float angle = i * (360 / positionCount);
            Vector2 direction = Quaternion.Euler(0, 0, angle) * new Vector2(1, 0);
            Vector2 position = startPostion + direction * distance;
            positionList.Add(position);
        }
        return positionList;
    }
}
