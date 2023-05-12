using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public MusicalChairsGame gameController;
    public Button[] chairs;

    private Button currentChair;

    private void Start()
    {
        foreach (Button chair in chairs)
        {
            chair.onClick.AddListener(() => ChairClicked(chair));
        }
    }

    public void ChairClicked(Button chair)
    {
        if (gameController.IsRoundActive())
        {
            gameController.PlayerClickedChair(chair, gameObject);
        }
    }

    public void SetCurrentChair(Button chair)
    {
        currentChair = chair;
    }

    public void RemoveCurrentChair()
    {
        currentChair = null;
    }
}
