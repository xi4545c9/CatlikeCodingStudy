using UnityEngine;

public class Graph3D : MonoBehaviour
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
        //var position = Vector3.zero;
        var scale = Vector3.one*step;
        points = new Transform[resolution*resolution];
        for (int i = 0,x=0,z=0; i < points.Length; i++,x++)
        {
            /*if (x == resolution)
            {
                x = 0;
                z++;
            }*/
            Transform point=Instantiate(pointPrefab);
            /*position.x = (x + 0.5f) * step - 1f;
            position.z = (z + 0.5f) * step - 1f;
            point.localPosition = position;*/
            point.localScale = scale;
            point.SetParent(transform,false);
            points[i] = point;
        }
    }
    private void Update()
    {
        FunctionLibrary.Function3D f = FunctionLibrary.GetFunction3D(function);
        float time = Time.time;
        float step = 2f / resolution;
        float v = 0.5f * step - 1f;
        for (int i = 0,x=0,z=0; i < points.Length; i++,x++)
        {
            if (x == resolution)
            {
                x = 0;
                z++;
                v = (z + 0.5f) * step - 1f;
            }

            float u = (x + 0.5f) * step - 1f;
            //float v = (z + 0.5f) * step - 1f;
            points[i].localPosition = f(u, v, time);
        }
    }
}
