using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    float sinCenterY;
    public float amplitude = 2;
    public float frequency = 0.5f;
    public bool inverted = false;
    // Start is called before the first frame update
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        if (inverted)
        {
            sin = -sin;
        }
        pos.y = sinCenterY + sin;
        transform.position = pos;
    }
}
