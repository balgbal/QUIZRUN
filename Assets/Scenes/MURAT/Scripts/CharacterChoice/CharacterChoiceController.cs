using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterChoiceController : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    private int currentCharacter;
    private void Awake()
    {
        SelectCharacter(0);
    }
    public void SelectCharacter(int indexNo)
    {
        previousButton.interactable  = (indexNo!=0);
        nextButton.interactable  = (indexNo!=transform.childCount-1);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == indexNo);
        }
    }
    public void ChangeChracter(int change)
    {
        currentCharacter += change;
        SelectCharacter(currentCharacter);
    }
}
