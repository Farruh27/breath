using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimeScroller : MonoBehaviour, IDragHandler, IDisposable
{
    private const float Epsilon = 0.001f;

    [SerializeField] 
    private SlotNumberTime _slotNumberTime;
    
    [SerializeField] 
    private ScrollRect _scrollRect;
    
    [SerializeField] 
    private float _speedDrag;
    
    private int _currentIndexSlot;
    private ScrollerTimeMoveState _currentScrollerTimeMoveState;
    
    private int FirstIndexElement => 1;
    private int LastIndexElement => _slots.Count - 2;
    
    private float WidthOneElement => _slotNumberTime.Rect.rect.width;

    public Action<int> OnSelectedTime;

    private List<SlotNumberTime> _slots = new List<SlotNumberTime>();
    private float _endValuePositionX;

    public void Init(int minTime, int maxTime)
    {
        CreateEmptySlot();
        
        for (var i = minTime; i <= maxTime; i++)
        {
            var slotInstance = Instantiate(_slotNumberTime, _scrollRect.content);
            slotInstance.SetData(i);
            _slots.Add(slotInstance);
        }

        CreateEmptySlot();

        _currentScrollerTimeMoveState = ScrollerTimeMoveState.Drag;
        _scrollRect.normalizedPosition = Vector2.zero;
        _currentIndexSlot = (LastIndexElement + FirstIndexElement) / 2;

        RefreshPosition(_currentIndexSlot - 1);
        RefreshCurrentIndexSlot(_currentIndexSlot);
        _scrollRect.content.localPosition = new Vector3(_endValuePositionX, _scrollRect.content.localPosition.y, 0);
    }

    private void CreateEmptySlot()
    {
        var slotEmpty = Instantiate(_slotNumberTime, _scrollRect.content);
        slotEmpty.EmptyState();
        _slots.Add(slotEmpty);
    }
    
    public void Dispose()
    {
        foreach (var slot in _slots)
            Destroy(slot.gameObject);
        
        _slots.Clear();
    }

    private void Update()
    {
        if (_slots.Count == 0)
            return;
        
        if (_currentScrollerTimeMoveState != ScrollerTimeMoveState.Move) 
            return;
        
        var offsetX = Mathf.MoveTowards(_scrollRect.content.localPosition.x,
            _endValuePositionX, Time.deltaTime * _speedDrag);
        
        _scrollRect.content.localPosition = new Vector3(offsetX, _scrollRect.content.localPosition.y, 0);
        
        if (Mathf.Abs(_scrollRect.content.localPosition.x - _endValuePositionX) < Epsilon)
            _currentScrollerTimeMoveState = ScrollerTimeMoveState.Drag;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_currentScrollerTimeMoveState == ScrollerTimeMoveState.Move)
            return;

        if (Mathf.Abs(eventData.delta.x) < Epsilon)
            return;
            
        var multiply = eventData.delta.x > 0 ? -1 : 1;
        
        RefreshPosition(multiply);
        
        var currentIndexSlot = _currentIndexSlot + 1 * multiply;
        RefreshCurrentIndexSlot(currentIndexSlot);

        _currentScrollerTimeMoveState = ScrollerTimeMoveState.Move;
    }

    private void RefreshPosition(int multiply)
    {
        _endValuePositionX = _scrollRect.content.localPosition.x - WidthOneElement * multiply;
    }

    private void RefreshCurrentIndexSlot(int currentIndexSlot)
    {
        _currentIndexSlot = Mathf.Clamp(currentIndexSlot, FirstIndexElement, LastIndexElement);
        SelectTime();
    }

    private void SelectTime()
    {
        ResetColorInSlots();
        _slots[_currentIndexSlot].ChangeSelectColor();
        var currentTime = _slots[_currentIndexSlot].Number;
        OnSelectedTime?.Invoke(currentTime);
    }

    private void ResetColorInSlots()
    {
        foreach (var slot in _slots)
            slot.ChangeNotSelectColor();
    }
}


public enum ScrollerTimeMoveState
{
    Move,
    Drag
}