using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animals : MonoBehaviour
{
    private GameController gameController;
    //public List<string> animalsList;
    //int animalsIndex;

    public List<Sprite> sprites;
   
    public List<Image> images;
   
    public List<Sprite> randomImageList;
    [SerializeField] public List<Sprite> birds;



    private void Start()
    {

        AnamilsImage();
    }

    public void AnamilsImage()
    {
        for (int i = 0; i < images.Count; i++)
        {
            again:
            images[i].GetComponent<Image>().color = new Color32(0, 0, 0, 255);


            int randomImageNo = Random.Range(0, sprites.Count);
            if (!randomImageList.Contains(sprites[randomImageNo]))
            {
                randomImageList.Add(sprites[randomImageNo]);


                images[i].GetComponent<Image>().sprite = sprites[randomImageNo];
            }
            else
            {
                goto again;
            }

    }

    }

   

}
 class Birds : Animals
{
    
    public  Birds()
    {
       
       
       


    }
}

//public void Mammal()
//{


//}
//public void Reptile()
//{


//}
//public void Fish()
//{


//}
//public void Amphibian()
//{


//}
//public void Insect()
//{


//}
//public void Mollusc()
//{


//}
//public void Arachnid()
//{


//}
