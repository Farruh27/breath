using UnityEngine;
using UnityEngine.UI;

public class StarSlotView : MonoBehaviour
{
    [SerializeField] 
    private Image _selectedImage;
    
    [SerializeField] 
    private Image _notSelectedImage;

    public void ResetState()
    {
        RefreshState(false);
    }
    
    public void SelectState()
    {
        RefreshState(true);
    }

    private void RefreshState(bool isSelect)
    {
        _selectedImage.gameObject.SetActive(isSelect);
        _notSelectedImage.gameObject.SetActive(!isSelect);
    }
}
