using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicalChairsGame : MonoBehaviour
{
    public List<Button> chairs;
    public Text roundText;
    public Text messageText;
    public AudioSource musicAudioSource;
    public float musicMinDuration = 10.0f;
    public float musicMaxDuration = 20.0f;

    private int round = 1;
    private int numChairs;
    private List<GameObject> players = new List<GameObject>();
    private bool roundActive = false;

    private void Start()
    {
        numChairs = chairs.Count;
    }

    public void StartGame()
    {
        messageText.text = "";
        roundActive = true;
        StartCoroutine(PlayMusic());
        StartCoroutine(StartRound());
    }

    public void RestartGame()
    {
        round = 1;
        numChairs = chairs.Count;
        players.Clear();
        messageText.text = "";
        roundText.text = "Round " + round;
        roundActive = false;
    }

    private IEnumerator PlayMusic()
    {
        musicAudioSource.Play();
        float musicDuration = Random.Range(musicMinDuration, musicMaxDuration);
        yield return new WaitForSeconds(musicDuration);
        musicAudioSource.Stop();
        roundActive = false;
        StartCoroutine(EndRound());
    }

    private IEnumerator StartRound()
    {
        roundText.text = "Round " + round;
        ShuffleChairs();
        yield return new WaitForSeconds(1.0f);
        foreach (GameObject player in players)
        {
            ComputerController computerController = player.GetComponent<ComputerController>();
            StartCoroutine(computerController.ComputerReact());
        }
    }

    private IEnumerator EndRound()
    {
        yield return new WaitForSeconds(1.0f);
        int numPlayers = players.Count;
        for (int i = 0; i < numPlayers; i++)
        {
            GameObject player = players[i];
            ComputerController computerController = player.GetComponent<ComputerController>();
            if (!chairs.Contains(computerController.currentChair))
            {
                players.Remove(player);
                Destroy(player);
                numPlayers--;
                i--;
            }
        }

        int numRemaining = chairs.Count;
        foreach (Button chair in chairs)
        {
            if (!chair.interactable)
            {
                numRemaining--;
            }
        }

        if (numRemaining <= 1)
        {
            if (players.Count == 1)
            {
                messageText.text = "Player Wins!";
            }
            else
            {
                messageText.text = "All players lose.";
            }
            roundActive = false;
        }
        else
        {
            round++;
            numChairs--;
            roundText.text = "Round " + round;
            StartCoroutine(StartRound());
        }
    }

    private void ShuffleChairs()
    {
        int n = chairs.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Button temp = chairs[k];
            chairs[k] = chairs[n];
            chairs[n] = temp;
        }
    }

    public bool IsRoundActive()
    {
        return roundActive;
    }

    public void PlayerClickedChair(Button chair, GameObject player)
    {
        if (!roundActive)
        {
            return;
        }

        if (!chair.interactable)
        {
            return;
        }

        ComputerController computerController = player.GetComponent<ComputerController>();
        if (computerController.currentChair != null)
        {
            return;
        }

        computerController.currentChair = chair;

            chair.interactable = false;
            int numRemaining = chairs.Count;
    foreach (Button button in chairs)
    {
        if (!button.interactable)
        {
            numRemaining--;
        }
    }

    if (numRemaining == 1)
    {
        messageText.text = "Player Wins!";
        roundActive = false;
    }
    else
    {
        StartCoroutine(StartRound());
    }
    }

    public void AddPlayer(GameObject player)
    {
        players.Add(player);
    }

    public int GetNumChairs()
    {
        return numChairs;
    }

    
}



       
