using System;
using UnityEngine;

public class Graph : MonoBehaviour
{
  [SerializeField]
  private Transform pointPrefab = default;

  [SerializeField,Range(10,100)] 
  private int resolution = 10;

  //[SerializeField, Range(0, 2)] 
  //private int function = 0;
  [SerializeField] 
  private FunctionLibrary.FunctionName function = default;
  
  private Transform[] points;
  
  private void Awake()
  {
    float step = 2f / resolution;
    var position = Vector3.zero;
    var scale = Vector3.one*step;

    points = new Transform[resolution];
    for (int i = 0; i < resolution; i++)
    {
      Transform point=Instantiate(pointPrefab);
      position.x = (i + 0.5f) *step - 1f;
      //position.y = position.x*position.x*position.x;
      point.localPosition = position;
      point.localScale = scale;
      point.SetParent(transform,false);
      points[i] = point;
    }
  }
  private void Update()
  {
    FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
    float time = Time.time;
    for (int i = 0; i < points.Length; i++)
    {
      Transform point = points[i];
      Vector3 position = point.localPosition;
      /*if (function == 0)
      {
        position.y = FunctionLibrary.Wave(position.x, time);
      }
      else if(function==1)
      {
        position.y = FunctionLibrary.MultiWave(position.x, time);
      }
      else
      {
        position.y = FunctionLibrary.Ripple(position.x, time);
      }*/
      position.y = f(position.x, time);
      point.localPosition = position;
    }
  }
}
