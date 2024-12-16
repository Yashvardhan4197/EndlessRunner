using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController
{
    private InGameUIView inGameUIView;
    private int score;
    private int highScore;
    private bool gamePaused;
    private bool gameLostStatus;
    private bool doubleScorePickUpCheck;
    private PickupUIView pickupUIPrefab;
    private Dictionary<PickupType, PickupUIView> pickupBarsCollection;
    private Dictionary<PickupType, float> pickupBarsTimeCollection; 

    public InGameUIController(InGameUIView inGameUIView,PickupUIView pickupUIPrefab)
    {
        this.inGameUIView = inGameUIView;
        this.inGameUIView.SetController(this);
        this.pickupUIPrefab = pickupUIPrefab;
        GameService.Instance.GameStartAction += OnGameStart;
        GameService.Instance.GameLostAction += GameLost;
        pickupBarsCollection = new Dictionary<PickupType, PickupUIView>();
        pickupBarsTimeCollection = new Dictionary<PickupType, float>();
        inGameUIView.gameObject.SetActive(false);

    }

    private void DeactivatePowerPickUp(PickupType pickupType)
    {
        if (pickupType == PickupType.DOUBLE_COIN)
        {
            doubleScorePickUpCheck = false;
        }
        else if (pickupType == PickupType.DOUBLE_SPEED)
        {
            GameService.Instance.PlayerService.GetPlayerController().SetDoubleSpeedCheck(false);
        }
    }

    private void ActivatePowerPickup(PickupType pickupType)
    {
        if (pickupType == PickupType.DOUBLE_COIN)
        {
            doubleScorePickUpCheck = true;
        }
        else if (pickupType == PickupType.DOUBLE_SPEED)
        {
            GameService.Instance.PlayerService.GetPlayerController().SetDoubleSpeedCheck(true);
        }
    }

    private void RemovePickUpBars()
    {
        foreach (var item in pickupBarsCollection)
        {
            UnityEngine.Object.Destroy(item.Value.gameObject);
        }
        foreach (var item in new List<PickupType>(pickupBarsTimeCollection.Keys))
        {
            pickupBarsTimeCollection[item] = 0f;
        }
    }

    public void OnGameStart()
    {
        score = 0;
        highScore = +PlayerPrefs.GetInt("HighScore",0);
        inGameUIView.GetScoreText().text=score.ToString();
        inGameUIView.GetPauseMenuGB().SetActive(false);
        inGameUIView.gameObject.SetActive(true);
        inGameUIView.GetLostMenuGB().SetActive(false);
        gamePaused = false;
        gameLostStatus = false;
        RemovePickUpBars();
        pickupBarsCollection.Clear();
        pickupBarsTimeCollection.Clear();
        doubleScorePickUpCheck = false;
    }

    public void IncrementScore()
    {
        if (doubleScorePickUpCheck)
        {
            score += 2;
        }
        else
        {
            score++;
        }
        inGameUIView.GetScoreText().text = score.ToString();
        if(score> highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        GameService.Instance.SoundService.PlaySFX(Sound.SCORE_INCREMENT);
    }

    public void OpenPauseScreen()
    {
        inGameUIView.GetPauseMenuGB().SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePauseScreen()
    {
        GameService.Instance.PlayerService.GetPlayerController().SetPauseStatus(false);
        inGameUIView.GetPauseMenuGB().SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitToLobby()
    {
        GameService.Instance.UIService.GetLobbyController().OpenLobby();
        inGameUIView.gameObject.SetActive(false);
        inGameUIView.GetPauseMenuGB().SetActive(false);
        inGameUIView.GetLostMenuGB().SetActive(false);
    }

    public void TogglePauseMenu()
    {
        if (!gameLostStatus)
        {
            if (gamePaused)
            {
                gamePaused = false;
                ClosePauseScreen();
            }
            else
            {
                gamePaused = true;
                OpenPauseScreen();
            }
            GameService.Instance.PlayerService.GetPlayerController().SetPauseStatus(gamePaused);
            GameService.Instance.SoundService.PlaySpecialSound(Sound.BUTTON_CLICK);
        }
    }

    public void ResumeGame()
    {
        ClosePauseScreen();
        gamePaused = false;
        GameService.Instance.PlayerService.GetPlayerController().SetPauseStatus(gamePaused);
    }

    public void RestartGame()
    {
        GameService.Instance.SoundService.PlaySFX(Sound.BUTTON_CLICK);
        GameService.Instance.GameStartAction?.Invoke();
        Time.timeScale = 1f;
    }

    public void GameLost()
    {
        inGameUIView.GetLostMenuGB().SetActive(true);
        inGameUIView.GetPauseMenuGB() .SetActive(false);
        inGameUIView.GetHighScoreText().text="HIGH SCORE: "+highScore.ToString();
        inGameUIView.GetLostScreenYourScoreText().text = "Your Score: " + score.ToString();
        Time.timeScale = 0f;
        gameLostStatus = true;
        GameService.Instance.SoundService.PlaySpecialSound(Sound.GAME_LOST);
    }

    public void OnPickupPowerActivated(PickupType pickupType, float pickupTime, Sprite pickupImage)
    {
        if (pickupBarsCollection.ContainsKey(pickupType)==false)
        {
            PickupUIView newPickUpBar = UnityEngine.Object.Instantiate(pickupUIPrefab);
            newPickUpBar.gameObject.GetComponent<RectTransform>().SetParent(inGameUIView.GetPickupBarParent(),false);
            newPickUpBar.gameObject.GetComponent<RectTransform>().sizeDelta = Vector2.one;
            newPickUpBar.SetMaxTime(pickupTime);
            newPickUpBar.GetPickUpImage().sprite = pickupImage;
            pickupBarsCollection.Add(pickupType, newPickUpBar);
            ActivatePowerPickup(pickupType);
        }
        if (pickupBarsTimeCollection.ContainsKey(pickupType)==false)
        {
            pickupBarsTimeCollection.Add(pickupType, pickupTime);
        }
        else
        {
            pickupBarsTimeCollection[pickupType] = pickupTime;
        }
    }

    public void Update()
    {
        foreach(var type in new List<PickupType>(pickupBarsTimeCollection.Keys))
        {
            if (pickupBarsTimeCollection.ContainsKey(type))
            {
                if (pickupBarsTimeCollection[type] > 0)
                {
                    pickupBarsTimeCollection[type] -= Time.deltaTime;
                    pickupBarsCollection[type].GetPickUpProgressBar().fillAmount = pickupBarsTimeCollection[type] / pickupBarsCollection[type].MaxTime;
                }

                else
                {
                    if (pickupBarsCollection.ContainsKey(type))
                    {
                        UnityEngine.Object.Destroy(pickupBarsCollection?[type].gameObject);
                        pickupBarsCollection.Remove(type);
                        DeactivatePowerPickUp(type);
                    }
                }
            }
        }
    }

}