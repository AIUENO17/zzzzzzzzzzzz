using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMainManager : MonoBehaviour
{
    public enum State
    {
        Init,
        Start,
        Command,
        Action,
        Result,
    }
    public State GameState = State.Init;

    public GameParamUIPresenter gameParamUIPresenter;

    public CharacterParamManager[] CharacterParamManagers = new CharacterParamManager[3];

    private CharacterParam[] characterParams = new CharacterParam[3];

    private int fastCharacterPos = 0;

    public CharacterParamManager EnemyCharacterParamManager = null;
    private void Update()
    {
        int a = 0;
        if (a<0)
        {
            SceneManager.LoadScene("Result");
        }


        
        switch (GameState)
        {
            case State.Init:
                for (int i = 0; i < 3; i++)
                {
                    if (CharacterParamManagers[i] != null)
                    {
                        characterParams[i] = CharacterParamManagers[i].CharacterParam;
                    }
                }

                gameParamUIPresenter.SetCharacterParamViewer(characterParams);
                GameState = State.Start;
                break;

            case State.Start:

                for (int i = 0; i < 3; i++)
                {
                    if (gameParamUIPresenter.CenterUIViwer.CheckCenterUIVisible(gameParamUIPresenter.WaitGaugeViewer.GetWaitGaugeRate(i)))
                    {
                        fastCharacterPos = i;
                        gameParamUIPresenter.CenterUIViwer.SetCenterUIVisible(true);
                        GameState = State.Command;
                    }
                }
                break;

        case State.Command:
                gameParamUIPresenter.CenterUIViwer.SetCharacterActionButtons(characterParams[fastCharacterPos]
                    ,()=> gameParamUIPresenter.WaitGaugeViewer.ResetWaitGaugeRate(fastCharacterPos));
                GameState = State.Action;
                break;
            
                
                

            case State.Action:
                GameState = State.Start;
        break;
            case State.Result:
                break;
    }
}

}