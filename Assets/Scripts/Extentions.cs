using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public static class Extentions
{
    public static T GetRandomElementFromList<T>(this List<T> list) => list[Random.Range(0, list.Count)];
    public static void TurnOffNavmesh(this NavMeshAgent navMeshAgent)
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    public static void ChangeStateOfCanvasGroup(this CanvasGroup canvasGroup, bool isTunrOn)
    {
        canvasGroup.interactable = isTunrOn;
        canvasGroup.blocksRaycasts = isTunrOn;
        canvasGroup.alpha = isTunrOn ? 1 : 0;
    }
    public static List<T> SortListByDistance<T>(this List<T> list, Transform transform) where T : MonoBehaviour
    {
        list.Sort(delegate (T target1, T target2)
        {
            return Vector3.Distance(target1.transform.position, transform.position).CompareTo(Vector3.Distance(target2.transform.position, transform.position));
        });
        return list;
    }
    public static Vector3 GetMouseWorldPosition(this Camera camera) => camera.ScreenToWorldPoint(Input.mousePosition);
    public static void DivideImageBar(this Image image, float biggerValue, float smallerValue)
    {
        float fillValue = (float)smallerValue;
        fillValue /= biggerValue;
        image.fillAmount = fillValue;
    }
}
