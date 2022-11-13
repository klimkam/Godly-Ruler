using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public static class Extentions 
{
    public static T GetRandomElementFromList<T>(this List<T> list) => list[Random.Range(0, list.Count)];

    public static void ChangeStateOfCanvasGroup(this CanvasGroup canvasGroup, bool isTunrOn)
    {
        canvasGroup.interactable = isTunrOn;
        canvasGroup.blocksRaycasts = isTunrOn;
        canvasGroup.alpha = isTunrOn ? 1 : 0;
    }
    public static Vector3 GetMouseWorldPosition(this Camera camera) => camera.ScreenToWorldPoint(Input.mousePosition);
    public static void DivideImageBar(this Image image, float biggerValue, float smallerValue)
    {
        float fillValue = (float)smallerValue;
        fillValue /= biggerValue;
        image.fillAmount = fillValue;
    }
}
