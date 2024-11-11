using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameObject[] itemSlots;
    public GameObject selectedFrame;

    private int nrLoaded;

    public Sprite[] itemSpritesInInventory;
    private int upPos = 0;
    private int selectedItem = -1;

    public TextMeshProUGUI HintText;


    public GameStates gamestate = GameStates.Menu;
    public GameObject gameUI, pauseMenu, mainMenu, loadingMenu, winMenu;
    private bool paused = false;


    public GameObject levelPrefab;
    public GameObject mainCamera;

    public GameObject spikesL, spikesR;
    private bool moving = false;


    public GameObject returnArrow;
    private float retX = 0, retY = 0, retZ = 0;


    private int[] code = new int[4];

    private int retRot = 0;

    public AudioSource src;
    public AudioSource src_walk;

    void Start()
    {
        BackToMenu();

    }


    public int[] GetCode()
    {
        return code;
    }

    void GenerateCode()
    {
        int[] numbers = new int[6];

        GameObject[] numbersPlacesNoOrder = new GameObject[6];

        numbersPlacesNoOrder = GameObject.FindGameObjectsWithTag("NumberPlace");


        GameObject[] numbersPlaces = new GameObject[6];

        foreach (GameObject obj in numbersPlacesNoOrder)
        {
            if (obj.name == "BlackNumber")
            {
                numbersPlaces[0] = obj;
            }
            if (obj.name == "BlueNumber")
            {
                numbersPlaces[1] = obj;
            }
            if (obj.name == "GreenNumber")
            {
                numbersPlaces[2] = obj;
            }
            if (obj.name == "OrangeNumber")
            {
                numbersPlaces[3] = obj;
            }
            if (obj.name == "PurpleNumber")
            {
                numbersPlaces[4] = obj;
            }
            if (obj.name == "RedNumber")
            {
                numbersPlaces[5] = obj;
            }
        }




        GameObject[] coloredSquaresNoOrder = new GameObject[4];

        coloredSquaresNoOrder = GameObject.FindGameObjectsWithTag("ColorPlace");


        GameObject[] coloredSquares = new GameObject[4];

        foreach (GameObject obj in coloredSquaresNoOrder)
        {
            if (obj.name == "ColoredSquare1")
            {
                coloredSquares[0] = obj;
            }
            if (obj.name == "ColoredSquare2")
            {
                coloredSquares[1] = obj;
            }
            if (obj.name == "ColoredSquare3")
            {
                coloredSquares[2] = obj;
            }
            if (obj.name == "ColoredSquare4")
            {
                coloredSquares[3] = obj;
            }

        }




        for (int i = 0; i < 6; i++)
        {
            System.Random random = new System.Random();
            numbers[i] = random.Next(0, 10);
        }

        numbersPlaces[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/numbers/black/black_" + numbers[0]);
        numbersPlaces[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/numbers/blue/blue_" + numbers[1]);
        numbersPlaces[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/numbers/green/green_" + numbers[2]);
        numbersPlaces[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/numbers/orange/orange_" + numbers[3]);
        numbersPlaces[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/numbers/purple/purple_" + numbers[4]);
        numbersPlaces[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/numbers/red/red_" + numbers[5]);


        code[0] = -1; code[1] = -1; code[2] = -1; code[3] = -1;

        for (int i = 0; i < 4; i++)
        {
            System.Random random = new System.Random();
            int j = -1;
            while (code[i] == -1)
            {
                j = random.Next(0, 6);
                code[i] = numbers[j];
                numbers[j] = -1;
            }

            if (j == 0)
                coloredSquares[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/numbers/squares/square_black");

            if (j == 1)
                coloredSquares[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/numbers/squares/square_blue");

            if (j == 2)
                coloredSquares[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/numbers/squares/square_green");

            if (j == 3)
                coloredSquares[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/numbers/squares/square_orange");

            if (j == 4)
                coloredSquares[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/numbers/squares/square_purple");

            if (j == 5)
                coloredSquares[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/numbers/squares/square_red");

        }


    }


    public IEnumerator MoveTo(float x, float y, float z, bool arr, float rotat)
    {

        if (!moving)
        {
            src_walk.Play();
            if (!arr)
            {
                returnArrow.SetActive(arr);
            }

            moving = true;

            for (int p = 2000; p >= 500; p = p - 50)
            {
                spikesL.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-p, 0, 0);
                spikesR.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(p, 0, 0);

                yield return new WaitForSeconds(0.0001f);
            }


            mainCamera.transform.position = new Vector3(x, y, z);
            mainCamera.transform.localRotation = new Quaternion(0, 0, 0, mainCamera.transform.rotation.w);
            mainCamera.transform.Rotate(new Vector3(0, rotat, 0));



            for (int p = 500; p <= 2000; p = p + 50)
            {
                spikesL.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-p, 0, 0);
                spikesR.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(p, 0, 0);

                yield return new WaitForSeconds(0.0001f);
            }

            returnArrow.SetActive(arr);

            moving = false;

        }
    }

    public void BackToMenu()
    {
        src.Stop();
        gamestate = GameStates.Menu;
        Time.timeScale = 1;
        paused = false;
        SetText("");

        _instance = this;
        returnArrow.SetActive(false);
        gameUI.SetActive(false);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        loadingMenu.SetActive(false);
        winMenu.SetActive(false);


        GameObject[] levels = GameObject.FindGameObjectsWithTag("LEVEL");

        foreach (GameObject lv in levels)
        {
            Destroy(lv);
        }

        ClearInv();

    }

    void ClearInv()
    {
        while (itemSpritesInInventory.Length > 0)
        {
            DeleteItem(0);
        }

        UpdateInv();
    }

    public void PowerOn()
    {

        GameObject[] obj = GameObject.FindGameObjectsWithTag("P_ON_OFF");

        foreach (GameObject o in obj)
        {
            o.SetActive(false);
        }

        obj = GameObject.FindGameObjectsWithTag("P_ON_ON");

        foreach (GameObject o in obj)
        {
            o.transform.localScale = new Vector3(1f, 1f, 1f);

        }


        Return(0);
    }

    void Update()
    {

        if (Input.GetButtonDown("Pause") && !gamestate.Equals(GameStates.Menu) && !gamestate.Equals(GameStates.Win))
        {
            PauseGame();

        }

    }

    public void ObjectLoaded()
    {
        nrLoaded++;

        if (nrLoaded == 243)
        {
            GenerateCode();
            mainCamera.transform.position = new Vector3(1.65f, 0.5f, -6.73f);
            mainCamera.transform.rotation = new Quaternion(0, 0, 0, mainCamera.transform.rotation.w);
            loadingMenu.SetActive(false);

            gameUI.SetActive(true);
            gamestate = GameStates.Gameplay;
            SetText("");

            spikesL.GetComponent<RectTransform>().anchoredPosition = new Vector3(-2000, 0, 0);
            spikesR.GetComponent<RectTransform>().anchoredPosition = new Vector3(2000, 0, 0);
            src.Play();

            moving = false;
        }
    }

    public void SetReturnPos(float x, float y, float z)
    {
        retX = x;
        retY = y;
        retZ = z;
    }

    public void setRetRot(int x)
    {
        retRot = x;
    }

    public void ReturnArrow()
    {
        Return(retRot);
    }



    public void Return(int rot)
    {
        StartCoroutine(MoveTo(retX, retY, retZ, false, rot));
    }

    public void StartGame()
    {
        nrLoaded = 0;
        loadingMenu.SetActive(true);
        mainMenu.SetActive(false);

        Instantiate(levelPrefab, new Vector3(0, 0, 0), Quaternion.identity);

    }

    public int GetSelectedItem()
    {
        return selectedItem;
    }

    public void ScrollUp()
    {
        Select(-1);

        upPos = upPos - itemSlots.Length;
        if (upPos < 0)
            upPos = 0;

        UpdateInv();
    }

    public void ScrollDown()
    {
        Select(-1);

        if (itemSpritesInInventory.Length - upPos >= itemSlots.Length)
            upPos = upPos + itemSlots.Length;

        UpdateInv();
    }


    public void Select(int k)
    {
        if (k >= 0 && ((upPos + k) < itemSpritesInInventory.Length) && (selectedItem != (upPos + k)))
        {

            selectedFrame.transform.parent = itemSlots[k].transform;
            selectedFrame.transform.position = itemSlots[k].transform.position;
            selectedFrame.SetActive(true);
            selectedFrame.transform.localScale = new Vector3(1, 1, 1);
            selectedItem = upPos + k;


        }
        else
        {
            selectedFrame.SetActive(false);
            selectedItem = -1;
        }
    }

    public void UpdateInv()
    {
        while (upPos >= itemSpritesInInventory.Length)
        {
            upPos = upPos - 3;
        }

        if (upPos < 0)
        {
            upPos = 0;
        }

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if ((upPos + i) < itemSpritesInInventory.Length)
            {
                itemSlots[i].GetComponent<Image>().sprite = itemSpritesInInventory[upPos + i];
            }
            else
            {
                itemSlots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/nothing");
            }
        }
    }

    public void SetText(string tx)
    {
        HintText.text = tx;
        StopAllCoroutines();

        StartCoroutine(SetText2());

    }

    public IEnumerator SetText2()
    {

        for (int i = 0; i <= 10; i++)
        {
            HintText.color = new Color(1f, 1f, 1f, (float)(i) / 10f);
            yield return new WaitForSeconds(.15f);
        }

        yield return new WaitForSeconds(5f);

        for (int i = 10; i >= 0; i--)
        {
            HintText.color = new Color(1f, 1f, 1f, (float)(i) / 10f);
            yield return new WaitForSeconds(.15f);
        }

    }

    public void DeleteItem(int pos)
    {
        for (int i = pos; i < itemSpritesInInventory.Length - 1; i++)
        {
            itemSpritesInInventory[i] = itemSpritesInInventory[i + 1];
        }
        Array.Resize(ref itemSpritesInInventory, itemSpritesInInventory.Length - 1);


        UpdateInv();
        Select(-1);
    }

    public void AddItem(string name)
    {
        Array.Resize(ref itemSpritesInInventory, itemSpritesInInventory.Length + 1);
        itemSpritesInInventory[itemSpritesInInventory.Length - 1] = Resources.Load<Sprite>("Sprites/Items/" + name);


        UpdateInv();
        Select(-1);
    }



    public void PauseGame()
    {
        paused = !paused;

        if (paused)
        {


            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            gamestate = GameStates.Paused;
        }
        else
        {

            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            gamestate = GameStates.Gameplay;
        }
    }

    public void QuitGame()
    {
        Application.Quit();

    }

    public void Win()
    {
        src.Stop();
        gamestate = GameStates.Win;
        gameUI.SetActive(false);
        winMenu.SetActive(true);
    }



}
