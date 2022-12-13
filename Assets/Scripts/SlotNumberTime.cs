using TMPro;
using UnityEngine;

public class SlotNumberTime : MonoBehaviour
{
    [SerializeField] 
    private RectTransform _rect;
    
    [SerializeField] 
    private TMP_Text _label;
    
    private int _number;
    
    public RectTransform Rect => _rect;

    public int Number => _number;

    public void SetData(int number)
    {
        _number = number;
        
        _label.text = number.ToString();
    }

    public void EmptyState()
    {
        _label.gameObject.SetActive(false);
    }
}
