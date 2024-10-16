using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class DerpyScript : MonoBehaviour
{
    public SpriteRenderer SR;
    Color startColor = Color.blue; 
    // Start is called before the first frame update
    void Start()
    {
        SR.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(0.01f, 0, 0);
        transform.Rotate(0, 0, 90*Time.deltaTime);
    }
}
