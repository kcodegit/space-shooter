﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  [SerializeField]
  private Text _scoreText;
  [SerializeField]
  private Image _livesImage;
  [SerializeField]
  private Sprite[] _livesSprites;
  [SerializeField]
  private Text _gameOverText;
  [SerializeField]
  private Text _restartText;

  void Start()
  {
    UpdateScoreText(0);
  }

  public void UpdateScoreText(int score)
  {
    _scoreText.text = "Score: " + score;
    _gameOverText.gameObject.SetActive(false);
    _restartText.gameObject.SetActive(false);
  }

  public void UpdateLives(int currentLives){
    _livesImage.sprite = _livesSprites[currentLives];

    if(currentLives == 0){
      GameOverSequence();
    }
  }

  void GameOverSequence(){
    _gameOverText.gameObject.SetActive(true);
    _restartText.gameObject.SetActive(true);
    StartCoroutine(GameOverFlickerRoutine());
  }

  IEnumerator GameOverFlickerRoutine(){
    while(true){
      _gameOverText.text = "GAME OVER";
      yield return new WaitForSeconds(0.5f);
      _gameOverText.text = "";
      yield return new WaitForSeconds(0.5f);
    }
  }
}
