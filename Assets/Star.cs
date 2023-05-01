using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    SpriteRenderer apparentity;

    void Start()
    {
        apparentity = GetComponent<SpriteRenderer>();

        float random = Random.Range(0.01f, 0.03f);

        transform.localScale = new Vector3(random, random, 1.0f);

        if(random > 0.02)
        {
            apparentity.enabled = false;
        }
        InvokeRepeating("apparentityChange", 0.0f, 3.0f);
    }

    void apparentityChange()
    {
        apparentity.enabled = !apparentity.enabled;
    }
    
    
}
