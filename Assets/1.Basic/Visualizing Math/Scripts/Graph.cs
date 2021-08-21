﻿using System;
using UnityEngine;

public class Graph : MonoBehaviour
{
  [SerializeField]
  private Transform pointPrefab = default;

  [SerializeField,Range(10,100)] 
  private int resolution = 10;
  
  
  private void Awake()
  {
    float step = 2f / resolution;
    var position = Vector3.zero;
    var scale = Vector3.one*step;

    
    for (int i = 0; i < resolution; i++)
    {
      Transform point=Instantiate(pointPrefab);
      position.x = (i + 0.5f) *step - 1f;
      position.y = position.x*position.x*position.x;
      point.localPosition = position;
      point.localScale = scale;
      point.SetParent(transform,false);
    }
   
    
  }
}
