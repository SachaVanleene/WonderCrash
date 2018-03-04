using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 4.0f;
    private int[] characters;
    private UnityEngine.UI.Image mainIcon;
    Character characterComponenet;
    private Vector3 movment;
    PlayerStats stats;
    public float RandomChangePeriode = 3f;
    float elapsed = 0f;
    bool[] enabling;
    private UnityEngine.UI.Image iconPerso1, iconPerso2, iconPerso3;

    public delegate void onPersonallityChange();
    public onPersonallityChange onTriggerPersonallityChanged; //PRévenir que j'ai changé de personnalité

    AudioSource step;
    bool moving;
    float movingTime; // depusi combien de temps je bouge

    public bool talking;

    private Rigidbody rb;


    private void Awake()
    {
        iconPerso1 = GameObject.FindGameObjectWithTag("Icon0").GetComponent<UnityEngine.UI.Image>();
        iconPerso2 = GameObject.FindGameObjectWithTag("Icon1").GetComponent<UnityEngine.UI.Image>();
        iconPerso3 = GameObject.FindGameObjectWithTag("Icon2").GetComponent<UnityEngine.UI.Image>();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            enabling = new bool[] { false, false, false };

        }
        else enabling = new bool[] { true, true, true };
        moving = false;
        movingTime = 0;
        talking = false;
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        characters = new int[] { 1, 2, 3 };
        characterComponenet = GetComponent<Character>();

        characterComponenet.setCharacter(characters[0]);
        iconPerso1.GetComponent<UnityEngine.UI.Image>().sprite = characterComponenet.getCurrentSprite();
        iconPerso2.GetComponent<UnityEngine.UI.Image>().sprite = characterComponenet.getSpriteByCharacter(characters[1]);
        iconPerso3.GetComponent<UnityEngine.UI.Image>().sprite = characterComponenet.getSpriteByCharacter(characters[2]);

        
        if (!enabling[0])
        {
            iconPerso1.GetComponent<UnityEngine.UI.Image>().color=new Color32(255,255,255,0);
        }
        if (!enabling[1])
        {
            iconPerso2.GetComponent<UnityEngine.UI.Image>().color = new Color32(255, 255, 255, 0);
        }
        if (!enabling[2])
        {
            iconPerso3.GetComponent<UnityEngine.UI.Image>().color = new Color32(255, 255, 255, 0);
        }


        stats = GetComponent<PlayerStats>();
        step = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!stats.isCrazy())
        {
            elapsed += Time.deltaTime;

            if (elapsed >= 1f)
            {
                elapsed = 0;

                Debug.Log("change : " + stats.getCurrentChange() + "id : " + characters[0]);
                if (characters[0] == 2) stats.incrCraziness(15);
                else if (characters[0] == 3) stats.incrCraziness(20);
                else if (stats.getCurrentChange() >= 2) stats.incrCraziness(-2);
                Debug.Log("change : " + stats.getCurrentChange() + "id : " + characters[0]);
            }

            changeCharacter();
        }

        float h = 0f;
        float v = 0f;
        if (!talking)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }
        if (!stats.getSpotted())
        {
            Move(h, v);

        }
        else
        {
            movment = (h * transform.right + v * transform.forward).normalized;
            rb.velocity = movment * 0f;
        }
        //Audio Management 
        if (Mathf.Abs(h + v) > 0)
        {
            movingTime += Time.deltaTime;
            if (moving)
            {
                if (movingTime > 2.611f)
                {
                    step.Play();
                    movingTime = 0f;
                }
            }
            else
            {
                moving = true;
                step.Play();
            }
        }
        else
        {
            moving = false;
            movingTime = 0f;
            if (step.isPlaying)
            {
                step.Stop();
            }
        }

    }

    void Move(float h, float v)
    {
        movment = (h * transform.right + v * transform.forward).normalized;
        rb.velocity = movment * speed;
        //transform.Translate(movment);


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

        if (Input.GetKeyDown(KeyCode.Alpha1) && enabling[0] && characters[0] != 1)
        {
            getCharacter(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && enabling[1] && characters[0] != 2)
        {
            getCharacter(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && enabling[2] && characters[0] != 3)
        {
            getCharacter(3);

            // Police man get the player crazy faster 

        }
    }

    void getCharacter(int character)
    {
        int lastCharacter = characters[0];
        int index = findIndexOf(character);
        characters[findIndexOf(character)] = lastCharacter;
        characters[0] = character;
        characterComponenet.setCharacter(character);
        iconPerso1.sprite = characterComponenet.getCurrentSprite();
        GameObject.FindGameObjectWithTag("Icon" + index).GetComponent<UnityEngine.UI.Image>().sprite = characterComponenet.getSpriteByCharacter(lastCharacter);
        onTriggerPersonallityChanged.Invoke();
    }

    public IEnumerator RandomChange()
    {
        yield return new WaitForSeconds(RandomChangePeriode);
        int character = Random.Range(1, 4);
        while (character == characters[0])
        {
            character = Random.Range(1, 3);
        }
        getCharacter(character);

        StartCoroutine(RandomChange());
    }


    public void addGuard(PlayerController.onPersonallityChange function)
    {
        onTriggerPersonallityChanged += function;
    }

    public void enablingChange(int id, bool _enabling)
    {
        enabling[id] = _enabling;

        if (_enabling)
        {
            if (id == 0) iconPerso1.GetComponent<UnityEngine.UI.Image>().color = new Color32(255, 255, 255, 110);
            if (id == 1) iconPerso2.GetComponent<UnityEngine.UI.Image>().color = new Color32(255, 255, 255, 110);
            if (id == 2) iconPerso3.GetComponent<UnityEngine.UI.Image>().color = new Color32(255, 255, 255, 110);
        }
    }
}
