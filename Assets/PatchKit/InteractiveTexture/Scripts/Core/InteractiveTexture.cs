using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PatchKit.InteractiveTexture.Core
{
    public class InteractiveTexture : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler,
        IPointerEnterHandler
    {
        private float _widthImage, _heightImage, _widthTexture, _heightTexture;
        private Vector2 _normalisedPos, _previousNormalisedPos;
        private GraphicRaycaster _raycaster;
        private PointerEventData _pointerEventData;
        private List<RaycastResult> _results;
        private Canvas _canvas;
        private bool _isScreenSpaceOverlay;
        private RectTransform _rectTransform;
        private bool _isPointer;

        public event Action<PointerEventData> OnClickDown;
        public event Action<PointerEventData> OnClickUp;
        public event Action<Vector2> OnMove;
        public event Action OnExit;

        private void Awake()
        {
            Image image = GetComponent<Image>();
            _raycaster = GetComponentInParent<GraphicRaycaster>();
            _canvas = GetComponentInParent<Canvas>();
            _pointerEventData = new PointerEventData(EventSystem.current);
            _rectTransform = GetComponent<RectTransform>();
            _widthTexture = image.mainTexture.width;
            _heightTexture = image.mainTexture.height;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnClickDown?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnClickUp?.Invoke(eventData);
        }

        private void OnPointerMove()
        {
            _results = new List<RaycastResult>();
            _pointerEventData.position = Input.mousePosition;
            _raycaster.Raycast(_pointerEventData, _results);

            if (_results.Count <= 0)
            {
                return;
            }

            Vector3 hitPosition =
                _isScreenSpaceOverlay ? (Vector3)_results[0].screenPosition : _results[0].worldPosition;
            var mousePosition = transform.InverseTransformPoint(hitPosition);
            _normalisedPos = new Vector2(Mathf.RoundToInt(Mathf.Abs(mousePosition.x) / _widthImage * _widthTexture),
                Mathf.RoundToInt(Mathf.Abs(mousePosition.y) / _heightImage * _heightTexture));

            if (_previousNormalisedPos != _normalisedPos)
            {
                _previousNormalisedPos = _normalisedPos;
                OnMove?.Invoke(_normalisedPos);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isPointer = false;
            OnExit?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isPointer = true;
            _isScreenSpaceOverlay = _canvas.renderMode == RenderMode.ScreenSpaceOverlay;
            _widthImage = _rectTransform.rect.width;
            _heightImage = _rectTransform.rect.height;
        }

        private void Update()
        {
            if (_isPointer)
            {
                OnPointerMove();
            }
        }
    }
}