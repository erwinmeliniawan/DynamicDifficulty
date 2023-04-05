using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 poss = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, poss, speed * Time.deltaTime);
    }
}
