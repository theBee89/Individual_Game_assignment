using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_AnimationEnd : MonoBehaviour
{
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        float animTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, animTime + delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
