using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fSpeed;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * fSpeed * Time.deltaTime;
    }
    public void Fire(Vector3 start, Vector3 target)
    {
        gameObject.SetActive(true);
        transform.position = start;
        transform.forward = target - start;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit "+other.name);
    }
}
