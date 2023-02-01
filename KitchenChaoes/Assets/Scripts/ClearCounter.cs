using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private Transform tomatoPrefab;
    [SerializeField] private Transform topPoint;


    public void Interact()
    {
        Transform tomatoTransform = Instantiate(tomatoPrefab, topPoint);
        tomatoTransform.localPosition = Vector3.zero;
    }
}
