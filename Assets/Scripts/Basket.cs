﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //this line enables use of uGUI features

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        //find a reference to the scorecounter gameobject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //get the text component of that gameobject
        scoreGT = scoreGO.GetComponent<Text>();
        //set the starting number of points to 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //get the current screen position of the mouse from input
        Vector3 mousePos2D = Input.mousePosition;
        //the camer'as z position sets how far to push the mouse into 3d
        mousePos2D.z = -Camera.main.transform.position.z;
        //convert the point from 2d screen space into 3d game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        //move the x position of this basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll) {
        //find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag=="Apple") {
            Destroy(collidedWith);

            //parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            //add points for catching the apple
            score += 100;
            //convert the score back to a string and display it
            scoreGT.text = score.ToString();
        }
    }
}
