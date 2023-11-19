using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animation anim = GetComponent<Animation>();
        AnimationClip clip = anim.GetClip("IntroCamera");
        if (clip != null)
        {
            anim.clip = clip;
            anim.Play();
        }
    }

}
