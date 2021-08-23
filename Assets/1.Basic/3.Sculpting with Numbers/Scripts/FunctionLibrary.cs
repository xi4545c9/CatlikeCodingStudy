using UnityEngine;
using static UnityEngine.Mathf;
public static class FunctionLibrary
{
  public delegate float Function(float x, float t);

  public delegate Vector3 Function3D(float u, float v, float t);

  public enum FunctionName
  {
    Wave,MultiWave,Ripple
  }
  private static Function[] functions={Wave,MultiWave,Ripple};
  private static Function3D[] function3Ds = { Wave, MultiWave, Ripple };
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
}
