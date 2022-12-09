using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public float rotetSpeed, bulletSpeed;
    public Transform canonPos;
    Vector2 direction;
    public Transform shotPoint;
    public float lunchForce;
    public GameObject bullet;


    public GameObject point;
    GameObject[] points;
    public int numberOfPoint;
    public float spaceBetweenpoint;
    // Start is called before the first frame update
    void Awake()
    {
        canonPos = GameObject.Find("canon").transform;
        points = new GameObject[numberOfPoint];
        for (int i = 0; i < numberOfPoint; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }
    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Aim();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }


        for (int i = 0; i < numberOfPoint; i++)
        {
            points[i].transform.position = PointPosition(i*spaceBetweenpoint);
        }
    }

    void Aim()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - canonPos.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        canonPos.rotation = Quaternion.Slerp(transform.rotation, rotation, rotetSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet,shotPoint.position,Quaternion.identity);
        /*if (transform.localScale.x > 0)
        {
            b.GetComponent<Rigidbody2D>().AddForce(shotPoint.right * bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            b.GetComponent<Rigidbody2D>().AddForce(-shotPoint.right * bulletSpeed, ForceMode2D.Impulse);
      } */
        b.GetComponent<Rigidbody2D>().AddForce(shotPoint.up * bulletSpeed, ForceMode2D.Impulse);
        Destroy(b,5);
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * lunchForce * t) + 0.5f * Physics2D.gravity * (t*t);
        return position ;
    }
}
