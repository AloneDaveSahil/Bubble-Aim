using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
    public GameObject particle;
    public GameObject drop_coin;
   

    // Start is called before the first frame update
   

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag=="Bullet")
        {
            GameM.instance.AddPoint();
            Destroy(gameObject);
           GameObject b= Instantiate(particle,transform.position,Quaternion.identity);
            GameObject c = Instantiate(drop_coin,transform.position,Quaternion.identity);
           Destroy(b,10);
            Destroy(c,7);
           
        }
    }

    
}
