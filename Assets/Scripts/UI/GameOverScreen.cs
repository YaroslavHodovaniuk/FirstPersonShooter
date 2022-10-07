using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _showNumberKills;
    [SerializeField] private Player _player;

    private NumberKills _numberKills;
    private Enemy _enemies;

    private CanvasGroup _gameOverGroup;
    private void OnEnable()
    {
        _player.Died += OnDied;
    }
    private void OnDisable()
    {
        _player.Died -= OnDied;
    }
    private void Start()
    {
        _numberKills = FindObjectOfType<NumberKills>();
        _enemies = FindObjectOfType<Enemy>();
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _gameOverGroup.blocksRaycasts = false;
        _gameOverGroup.interactable = false;
    }
    private void OnDied()
    {
        _showNumberKills.text = _numberKills.GetNumberKills().ToString(); 
        _gameOverGroup.alpha = 1;
        _gameOverGroup.blocksRaycasts = true;
        _gameOverGroup.interactable = true;
        Time.timeScale = 0;
    }
}
