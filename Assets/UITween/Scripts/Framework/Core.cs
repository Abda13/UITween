using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UITween.Internal;
using TMPro;


namespace UITween
{
    public static class Core 
    {
        static TweenManager TweenManager
        {
            get
            {
                if (TweenManager.instance == null)
                {
                    GameObject gameObject = new GameObject("TweenManager");
                    gameObject.AddComponent<TweenManager>();
                }
                return TweenManager.instance;
            }
        }

        #region Translation
        public static void LocalMove(this RectTransform rectTransform,Vector3 targetPosition, float duration)
        {
            TweenManager.Move(rectTransform, targetPosition, duration,Space.Self,false);
        }
        public static void LocalSphericalMove(this RectTransform rectTransform, Vector3 targetPosition, float duration)
        {
            TweenManager.Move(rectTransform, targetPosition, duration, Space.Self, true);
        }
        public static void Move(this RectTransform rectTransform, Vector3 targetPosition, float duration)
        {
            TweenManager.Move(rectTransform, targetPosition, duration, Space.World, false);
        }
        public static void SphericalMove(this RectTransform rectTransform, Vector3 targetPosition, float duration)
        {
            TweenManager.Move(rectTransform, targetPosition, duration, Space.World, true);
        }
        #endregion

        #region Rotation 
        public static void TLocalRotate(this RectTransform rectTransform, Vector3 targetRotation, float duration)
        {
            TweenManager.Rotate(rectTransform, Quaternion.Euler(targetRotation), duration,Space.Self,false);
        }
        public static void TLocalRotate(this RectTransform rectTransform, Quaternion targetRotation, float duration)
        {
            TweenManager.Rotate(rectTransform, targetRotation, duration, Space.Self, false);
        }

        public static void TSLocalRotate(this RectTransform rectTransform, Vector3 targetRotation, float duration)
        {
            TweenManager.Rotate(rectTransform, Quaternion.Euler(targetRotation), duration, Space.Self, true);
        }
        public static void TSLocalRotate(this RectTransform rectTransform, Quaternion targetRotation, float duration)
        {
            TweenManager.Rotate(rectTransform, targetRotation, duration, Space.Self, true);
        }

        public static void TRotate(this RectTransform rectTransform, Vector3 targetRotation, float duration)
        {
            TweenManager.Rotate(rectTransform, Quaternion.Euler(targetRotation), duration, Space.World, false);
        }

        public static void TRotate(this RectTransform rectTransform, Quaternion targetRotation, float duration)
        {
            TweenManager.Rotate(rectTransform, targetRotation, duration, Space.World, false);
        }

        public static void TSRotate(this RectTransform rectTransform, Vector3 targetRotation, float duration)
        {
            TweenManager.Rotate(rectTransform, Quaternion.Euler(targetRotation), duration, Space.World, true);
        }

        public static void STRotate(this RectTransform rectTransform, Quaternion targetRotation, float duration)
        {
            TweenManager.Rotate(rectTransform, targetRotation, duration, Space.World, true);
        }

        #endregion

        #region Effects
        public static void Scale(this RectTransform rectTransform, Vector3 targetPosition, float duration)
        {
            TweenManager.Scale(rectTransform, targetPosition, duration);
        }    
        
        public static void Shake(this RectTransform rectTransform, float duration, float intensity)
        {
            TweenManager.Shake(rectTransform,duration,intensity);
        }

        public static void Pop(this RectTransform rectTransform, Vector3 targetScale, float duration)
        {
            TweenManager.Pop(rectTransform, targetScale, duration);
        } 
        
        public static void Bounce(this RectTransform rectTransform, Vector3 targetPosition, float duration)
        {
            TweenManager.Bounce(rectTransform, targetPosition, duration);
        }
        public static void Bounce(this RectTransform rectTransform, Vector3 targetPosition, float duration, AnimationCurve bounceCurve)
        {
            TweenManager.Bounce(rectTransform, targetPosition, duration, bounceCurve);
        }
          
        public static void Pulse(this RectTransform rectTransform, Vector3 targetScale, float pulseDuration, float duration, float speed = 1f)
        {
            TweenManager.Pulse(rectTransform, targetScale, pulseDuration, duration, speed);
        } 
        public static void Spring(this RectTransform rectTransform, Vector3 targetPosition, float duration, AnimationCurve springCurve)
        {
            TweenManager.Spring(rectTransform, targetPosition, duration, springCurve);
        }
        #endregion
    }
}
