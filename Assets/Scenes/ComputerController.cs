using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour
{
    public float reactionTime = 2.0f;
    public MusicalChairsGame gameController;

    [HideInInspector]
    public Button currentChair = null;

    private bool reacting = false;

    public IEnumerator ComputerReact()
    {
        if (reacting)
        {
            yield break;
        }

        reacting = true;

        yield return new WaitForSeconds(Random.Range(0.0f, reactionTime));

        if (gameController.IsRoundActive() && currentChair == null)
        {
            List<Button> availableChairs = new List<Button>();
            foreach (Button chair in gameController.chairs)
            {
                if (chair.interactable)
                {
                    availableChairs.Add(chair);
                }
            }

            if (availableChairs.Count > 0)
            {
                int index = Random.Range(0, availableChairs.Count);
                currentChair = availableChairs[index];
                currentChair.interactable = false;
                Debug.Log("Computer " + gameObject.name + " has selected chair " + currentChair.name);
            }
        }

        reacting = false;
    }
}
