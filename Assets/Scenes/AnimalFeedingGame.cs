using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalFeedingGame : MonoBehaviour
{
    
    public Text foodTypeText;
    public Image foodImage;
    public Button lionButton;
    public Button elephantButton;
    public Text messageText;
    public Text lionCounterText;
    public Text elephantCounterText;

    public int maxFedTimes = 5; // Number of times each animal needs to be fed before game ends

    private List<string> lionFoodTypes = new List<string>() { "Fisk", "Kylling", "Kød" };
    private List<string> elephantFoodTypes = new List<string>() { "Halm", "Frugt", "Nødder", "Grøntsager" };
    private Dictionary<string, Sprite> foodSprites = new Dictionary<string, Sprite>();

    private string currentFoodType;

    private int lionFedTimes = 0;
    private int elephantFedTimes = 0;

    private SoundManager soundManager;
 

    void Start()
    {
        SoundManager soundManager = SoundManager.Instance;
         // Load all food sprites from Resources folder
        Sprite[] sprites = Resources.LoadAll<Sprite>("FoodSprites");
        foreach (Sprite sprite in sprites)
        {
            foodSprites.Add(sprite.name, sprite);
        }

        SpawnFood();
    }

    public void LionButtonClicked()
    {
        if (lionFoodTypes.Contains(currentFoodType))
        {
            soundManager.PlayClipByIndex(1);
            messageText.text = "Lion fed!";
            lionFedTimes++;            
            lionCounterText.text = "Lion: " + lionFedTimes + " / " + maxFedTimes;
            if (lionFedTimes >= maxFedTimes && elephantFedTimes >= maxFedTimes) {
                EndGame();
            } else {
                SpawnFood();
            }
        }
        else
        {
            soundManager.PlayClipByIndex(0);
            messageText.text = "Incorrect!";
        }
    }

    public void ElephantButtonClicked()
    {
        if (elephantFoodTypes.Contains(currentFoodType))
        {
            soundManager.PlayClipByIndex(1);
            messageText.text = "Elephant fed!";
            elephantFedTimes++;
            elephantCounterText.text = "Elephant: " + elephantFedTimes + " / " + maxFedTimes;
            if (lionFedTimes >= maxFedTimes && elephantFedTimes >= maxFedTimes) {
                EndGame();
            } else {
                SpawnFood();
            }
        }
        else
        {
            soundManager.PlayClipByIndex(0);
            messageText.text = "Incorrect!";
        }
    }

    private void SpawnFood()
    {
        currentFoodType = GetRandomFoodType();
        foodTypeText.text = "Food type: " + currentFoodType;
                // Display corresponding food image
        Sprite foodSprite;
        if (foodSprites.TryGetValue(currentFoodType, out foodSprite))
        {
            foodImage.sprite = foodSprite;
        }
        else
        {
            Debug.LogError("No sprite found for food type: " + currentFoodType);
        }
        messageText.text = "";
    }

    private string GetRandomFoodType()
    {
        int randomIndex = Random.Range(0, lionFoodTypes.Count + elephantFoodTypes.Count);
        if (randomIndex < lionFoodTypes.Count)
        {
            return lionFoodTypes[randomIndex];
        }
        else
        {
            return elephantFoodTypes[randomIndex - lionFoodTypes.Count];
        }
    }

    private void EndGame()
    {
        messageText.text = "Game over!";
        lionButton.interactable = false;
        elephantButton.interactable = false;
    }
}
