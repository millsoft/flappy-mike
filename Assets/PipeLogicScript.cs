using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLogicScript : MonoBehaviour
{

    public Animator fingerAnimator;
    private float showTime;
    private float showTimer =  0;
    private float stayTimer =  0;
    private float stayDuration =  0;

    private bool isFingerVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        resetShowTime();

    }

    void resetShowTime()
    {
        showTime = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {

        if (!isFingerVisible)
        {
            if (showTimer < showTime)
            {
                showTimer += Time.deltaTime;
            }
            else
            {

                //show finger but only in front of the bird
                if (showTime < 2)
                {
                    showFinger();
                    showTimer = 0;
                    stayDuration = Random.Range(4, 6);
                }

            }
        }
        else
        {
            if (stayTimer < stayDuration)
            {
                stayTimer += Time.deltaTime;
            }
            else
            {
                hideFinger();
                resetShowTime();
            }
        }
    }

    void showFinger()
    {
        fingerAnimator.SetBool("isFingerVisible", true);
        isFingerVisible = true;
    }
    void hideFinger()
    {
        fingerAnimator.SetBool("isFingerVisible", false);
        isFingerVisible = false;
    }
}
