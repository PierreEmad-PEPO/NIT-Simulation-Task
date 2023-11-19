using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsDictionary : MonoBehaviour
{
    private Animation animation;
    [SerializeField] private List<AnimationClip> animations0 = new List<AnimationClip>();
    [SerializeField] private List<AnimationClip> animations1 = new List<AnimationClip>();
    [SerializeField] private List<AnimationClip> animations2 = new List<AnimationClip>();
    [SerializeField] private List<AnimationClip> animations3 = new List<AnimationClip>();
    [SerializeField] private List<AnimationClip> animations4 = new List<AnimationClip>();
    [SerializeField] private List<AnimationClip> animations5 = new List<AnimationClip>();
    [SerializeField] private List<AnimationClip> animations6 = new List<AnimationClip>();
    [SerializeField] private List<AnimationClip> animations7 = new List<AnimationClip>();
    [SerializeField] private List<AnimationClip> animations8 = new List<AnimationClip>();
    [SerializeField] private List<AnimationClip> animations9 = new List<AnimationClip>();
    [SerializeField] private List<AnimationClip> animations10 = new List<AnimationClip>();

    private void Start()
    {
        animation = GetComponent<Animation>();
    }

    public void Play(int index)
    {
        switch (index)
        {
            case 0:
                foreach (var anim in animations0)
                {
                    animation.PlayQueued(anim.name);
                } break;
            case 1:
                foreach (var anim in animations1)
                {
                    animation.PlayQueued(anim.name);
                }
                break;
            case 2:
                foreach (var anim in animations2)
                {
                    animation.PlayQueued(anim.name);
                }
                break;
            case 3:
                foreach (var anim in animations3)
                {
                    animation.PlayQueued(anim.name);
                }
                break;
            case 4:
                foreach (var anim in animations4)
                {
                    animation.PlayQueued(anim.name);
                }
                break;
            case 5:
                foreach (var anim in animations5)
                {
                    animation.PlayQueued(anim.name);
                }
                break;
            case 6:
                foreach (var anim in animations6)
                {
                    animation.PlayQueued(anim.name);
                }
                break;
            case 7:
                foreach (var anim in animations7)
                {
                    animation.PlayQueued(anim.name);
                }
                break;
            case 8:
                foreach (var anim in animations8)
                {
                    animation.PlayQueued(anim.name);
                }
                break;
            case 9:
                foreach (var anim in animations9)
                {
                    animation.PlayQueued(anim.name);
                }
                break;
            case 10:
                foreach (var anim in animations10)
                {
                    animation.PlayQueued(anim.name);
                }
                break;
        }

    }
}
