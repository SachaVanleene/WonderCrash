using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    private int craziness;
    new string name;
    private string description;
    private Sprite currentIcon;
    private string[] dialog;
    public Sprite patient, doctor, police;

    public void setCharacter(int character)
    {
        if (character == 1)
        {
            craziness = 1;
            currentIcon = patient;
            name = "Patient";
        }
        else if (character == 2)
        {
            craziness = 1;
            currentIcon = doctor;
            name = "Doctor";
        }
        else if (character == 3)
        {
            craziness = 2;
            currentIcon = police;
            name = "police";
        }

        setDialog(character);
    }

    public void setDialog(int character)
    {

    }

    public void setDescription(int character)
    {

    }

    public string getName()
    {
        return name;
    }

    public Sprite getCurrentSprite()
    {
        return currentIcon;
    }

    public Sprite getSpriteByCharacter(int character)
    {
        if (character == 1) return patient;
        else if (character == 2) return doctor;
        else return police;
    }



}
