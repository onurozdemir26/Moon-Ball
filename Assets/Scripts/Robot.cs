using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private Animator robotAnim;
    // Start is called before the first frame update
    void Start()
    {
        robotAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        robotAnim.SetTrigger("Idle");
        
    }
}
