using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 4.0f;
    private int[] characters;
    private UnityEngine.UI.Image mainIcon;
    Character characterComponenet;
    private Vector3 movment;
    PlayerStats stats;

    // Use this for initialization
    void Start () {
        characters = new int[] { 1, 2, 3 };
        characterComponenet = GetComponent<Character>();
        mainIcon = GameObject.FindGameObjectWithTag("Icon0").GetComponent<UnityEngine.UI.Image>();
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

        changeCharacter();
        float h = 0f;
        float v = 0f;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (!stats.getSpotted())
        {
            Move(h, v);

        }

    }

    void Move(float h, float v)
    {
        movment.Set(h, 0f, v);
        movment = movment.normalized * speed * Time.deltaTime;
        transform.Translate(movment);
    }

    int findIndexOf(int character)
    {
        if (characters[0] == character)
            return 0;
        else if (characters[1] == character)
            return 1;
        else
            return 2;
    }

    public int[] getCharacters()
    {
        return characters;
    }
    
    public int getCurrentCharacter()
    {
        return characters[0];
    }

    void changeCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && characters[0] != 1)
        {
            int lastCharacter = characters[0];
            int index = findIndexOf(1);
            characters[findIndexOf(1)] = lastCharacter;
            characters[0] = 1;
            characterComponenet.setCharacter(1);
            mainIcon.sprite = characterComponenet.getCurrentSprite();
            GameObject.FindGameObjectWithTag("Icon" + index).GetComponent<UnityEngine.UI.Image>().sprite = characterComponenet.getSpriteByCharacter(lastCharacter);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && characters[0] != 2)
        {
            int lastCharacter = characters[0];
            int index = findIndexOf(2);
            characters[index] = lastCharacter;
            characters[0] = 2;
            characterComponenet.setCharacter(2);
            mainIcon.sprite = characterComponenet.getCurrentSprite();
            GameObject.FindGameObjectWithTag("Icon" + index).GetComponent<UnityEngine.UI.Image>().sprite = characterComponenet.getSpriteByCharacter(lastCharacter);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && characters[0] != 3)
        {
            int lastCharacter = characters[0];
            int index = findIndexOf(3);
            characters[index] = lastCharacter;
            characters[0] = 3;
            characterComponenet.setCharacter(3);
            mainIcon.sprite = characterComponenet.getCurrentSprite();
            GameObject.FindGameObjectWithTag("Icon" + index).GetComponent<UnityEngine.UI.Image>().sprite = characterComponenet.getSpriteByCharacter(lastCharacter);
        }
    }
}
