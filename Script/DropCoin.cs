using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoin : MonoBehaviour
{
    public Transform coinTerget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 a = transform.position;
        Vector2 b = coinTerget.position;
        transform.position = Vector2.Lerp(a,b,.2f);
    }
}
