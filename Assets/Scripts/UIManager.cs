using System.Collections;
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

  void Start()
  {
    UpdateScoreText(0);
  }

  public void UpdateScoreText(int score)
  {
    _scoreText.text = "Score: " + score;
  }

  public void UpdateLives(int currentLives){
    _livesImage.sprite = _livesSprites[currentLives];
  }
}
