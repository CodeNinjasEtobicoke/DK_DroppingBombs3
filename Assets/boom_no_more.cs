using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom_no_more : MonoBehaviour
{
    private ParticleSystem particleSmoke;
    // Start is called before the first frame update
    private void Awake()
    {
        particleSmoke = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!particleSmoke.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
