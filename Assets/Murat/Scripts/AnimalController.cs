using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public List<Is> isList;
    public List<Can> canList;
    public List<Does> doesList;
    public List<AnimalsColor> colorList;
    public List<What> whatList;
    public List<How> howList;
    public List<Where> whereList;
    public List<DoesItEat> doesItEatList;
    public List<Do> doList;    
}
[System.Serializable]
public class Is
{
    public bool big;
    public bool tall;
    public bool dangerous;
    public bool small;
    public bool fat;
}
[System.Serializable]
public class Can
{
    public bool fly;
    public bool swim;
    public bool climbTrees;
    public bool jumpHight;
}
[System.Serializable]
public class Does
{
    public bool wings;
    public bool fur;
    public bool fins;
    public bool feathers;
    public bool tail;
    public bool beak;
    public bool shell;
    public bool mane;
    public bool trunk;
}
[System.Serializable]
public class AnimalsColor
{
    public bool green;
    public bool blue;
    public bool orange;
    public bool brown;
    public bool grey;
    public bool white;
    public bool pink;
    public bool yellow;
    public bool black;

}
[System.Serializable]
public class What
{
    public bool kindOfBird;
    public bool kindOfMammal;
    public bool kindOfFish;
    public bool kindOfReptile;
    public bool kindOfAmphibian;
    public bool kindOfInsect;
    public bool kindOfMollusc;
    public bool kindOfArachnid;
}
[System.Serializable]
public class How
{
    public bool notHeawy;
    public bool quiteHeawy;
    public bool veryHeawy;
    public bool slow;
    public bool avarageFast;
    public bool quickFast;
    public bool manyLegsZero;
    public bool manyLegsTwo;
    public bool manyLegsFour;
    public bool manyLegsSix;
    public bool manyLegsEight;
    public bool twoArms;
}
[System.Serializable]
public class Where
{
    public bool inTree;
    public bool inHome;
    public bool inWild;
    public bool inWater;
    public bool inFarm;
    public bool inIce;
}
[System.Serializable]
public class DoesItEat
{
    public bool meat;
    public bool grass;
    public bool bananas;
    public bool leaves;
}
[System.Serializable]
public class Do
{
    public bool eat;
    public bool lookAfter;
    public bool ride;
}

