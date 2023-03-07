using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteract : MonoBehaviour
{
    public static ButtonInteract instance;
    public string NamaScene;

    GameObject playerMetaGame;

    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);

        playerMetaGame = GameObject.FindGameObjectWithTag("Player");
    }

    public void CallButton()
    {
        //Save posisi player
        SaveManager.instance.GameSave.SavePosisiPlayer(playerMetaGame.transform.position);

        SceneManager.LoadScene(NamaScene);
    }

    public void SceneMiniGame(string namaScene)
    {
        NamaScene = namaScene;
    }
}
