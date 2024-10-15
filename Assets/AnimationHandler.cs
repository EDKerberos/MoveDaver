    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using DG.Tweening;

    public class AnimationHandler : MonoBehaviour
    {
        [SerializeField] private Image imageToAnimate;

        bool isFlipped;
        bool isDropShrunk;
        bool isFaded;

        public void Shake()
        {
            imageToAnimate.rectTransform.DOShakePosition(.5f, 35f);
        }

        public void Flip()
        {
            if(!isFlipped)
            {
                imageToAnimate.rectTransform.DORotate(new Vector3(0f, 90f, 0f), .2f);
                isFlipped = true;
            }
            else
            {
                imageToAnimate.rectTransform.DORotate(new Vector3(0f, 0f, 0f), .2f);
                isFlipped = false;
            }
        }

        public void Drop()
        {
            if(!isDropShrunk)
            {
                imageToAnimate.rectTransform.DOScale(0f, .15f);
                imageToAnimate.rectTransform.DOAnchorPos(new Vector3(20f, 550f, 0f), .15f);
                isDropShrunk = true;
            }
            else
            {
                Sequence dropScale = DOTween.Sequence();

                dropScale.Append(imageToAnimate.rectTransform.DOScale(.85f, .15f));
                dropScale.Append(imageToAnimate.rectTransform.DOScale(.7f, .15f));
                imageToAnimate.rectTransform.DOAnchorPos(new Vector3(20f, 350f, 0f), .1f);
                isDropShrunk = false;
            }
        }

        public void Bounce()
        {
            Sequence bounceSeq = DOTween.Sequence();

            bounceSeq.Append(imageToAnimate.rectTransform.DOAnchorPos(new Vector3(20f, 390f, 0f), .25f));
            bounceSeq.Append(imageToAnimate.rectTransform.DOAnchorPos(new Vector3(20f, 345f, 0f), .15f));
            bounceSeq.Append(imageToAnimate.rectTransform.DOAnchorPos(new Vector3(20f, 370f, 0f), .15f));
            bounceSeq.Append(imageToAnimate.rectTransform.DOAnchorPos(new Vector3(20f, 350f, 0f), .15f));
            bounceSeq.Append(imageToAnimate.rectTransform.DOAnchorPos(new Vector3(20f, 365f, 0f), .15f));
            bounceSeq.Append(imageToAnimate.rectTransform.DOAnchorPos(new Vector3(20f, 350f, 0f), .15f));
        }

        public void Jiggle()
        {
            Sequence jiggleSeq = DOTween.Sequence();

            jiggleSeq.Append(imageToAnimate.rectTransform.DOScale(new Vector3(.95f, .3f, 0f), .25f));
            jiggleSeq.Append(imageToAnimate.rectTransform.DOScale(new Vector3(.95f, .3f, 0f), .1f));
            jiggleSeq.Append(imageToAnimate.rectTransform.DOScale(new Vector3(.5f, .9f, 0f), .1f));
            jiggleSeq.Append(imageToAnimate.rectTransform.DOScale(new Vector3(.7f, .6f, 0f), .1f));
            jiggleSeq.Append(imageToAnimate.rectTransform.DOScale(new Vector3(.65f, .75f, 0f), .1f));
            jiggleSeq.Append(imageToAnimate.rectTransform.DOScale(new Vector3(.73f, .68f, 0f), .1f));
            jiggleSeq.Append(imageToAnimate.rectTransform.DOScale(new Vector3(.7f, .7f, 0f), .1f));
        }

        public void Fade()
        {
            if(!isFaded)
            {
                imageToAnimate.DOFade(0f, 2f);
                isFaded = true;
            }
            else
            {
                imageToAnimate.DOFade(1f, 2f);
                isFaded = false;
            }
        }
    }
