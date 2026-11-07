using System.Collections;
using UnityEngine;

public class Btn : MonoBehaviour
{

    public void mulaigame()
    {
        // Get the Animator from the parent GameObject directly
        Animator bgAnimator = transform.parent != null ? transform.parent.GetComponent<Animator>() : null;
        
        // Get the Animator attached to this Button/Text
        Animator textAnimator = GetComponent<Animator>();

        if (bgAnimator != null)
        {
            StartCoroutine(gotoMenu(bgAnimator, textAnimator));
        }
        else
        {
            Debug.LogError("No Animator found on the parent GameObject!", this);
        }
    }

    IEnumerator gotoMenu(Animator Bg, Animator text)
    {
        Bg.SetTrigger("IsStart");
        text.SetTrigger("IsStart");
        yield return new WaitForSeconds(1f);
        Bg.gameObject.SetActive(false);

    }
}
