using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _powerDisplay;

    private void OnEnable()
    {
        _player.PowerChanged += OnPowerChanged;
    }

    private void OnDisable()
    {
        _player.PowerChanged -= OnPowerChanged;
    }

    public void OnPowerChanged(int power)
    {
        _powerDisplay.text = power.ToString();
    }
}
