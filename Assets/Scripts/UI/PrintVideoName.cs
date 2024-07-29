using TMPro;
using UnityEngine;

public class PrintVideoName : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;

    public void ChangeText(string text) {
        _nameText.text = text;
    }
}
