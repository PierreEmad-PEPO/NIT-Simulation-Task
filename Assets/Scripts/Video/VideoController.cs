using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    [SerializeField] private Animator camera;
    [SerializeField] private Animator mfk;
    [SerializeField] private Animator bakra;
    [SerializeField] private Animator bensa;
    [SerializeField] private Animator nut;
    [SerializeField] private GameObject againMenu;

    void Start()
    {
        StartCoroutine(PlayAnimations());
    }

    IEnumerator PlayAnimations()
    {
        camera.Play("IntroCamera");
        yield return new WaitForSeconds(camera.GetCurrentAnimatorStateInfo(0).length + 2);

        mfk.Play("MfkGoesUp");
        yield return new WaitForSeconds(mfk.GetCurrentAnimatorStateInfo(0).length + 2);

        bakra.Play("BakraDecomposition");
        yield return new WaitForSeconds(bakra.GetCurrentAnimatorStateInfo(0).length + 2);

        bensa.Play("BensaGoesUp");
        yield return new WaitForSeconds(bensa.GetCurrentAnimatorStateInfo(0).length + 2);

        nut.Play("NutDecomposition");
        yield return new WaitForSeconds(nut.GetCurrentAnimatorStateInfo(0).length + 2);

        nut.Play("NutComposition");
        yield return new WaitForSeconds(nut.GetCurrentAnimatorStateInfo(0).length + 2);

        bensa.Play("BensaGoesUp");
        yield return new WaitForSeconds(bensa.GetCurrentAnimatorStateInfo(0).length + 2);

        bakra.Play("BakraComposition");
        yield return new WaitForSeconds(bakra.GetCurrentAnimatorStateInfo(0).length + 2);

        mfk.Play("MfkGoesUp");
        yield return new WaitForSeconds(mfk.GetCurrentAnimatorStateInfo(0).length + 2);


        Instantiate(againMenu);
    }
}
