using TMPro;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public string[] texts;
    public GameObject[] controlledObject;
    private bool[] didThing = new bool[5] { false, false, false, false, false };

    void Start()
    {

    }

    void Update()
    {

    }


    private void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                int sI = GameManager._instance.GetSelectedItem();

                switch (gameObject.name)
                {


                    case "picture_spider":
                        controlledObject[0].SetActive(true);
                        controlledObject[1].SetActive(true);
                        GameManager._instance.SetText(texts[0]);
                        gameObject.SetActive(false);
                        break;


                    case "picture_spider2":
                        GameManager._instance.SetText(texts[0]);
                        break;


                    case "frontHole":
                        GameManager._instance.SetReturnPos(1.65f, 0.5f, -6.73f);
                        StartCoroutine(GameManager._instance.MoveTo(1.8f, 0.4f, -2.72f, true, 0));
                        break;

                    case "hammer":
                        GameManager._instance.AddItem("hammer");
                        GameManager._instance.SetText(texts[0]);
                        gameObject.SetActive(false);
                        break;

                    case "chest_key":

                        if (didThing[0] == false)
                        {
                            didThing[0] = true;
                            GameManager._instance.AddItem("chest_key");
                            GameManager._instance.SetText(texts[0]);

                            gameObject.GetComponent<AudioSource>().Play();
                            gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        break;


                    case "Door_R1_1":
                        StartCoroutine(GameManager._instance.MoveTo(-6.6f, 0.5f, -6.73f, false, 0));
                        break;

                    case "Door_R1_2":
                        StartCoroutine(GameManager._instance.MoveTo(10f, 0.5f, -6.73f, false, 0));
                        break;

                    case "Ladder":
                        GameManager._instance.AddItem("ladder");
                        GameManager._instance.SetText(texts[0]);
                        gameObject.SetActive(false);
                        break;



                    case "wires_place":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("wires"))
                            {
                                GameManager._instance.DeleteItem(sI);
                                GameManager._instance.SetText(texts[1]);

                                controlledObject[0].SetActive(true);
                                controlledObject[0].GetComponent<AudioSource>().Play();

                                controlledObject[1].SetActive(false);
                                controlledObject[2].SetActive(true);
                                controlledObject[3].SetActive(true);


                                gameObject.SetActive(false);
                            }
                            else
                            {
                                GameManager._instance.SetText(texts[2]);
                            }
                        }

                        break;


                    case "unpowered":
                        GameManager._instance.SetText(texts[0]);
                        break;

                    case "powered_box":
                        GameManager._instance.SetReturnPos(19.72f, 10.3f, -7.7f);
                        StartCoroutine(GameManager._instance.MoveTo(20f, 10.7f, -3.65f, true, -90f));
                        break;


                    case "puzzle_ball":

                        foreach (GameObject obj in controlledObject)
                        {
                            obj.SetActive(!obj.activeSelf);
                        }


                        GameObject[] objs = GameObject.FindGameObjectsWithTag("PoweredB");

                        if (objs.Length == 9)
                        {
                            GameManager._instance.PowerOn();
                        }

                        gameObject.SetActive(false);

                        break;


                    case "puzzle_ball_active":
                        foreach (GameObject obj in controlledObject)
                        {
                            obj.SetActive(!obj.activeSelf);
                        }


                        gameObject.SetActive(false);
                        break;


                    case "Door_R2_1":
                        StartCoroutine(GameManager._instance.MoveTo(1.65f, 0.5f, -6.73f, false, 0));
                        break;

                    case "Door_R2_2":

                        if (controlledObject[0].activeSelf)
                        {
                            controlledObject[0].SetActive(false);
                            controlledObject[1].SetActive(true);
                        }
                        else
                        {
                            if (controlledObject[1].activeSelf)
                            {
                                controlledObject[1].SetActive(false);
                                controlledObject[2].SetActive(true);
                            }
                            else
                            {
                                if (controlledObject[2].activeSelf)
                                {
                                    controlledObject[2].SetActive(false);
                                    controlledObject[3].SetActive(true);
                                }
                                else
                                {
                                    controlledObject[3].SetActive(false);
                                    controlledObject[0].SetActive(true);
                                }
                            }
                        }


                        StartCoroutine(GameManager._instance.MoveTo(19.5f, 0.5f, -6.73f, false, 0));
                        break;

                    case "Door_R3_1":
                        StartCoroutine(GameManager._instance.MoveTo(10f, 0.5f, -6.73f, false, 0));
                        break;




                    case "lock_green":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("crowbar")
                                || GameManager._instance.itemSpritesInInventory[sI].name.Equals("hammer"))
                            {

                                GameManager._instance.SetText(texts[2]);



                            }
                            else
                            {
                                if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("green_key"))
                                {
                                    GameManager._instance.DeleteItem(sI);
                                    controlledObject[0].SetActive(true);
                                    controlledObject[0].GetComponent<AudioSource>().Play();
                                    gameObject.SetActive(false);
                                }
                                else
                                {
                                    if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("chest_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("blue_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("red_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("yellow_key"))
                                    {
                                        GameManager._instance.SetText(texts[1]);
                                    }
                                    else
                                    {
                                        GameManager._instance.SetText(texts[3]);
                                    }
                                }


                            }
                        }

                        break;



                    case "lock_red":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("crowbar")
                                || GameManager._instance.itemSpritesInInventory[sI].name.Equals("hammer"))
                            {

                                GameManager._instance.SetText(texts[2]);



                            }
                            else
                            {
                                if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("red_key"))
                                {
                                    GameManager._instance.DeleteItem(sI);
                                    controlledObject[0].SetActive(true);
                                    controlledObject[0].GetComponent<AudioSource>().Play();
                                    gameObject.SetActive(false);
                                }
                                else
                                {
                                    if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("chest_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("blue_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("green_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("yellow_key"))
                                    {
                                        GameManager._instance.SetText(texts[1]);
                                    }
                                    else
                                    {
                                        GameManager._instance.SetText(texts[3]);
                                    }
                                }


                            }
                        }

                        break;




                    case "lock_blue":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("crowbar")
                                || GameManager._instance.itemSpritesInInventory[sI].name.Equals("hammer"))
                            {

                                GameManager._instance.SetText(texts[2]);
                            }
                            else
                            {
                                if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("blue_key"))
                                {
                                    GameManager._instance.DeleteItem(sI);
                                    controlledObject[0].SetActive(true);
                                    controlledObject[0].GetComponent<AudioSource>().Play();
                                    gameObject.SetActive(false);
                                }
                                else
                                {
                                    if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("chest_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("green_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("red_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("yellow_key"))
                                    {
                                        GameManager._instance.SetText(texts[1]);
                                    }
                                    else
                                    {
                                        GameManager._instance.SetText(texts[3]);
                                    }
                                }


                            }
                        }

                        break;




                    case "lock_yellow":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("crowbar")
                                || GameManager._instance.itemSpritesInInventory[sI].name.Equals("hammer"))
                            {

                                GameManager._instance.SetText(texts[2]);
                            }
                            else
                            {
                                if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("yellow_key"))
                                {
                                    GameManager._instance.DeleteItem(sI);
                                    controlledObject[0].SetActive(true);
                                    controlledObject[0].GetComponent<AudioSource>().Play();
                                    gameObject.SetActive(false);
                                }
                                else
                                {
                                    if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("chest_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("blue_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("red_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("green_key"))
                                    {
                                        GameManager._instance.SetText(texts[1]);
                                    }
                                    else
                                    {
                                        GameManager._instance.SetText(texts[3]);
                                    }
                                }


                            }
                        }

                        break;


                    case "Escape_Door":

                        int nr = 0;
                        foreach (GameObject go in controlledObject)
                        {
                            if (go.activeSelf)
                            {
                                nr++;
                            }
                        }

                        GameManager._instance.SetText(texts[4 - nr]);

                        if (nr == 0)
                        {
                            GameManager._instance.Win();
                        }


                        break;



                    case "LadderPlace":

                        if (sI == -1)
                        {

                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("ladder"))
                            {
                                GameManager._instance.DeleteItem(sI);

                                controlledObject[0].SetActive(false);
                                controlledObject[1].SetActive(true);
                                controlledObject[2].SetActive(true);

                                gameObject.SetActive(false);
                            }

                        }

                        break;


                    case "Ladder2":
                        StartCoroutine(GameManager._instance.MoveTo(19.72f, 10.3f, -7.7f, false, 0));
                        break;

                    case "Trapdoor":
                        StartCoroutine(GameManager._instance.MoveTo(19.72f, 10.3f, -7.7f, false, 0));
                        break;

                    case "Trapdoor_NO":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("ladder"))
                            {
                                GameManager._instance.DeleteItem(sI);

                                controlledObject[0].SetActive(false);
                                controlledObject[1].SetActive(true);
                                controlledObject[2].SetActive(true);

                                gameObject.SetActive(false);
                            }
                            else
                            {
                                GameManager._instance.SetText(texts[0]);
                            }
                        }


                        break;

                    case "Trapdoor2":

                        if (controlledObject[0].activeSelf)
                        {
                            controlledObject[0].SetActive(false);
                            controlledObject[1].SetActive(true);
                        }
                        else
                        {
                            if (controlledObject[1].activeSelf)
                            {
                                controlledObject[1].SetActive(false);
                                controlledObject[2].SetActive(true);
                            }
                            else
                            {
                                if (controlledObject[2].activeSelf)
                                {
                                    controlledObject[2].SetActive(false);
                                    controlledObject[3].SetActive(true);
                                }
                                else
                                {
                                    controlledObject[3].SetActive(false);
                                    controlledObject[0].SetActive(true);
                                }
                            }
                        }


                        StartCoroutine(GameManager._instance.MoveTo(19.5f, 0.5f, -6.73f, false, 0));
                        break;

                    case "blue_key":
                        if (didThing[0] == false)
                        {
                            GameManager._instance.AddItem("blue_key");
                            GameManager._instance.SetText(texts[0]);
                            gameObject.GetComponent<AudioSource>().Play();
                            gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        break;
                    case "green_key":
                        if (didThing[0] == false)
                        {
                            GameManager._instance.AddItem("green_key");
                            GameManager._instance.SetText(texts[0]);
                            controlledObject[0].SetActive(false);
                            gameObject.GetComponent<AudioSource>().Play();
                            gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        break;
                    case "red_key":
                        if (didThing[0] == false)
                        {
                            GameManager._instance.AddItem("red_key");
                            GameManager._instance.SetText(texts[0]);
                            gameObject.GetComponent<AudioSource>().Play();
                            gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        break;
                    case "yellow_key":
                        if (didThing[0] == false)
                        {
                            GameManager._instance.AddItem("yellow_key");
                            GameManager._instance.SetText(texts[0]);
                            gameObject.GetComponent<AudioSource>().Play();
                            gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        break;



                    case "piggy_bank":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("hammer") ||
                                GameManager._instance.itemSpritesInInventory[sI].name.Equals("crowbar"))
                            {
                                controlledObject[0].SetActive(true);
                                controlledObject[0].GetComponent<AudioSource>().Play();
                                controlledObject[1].SetActive(true);

                                gameObject.SetActive(false);
                            }
                            else
                            {
                                GameManager._instance.SetText(texts[0]);
                            }
                        }


                        break;


                    case "piggy_bank_broken":

                        if (didThing[0] == false)
                        {
                            GameManager._instance.SetText(texts[0]);
                            didThing[0] = true;
                        }
                        else
                        {
                            GameManager._instance.SetText(texts[1]);
                        }


                        break;

                    case "medalion_pick":

                        GameManager._instance.AddItem("medalion");
                        GameManager._instance.SetText(texts[0]);
                        gameObject.SetActive(false);


                        break;


                    case "Crowbar":

                        GameManager._instance.AddItem("crowbar");
                        GameManager._instance.SetText(texts[0]);
                        gameObject.SetActive(false);


                        break;


                    case "codeStart":
                        GameManager._instance.SetReturnPos(19.72f, 0.5f, -6.73f);
                        StartCoroutine(GameManager._instance.MoveTo(19f, 0.55f, -3.6f, true, 0));
                        break;


                    case "medalionHole":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("medalion"))
                            {
                                GameManager._instance.DeleteItem(sI);
                                controlledObject[0].SetActive(true);

                                gameObject.SetActive(false);
                            }
                            else
                            {
                                GameManager._instance.SetText(texts[2]);
                            }
                        }


                        break;


                    case "enter_code_1":

                        string numb1Str = controlledObject[0].GetComponent<SpriteRenderer>().sprite.name.ToString();
                        int numb1 = int.Parse(numb1Str[numb1Str.Length - 1].ToString());
                        numb1 = (numb1 + 1) % 10;

                        controlledObject[0].GetComponent<SpriteRenderer>().sprite =
                        Resources.Load<Sprite>("Sprites/Items/numbers/code/code_" + numb1);

                        break;


                    case "enter_code_2":

                        string numb2Str = controlledObject[0].GetComponent<SpriteRenderer>().sprite.name.ToString();
                        int numb2 = int.Parse(numb2Str[numb2Str.Length - 1].ToString());
                        numb2 = (numb2 + 1) % 10;

                        controlledObject[0].GetComponent<SpriteRenderer>().sprite =
                        Resources.Load<Sprite>("Sprites/Items/numbers/code/code_" + numb2);

                        break;


                    case "enter_code_3":

                        string numb3Str = controlledObject[0].GetComponent<SpriteRenderer>().sprite.name.ToString();
                        int numb3 = int.Parse(numb3Str[numb3Str.Length - 1].ToString());
                        numb3 = (numb3 + 1) % 10;

                        controlledObject[0].GetComponent<SpriteRenderer>().sprite =
                        Resources.Load<Sprite>("Sprites/Items/numbers/code/code_" + numb3);

                        break;


                    case "enter_code_4":

                        string numb4Str = controlledObject[0].GetComponent<SpriteRenderer>().sprite.name.ToString();
                        int numb4 = int.Parse(numb4Str[numb4Str.Length - 1].ToString());
                        numb4 = (numb4 + 1) % 10;

                        controlledObject[0].GetComponent<SpriteRenderer>().sprite =
                        Resources.Load<Sprite>("Sprites/Items/numbers/code/code_" + numb4);

                        break;


                    case "medalion":

                        string numbStr = controlledObject[0].GetComponent<SpriteRenderer>().sprite.name.ToString();
                        int n1 = int.Parse(numbStr[numbStr.Length - 1].ToString());

                        numbStr = controlledObject[1].GetComponent<SpriteRenderer>().sprite.name.ToString();
                        int n2 = int.Parse(numbStr[numbStr.Length - 1].ToString());

                        numbStr = controlledObject[2].GetComponent<SpriteRenderer>().sprite.name.ToString();
                        int n3 = int.Parse(numbStr[numbStr.Length - 1].ToString());

                        numbStr = controlledObject[3].GetComponent<SpriteRenderer>().sprite.name.ToString();
                        int n4 = int.Parse(numbStr[numbStr.Length - 1].ToString());

                        int[] code = GameManager._instance.GetCode();

                        if ((code[0] == n1) && (code[1] == n2) && (code[2] == n3) && (code[3] == n4))
                        {
                            GameManager._instance.SetText(texts[1]);
                            controlledObject[4].SetActive(false);
                            controlledObject[5].SetActive(true);
                            controlledObject[6].SetActive(true);


                            GameManager._instance.Return(0);
                        }
                        else
                        {
                            GameManager._instance.SetText(texts[0]);
                        }

                        break;




                    case "Door_R5_1":
                        StartCoroutine(GameManager._instance.MoveTo(-14.1f, 0.5f, -6.73f, false, 0));
                        break;

                    case "Door_R5_2":
                        StartCoroutine(GameManager._instance.MoveTo(1.65f, 0.5f, -6.73f, false, 0));
                        break;



                    case "wires_start":
                        GameManager._instance.SetReturnPos(-6.6f, 0.5f, -6.73f);
                        StartCoroutine(GameManager._instance.MoveTo(-7.15f, 0.5f, -3.8f, true, 0f));
                        break;


                    case "puz_up":
                        for (int i = 0; i <= 5; i++)
                        {
                            controlledObject[i].GetComponent<SpriteRenderer>().sprite =
                                controlledObject[(i + 1) % 6].GetComponent<SpriteRenderer>().sprite;
                        }


                        if (controlledObject[6].GetComponent<SpriteRenderer>().sprite.name.ToString().Equals("connect_1") &&
                            controlledObject[7].GetComponent<SpriteRenderer>().sprite.name.ToString().Equals("connect_3") &&
                            controlledObject[8].GetComponent<SpriteRenderer>().sprite.name.ToString().Equals("connect_6") &&
                            controlledObject[9].GetComponent<SpriteRenderer>().sprite.name.ToString().Equals("connect_3") &&
                            controlledObject[10].GetComponent<SpriteRenderer>().sprite.name.ToString().Equals("connect_6"))
                        {

                            GameManager._instance.SetText(texts[0]);

                            controlledObject[11].SetActive(true);
                            controlledObject[12].SetActive(false);
                            controlledObject[13].SetActive(true);

                            GameManager._instance.Return(0);

                        }

                        break;


                    case "puz_do":

                        controlledObject[0].GetComponent<SpriteRenderer>().sprite =
                                controlledObject[5].GetComponent<SpriteRenderer>().sprite;

                        for (int i = 5; i > 0; i--)
                        {
                            controlledObject[i].GetComponent<SpriteRenderer>().sprite =
                                controlledObject[(i - 1)].GetComponent<SpriteRenderer>().sprite;
                        }


                        if (controlledObject[6].GetComponent<SpriteRenderer>().sprite.name.ToString().Equals("connect_1") &&
                            controlledObject[7].GetComponent<SpriteRenderer>().sprite.name.ToString().Equals("connect_3") &&
                            controlledObject[8].GetComponent<SpriteRenderer>().sprite.name.ToString().Equals("connect_6") &&
                            controlledObject[9].GetComponent<SpriteRenderer>().sprite.name.ToString().Equals("connect_3") &&
                            controlledObject[10].GetComponent<SpriteRenderer>().sprite.name.ToString().Equals("connect_6"))
                        {

                            GameManager._instance.SetText(texts[0]);

                            controlledObject[11].SetActive(true);
                            controlledObject[12].SetActive(false);
                            controlledObject[13].SetActive(true);

                            GameManager._instance.Return(0);

                        }

                        break;




                    case "Chest":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("crowbar")
                                || GameManager._instance.itemSpritesInInventory[sI].name.Equals("hammer"))
                            {

                                GameManager._instance.SetText(texts[1]);



                            }
                            else
                            {
                                if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("chest_key"))
                                {
                                    GameManager._instance.DeleteItem(sI);
                                    GameManager._instance.SetText(texts[3]);

                                    controlledObject[0].SetActive(true);
                                    controlledObject[0].GetComponent<AudioSource>().Play();

                                    controlledObject[1].SetActive(true);
                                    controlledObject[2].SetActive(true);
                                    gameObject.SetActive(false);
                                }
                                else
                                {
                                    if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("yellow_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("blue_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("red_key") ||
                                        GameManager._instance.itemSpritesInInventory[sI].name.Equals("green_key"))
                                    {
                                        GameManager._instance.SetText(texts[2]);
                                    }
                                    else
                                    {
                                        GameManager._instance.SetText(texts[4]);
                                    }
                                }


                            }
                        }

                        break;



                    case "Wires_pickup":

                        GameManager._instance.AddItem("wires");
                        GameManager._instance.SetText(texts[0]);
                        gameObject.SetActive(false);

                        break;

                    case "Knife_pickup":

                        GameManager._instance.AddItem("knife");
                        GameManager._instance.SetText(texts[0]);
                        gameObject.SetActive(false);

                        break;



                    case "plank":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("crowbar"))
                            {

                                controlledObject[0].SetActive(true);
                                controlledObject[1].SetActive(true);
                                controlledObject[2].SetActive(true);
                                controlledObject[3].SetActive(true);
                                controlledObject[4].SetActive(true);

                                gameObject.SetActive(false);

                            }
                            else
                            {
                                GameManager._instance.SetText(texts[1]);
                            }
                        }
                        break;


                    case "Teddy":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("knife"))
                            {

                                controlledObject[0].SetActive(true);
                                controlledObject[1].SetActive(true);

                                gameObject.GetComponent<AudioSource>().Play();

                                gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                            }
                            else
                            {
                                GameManager._instance.SetText(texts[0]);
                            }
                        }
                        break;

                    case "Deady":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("knife"))
                            {

                                GameManager._instance.SetText(texts[1]);

                            }
                            else
                            {
                                GameManager._instance.SetText(texts[0]);
                            }
                        }
                        break;




                    case "Door_R6_2":
                        StartCoroutine(GameManager._instance.MoveTo(-6.6f, 0.5f, -6.73f, false, 0));
                        break;



                    case "to_shelf":
                        GameManager._instance.SetReturnPos(-14.1f, 0.5f, -6.73f);
                        StartCoroutine(GameManager._instance.MoveTo(-14.85f, 0.5f, -3.8f, true, 0));
                        break;

                    case "TheBook":

                        if (didThing[0] == false)
                        {
                            didThing[0] = true;


                            GameManager._instance.SetText(texts[0]);

                            controlledObject[0].transform.localPosition = new Vector3(2.62f, 0.212f, -2.46f);
                            controlledObject[1].SetActive(false);

                            gameObject.GetComponent<AudioSource>().Play();

                            controlledObject[2].SetActive(true);
                            controlledObject[3].SetActive(true);
                            controlledObject[4].SetActive(true);
                            controlledObject[5].SetActive(true);

                            GameManager._instance.Return(0);
                        }

                        break;


                    case "toSecret":
                        GameManager._instance.setRetRot(180);
                        StartCoroutine(GameManager._instance.MoveTo(-14.1f, 0.5f, 1.5f, false, 180));
                        break;

                    case "fromSecret":
                        GameManager._instance.setRetRot(0);
                        StartCoroutine(GameManager._instance.MoveTo(-14.1f, 0.5f, -6.73f, false, 0));
                        break;


                    case "stuckGreen":
                        GameManager._instance.SetText(texts[0]);
                        break;


                    case "clock":

                        if (sI == -1)
                        {
                            GameManager._instance.SetText(texts[0]);
                        }
                        else
                        {
                            if (GameManager._instance.itemSpritesInInventory[sI].name.Equals("hammer"))
                            {

                                GameManager._instance.SetText(texts[1]);

                            }
                            else
                            {
                                GameManager._instance.SetText(texts[0]);
                            }
                        }

                        break;


                    case "toLaptop":
                        GameManager._instance.SetReturnPos(-14.1f, 0.5f, 1.5f);
                        StartCoroutine(GameManager._instance.MoveTo(-13f, 0.36f, -1.07f, true, 180));
                        break;


                    case "LogInButton":

                        string pass = controlledObject[1].GetComponent<TMP_InputField>().text;

                        if (pass.Equals("1250"))
                        {
                            controlledObject[2].SetActive(true);
                            controlledObject[3].SetActive(true);

                            controlledObject[4].SetActive(false);
                            controlledObject[5].SetActive(false);
                        }
                        else
                        {
                            if (didThing[0] == false)
                            {
                                didThing[0] = true;
                            }
                            else
                            {
                                if (didThing[1] == false)
                                {
                                    didThing[1] = true;
                                }
                                else
                                {
                                    controlledObject[0].SetActive(true);
                                }
                            }

                        }


                        break;



                    case "Magnet_ON_OFF":

                        controlledObject[0].SetActive(true);

                        if (controlledObject[2].activeSelf)
                        {
                            controlledObject[1].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                            controlledObject[2].transform.localScale = new Vector3(0f, 0f, 0f);
                        }

                        gameObject.SetActive(false);
                        break;


                    case "Magnet_OFF_ON":

                        controlledObject[0].SetActive(true);

                        if (controlledObject[2].activeSelf)
                        {
                            controlledObject[2].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                            controlledObject[1].transform.localScale = new Vector3(0f, 0f, 0f);
                        }

                        gameObject.SetActive(false);
                        break;


                    case "picture_change":
                        System.Random random = new System.Random();
                        GameManager._instance.SetText(texts[random.Next(0, texts.Length)]);
                        break;




                    default:
                        break;
                }
            }
        }
    }
}