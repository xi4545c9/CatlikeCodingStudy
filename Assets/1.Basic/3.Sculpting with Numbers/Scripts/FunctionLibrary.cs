﻿using UnityEngine;
using static UnityEngine.Mathf;
public static class FunctionLibrary
{
  public delegate float Function(float x, float t);

  public delegate Vector3 Function3D(float u, float v, float t);

  public enum FunctionName
  {
    Wave,MultiWave,Ripple,Sphere,Torus
  }
  private static Function[] functions={Wave,MultiWave,Ripple};
  private static Function3D[] function3Ds = { Wave, MultiWave, Ripple,Sphere,Torus };
  public static Function GetFunction(FunctionName name)
  {
    return functions[(int)name];
  }

  public static Function3D GetFunction3D(FunctionName name)
  {
    return function3Ds[(int)name];
  }
  public static float Wave(float x,float t)
  {
    return Sin(PI * (x + t));
  }

  public static Vector3 Wave(float u, float v, float t)
  {
    Vector3 p;
    p.x = u;
    p.y = Sin(PI * (u + v + t));
    p.z = v;
    return p;
  }
  public static float MultiWave(float x,float t)
  {
    float y = Sin(PI * x + 0.5f*t);
    y += 0.5f*Sin(2f * PI * (x + t));
    
    return y*(2f/3f);
  }
  public static Vector3 MultiWave(float u,float v,float t)
  {
    Vector3 p;
    p.x = u;
    p.y = Sin(PI * (u + 0.5f * t));
    p.y += 0.5f * Sin(2f * PI * (v + t));
    p.y *= 1f / 2.5f;
    p.z = v;
    return p;
  }

  public static float Ripple(float x, float t)
  {
    float d = Abs(x);
    float y = Sin(PI*(4f*d-t));
    return y/(1f+10f*d);
  }
  public static Vector3 Ripple(float u,float v, float t)
  {
    float d = Sqrt(u * u + v * v);
    Vector3 p;
    p.x = u;
    p.y = Sin(PI * (4f * d - t));
    p.y /= 1f + 10f * d;
    p.z = v;
    return p;
  }
  
  public static Vector3 Sphere(float u, float v, float t)
  {
    float r = 0.9f + 0.1f * Sin(PI*(6f*u+4f*v+t));
    float s =r*Cos(0.5f*PI*v);
    Vector3 p;
    p.x = s*Sin(PI * u);
    p.y = r*Sin(PI*0.5f*v);
    p.z = s*Cos(PI*u);
    return p;
  }

  public static Vector3 Torus(float u, float v, float t)
  {
    float r1 = 0.7f+0.1f*Sin(PI*(6f*u+0.5f*t));
    float r2 = 0.15f+0.05f*Sin(PI*(8f*u+4f*v+2f*t));
    float s =r1+r2 * Cos(PI * v);
    Vector3 p;
    p.x = s * Sin(PI * u);
    p.y = r2 * Sin(PI * v);
    p.z = s * Cos(PI * u);
    return p;
  }
}
