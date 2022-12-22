using TMPro;
using UnityEngine;

public class SlotNumberTime : MonoBehaviour
{
    [SerializeField] 
    private RectTransform _rect;
    
    [SerializeField] 
    private TMP_Text _label;
    
    [SerializeField] 
    private Color _colorSelect;
    
    [SerializeField] 
    private Color _colorNotSelect;
    
    private int _number;
    
    public RectTransform Rect => _rect;

    public int Number => _number;

    public void SetData(int number)
    {
        _number = number;
        
        var seconds = Mathf.FloorToInt(((float) number) % 60);
        var minutes = Mathf.FloorToInt(((float) number) / 60);
        
        _label.text = $"{minutes}m {seconds}s";
        ChangeSelectColor();
    }

    public void ChangeSelectColor()
    {
        _label.color = _colorSelect;
    }
    
    public void ChangeNotSelectColor()
    {
        _label.color = _colorNotSelect;
    }

    public void EmptyState()
    {
        _label.gameObject.SetActive(false);
    }
}
