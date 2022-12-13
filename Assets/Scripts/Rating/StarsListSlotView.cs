using System.Collections.Generic;
using UnityEngine;

public class StarsListSlotView : MonoBehaviour
{
    [SerializeField] 
    private List<StarSlotView> _starSlotViews;

    public void Init(PracticeInfoData practiceInfoData)
    {
        ResetRating();
            
        var indexSelectStar = PlayerPrefs.GetInt($"{practiceInfoData.Code}_{Const.StarKey}");
        
        if (indexSelectStar != -1)
        {
            for (var i = 0; i < _starSlotViews.Count; i++)
            {
                _starSlotViews[i].SelectState();
                
                if (indexSelectStar == i)
                    return;
            }
        }
    }

    private void ResetRating()
    {
        foreach (var slot in _starSlotViews)
            slot.ResetState();
    }
}
