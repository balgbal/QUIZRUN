using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class GameController : MonoBehaviour
{
    #region Degiskenler
    public List<GameObject> allImages;
    public List<GameObject> images;
    public List<GameObject> randomImageList;
    public List<GameObject> questionMarks;
    //public List<Sprite> questionMarkSprites;

    public List<FirstWord> firstWord;
    public List<FirstAnswerWord> firstAnswerWord;
    [SerializeField] private Button selectedButton;
    [SerializeField] private string selectedBtnName;
    #region buton ve kelime sýrasý

    private int selectedBtnFirstWord;
    private int selectedBtnSecondWord;
    private int selectedBtnThirdWord;
    private int selectedBtnFourthWord;

    private int secondWordCount;
    private int thirdWordCount;
    private int fourthWordCount;
    private int fifthWordCount;

    private int selectedBtnFirstAnswer;
    private int selectedBtnSecondAnswer;
    private int selectedBtnThirdAnswer;
    private int selectedBtnFourthAnswer;

    private int secondAnswerCount;
    private int thirdAnswerCount;
    private int fourthAnswerCount;
    private int fifthAnswerCount;

    private int question = 0;
    #endregion
    [SerializeField] private int wordInSentence = 1;
    [SerializeField] private int answerInSentece = 1;

    [SerializeField] private List<string> tempList = new List<string>();
    [SerializeField] private List<ButtonsControl> buttonsControls;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] private string lastPressedButton;
    [SerializeField] private string firstPressedButton;
    [SerializeField] private GameObject questionGO;
    #endregion

    /*
     * 1.Adým => Butonlara ayný sorularý atamamasý için atananlarý kontrol ettik. atanmamýþsa yeni atama yaptýk. atandýysa tekrarladýk.
     * 2.Adým => Seçilen butondaki kelimeyi aldýk, ekrana yazdýk veya devamýna ekledik.
     * 3.Adým => Seçilen butondaki kelimenin listedeki indexini al.
     * 4.Adým => Butonlardaki kelimeleri sildik.
     * 5.Adým => seçilen kelimenin çocuklarýndan fazla olan butonlar false yapýldý.
     * 6.Adým => Butonlara 2.kelimeleri ata. ( 1.Adým )
     * 7.Adým => tüm adýmlarý tekrarla
    */
    private void Start()
    {
        AnimalImage();
        FirstQuestionWord();
        QuestionMark();
        TrueAnswer();
    }
    public void VariableReset()
    {
        selectedBtnFirstWord = 0;
        selectedBtnSecondWord = 0;
        selectedBtnThirdWord = 0;
        selectedBtnFourthWord = 0;
        secondWordCount = 0;
        thirdWordCount = 0;
        fourthWordCount = 0;
        fifthWordCount = 0;
        selectedBtnFirstAnswer = 0;
        selectedBtnSecondAnswer = 0;
        selectedBtnThirdAnswer = 0;
        selectedBtnFourthAnswer = 0;
        secondAnswerCount = 0;
        thirdAnswerCount = 0;
        fourthAnswerCount = 0;
        fifthAnswerCount = 0;
        wordInSentence = 1;
        answerInSentece = 1;
    }
    public void ResetButtons()
    {
        for (int i = 0; i < buttonsControls.Count; i++)
        {
            buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
        }
        questionText.text = "";
        answerText.text = "";
    }
    #region Sorular icin kelimelerin cekildiði alan
    public void FirstQuestionWord()
    {
        // 1.Adým
        for (int i = 0; i < buttonsControls.Count; i++)
        {
        again:
            int randomFirstWord = Random.Range(0, firstWord.Count);

            if (!tempList.Contains(firstWord[randomFirstWord].word1))
            {
                if (buttonsControls[i].questionOrAnswer == true)
                {
                    tempList.Add(firstWord[randomFirstWord].word1);
                    buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstWord[randomFirstWord].word1;
                }
                else
                {
                    tempList.Add(firstAnswerWord[0].answerWord1);
                    buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstAnswerWord[0].answerWord1;
                }
            }
            else
            {
                goto again;
            }
        }
    }
    public void SecondQuestionWord()
    {
        wordInSentence++;
        if (secondWordCount > 0)
        {
            if (secondWordCount <= buttonsControls.Count)
            {
                for (int i = 0; i < secondWordCount; i++)
                {
                again:
                    int randomSecondWord = Random.Range(0, secondWordCount);
                    if (!tempList.Contains(firstWord[selectedBtnFirstWord].secondWord[randomSecondWord].word2))
                    {
                        tempList.Add(firstWord[selectedBtnFirstWord].secondWord[randomSecondWord].word2);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstWord[selectedBtnFirstWord].secondWord[randomSecondWord].word2;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                again:
                    int randomSecondWord = Random.Range(0, secondWordCount);
                    if (!tempList.Contains(firstWord[selectedBtnFirstWord].secondWord[randomSecondWord].word2))
                    {
                        tempList.Add(firstWord[selectedBtnFirstWord].secondWord[randomSecondWord].word2);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstWord[selectedBtnFirstWord].secondWord[randomSecondWord].word2;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
        }
        else
        {
            StartCoroutine(Wait());
        }
    }
    public void SecondAnswerWord()
    {
        answerInSentece++;
        if (secondAnswerCount > 0)
        {
            if (secondAnswerCount <= buttonsControls.Count)
            {
                for (int i = 0; i < secondAnswerCount; i++)
                {
                again:
                    int randomSecondAnswerWord = Random.Range(0, secondAnswerCount);
                    if (!tempList.Contains(firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[randomSecondAnswerWord].answerWord2))
                    {
                        tempList.Add(firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[randomSecondAnswerWord].answerWord2);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[randomSecondAnswerWord].answerWord2;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                again:
                    int randomSecondAnswerWord = Random.Range(0, secondAnswerCount);
                    if (!tempList.Contains(firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[randomSecondAnswerWord].answerWord2))
                    {
                        tempList.Add(firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[randomSecondAnswerWord].answerWord2);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[randomSecondAnswerWord].answerWord2;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
        }
        else
        {
            StartCoroutine(Wait());
        }
    }
    public void ThirdQuestion()
    {
        wordInSentence++;
        if (thirdWordCount > 0)
        {
            if (thirdWordCount <= buttonsControls.Count)
            {
                for (int i = 0; i < thirdWordCount; i++)
                {
                again:
                    int randomThirdWord = Random.Range(0, thirdWordCount);
                    if (!tempList.Contains(firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[randomThirdWord].word3))
                    {
                        tempList.Add(firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[randomThirdWord].word3);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[randomThirdWord].word3;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                again:
                    int randomThirdWord = Random.Range(0, thirdWordCount);
                    if (!tempList.Contains(firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[randomThirdWord].word3))
                    {
                        tempList.Add(firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[randomThirdWord].word3);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[randomThirdWord].word3;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
        }
        else
        {
            StartCoroutine(Wait());
        }
    }
    public void ThirdAnswerWord()
    {
        answerInSentece++;
        if (thirdAnswerCount > 0)
        {
            if (thirdAnswerCount <= buttonsControls.Count)
            {
                for (int i = 0; i < thirdAnswerCount; i++)
                {
                again:
                    int randomThirdAnswerWord = Random.Range(0, thirdAnswerCount);
                    if (!tempList.Contains(firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[randomThirdAnswerWord].answerWord3))
                    {
                        tempList.Add(firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[randomThirdAnswerWord].answerWord3);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[randomThirdAnswerWord].answerWord3;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                again:
                    int randomThirdAnswerWord = Random.Range(0, thirdAnswerCount);
                    if (!tempList.Contains(firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[randomThirdAnswerWord].answerWord3))
                    {
                        tempList.Add(firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[randomThirdAnswerWord].answerWord3);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[randomThirdAnswerWord].answerWord3;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
        }
        else
        {
            StartCoroutine(Wait());
        }
    }
    public void FourthQuestion()
    {
        wordInSentence++;
        if (fourthWordCount > 0)
        {
            if (fourthWordCount <= buttonsControls.Count)
            {
                for (int i = 0; i < fourthWordCount; i++)
                {
                again:
                    int randomFourthWord = Random.Range(0, fourthWordCount);
                    if (!tempList.Contains(firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[randomFourthWord].word4))
                    {
                        tempList.Add(firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[randomFourthWord].word4);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[randomFourthWord].word4;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                again2:
                    int randomFourthWord = Random.Range(0, fourthWordCount);
                    if (!tempList.Contains(firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[randomFourthWord].word4))
                    {
                        tempList.Add(firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[randomFourthWord].word4);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[randomFourthWord].word4;
                    }
                    else
                    {
                        goto again2;
                    }
                }
            }
        }
        else
        {
            StartCoroutine(Wait());            
        }
    }
    public void FourthAnswerWord()
    {
        answerInSentece++;

        for (int i = 0; i < buttonsControls.Count; i++)
        {
            if (buttonsControls[i].questionOrAnswer == false)
            {
            again:
                int randomFourthAnswerWord = Random.Range(0, images.Count);
                if (!tempList.Contains(images[randomFourthAnswerWord].GetComponent<Image>().sprite.name))
                {
                    tempList.Add(images[randomFourthAnswerWord].GetComponent<Image>().sprite.name);
                    buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = images[randomFourthAnswerWord].GetComponent<Image>().sprite.name;
                    firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[selectedBtnFourthAnswer].fourthAnswerWords[i].answerWord4 = images[randomFourthAnswerWord].GetComponent<Image>().sprite.name;
                }
                else
                {
                    goto again;
                }
            }
            if (buttonsControls[i].questionOrAnswer)
            {
            again:
                int randomFourthAnswerWord = Random.Range(0, images.Count);
                if (!tempList.Contains(images[randomFourthAnswerWord].GetComponent<Image>().sprite.name))
                {
                    tempList.Add(images[randomFourthAnswerWord].GetComponent<Image>().sprite.name);
                    buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = images[randomFourthAnswerWord].GetComponent<Image>().sprite.name;
                    firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[selectedBtnFourthAnswer].fourthAnswerWords[i].answerWord4 = images[randomFourthAnswerWord].GetComponent<Image>().sprite.name;
                }
                else
                {
                    goto again;
                }
            }
        }
    }
    public void FifthQuestion()
    {
        wordInSentence++;
        if (fifthWordCount > 0)
        {
            if (fifthWordCount <= buttonsControls.Count)
            {
                for (int i = 0; i < fifthWordCount; i++)
                {
                again:
                    int randomFifthWord = Random.Range(0, fifthWordCount);
                    if (!tempList.Contains(firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[selectedBtnFourthWord].fifthWord[randomFifthWord].word5))
                    {
                        tempList.Add(firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[selectedBtnFourthWord].fifthWord[randomFifthWord].word5);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[selectedBtnFourthWord].fifthWord[randomFifthWord].word5;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                again:
                    int randomFifthWord = Random.Range(0, fifthWordCount);
                    if (!tempList.Contains(firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[selectedBtnFourthWord].fifthWord[randomFifthWord].word5))
                    {
                        tempList.Add(firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[selectedBtnFourthWord].fifthWord[randomFifthWord].word5);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[selectedBtnFourthWord].fifthWord[randomFifthWord].word5;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
        }
        else
        {
            StartCoroutine(Wait());
        }
    }
    public void FifthAnswerWord()
    {
        answerInSentece++;
        if (fifthAnswerCount > 0)
        {
            Debug.Log(fifthAnswerCount);
            if (fifthAnswerCount <= buttonsControls.Count)
            {
                for (int i = 0; i < fifthAnswerCount; i++)
                {
                again:
                    int randomFifthAnswerWord = Random.Range(0, fifthAnswerCount);
                    if (!tempList.Contains(firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[selectedBtnThirdAnswer].fourthAnswerWords[selectedBtnFourthAnswer].fifthAnswerWords[randomFifthAnswerWord].answerWord5))
                    {
                        tempList.Add(firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[selectedBtnThirdAnswer].fourthAnswerWords[selectedBtnFourthAnswer].fifthAnswerWords[randomFifthAnswerWord].answerWord5);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[selectedBtnThirdAnswer].fourthAnswerWords[selectedBtnFourthAnswer].fifthAnswerWords[randomFifthAnswerWord].answerWord5;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                again:
                    int randomFifthAnswerWord = Random.Range(0, fifthAnswerCount);
                    if (!tempList.Contains(firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[selectedBtnThirdAnswer].fourthAnswerWords[selectedBtnFourthAnswer].fifthAnswerWords[randomFifthAnswerWord].answerWord5))
                    {
                        tempList.Add(firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[selectedBtnThirdAnswer].fourthAnswerWords[selectedBtnFourthAnswer].fifthAnswerWords[randomFifthAnswerWord].answerWord5);
                        buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[selectedBtnThirdAnswer].fourthAnswerWords[selectedBtnFourthAnswer].fifthAnswerWords[randomFifthAnswerWord].answerWord5;
                    }
                    else
                    {
                        goto again;
                    }
                }
            }
        }
        else
        {
            StartCoroutine(Wait());
        }
    }

    #endregion
    public void TrueAnswerControl()
    {
        if (lastPressedButton == questionGO.GetComponent<Image>().sprite.name)
        {
            answerText.text = "Tebrikler";
        }
    }

    public void WordPool(int indexNo)
    {
        if (!buttonsControls[indexNo].questionOrAnswer && wordInSentence == 1 && answerInSentece == 1)
        {
            wordInSentence = 0;
            if (answerInSentece == 1)
            {
                for (int i = 0; i < firstAnswerWord.Count; i++)
                {
                    if (firstAnswerWord[i].answerWord1 == tempList[indexNo])
                    {
                        questionText.text = questionText.text + " " + buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        firstPressedButton = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        lastPressedButton = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        selectedButton = buttonsControls[indexNo].selectedBtn;
                        selectedBtnName = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        secondAnswerCount = firstAnswerWord[i].secondAnswerWords.Count;
                        selectedBtnFirstAnswer = i;
                    }
                }
                tempList.Clear();
                if (secondAnswerCount <= buttonsControls.Count)
                {
                    for (int i = 0; i < secondAnswerCount; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
                    }
                }
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = "";
                }
                for (int i = secondAnswerCount; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(false);
                }
                SecondAnswerWord();
            }
            question++;
        }
        else
        {
            if (wordInSentence == 1 && firstWord.Count > 0)
            {
                answerInSentece = 0;
                for (int i = 0; i < firstWord.Count; i++)
                {
                    if (firstWord[i].word1 == tempList[indexNo])
                    {
                        // 2.Adým
                        questionText.text = questionText.text + " " + buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        firstPressedButton = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        lastPressedButton = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        selectedButton = buttonsControls[indexNo].selectedBtn;
                        selectedBtnName = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        secondWordCount = firstWord[i].secondWord.Count;
                        // 3.Adým
                        selectedBtnFirstWord = i;
                    }
                }
                tempList.Clear();
                // 4.Adým
                if (secondWordCount <= buttonsControls.Count)
                {
                    for (int i = 0; i < secondWordCount; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
                    }
                }
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = "";
                }
                for (int i = secondWordCount; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(false);
                }
                SecondQuestionWord();
            }
            else if (wordInSentence == 2 && secondWordCount > 0)
            {
                for (int i = 0; i < secondWordCount; i++)
                {
                    if (firstWord[selectedBtnFirstWord].secondWord[i].word2 == tempList[indexNo])
                    {
                        // 2.Adým
                        questionText.text = questionText.text + " " + buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        lastPressedButton = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        selectedButton = buttonsControls[indexNo].selectedBtn;
                        selectedBtnName = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        thirdWordCount = firstWord[selectedBtnFirstWord].secondWord[i].thirdWord.Count;
                        // 3.Adým
                        selectedBtnSecondWord = i;
                    }
                }
                tempList.Clear();
                // 4.Adým
                if (thirdWordCount <= buttonsControls.Count)
                {
                    for (int i = 0; i < thirdWordCount; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
                    }
                }
                else
                {
                    for (int i = 0; i < buttonsControls.Count; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
                    }
                }
                // 5.Adým
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = "";
                }
                for (int i = thirdWordCount; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(false);
                }
                ThirdQuestion();
            }
            else if (wordInSentence == 3 && thirdWordCount > 0)
            {
                for (int i = 0; i < thirdWordCount; i++)
                {
                    if (firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[i].word3 == tempList[indexNo])
                    {
                        // 2.Adým
                        questionText.text = questionText.text + " " + buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        lastPressedButton = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        selectedButton = buttonsControls[indexNo].selectedBtn;
                        selectedBtnName = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        fourthWordCount = firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[i].fourthWord.Count;
                        // 3.Adým
                        selectedBtnThirdWord = i;
                    }
                }
                tempList.Clear();
                // 4.Adým
                if (fourthWordCount <= buttonsControls.Count)
                {
                    for (int i = 0; i < fourthWordCount; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
                    }
                }
                // 5.Adým
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = "";
                }
                for (int i = thirdWordCount; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(false);
                }
                FourthQuestion();
            }
            else if (wordInSentence == 4 && fourthWordCount > 0)
            {
                for (int i = 0; i < fourthWordCount; i++)
                {
                    if (firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[i].word4 == tempList[indexNo])
                    {
                        // 2.Adým
                        questionText.text = questionText.text + " " + buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        lastPressedButton = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        selectedButton = buttonsControls[indexNo].selectedBtn;
                        selectedBtnName = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        fifthWordCount = firstWord[selectedBtnFirstWord].secondWord[selectedBtnSecondWord].thirdWord[selectedBtnThirdWord].fourthWord[i].fifthWord.Count;
                        // 3.Adým
                        selectedBtnFourthWord = i;
                    }
                }
                tempList.Clear();
                // 4.Adým
                if (fourthWordCount <= buttonsControls.Count)
                {
                    for (int i = 0; i < fourthWordCount; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
                    }
                }
                // 5.Adým
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = "";
                }
                for (int i = thirdWordCount; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(false);
                }
                FifthQuestion();
            }
            else if (answerInSentece == 2 && secondAnswerCount > 0)
            {
                for (int i = 0; i < secondAnswerCount; i++)
                {
                    if (firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[i].answerWord2 == tempList[indexNo])
                    {
                        questionText.text = questionText.text + " " + buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        lastPressedButton = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        selectedButton = buttonsControls[indexNo].selectedBtn;
                        selectedBtnName = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        thirdAnswerCount = firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[i].thirdAnswerWords.Count;
                        selectedBtnThirdAnswer = i;
                    }
                }
                tempList.Clear();
                if (thirdAnswerCount <= buttonsControls.Count)
                {
                    for (int i = 0; i < thirdAnswerCount; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
                    }
                    for (int i = thirdAnswerCount; i < buttonsControls.Count; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(false);
                    }
                }
                else
                {
                    for (int i = 0; i < buttonsControls.Count; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
                    }
                }
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = "";
                }
                
                ThirdAnswerWord();

            }
            else if (answerInSentece == 3 && thirdAnswerCount > 0)
            {
                
                for (int i = 0; i < thirdAnswerCount; i++)
                {
                    if (firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[i].answerWord3 == tempList[indexNo])
                    {

                        questionText.text = questionText.text + " " + buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        lastPressedButton = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        selectedButton = buttonsControls[indexNo].selectedBtn;
                        selectedBtnName = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        fourthAnswerCount = firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[i].fourthAnswerWords.Count;
                        selectedBtnThirdAnswer = i;
                    }
                }
                tempList.Clear();
                if (fourthAnswerCount <= buttonsControls.Count)
                {
                    for (int i = 0; i < fourthAnswerCount; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
                    }
                    for (int i = fourthAnswerCount; i < buttonsControls.Count; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(false);
                    }
                }
                else
                {
                    for (int i = 0; i < buttonsControls.Count; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
                    }
                }
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = "";
                }
                
                FourthAnswerWord();
            }
            else if (answerInSentece == 4 && fourthAnswerCount > 0)
            {
                for (int i = 0; i < fourthAnswerCount; i++)
                {
                    if (firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[selectedBtnFourthAnswer].fourthAnswerWords[i].answerWord4 == tempList[indexNo])
                    {
                        questionText.text = questionText.text + " " + buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        lastPressedButton = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        selectedButton = buttonsControls[indexNo].selectedBtn;
                        selectedBtnName = buttonsControls[indexNo].selectedBtn.GetComponentInChildren<TMP_Text>().text;
                        fifthAnswerCount = firstAnswerWord[selectedBtnFirstAnswer].secondAnswerWords[selectedBtnSecondAnswer].thirdAnswerWords[selectedBtnFourthAnswer].fourthAnswerWords[i].fifthAnswerWords.Count;
                        selectedBtnThirdAnswer = i;
                    }
                }
                tempList.Clear();
                if (fifthAnswerCount <= buttonsControls.Count)
                {
                    for (int i = 0; i < fifthAnswerCount; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
                    }
                    for (int i = fifthAnswerCount; i < buttonsControls.Count; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(false);
                    }
                }
                else
                {
                    for (int i = 0; i < buttonsControls.Count; i++)
                    {
                        buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(true);
                    }
                }
                for (int i = 0; i < buttonsControls.Count; i++)
                {
                    buttonsControls[i].selectedBtn.GetComponentInChildren<TMP_Text>().text = "";
                }
                
                FifthAnswerWord();
            }
            else
            {
                StartCoroutine(Wait());
                Debug.Log(questionText.text);
                ResetButtons();
                VariableReset();
                FirstQuestionWord();
            }
        }
    }
    public void TrueAnswer()
    {
        int randomAnimalNo = Random.Range(0,images.Count);
        //System.GC.Collect();
        questionGO = randomImageList[randomAnimalNo];
        //AnimalProperties();
    }
    public void AnimalProperties()
    {
        for (int i = 0; i < questionGO.GetComponent<AnimalController>().isList.Count; i++)
        {
            if (questionGO.GetComponent<AnimalController>().isList[i].big)
            {
                Debug.Log("big");
            }
            if (questionGO.GetComponent<AnimalController>().isList[i].tall)
            {
                Debug.Log("tall");
            }
            if (questionGO.GetComponent<AnimalController>().isList[i].dangerous)
            {
                Debug.Log("dangerous");
            }
            if (questionGO.GetComponent<AnimalController>().isList[i].fat)
            {
                Debug.Log("fat");
            }
            if (questionGO.GetComponent<AnimalController>().isList[i].small)
            {
                Debug.Log("small");
            }
        }
        for (int i = 0; i < questionGO.GetComponent<AnimalController>().canList.Count; i++)
        {
            if (questionGO.GetComponent<AnimalController>().canList[i].fly)
            {
                Debug.Log("fly");
            }
            if (questionGO.GetComponent<AnimalController>().canList[i].swim)
            {
                Debug.Log("swim");
            }
            if (questionGO.GetComponent<AnimalController>().canList[i].climbTrees)
            {
                Debug.Log("climb trees");
            }
            if (questionGO.GetComponent<AnimalController>().canList[i].jumpHight)
            {
                Debug.Log("jump hight");
            }
        }
        for (int i = 0; i < questionGO.GetComponent<AnimalController>().doesList.Count; i++)
        {
            if (questionGO.GetComponent<AnimalController>().doesList[i].wings)
            {
                Debug.Log("wings");
            }
            if (questionGO.GetComponent<AnimalController>().doesList[i].fur)
            {
                Debug.Log("fur");
            }
            if (questionGO.GetComponent<AnimalController>().doesList[i].fins)
            {
                Debug.Log("fins");
            }
            if (questionGO.GetComponent<AnimalController>().doesList[i].feathers)
            {
                Debug.Log("feathers");
            }
            if (questionGO.GetComponent<AnimalController>().doesList[i].tail)
            {
                Debug.Log("tail");
            }
            if (questionGO.GetComponent<AnimalController>().doesList[i].beak)
            {
                Debug.Log("beak");
            }
            if (questionGO.GetComponent<AnimalController>().doesList[i].shell)
            {
                Debug.Log("shell");
            }
            if (questionGO.GetComponent<AnimalController>().doesList[i].mane)
            {
                Debug.Log("mane");
            }
            if (questionGO.GetComponent<AnimalController>().doesList[i].trunk)
            {
                Debug.Log("trunk");
            }
        }
        for (int i = 0; i < questionGO.GetComponent<AnimalController>().colorList.Count; i++)
        {
            if (questionGO.GetComponent<AnimalController>().colorList[i].green)
            {
                Debug.Log("green");
            }
            if (questionGO.GetComponent<AnimalController>().colorList[i].blue)
            {
                Debug.Log("blue");
            }
            if (questionGO.GetComponent<AnimalController>().colorList[i].orange)
            {
                Debug.Log("orange");
            }
            if (questionGO.GetComponent<AnimalController>().colorList[i].brown)
            {
                Debug.Log("brown");
            }
            if (questionGO.GetComponent<AnimalController>().colorList[i].grey)
            {
                Debug.Log("grey");
            }
            if (questionGO.GetComponent<AnimalController>().colorList[i].white)
            {
                Debug.Log("white");
            }
            if (questionGO.GetComponent<AnimalController>().colorList[i].pink)
            {
                Debug.Log("pink");
            }
            if (questionGO.GetComponent<AnimalController>().colorList[i].yellow)
            {
                Debug.Log("yellow");
            }
            if (questionGO.GetComponent<AnimalController>().colorList[i].black)
            {
                Debug.Log("black");
            }
        }
        for (int i = 0; i < questionGO.GetComponent<AnimalController>().whatList.Count; i++)
        {
            if (questionGO.GetComponent<AnimalController>().whatList[i].kindOfBird)
            {
                Debug.Log("kind of bird");
            }
            if (questionGO.GetComponent<AnimalController>().whatList[i].kindOfMammal)
            {
                Debug.Log("kind of mammal");
            }
            if (questionGO.GetComponent<AnimalController>().whatList[i].kindOfFish)
            {
                Debug.Log("kind of fish");
            }
            if (questionGO.GetComponent<AnimalController>().whatList[i].kindOfReptile)
            {
                Debug.Log("kind of reptile");
            }
            if (questionGO.GetComponent<AnimalController>().whatList[i].kindOfAmphibian)
            {
                Debug.Log("kind of amphibian");
            }
            if (questionGO.GetComponent<AnimalController>().whatList[i].kindOfInsect)
            {
                Debug.Log("kind of insect");
            }
            if (questionGO.GetComponent<AnimalController>().whatList[i].kindOfMollusc)
            {
                Debug.Log("kind of mollusc");
            }
            if (questionGO.GetComponent<AnimalController>().whatList[i].kindOfArachnid)
            {
                Debug.Log("kind of arachid");
            }
        }
        for (int i = 0; i < questionGO.GetComponent<AnimalController>().howList.Count; i++)
        {
            if (questionGO.GetComponent<AnimalController>().howList[i].notHeawy)
            {
                Debug.Log("NotHeavy");
            }
            if (questionGO.GetComponent<AnimalController>().howList[i].quiteHeawy)
            {
                Debug.Log("quite heawy");
            }
            if (questionGO.GetComponent<AnimalController>().howList[i].veryHeawy)
            {
                Debug.Log("very heawy");
            }
            if (questionGO.GetComponent<AnimalController>().howList[i].slow)
            {
                Debug.Log("slow");
            }
            if (questionGO.GetComponent<AnimalController>().howList[i].avarageFast)
            {
                Debug.Log("avarage fast");
            }
            if (questionGO.GetComponent<AnimalController>().howList[i].quickFast)
            {
                Debug.Log("quick fast");
            }
            if (questionGO.GetComponent<AnimalController>().howList[i].manyLegsZero)
            {
                Debug.Log("no legs");
            }
            if (questionGO.GetComponent<AnimalController>().howList[i].manyLegsTwo)
            {
                Debug.Log("two legs");
            }
            if (questionGO.GetComponent<AnimalController>().howList[i].manyLegsFour)
            {
                Debug.Log("four legs");
            }
            if (questionGO.GetComponent<AnimalController>().howList[i].manyLegsSix)
            {
                Debug.Log("siz legs");
            }
            if (questionGO.GetComponent<AnimalController>().howList[i].manyLegsEight)
            {
                Debug.Log("eight legs");
            }
            if (questionGO.GetComponent<AnimalController>().howList[i].twoArms)
            {
                Debug.Log("two arms");
            }
        }
        for (int i = 0; i < questionGO.GetComponent<AnimalController>().whereList.Count; i++)
        {
            if (questionGO.GetComponent<AnimalController>().whereList[i].inTree)
            {
                Debug.Log("tree");
            }
            if (questionGO.GetComponent<AnimalController>().whereList[i].inHome)
            {
                Debug.Log("home");
            }
            if (questionGO.GetComponent<AnimalController>().whereList[i].inWild)
            {
                Debug.Log("wild");
            }
            if (questionGO.GetComponent<AnimalController>().whereList[i].inWater)
            {
                Debug.Log("water");
            }
            if (questionGO.GetComponent<AnimalController>().whereList[i].inFarm)
            {
                Debug.Log("farm");
            }
            if (questionGO.GetComponent<AnimalController>().whereList[i].inIce)
            {
                Debug.Log("ice");
            }
        }
        for (int i = 0; i < questionGO.GetComponent<AnimalController>().doesItEatList.Count; i++)
        {
            if (questionGO.GetComponent<AnimalController>().doesItEatList[i].meat)
            {
                Debug.Log("meat");
            }
            if (questionGO.GetComponent<AnimalController>().doesItEatList[i].grass)
            {
                Debug.Log("grass");
            }
            if (questionGO.GetComponent<AnimalController>().doesItEatList[i].bananas)
            {
                Debug.Log("bananas");
            }
            if (questionGO.GetComponent<AnimalController>().doesItEatList[i].leaves)
            {
                Debug.Log("leaves");
            }
        }
        for (int i = 0; i < questionGO.GetComponent<AnimalController>().doList.Count; i++)
        {
            if (questionGO.GetComponent<AnimalController>().doList[i].eat)
            {
                Debug.Log("eat");
            }
            if (questionGO.GetComponent<AnimalController>().doList[i].lookAfter)
            {
                Debug.Log("look after");
            }
            if (questionGO.GetComponent<AnimalController>().doList[i].ride)
            {
                Debug.Log("ride");
            }
        }
    }
    public void QuestionMark()
    {
        LeanTween.scale(questionMarks[question], new Vector3(3, 3, 0), 0.5f);
        LeanTween.move(questionMarks[question], new Vector3(960, 850, 0), 0.5f);
    }
    public void AnimalImage()
    {
        for (int i = 0; i < images.Count; i++)
        {
        again:
            int randomImageNo = Random.Range(0, allImages.Count);
            if (!randomImageList.Contains(allImages[randomImageNo]))
            {
                randomImageList.Add(allImages[randomImageNo]);
                images[i].GetComponent<Image>().sprite = allImages[randomImageNo].GetComponent<Image>().sprite;
                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            }
            else
            {
                goto again;
            }
        }
    }
    IEnumerator Wait()
    {
        if (answerInSentece == 4)
        {
            TrueAnswerControl();
        }
        //TrueAnswerControl();
        for (int i = 0; i < buttonsControls.Count; i++)
        {
            buttonsControls[i].selectedBtn.GetComponent<Button>().gameObject.SetActive(false);
        }
        Debug.Log(questionText.text);
        QuestionControl();
        yield return new WaitForSecondsRealtime(2.0f);        
        ResetButtons();
        VariableReset();
        FirstQuestionWord();
    }
    public void QuestionControl()
    {
        if (firstPressedButton == "Is")
        {
            string isBig = "Is it big";
            string isTall = "Is it tall";
            string isDangerous = "It is dangerous";
            string isSmall = "It is small";
            string isFat = "It is fat";
            string pattern = string.Format(@"\b{0}\b", lastPressedButton);

            if (Regex.IsMatch(isBig, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().isList[0].big)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().isList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().isList[j].big == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().isList[0].big == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().isList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().isList[j].big == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().isList[i].big)
                    {
                        answerText.text = "Yes it is.";
                    }
                    else
                    {
                        answerText.text = "No it isn't.";
                    }
                }
            }

            if (Regex.IsMatch(isTall, pattern))
            {
                if (questionGO.GetComponent<AnimalController>().isList[0].tall)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().isList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().isList[j].tall == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().isList[0].tall == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().isList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().isList[j].tall == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().isList[i].tall)
                    {
                        answerText.text = "Yes it is.";
                    }
                    else
                    {
                        answerText.text = "No it isn't.";
                    }
                }
            }

            if (Regex.IsMatch(isDangerous, pattern))
            {
                if (questionGO.GetComponent<AnimalController>().isList[0].dangerous)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().isList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().isList[j].dangerous == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().isList[0].dangerous == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().isList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().isList[j].dangerous == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().isList[i].dangerous)
                    {
                        answerText.text = "Yes it is.";
                    }
                    else
                    {
                        answerText.text = "No it isn't.";
                    }
                }
            }

            if (Regex.IsMatch(isSmall, pattern))
            {
                if (questionGO.GetComponent<AnimalController>().isList[0].small)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().isList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().isList[j].small == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().isList[0].small == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().isList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().isList[j].small == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().isList[i].small)
                    {
                        answerText.text = "Yes it is.";
                    }
                    else
                    {
                        answerText.text = "No it isn't.";
                    }
                }
            }

            if (Regex.IsMatch(isFat, pattern))
            {
                if (questionGO.GetComponent<AnimalController>().isList[0].fat)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().isList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().isList[j].fat == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().isList[0].fat == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().isList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().isList[j].fat == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().isList[i].fat)
                    {
                        answerText.text = "Yes it is.";
                    }
                    else
                    {
                        answerText.text = "No it isn't.";
                    }
                }
            }
        }
        if (firstPressedButton == "Can")
        {
            string canFly = "Can it fly";
            string canSwim = "Can it swim";
            string canClimb = "Can it climb trees";
            string canJump = "Can it jump high";
            string pattern = string.Format(@"\b{0}\b", lastPressedButton);

            if (Regex.IsMatch(canFly, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().canList[0].fly)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().canList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().canList[j].fly == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().canList[0].fly == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().canList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().canList[j].fly == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().canList[i].fly)
                    {
                        answerText.text = "Yes it can.";
                    }
                    else
                    {
                        answerText.text = "No it can't.";
                    }
                }
            }

            if (Regex.IsMatch(canSwim, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().canList[0].swim)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().canList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().canList[j].swim == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().canList[0].swim == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().canList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().canList[j].swim == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().canList[i].swim)
                    {
                        answerText.text = "Yes it can.";
                    }
                    else
                    {
                        answerText.text = "No it can't.";
                    }
                }
            }

            if (Regex.IsMatch(canClimb, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().canList[0].climbTrees)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().canList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().canList[j].climbTrees == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().canList[0].climbTrees == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().canList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().canList[j].climbTrees == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().canList[i].climbTrees)
                    {
                        answerText.text = "Yes it can.";
                    }
                    else
                    {
                        answerText.text = "No it can't.";
                    }
                }
            }

            if (Regex.IsMatch(canJump, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().canList[0].jumpHight)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().canList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().canList[j].jumpHight == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().canList[0].jumpHight == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().canList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().canList[j].jumpHight == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().canList[i].jumpHight)
                    {
                        answerText.text = "Yes it can.";
                    }
                    else
                    {
                        answerText.text = "No it can't.";
                    }
                }
            }
        }
        if (firstPressedButton == "Does")
        {
            string wings = "Does it have wings";
            string fur = "Does it have fur";
            string fins = "Does it have fins";
            string feathers = "Does it have feathehrs";
            string tail = "Does it have a tail";
            string beak = "Does it have a beak";
            string shell = "Does it have a shell";
            string mane = "Does it have a mane";
            string trunk = "Does it have a trunk";
            string pattern = string.Format(@"\b{0}\b", lastPressedButton);

            if (Regex.IsMatch(wings, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().doesList[0].wings)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].wings == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesList[0].wings == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].wings == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesList[i].wings)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }

            if (Regex.IsMatch(fur, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().doesList[0].fur)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].fur == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesList[0].fur == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].fur == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesList[i].fur)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }

            if (Regex.IsMatch(fins, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().doesList[0].fins)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].fins == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesList[0].fins == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].fins == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesList[i].fins)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }

            if (Regex.IsMatch(feathers, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().doesList[0].feathers)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].feathers == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesList[0].feathers == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].feathers == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesList[i].feathers)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }

            if (Regex.IsMatch(tail, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().doesList[0].tail)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].tail == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesList[0].tail == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].tail == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesList[i].tail)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }

            if (Regex.IsMatch(beak, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().doesList[0].beak)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].beak == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesList[0].beak == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].beak == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesList[i].beak)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }

            if (Regex.IsMatch(shell, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().doesList[0].shell)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].shell == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesList[0].shell == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].shell == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesList[i].shell)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }

            if (Regex.IsMatch(mane, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().doesList[0].mane)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].mane == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesList[0].mane == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].mane == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesList[i].mane)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }

            if (Regex.IsMatch(trunk, pattern))
            {

                if (questionGO.GetComponent<AnimalController>().doesList[0].trunk)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].trunk == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesList[0].trunk == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesList[j].trunk == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesList[i].trunk)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }
        }
        if (firstPressedButton == "What")
        {
            string animalColor = "What color is it";
            string kindOfAnimal = "What kind of animal is it";

            string pattern = string.Format(@"\b{0}\b", lastPressedButton);

            if (Regex.IsMatch(animalColor, "color"))
            {
                if (questionGO.GetComponent<AnimalController>().colorList[0].green)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().colorList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().colorList[j].green == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is green.";
                }
                else if (questionGO.GetComponent<AnimalController>().colorList[0].blue)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().colorList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().colorList[j].blue == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is blue.";
                }
                else if (questionGO.GetComponent<AnimalController>().colorList[0].orange)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().colorList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().colorList[j].orange == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is orange.";
                }
                else if (questionGO.GetComponent<AnimalController>().colorList[0].brown)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().colorList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().colorList[j].brown == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is brown.";
                }
                else if (questionGO.GetComponent<AnimalController>().colorList[0].grey)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().colorList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().colorList[j].grey == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is grey.";
                }
                else if (questionGO.GetComponent<AnimalController>().colorList[0].white)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().colorList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().colorList[j].white == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is white.";
                }
                else if (questionGO.GetComponent<AnimalController>().colorList[0].pink)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().colorList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().colorList[j].pink == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is pink.";
                }
                else if (questionGO.GetComponent<AnimalController>().colorList[0].yellow)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().colorList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().colorList[j].yellow == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is yellow.";
                }
                else if (questionGO.GetComponent<AnimalController>().colorList[0].black)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().colorList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().colorList[j].black == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is black.";
                }
            }
            if (Regex.IsMatch(kindOfAnimal, pattern))
            {
                if (questionGO.GetComponent<AnimalController>().whatList[0].kindOfBird)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whatList[j].kindOfBird == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is a kind of bird.";
                }
                else if (questionGO.GetComponent<AnimalController>().whatList[0].kindOfMammal)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whatList[j].kindOfMammal == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is a kind of mammal.";
                }
                else if (questionGO.GetComponent<AnimalController>().whatList[0].kindOfFish)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whatList[j].kindOfFish == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is a kind of fish.";
                }
                else if (questionGO.GetComponent<AnimalController>().whatList[0].kindOfReptile)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whatList[j].kindOfReptile == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is a kind of reptile.";
                }
                else if (questionGO.GetComponent<AnimalController>().whatList[0].kindOfAmphibian)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whatList[j].kindOfAmphibian == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is a kind of amphibian.";
                }
                else if (questionGO.GetComponent<AnimalController>().whatList[0].kindOfInsect)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whatList[j].kindOfInsect == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is a kind of insect.";
                }
                else if (questionGO.GetComponent<AnimalController>().whatList[0].kindOfMollusc)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whatList[j].kindOfMollusc == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is a kind of mollusc.";
                }
                else if (questionGO.GetComponent<AnimalController>().whatList[0].kindOfArachnid)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whatList[j].kindOfArachnid == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is a kind of arachnid.";
                }
            }
        }
        if (firstPressedButton == "How")
        {
            string heavy = "How heavy is it";
            string fast = "How fast is it";
            string legs = "How many legs does it have";
            string arms = "How many arms";

            string pattern = string.Format(@"\b{0}\b", lastPressedButton);
            if (Regex.IsMatch(heavy, pattern))
            {
                if (questionGO.GetComponent<AnimalController>().howList[0].notHeawy)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].notHeawy == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is not heavy.";
                }
                else if (questionGO.GetComponent<AnimalController>().howList[0].quiteHeawy)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].quiteHeawy == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is quite heavy.";
                }
                else if (questionGO.GetComponent<AnimalController>().howList[0].veryHeawy)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].veryHeawy == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is very heavy.";
                }
            }
            if (Regex.IsMatch(fast, pattern))
            {
                if (questionGO.GetComponent<AnimalController>().howList[0].slow)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].slow == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is slow.";
                }
                else if (questionGO.GetComponent<AnimalController>().howList[0].avarageFast)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].avarageFast == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is avarage.";
                }
                else if (questionGO.GetComponent<AnimalController>().howList[0].quickFast)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].quickFast == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It is quick.";
                }
            }
            if (Regex.IsMatch(legs, pattern))
            {
                if (questionGO.GetComponent<AnimalController>().howList[0].manyLegsZero)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].manyLegsZero == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It has no legs.";
                }
                else if (questionGO.GetComponent<AnimalController>().howList[0].manyLegsTwo)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].manyLegsTwo == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It has two legs.";
                }
                else if (questionGO.GetComponent<AnimalController>().howList[0].manyLegsFour)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].manyLegsFour == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It has four legs.";
                }
                else if (questionGO.GetComponent<AnimalController>().howList[0].manyLegsSix)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].manyLegsSix == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It has six legs.";
                }
                else if (questionGO.GetComponent<AnimalController>().howList[0].manyLegsEight)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].manyLegsEight == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It has eight legs.";
                }
            }
            if (Regex.IsMatch(arms, pattern))
            {
                if (questionGO.GetComponent<AnimalController>().howList[0].twoArms)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].twoArms == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().howList[0].twoArms == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().howList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().howList[j].twoArms == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().howList[i].twoArms)
                    {
                        answerText.text = "It has two arms.";
                    }
                    else
                    {
                        answerText.text = "It has no arms.";
                    }
                }
            }
        }
        if (firstPressedButton == "Where")
        {
            string inLive = "Where does it live";
            string pattern = string.Format(@"\b{0}\b", lastPressedButton);
            if (Regex.IsMatch(inLive,pattern))
            {
                if (questionGO.GetComponent<AnimalController>().whereList[0].inTree)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whereList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whereList[j].inTree == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It lives in a tree.";
                }
                else if (questionGO.GetComponent<AnimalController>().whereList[0].inHome)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whereList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whereList[j].inHome == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It lives in a home.";
                }
                else if (questionGO.GetComponent<AnimalController>().whereList[0].inWild)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whereList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whereList[j].inWild == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It lives in the wild.";
                }
                else if (questionGO.GetComponent<AnimalController>().whereList[0].inWater)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whereList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whereList[j].inWater == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It lives in water.";
                }
                else if (questionGO.GetComponent<AnimalController>().whereList[0].inFarm)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whereList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whereList[j].inFarm == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It lives on a farm.";
                }
                else if (questionGO.GetComponent<AnimalController>().whereList[0].inIce)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().whereList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().whereList[j].inIce == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                    answerText.text = "It lives on ice.";
                }
            }
        }
        if (firstPressedButton == "Does")
        {
            string eatMeat = "Does it eat meat";
            string eatGrass = "Does it eat grass";
            string eatBananas = "Does it eat bananas";
            string eatLeaves = "Does it eat leaves";
            string pattern = string.Format(@"\b{0}\b", lastPressedButton);
            if (Regex.IsMatch(eatMeat,pattern))
            {
                if (questionGO.GetComponent<AnimalController>().doesItEatList[0].meat)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesItEatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesItEatList[j].meat == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesItEatList[0].meat == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesItEatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesItEatList[j].meat == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesItEatList[i].meat)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }
            if (Regex.IsMatch(eatGrass,pattern))
            {
                if (questionGO.GetComponent<AnimalController>().doesItEatList[0].grass)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesItEatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesItEatList[j].grass == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesItEatList[0].grass == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesItEatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesItEatList[j].grass == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesItEatList[i].grass)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }
            if (Regex.IsMatch(eatBananas,pattern))
            {
                if (questionGO.GetComponent<AnimalController>().doesItEatList[0].bananas)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesItEatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesItEatList[j].bananas == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesItEatList[0].bananas == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesItEatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesItEatList[j].bananas == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesItEatList[i].bananas)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }
            if (Regex.IsMatch(eatLeaves,pattern))
            {
                if (questionGO.GetComponent<AnimalController>().doesItEatList[0].leaves)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesItEatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesItEatList[j].leaves == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doesItEatList[0].leaves == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doesItEatList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doesItEatList[j].leaves == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doesItEatList[i].leaves)
                    {
                        answerText.text = "Yes it does.";
                    }
                    else
                    {
                        answerText.text = "No it doesn't.";
                    }
                }
            }
        }
        if (firstPressedButton == "Do")
        {
            string eatIt = "Do people eat it";
            string lookAfterIt = "Do people look after it";
            string rideIt = "Do people ride it";
            string pattern = string.Format(@"\b{0}\b", lastPressedButton);
            if (Regex.IsMatch(eatIt,pattern))
            {
                if (questionGO.GetComponent<AnimalController>().doList[0].eat)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doList[j].eat == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doList[0].eat == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doList[j].eat == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doList[i].eat)
                    {
                        answerText.text = "Yes people eat it.";
                    }
                    else
                    {
                        answerText.text = "People don't eat it.";
                    }
                }
            }
            if (Regex.IsMatch(lookAfterIt, pattern))
            {
                if (questionGO.GetComponent<AnimalController>().doList[0].lookAfter)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doList[j].lookAfter == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doList[0].lookAfter == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doList[j].lookAfter == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doList[i].lookAfter)
                    {
                        answerText.text = "Yes people look after it.";
                    }
                    else
                    {
                        answerText.text = "People don't look after it.";
                    }
                }
            }
            if (Regex.IsMatch(rideIt, pattern))
            {
                if (questionGO.GetComponent<AnimalController>().doList[0].ride)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doList[j].ride == false)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                else if (questionGO.GetComponent<AnimalController>().doList[0].ride == false)
                {
                    for (int i = 0; i < randomImageList.Count; i++)
                    {
                        for (int j = 0; j < randomImageList[i].GetComponent<AnimalController>().doList.Count; j++)
                        {
                            if (randomImageList[i].GetComponent<AnimalController>().doList[j].ride == true)
                            {
                                images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 125);
                            }
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (questionGO.GetComponent<AnimalController>().doList[i].ride)
                    {
                        answerText.text = "Yes people ride it.";
                    }
                    else
                    {
                        answerText.text = "People don't ride it.";
                    }
                }
            }
        }
    }
}

#region Kelime Listeleri

[System.Serializable]
public class ButtonsControl
{
    public Button selectedBtn;
    public bool questionOrAnswer;
    // true ise question
    // false ise answer
}
[System.Serializable]
public class FirstWord
{
    public string word1;
    public List<SecondWord> secondWord;
}

[System.Serializable]
public class SecondWord
{
    public string word2;
    public List<ThirdWord> thirdWord;
}

[System.Serializable]
public class ThirdWord
{
    public string word3;
    public List<FourthWord> fourthWord;
}

[System.Serializable]
public class FourthWord
{
    public string word4;
    public List<FifthWord> fifthWord;
}
[System.Serializable]
public class FifthWord
{
    public string word5;
}



[System.Serializable]
public class FirstAnswerWord
{
    public string answerWord1;
    public List<SecondAnswerWord> secondAnswerWords;
}
[System.Serializable]
public class SecondAnswerWord
{
    public string answerWord2;
    public List<ThirdAnswerWord> thirdAnswerWords;
}
[System.Serializable]
public class ThirdAnswerWord
{
    public string answerWord3;
    public List<FourthAnswerWord> fourthAnswerWords;
}
[System.Serializable]
public class FourthAnswerWord
{
    public string answerWord4;
    public List<FifthAnswerWord> fifthAnswerWords;
}
[System.Serializable]
public class FifthAnswerWord
{
    public string answerWord5;
}
#endregion

