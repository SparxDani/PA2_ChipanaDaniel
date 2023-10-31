using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgLoop : MonoBehaviour
{
    public float speed = 0.25f;
    private Vector2 offset = Vector2.zero;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = material.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        offset.x += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
