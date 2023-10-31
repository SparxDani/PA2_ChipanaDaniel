using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyController : MonoBehaviour
{
    public int frame;
    public int lifeChanges;

    void Update()
    {
        if (transform.position.x <= -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x)
        {
            CandyGenerator.instance.ManageCandy(this);
        }
    }
}
