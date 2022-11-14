using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class IncreaserTime : MonoBehaviour
{
    [SerializeField] private CollectorOfTargets _collectorOfTargets;
    [SerializeField] private float _reloadTime = 5;
    private float _currentTime;
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _reloadTime)
        {
            List<TargetCreator> targetCreators = _collectorOfTargets.TargetCreators.FindAll(e => e.gameObject.activeInHierarchy);
            targetCreators.ForEach(e => e.CreateTarget());
             _currentTime = 0;
        }
    }
}
