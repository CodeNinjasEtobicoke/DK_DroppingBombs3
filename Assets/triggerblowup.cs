using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerblowup : MonoBehaviour
{
    [Header("Explosion Parts")]
    public GameObject boom;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(boom, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
