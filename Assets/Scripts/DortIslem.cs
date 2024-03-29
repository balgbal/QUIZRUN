using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DortIslem : MonoBehaviour
{
    public TMP_Text question1,question2,operation,answer,conclusion;
    int number1,number2,operationNo;
    int operationConcluion;
    public GameController gameControllerScript;
    public bool diff = true;
    public string stringDeger;
    private void Start()
    {
        RandomNumberEasy();
        DifficultySelection();
        Difficulty();
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameController>();
        
    }
    public void DifficultySelection()
    {
        stringDeger = PlayerPrefs.GetString("diffSelection");
        if (stringDeger == "easy")
        {
            diff = true;
        }
        else if (stringDeger == "hard")
        {
            diff = false;
        }
    }
    
    public void Difficulty()
    {
        if (diff)
        {
            RandomNumberEasy();
        }
        else
        {
            RandomNumberHard();
        }
    }
    public void RandomNumberEasy()
    {
        number1 = Random.Range(1, 10);
        number2 = Random.Range(1, 10);
        operationNo = Random.Range(1, 5);
        switch (operationNo)
        {
            case 1:
                operation.text = "+";
                operationConcluion = number1 + number2;
                break;
            case 2:
                operation.text = "-";
                again:
                if (number1 >= number2)
                {
                    operationConcluion = number1 - number2;
                }
                else
                {
                    number2 = Random.Range(1, 10);
                    goto again;
                }
                break;
            case 3:
                operation.text = "*";
                operationConcluion = number1 * number2;
                break;
            case 4:
                operation.text = "/";
                if (number1 % number2 != 0)
                {
                    again2:
                    number2 = Random.Range(1, 10);
                    if (number1 % number2 == 0)
                    {
                        operationConcluion = number1 / number2;
                    }
                    else
                    {
                        goto again2;
                    }
                }
                else
                {
                    operationConcluion = number1 / number2;
                }
                break;
        }
        question1.text = number1 + "";
        question2.text = number2 + "";
        answer.text = "";
    }
    public void RandomNumberHard()
    {
        number1 = Random.Range(10, 100);
        number2 = Random.Range(10, 100);
        operationNo = Random.Range(1, 5);
        switch (operationNo)
        {
            case 1:
                operation.text = "+";
                operationConcluion = number1 + number2;
                break;
            case 2:
                operation.text = "-";
            again:
                if (number1 >= number2)
                {
                    operationConcluion = number1 - number2;
                }
                else
                {
                    number2 = Random.Range(10, 100);
                    goto again;
                }
                break;
            case 3:
                operation.text = "*";
                operationConcluion = number1 * number2;
                break;
            case 4:
                operation.text = "/";
                if (number1 % number2 != 0)
                {
                again2:
                    number2 = Random.Range(10, 100);
                    if (number1 % number2 == 0)
                    {
                        operationConcluion = number1 / number2;
                    }
                    else
                    {
                        goto again2;
                    }
                }
                else
                {
                    operationConcluion = number1 / number2;
                }
                break;
        }
        question1.text = number1 + "";
        question2.text = number2 + "";
        answer.text = "";
    }
    public void AnswerControl()
    {
        StartCoroutine(WaitAnswerCheck());
    }
    public IEnumerator WaitAnswerCheck()
    {        
        if (int.Parse(answer.text) == operationConcluion)
        {
            conclusion.text = "DOGRU";
            yield return new WaitForSecondsRealtime(1.5f);
            gameControllerScript.gameContinue = true;
            gameControllerScript.questionPanel.SetActive(false);
            gameControllerScript.timeCounter += 10;
            Difficulty();
        }
        else
        {
            conclusion.text = "YANLIS";
            gameControllerScript.HealtCounter = gameControllerScript.HealtCounter - 1;
            gameControllerScript.healt.text = gameControllerScript.HealtCounter + "";
            if (gameControllerScript.HealtCounter != 0)
            {
                yield return new WaitForSecondsRealtime(1.5f);
                gameControllerScript.questionPanel.SetActive(false);
                gameControllerScript.timeCounter -= 10;
                gameControllerScript.gameContinue = true;                
                Difficulty();
            }
        }
    }
    #region Numbers
    public void Number0()
    {
        answer.text = answer.text + 0 + "";
    }
    public void Number1()
    {
        answer.text = answer.text+ 1 + "";
    }
    public void Number2()
    {
        answer.text = answer.text + 2 + "";
    }
    public void Number3()
    {
        answer.text = answer.text + 3 + "";
    }
    public void Number4()
    {
        answer.text = answer.text + 4 + "";
    }
    public void Number5()
    {
        answer.text = answer.text + 5 + "";
    }
    public void Number6()
    {
        answer.text = answer.text + 6 + "";
    }
    public void Number7()
    {
        answer.text = answer.text + 7 + "";
    }
    public void Number8()
    {
        answer.text = answer.text + 8 + "";
    }
    public void Number9()
    {
        answer.text = answer.text + 9 + "";
    }
    public void ClearText()
    {
        answer.text = "";
    }
    #endregion
}
