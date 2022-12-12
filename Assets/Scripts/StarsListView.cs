using System;
using System.Collections.Generic;
using UnityEngine;

public class StarsListView : MonoBehaviour, IDisposable
{
    [SerializeField] 
    private List<StarView> _stars;

    private int _indexSelectStar;

    public int IndexSelectStar => _indexSelectStar;

    public void Init()
    {
        _indexSelectStar = -1;
        
        foreach (var star in _stars)
        {
            star.Init();
            star.OnClickStar += ClickStar;
        }
    }

    public void Dispose()
    {
        foreach (var star in _stars)
            star.OnClickStar -= ClickStar;
    }

    private void ClickStar(StarView clickStar)
    {
        if (clickStar.IsSelect)
        {
            var isBorderReached = false;

            for (var i = 0; i < _stars.Count; i++)
            {
                if (clickStar == _stars[i])
                {
                    _stars[i].ResetState();
                    _indexSelectStar = i - 1;
                    isBorderReached = true;
                }
                else
                {
                    if (isBorderReached)
                        _stars[i].ResetState();
                }
            }
        }
        else
        {
            var isBorderReached = false;

            for (var i = 0; i < _stars.Count; i++)
            {
                if (clickStar == _stars[i])
                {
                    _stars[i].SelectStar();
                    _indexSelectStar = i;
                    isBorderReached = true;
                }
                else
                {
                    if (isBorderReached)
                        _stars[i].ResetState();
                    else
                        _stars[i].SelectStar();
                }
            }
        }
    }
}
