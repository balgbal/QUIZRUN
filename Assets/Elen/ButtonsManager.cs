using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class ButtonsManager : MonoBehaviour
{
   
    
    [SerializeField] private List<string> firstWordListchildIs0 = new List<string>();
    [SerializeField] private List<string> firstWordListchildIs1 = new List<string>();
    [SerializeField] private List<string> firstWordListchildCan0 = new List<string>();
    [SerializeField] private List<string> firstWordListchildWhat0 = new List<string>();
    [SerializeField] private List<string> firstWordListchildWhere0 = new List<string>();
    [SerializeField] private List<string> firstWordListchildDo0 = new List<string>();
    [SerializeField] private List<string> firstWordListchildDoes0 = new List<string>();
    [SerializeField] private List<string> firstWordListchildHow0 = new List<string>();

    [SerializeField] private List<string> firstWordList = new List<string>();
    [SerializeField] private List<string> templist = new List<string>();
    [SerializeField] private List<string> WordIndexList = new List<string>();
    int index;
    [SerializeField] private List<GameObject> ButtonList;
    [SerializeField] private List<GameObject> buttontext;

    int WordIndex;

    private void Start()
    {
        FirstWord();

    }

    public void FirstWord()
    {

        for (index = 0; index < ButtonList.Count; index++)
        {
          
                WordIndex = Random.Range(0, firstWordList.Count);
                templist.Add(firstWordList[WordIndex]);
                
            if (!WordIndexList.Contains(firstWordList[WordIndex]))
            {
                WordIndexList.Add(firstWordList[WordIndex]);
                ButtonList[index].GetComponentInChildren<TMP_Text>().text = firstWordList[WordIndex];
            }
            else
            {
                return;
            }
        }
    }

    public void ButtonIndexText(int buttonIndex)
    {
        ButtonList[buttonIndex].SetActive(true);
        ButtonList[index].GetComponentInChildren<TMP_Text>().text = "";

        for (index = 0; index < ButtonList.Count; index++)
        {
            templist.Clear();
            
            ButtonList[index].GetComponentInChildren<TMP_Text>().text = "";
            

            ////////////////////////
            for (int i = 0; i < firstWordListchildIs0.Count; i++)
            {
                

                if (firstWordList[0] == WordIndexList[buttonIndex])
                {
                    
                    ButtonList[i].GetComponentInChildren<TMP_Text>().text = firstWordListchildIs0[i];

                    for (int a = firstWordListchildIs0.Count; a < ButtonList.Count; a++)
                    {
                        ButtonList[a].SetActive(false);

                       
                    }

                }
                
            }
           









            /////////////////

            for (int c = 0; c < firstWordListchildCan0.Count; c++)
            {
                if (firstWordList[1]==WordIndexList[buttonIndex])
                {
                    ButtonList[c].GetComponentInChildren<TMP_Text>().text = firstWordListchildCan0[c];

                    for (int b = firstWordListchildCan0.Count; b< ButtonList.Count; b++)
                    {
                        ButtonList[b].SetActive(false);
                       
                    }
                }

               
            }




            //////////////////////////


            for (int d=0; d< firstWordListchildWhat0.Count; d++)
            {
                if (firstWordList[2]==WordIndexList[buttonIndex])
                {
                    ButtonList[d].GetComponentInChildren<TMP_Text>().text = firstWordListchildWhat0[d];
                    for (int wh = firstWordListchildWhat0.Count; wh< ButtonList.Count; wh++)
                    {
                        ButtonList[wh].SetActive(false);
                       
                    }
                }
               
            }

         

            /////////////////////
            for (int w = 0; w < firstWordListchildWhere0.Count; w++)
            {
                if (firstWordList[3]==WordIndexList[buttonIndex])
                {
                    ButtonList[w].GetComponentInChildren<TMP_Text>().text = firstWordListchildWhere0[w];

                    for (int wher = firstWordListchildWhere0.Count; wher < ButtonList.Count; wher++)
                    {
                        ButtonList[wher].SetActive(false);
                       
                    }
                }
            }

            ////////////////////
            for (int t = 0; t < firstWordListchildDo0.Count; t++)
            {
                if (firstWordList[4] == WordIndexList[buttonIndex])
                {
                    ButtonList[t].GetComponentInChildren<TMP_Text>().text = firstWordListchildDo0[t];
                    for (int doo = firstWordListchildDo0.Count; doo < ButtonList.Count; doo++)
                    {
                        ButtonList[doo].SetActive(false);
                    }
                }

            }

            ////////////////
            for (int does = 0; does < firstWordListchildDoes0.Count; does++)
            {
                if (firstWordList[5]==WordIndexList[buttonIndex])
                {
                    ButtonList[does].GetComponentInChildren<TMP_Text>().text = firstWordListchildDoes0[does];
                    for (int doe = firstWordListchildDoes0.Count; doe < ButtonList.Count; doe++)
                    {
                        ButtonList[doe].SetActive(false);
                    }
                }
            }

            ////////////////////
            for (int how = 0; how < firstWordListchildHow0.Count; how++)
            {
                if (firstWordList[6]==WordIndexList[buttonIndex])
                {
                    ButtonList[how].GetComponentInChildren<TMP_Text>().text = firstWordListchildHow0[how];
                    for (int ho = firstWordListchildHow0.Count; ho < ButtonList.Count; ho++)
                    {
                        ButtonList[ho].SetActive(false);
                    }
                }
            }

            ////////////////////////
        }

        for (index = 0; index < ButtonList.Count; index++)
        {
            buttontext[index].GetComponentInChildren<TMP_Text>().text = WordIndexList[buttonIndex];

           
        }

       

    }


}
