using System.Collections;
using System.Collections.Generic;
using UITween;
using UnityEngine;

public class UITweenExamples : MonoBehaviour
{
    [SerializeField] RectTransform MoveUI;
    [SerializeField] AnimationCurve bounceCurve;
    [SerializeField] AnimationCurve SpringCurve;

    public void MoveUIPress()
    {
        resetUI();
        MoveUI.localPosition = new Vector3(-266, 0f, 0f);
        MoveUI.LocalMove(new Vector3(266, 0f, 0f), 1f);
    }

    public void SMoveUIPress()
    {
        resetUI();
        MoveUI.localPosition = new Vector3(-266, 0f, 0f);
        MoveUI.LocalSphericalMove(new Vector3(266, 0f, 0f), 1f);
    }

    public void ShakeUIPress()
    {
        resetUI();
        MoveUI.Shake(2f, 2f);
    }
    public void PopPress()
    {
        resetUI();
        MoveUI.Pop(new(2f,2f,2f), 0.2f);
    }
    public void ScalePress()
    {
        resetUI();
        MoveUI.Scale(new(1.5f, 1.5f, 1.5f), 0.4f);
    }

    public void RotationPress()
    {
        resetUI();
        MoveUI.TLocalRotate(new Vector3 (0f, 0f, 180f), 0.4f);
    }    
    public void SRotationPress()
    {
        resetUI();
        MoveUI.TSLocalRotate(new Vector3 (0f, 0f, 180f), 0.4f);
    }   
    public void BouncePress()
    {
        resetUI();
        MoveUI.Bounce(new Vector3(266, 0f, 0f), 0.5f, bounceCurve);
    }
    public void PulsePress()
    {
        resetUI();
        MoveUI.Pulse(new Vector3(1.2f, 1.2f, 1.2f), 0.4f, 3f);
    }  
    public void SpringPress()
    {
        resetUI();
        MoveUI.localPosition = new Vector3(-266, 0f, 0f);
        MoveUI.Spring(Vector3.zero, 1f,SpringCurve);
    }

    void resetUI()
    {
        MoveUI.localPosition = Vector3.zero;
        MoveUI.localRotation = Quaternion.identity;
        MoveUI.localScale = Vector3.one;
    }
}
