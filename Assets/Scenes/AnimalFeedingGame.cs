using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalFeedingGame : MonoBehaviour
{
    public Button lionButton;
    public Button elephantButton;
    public Text foodText;
    public Text messageText;
    public Image foodImage;

    private List<string> lionFoodTypes = new List<string>{"meat", "fish", "chicken"};
    private List<string> elephantFoodTypes = new List<string>{"hay", "fruit", "vegetables", "nuts"};
    private Dictionary<string, Sprite> foodSprites = new Dictionary<string, Sprite>();

    private string currentFoodType;

    // Start is called before the first frame update
    void Start()
    {
        // Load all food sprites from Resources folder
        Sprite[] sprites = Resources.LoadAll<Sprite>("FoodSprites");
        foreach (Sprite sprite in sprites)
        {
            foodSprites.Add(sprite.name, sprite);
        }

        SpawnFood();

        lionButton.onClick.AddListener(() =>
        {
            if (lionFoodTypes.Contains(currentFoodType))
            {
                messageText.text = "You fed the lion!";
                SpawnFood();
            }
            else
            {
                messageText.text = "Wrong food! Try again.";
            }
        });

        elephantButton.onClick.AddListener(() =>
        {
            if (elephantFoodTypes.Contains(currentFoodType))
            {
                messageText.text = "You fed the elephant!";
                SpawnFood();
            }
            else
            {
                messageText.text = "Wrong food! Try again.";
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnFood()
    {
        int animalIndex = Random.Range(0, 2);
        if (animalIndex == 0)
        {
            currentFoodType = lionFoodTypes[Random.Range(0, lionFoodTypes.Count)];
        }
        else
        {
            currentFoodType = elephantFoodTypes[Random.Range(0, elephantFoodTypes.Count)];
        }

        foodText.text = "Food type: " + currentFoodType;

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
    }
}
