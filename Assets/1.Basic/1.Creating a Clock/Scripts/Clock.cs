using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
  [SerializeField] 
  private Transform hoursPivot,minutesPivot,secondsPivot;

  private const float hoursToDegree = -30, minutesToDegree = -6f, secondsToDegree = -6f;
  private void Awake()
  {
    var time = DateTime.Now;
    hoursPivot.localRotation=Quaternion.Euler(0,0,hoursToDegree*time.Hour);
    minutesPivot.localRotation=Quaternion.Euler(0,0,minutesToDegree*time.Minute);
    secondsPivot.localRotation=Quaternion.Euler(0,0,secondsToDegree*time.Second);
  }

  private void Update()
  {
    var time = DateTime.Now.TimeOfDay;
    hoursPivot.localRotation=Quaternion.Euler(0,0,hoursToDegree*(float)time.TotalHours);
    minutesPivot.localRotation=Quaternion.Euler(0,0,minutesToDegree*(float)time.TotalMinutes);
    secondsPivot.localRotation=Quaternion.Euler(0,0,secondsToDegree*(float)time.TotalSeconds);
  }
}
