using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] objs = new GameObject[9];
    public static int stateOfLoad=0;// defalt 0
    private GameObject[] inst_objs = new GameObject[225];
    private float x;
    private float y;
    private int lenght = 0;
    private int notNullLenght;
    private int score=0;
    // Use this for initialization
    //x=-4.4->4.4(+1.1);
    //y=26.4->0(-1.1);
    //z=0;
    void Start()
    {
        x = -4.4f;
        y = 26.4f;
        lenght = 27;
        notNullLenght = lenght;
        if (stateOfLoad == 1)
        {
            
            for (int i = 0, j = 0; i < lenght; i++)
            {
                j = Random.Range(0, 9);
                inst_objs[i] = Instantiate(objs[j], new Vector3(x, y, 0f), new Quaternion(0f, 180f, 0f, 0f)) as GameObject;
                inst_objs[i].transform.name = (j + 1).ToString();
                if (x == -1.1f)
                {
                    x = 0f;
                }
                else if (x < 3.3f)
                {
                    x += 1.1f;
                }
                else
                {
                    x = -4.4f;
                    y -= 1.1f;
                }
            }
        }
        else if (stateOfLoad == 0)
        {
            for (int i = 0; i < 9; i++)
            {
                inst_objs[i] = Instantiate(objs[i], new Vector3(x, y, 0f), new Quaternion(0f, 180f, 0f, 0f)) as GameObject;
                inst_objs[i].transform.name = (i+1).ToString();
                if (x == -1.1f)
                {
                    x = 0f;
                }
                else if (x < 3.3f)
                {
                    x += 1.1f;
                }
                else
                {
                    x = -4.4f;
                    y -= 1.1f;
                }
            }
            for (int i = 9, j = 0; i < lenght; i++)
            {
                j = Random.Range(0, 9);
                inst_objs[i] = Instantiate(objs[j], new Vector3(x, y, 0f), new Quaternion(0f, 180f, 0f, 0f)) as GameObject;
                inst_objs[i].transform.name = (j + 1).ToString();
                if (x == -1.1f)
                {
                    x = 0f;
                }
                else if (x < 3.3f)
                {
                    x += 1.1f;
                }
                else
                {
                    x = -4.4f;
                    y -= 1.1f;
                }
            }
        }
        else if (stateOfLoad == 2)
        {
            LoadLastGame(GameObject.Find("LoadGameButton").GetComponent<LoadClick>().LoadGame());
        }
        else //testmode
        {

        }
    }

    public void Search()
    {
        int[] index = new int[2];
        int j = 0;
        for (int i = 0; i < lenght; i++)
        {
            if (inst_objs[i] != null)
            {
                if (inst_objs[i].GetComponent<Game_obj_click>().GetState() == true)
                {
                    index[j] = i;
                    if (j == 1)
                    {
                        break;
                    }
                    j += 1;
                }
            }
        }
        if (j == 1)
        {
            FirstCheck(index);
        }
    }
    private void FirstCheck(int[] index)
    {
        if (inst_objs[index[0]].name == inst_objs[index[1]].name || (int.Parse(inst_objs[index[1]].name) + int.Parse(inst_objs[index[0]].name)) == 10)
        {
            if (SecondCheak(index) == true)
            {
                Destroy(inst_objs[index[0]]);
                Destroy(inst_objs[index[1]]);
                notNullLenght -= 2;
                score += 2;

                GameObject.Find("Wall").GetComponent<Instcheaked>().SetNumobj(0);
                OffsetCheak(index);
            }
            else
            {
                inst_objs[index[0]].GetComponent<Game_obj_click>().OnMouseDown();
                inst_objs[index[1]].GetComponent<Game_obj_click>().OnMouseDown();
            }
        }
        else
        {
            inst_objs[index[0]].GetComponent<Game_obj_click>().OnMouseDown();
            inst_objs[index[1]].GetComponent<Game_obj_click>().OnMouseDown();
        }       
    }
    private bool SecondCheak(int[] index)
    {
        bool a = true, b = false;
        int up = 1;
        int down = 1;
        int left = 1;
        int right = 1;
        while (a)
        {
            b = false;
            if ((index[0] + (1 * right)) < inst_objs.Length)
            {
                if (index[0] + (1 * right) == index[1])
                {
                    return true;
                }
                else if (inst_objs[index[0] + (1 * right)] == null && (index[0] + (1 * left)) < index[1])
                {
                    b = true;
                    right += 1;
                }
            }
            if ((index[0] - (1 * left)) >= 0)
            {
                if (index[0] - (1 * left) == index[1])
                {
                    return true;
                }
                else if (inst_objs[index[0] - (1 * left)] == null && (index[0] - (1 * left)) > index[1])
                {
                    b = true;
                    left += 1;
                }
            }
            if ((index[0] + (9 * down)) < inst_objs.Length)
            {
                if (index[0] + (9 * down) == index[1])
                {
                    return true;
                }
                else if (inst_objs[index[0] + (9 * down)] == null && (index[0] + (9 * down)) < index[1])
                {
                    b = true;
                    down += 1;
                }
            }
            if ((index[0] - (9 * up)) >= 0)
            {
                if (index[0] - (9 * up) == index[1])
                {
                    return true;
                }
                else if (inst_objs[index[0] - (9 * up)] == null && (index[0] - (9 * up)) > index[1])
                {
                    b = true;
                    up += 1;
                }
            }
            if (b == false)
            {
                break;
            }

        }

        return false;
    }

    public void ADD()
    {
        int[] numembers = new int[notNullLenght];
        for (int i = 0, k = 0; i < lenght; i++)
        {
            if (inst_objs[i] != null)
            {
                numembers[k] = int.Parse(inst_objs[i].name) - 1;
                k += 1;
            }
        }
        if (lenght + notNullLenght < inst_objs.Length)
        {
            for (int i = lenght,j=0 ; i < lenght + notNullLenght; i++,j++)
            {
                inst_objs[i] = Instantiate(objs[numembers[j]], new Vector3(x, y, 0f), new Quaternion(0f, 180f, 0f, 0f)) as GameObject;
                inst_objs[i].transform.name = (numembers[j] + 1).ToString();
                if (x == -1.1f)
                {
                    x = 0f;
                }
                else if (x < 3.3f)
                {
                    x += 1.1f;
                }
                else
                {
                    x = -4.4f;
                    y -= 1.1f;
                }
            }
            lenght += notNullLenght;
            notNullLenght += notNullLenght;
        }
        else
        {
            for (int i = lenght,j=0; i < inst_objs.Length; i++,j++)
            {
                inst_objs[i] = Instantiate(objs[numembers[j]], new Vector3(x, y, 0f), new Quaternion(0f, 180f, 0f, 0f)) as GameObject;
                inst_objs[i].transform.name = (numembers[j] + 1).ToString();
                if (x == -1.1f)
                {
                    x = 0f;
                }
                else if (x < 3.3f)
                {
                    x += 1.1f;
                }
                else
                {
                    x = -4.4f;
                    y -= 1.1f;
                }
            }
            lenght += inst_objs.Length - lenght;
            notNullLenght += inst_objs.Length - lenght;
        }

    }
    public void Reset()
    {
        foreach (GameObject objet in inst_objs)
        {
            Destroy(objet);
        }
        x = -4.4f;
        y = 26.4f;
        for (int i = 0,j; i < inst_objs.Length; i++)
        {
            j = Random.Range(0, 9);
            inst_objs[i] = Instantiate(objs[j], new Vector3(x, y, 0f), new Quaternion(0f, 180f, 0f, 0f)) as GameObject;
            inst_objs[i].transform.name = (j + 1).ToString();
            if (x == -1.1f)
            {
                x = 0f;
            }
            else if (x < 3.3f)
            {
                x += 1.1f;
            }
            else
            {
                x = -4.4f;
                y -= 1.1f;
            }
        }
        notNullLenght = inst_objs.Length;
        GameObject.Find("Wall").GetComponent<Instcheaked>().SetNumobj(0);
    }
    public void Glitch()
    {
        x = -4.4f;
        y = 26.4f;
        GameObject.Find("Wall").GetComponent<Instcheaked>().SetNumobj(0);
        for (int i = 0,j=0; i < inst_objs.Length; i++)
        {
            j = Random.Range(0, 9);
            inst_objs[i] = Instantiate(objs[j], new Vector3(x, y, 0f), new Quaternion(0f, 180f, 0f, 0f)) as GameObject;
            inst_objs[i].transform.name = (j + 1).ToString();
            if (x == -1.1f)
            {
                x = 0f;
            }
            else if (x < 3.3f)
            {
                x += 1.1f;
            }
            else
            {
                x = -4.4f;
                y -= 1.1f;
            }
        }
        notNullLenght = inst_objs.Length;
    }
    public void ResetGame()
    {
        GameObject[] X = GameObject.FindGameObjectsWithTag("Cube with number");
        for(int i = 0; i < X.Length; i++)
        {
            Destroy(X[i]);
        }
        GameObject.Find("Wall").GetComponent<Instcheaked>().SetNumobj(0);
        Start(); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (lenght != inst_objs.Length)
            {
                ADD();
            }
            else
            {
                Reset();
            }
        }else if (Input.GetKeyDown(KeyCode.B))
        {
            Glitch();
        }else if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
        if(notNullLenght==0)
        {
            Message.mes = "You Win!!!!!!!!!!!!!!!!!!!!!!";
            Message.Index = -1;
            SceneManager.LoadScene("MainMenu");
        }
    }
    public GameObject[] GetObjects()
    {
        return inst_objs;
    }
    public int Getlenght()
    {
        return lenght;
    }
    public int Getinst_objsLenght()
    {
        return inst_objs.Length;
    }
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int score)
    {
        this.score = score;
    }
    public static int GetstateOfLoad()
    {
        return stateOfLoad;
    }
    public void LoadLastGame(string[] names)
    {
        if (names != null)
        {
            int k = 0;
            x = -4.4f;
            y = 26.4f;
            GameObject[] X = GameObject.FindGameObjectsWithTag("Cube with number");
            for (int i = 0; i < X.Length; i++)
            {
                Destroy(X[i]);
            }
            GameObject.Find("Wall").GetComponent<Instcheaked>().SetNumobj(0);
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i]!= "-1")
                {
                    inst_objs[i] = Instantiate(objs[(int.Parse(names[i]) - 1)], new Vector3(x,y, 0f), new Quaternion(0f, 180f, 0f, 0f)) as GameObject;
                    inst_objs[i].transform.name = names[i];
                }
                else
                {
                    k += 1;
                }
                if (x == -1.1f)
                {
                    x = 0f;
                }
                else if (x < 3.3f)
                {
                    x += 1.1f;
                }
                else
                {
                    x = -4.4f;
                    y -= 1.1f;
                }
            }
            lenght = names.Length;
            notNullLenght = lenght - k;
        }

    }
    private void OffsetCheak(int[] index)
    {

        int min, max;
        bool result;
        for (int k = 0; k < 2; k++)
        {
            min = -1;
            max = 9;
            result = true;
            for (; max < 255;)
            {
                if (min < index[k] && max > index[k])
                {
                    break;
                }
                else
                {
                    min += 9;
                    max += 9;
                }
            }
            for (int i = min + 1; i < max; i++)
            {
                if (inst_objs[i] != null && i!=index[0] && i != index[1])
                {
                    result = false;
                    break;
                }
            }
            if (result == true)
            {
                Offset(min, max,index);
                if (k == 0 && min < index[1] && max > index[1])
                {
                    return;
                }else if (index[1] - 9 > 0)
                {
                    index[1] -= 9;
                }
            }
        }
    }
    private void Offset(int min, int max, int[] index)
    {
        score += 10;
        int num=0;
        GameObject[] buff = new GameObject[lenght];
        for(int i=0;i<lenght;i++)
        {
            if(i>min && i<max)
            {
                continue;
            }else
            {
                if(i==index[0] || i == index[1])
                {
                    buff[num] = null;
                }
                else
                {
                    buff[num] = inst_objs[i];
                }
                num += 1;
            }
        }
        foreach (GameObject objet in inst_objs)
        {
            Destroy(objet);
        }
        x = -4.4f;
        y = 26.4f;
        lenght = num;
        for (int i = 0; i < lenght; i++)
        {
            inst_objs[i] = buff[i];
            if(buff[i]!=null)
            {
                num = int.Parse(inst_objs[i].name) - 1;
                inst_objs[i] = Instantiate(objs[num], new Vector3(x, y, 0f), new Quaternion(0f, 180f, 0f, 0f)) as GameObject;
                inst_objs[i].name = (num + 1).ToString();
            }
            if (x == -1.1f)
            {
                x = 0f;
            }
            else if (x < 3.3f)
            {
                x += 1.1f;
            }
            else
            {
                x = -4.4f;
                y -= 1.1f;
            }
        }
    }
}

