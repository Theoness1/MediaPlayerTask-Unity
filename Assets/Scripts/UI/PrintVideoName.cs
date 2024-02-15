using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class PrintVideoName : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;

    public void DeleteSymbolsInName(string videoName) {
        string[] pairOfNumbers = Regex.Split(videoName, @"\d+");
        string lastPair = pairOfNumbers[pairOfNumbers.Length - 1];
        int lastNumbersIndex = videoName.IndexOf(lastPair, 0);
        ChangeText(videoName.Remove(0, lastNumbersIndex).Replace('_', ' '));
    }

    private void ChangeText(string text) {
        _nameText.text = text;
    }
}
