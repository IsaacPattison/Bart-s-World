using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the bowling game
public class BowlingGameScript : MonoBehaviour
{

    public static BowlingGameScript instance = null;

    // Integers and booleans that keep track of each frames
    // scores, spares, strikes and what ball they are on
    [Header("Frame 1")]
    public int Frame_1_Ball_1_Score;
    public int Frame_1_Ball_2_Score;
    public int Frame_1_Score_Total_Score;
    public bool Frame_1_Strike = false;
    public bool Frame_1_Spare = false;
    [Space(10)]

    [Header("Frame 2")]
    public int Frame_2_Ball_1_Score;
    public int Frame_2_Ball_2_Score;
    public int Frame_2_Score_Total_Score;
    public bool Frame_2_Strike = false;
    public bool Frame_2_Spare = false;
    [Space(10)]

    [Header("Frame 3")]
    public int Frame_3_Ball_1_Score;
    public int Frame_3_Ball_2_Score;
    public int Frame_3_Score_Total_Score;
    public bool Frame_3_Strike = false;
    public bool Frame_3_Spare = false;
    [Space(10)]

    [Header("Frame 4")]
    public int Frame_4_Ball_1_Score;
    public int Frame_4_Ball_2_Score;
    public int Frame_4_Score_Total_Score;
    public bool Frame_4_Strike = false;
    public bool Frame_4_Spare = false;
    [Space(10)]

    [Header("Frame 5")]
    public int Frame_5_Ball_1_Score;
    public int Frame_5_Ball_2_Score;
    public int Frame_5_Score_Total_Score;
    public bool Frame_5_Strike = false;
    public bool Frame_5_Spare = false;
    [Space(10)]

    [Header("Frame 6")]
    public int Frame_6_Ball_1_Score;
    public int Frame_6_Ball_2_Score;
    public int Frame_6_Score_Total_Score;
    public bool Frame_6_Strike = false;
    public bool Frame_6_Spare = false;
    [Space(10)]

    [Header("Frame 7")]
    public int Frame_7_Ball_1_Score;
    public int Frame_7_Ball_2_Score;
    public int Frame_7_Score_Total_Score;
    public bool Frame_7_Strike = false;
    public bool Frame_7_Spare = false;
    [Space(10)]

    [Header("Frame 8")]
    public int Frame_8_Ball_1_Score;
    public int Frame_8_Ball_2_Score;
    public int Frame_8_Score_Total_Score;
    public bool Frame_8_Strike = false;
    public bool Frame_8_Spare = false;
    [Space(10)]

    [Header("Frame 9")]
    public int Frame_9_Ball_1_Score;
    public int Frame_9_Ball_2_Score;
    public int Frame_9_Score_Total_Score;
    public bool Frame_9_Strike = false;
    public bool Frame_9_Spare = false;
    [Space(10)]

    [Header("Frame 10")]
    public int Frame_10_Ball_1_Score;
    public int Frame_10_Ball_2_Score;
    public int Frame_10_Ball_3_Score;
    public int Frame_10_Score_Total_Score;
    public bool Frame_10_Strike1 = false;
    public bool Frame_10_Strike2 = false;
    public bool Frame_10_Strike3 = false;
    public bool Frame_10_Spare = false;
    [Space(10)]

    // Final Score of the match
    public int finalScore = 0;
    [Space(10)]

    // References to Game Objects in the scene involved in bowling game
    [Header("Bowling Game Objects")]
    public GameObject[] pins;
    public GameObject bowlingBall;
    public GameObject bowlingBallRespawn;
    [Space(10)]

    // Bowling Pin Game Objects
    public GameObject pin1;
    public GameObject pin2;
    public GameObject pin3;
    public GameObject pin4;
    public GameObject pin5;
    public GameObject pin6;
    public GameObject pin7;
    public GameObject pin8;
    public GameObject pin9;
    public GameObject pin10;
    [Space(10)]

    //Text mesh game objects that appear on the scoreboard
    public GameObject Frame1Ball1Text;
    public GameObject Frame1Ball2Text;
    public GameObject Frame1TotalText;

    public GameObject Frame2Ball1Text;
    public GameObject Frame2Ball2Text;
    public GameObject Frame2TotalText;

    public GameObject Frame3Ball1Text;
    public GameObject Frame3Ball2Text;
    public GameObject Frame3TotalText;

    public GameObject Frame4Ball1Text;
    public GameObject Frame4Ball2Text;
    public GameObject Frame4TotalText;

    public GameObject Frame5Ball1Text;
    public GameObject Frame5Ball2Text;
    public GameObject Frame5TotalText;

    public GameObject Frame6Ball1Text;
    public GameObject Frame6Ball2Text;
    public GameObject Frame6TotalText;

    public GameObject Frame7Ball1Text;
    public GameObject Frame7Ball2Text;
    public GameObject Frame7TotalText;

    public GameObject Frame8Ball1Text;
    public GameObject Frame8Ball2Text;
    public GameObject Frame8TotalText;

    public GameObject Frame9Ball1Text;
    public GameObject Frame9Ball2Text;
    public GameObject Frame9TotalText;

    public GameObject Frame10Ball1Text;
    public GameObject Frame10Ball2Text;
    public GameObject Frame10Ball3Text;
    public GameObject Frame10TotalText;

    public GameObject TotalScoreText;

    public GameObject[] FrameText;
    [Space(10)]

    // Debugging variables to check in the inspector while bowling
    [Header("Debug")]
    public bool playingBowling = false;
    public int pinsDown;
    public int ballNumber = 0;
    public bool colliding = false;
    [Space(10)]

    //Displays whether the pin is down or not
    public bool Pin1Down = false;
    public bool Pin2Down = false;
    public bool Pin3Down = false;
    public bool Pin4Down = false;
    public bool Pin5Down = false;
    public bool Pin6Down = false;
    public bool Pin7Down = false;
    public bool Pin8Down = false;
    public bool Pin9Down = false;
    public bool Pin10Down = false;
    [Space(10)]

    // Displays what frame the player is on
    private int frameNumber1 = 2;
    private int frameNumber2 = 4;
    private int frameNumber3 = 6;
    private int frameNumber4 = 8;
    private int frameNumber5 = 10;
    private int frameNumber6 = 12;
    private int frameNumber7 = 14;
    private int frameNumber8 = 16;
    private int frameNumber9 = 18;
    private int frameNumber10 = 20;
    private int frameNumber11 = 22;

    void Start()
    {
        // Find all objects tagged as pin or Bowling Text
        pins = GameObject.FindGameObjectsWithTag("Pin");
        FrameText = GameObject.FindGameObjectsWithTag("BowlingText");


        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        // Makes the pins and bowling ball active in the game again
        foreach (GameObject go in pins)
        {
            go.SetActive(false);
        }

        bowlingBall.SetActive(false);
    }


    // Checks the initial collision of bowling ball then assigns the proper bowling frame function 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BowlingBall")
        {
            if (colliding == false)
            {
                print("Collided");

                if (ballNumber == 1)
                {
                    StartCoroutine(Frame_1_Check_Score());
                }

                if (ballNumber == 2)
                {
                    StartCoroutine(Frame_2Ball_1());
                }

                if (ballNumber == 3)
                {
                    StartCoroutine(Frame_2_Check_Score());
                }

                if (ballNumber == 4)
                {
                    StartCoroutine(Frame_3Ball_1());
                }

                if (ballNumber == 5)
                {
                    StartCoroutine(Frame_3_Check_Score());
                }

                if (ballNumber == 6)
                {
                    StartCoroutine(Frame_4Ball_1());
                }

                if (ballNumber == 7)
                {
                    StartCoroutine(Frame_4_Check_Score());
                }

                if (ballNumber == 8)
                {
                    StartCoroutine(Frame_5Ball_1());
                }

                if (ballNumber == 9)
                {
                    StartCoroutine(Frame_5_Check_Score());
                }

                if (ballNumber == 10)
                {

                    StartCoroutine(Frame_6Ball_1());
                }

                if (ballNumber == 11)
                {
                    StartCoroutine(Frame_6_Check_Score());
                }

                if (ballNumber == 12)
                {
                    StartCoroutine(Frame_7Ball_1());
                }

                if (ballNumber == 13)
                {
                    StartCoroutine(Frame_7_Check_Score());
                }

                if (ballNumber == 14)
                {
                    StartCoroutine(Frame_8Ball_1());
                }

                if (ballNumber == 15)
                {
                    StartCoroutine(Frame_8_Check_Score());
                }

                if (ballNumber == 16)
                {
                    StartCoroutine(Frame_9Ball_1());
                }

                if (ballNumber == 17)
                {
                    StartCoroutine(Frame_9_Check_Score());
                }

                if (ballNumber == 18)
                {
                    StartCoroutine(Frame_10_Ball_Setup());
                }

                if (ballNumber == 19)
                {
                    StartCoroutine(Frame_10_Ball_1());
                }
                if (ballNumber == 20)
                {
                    StartCoroutine(Frame_10_Ball_2());
                }
                if (ballNumber == 21)
                {
                    StartCoroutine(Frame_10_Ball_3());
                }
            }
        }
    }
        
    // Sets values, text and positions for the start of the bowling game
    public void StartBowlingGame()
    {
        ballNumber = 1;
        pinsDown = 0;
        playingBowling = true;
        ResetBowlingScore();
        TextReset();
        Frame_1Ball_1();
    }

    // Resets Score all all frames to 0
    public void ResetBowlingScore()
    {
        Frame_1_Ball_1_Score = 0; Frame_1_Ball_2_Score = 0; Frame_1_Score_Total_Score = 0;
        Frame_2_Ball_1_Score = 0; Frame_2_Ball_2_Score = 0; Frame_2_Score_Total_Score = 0;
        Frame_3_Ball_1_Score = 0; Frame_3_Ball_2_Score = 0; Frame_3_Score_Total_Score = 0;
        Frame_4_Ball_1_Score = 0; Frame_4_Ball_2_Score = 0; Frame_4_Score_Total_Score = 0;
        Frame_5_Ball_1_Score = 0; Frame_5_Ball_2_Score = 0; Frame_5_Score_Total_Score = 0;
        Frame_6_Ball_1_Score = 0; Frame_6_Ball_2_Score = 0; Frame_6_Score_Total_Score = 0;
        Frame_7_Ball_1_Score = 0; Frame_7_Ball_2_Score = 0; Frame_7_Score_Total_Score = 0;
        Frame_8_Ball_1_Score = 0; Frame_8_Ball_2_Score = 0; Frame_8_Score_Total_Score = 0;
        Frame_9_Ball_1_Score = 0; Frame_9_Ball_2_Score = 0; Frame_9_Score_Total_Score = 0;
        Frame_10_Ball_1_Score = 0; Frame_10_Ball_2_Score = 0; Frame_10_Score_Total_Score = 0; Frame_10_Ball_3_Score = 0;
        finalScore = 0;

    // Resets all spares and strikes to false
        Frame_1_Spare = false; Frame_1_Strike = false;
        Frame_2_Spare = false; Frame_2_Strike = false;
        Frame_3_Spare = false; Frame_3_Strike = false;
        Frame_4_Spare = false; Frame_4_Strike = false;
        Frame_5_Spare = false; Frame_5_Strike = false;
        Frame_6_Spare = false; Frame_6_Strike = false;
        Frame_7_Spare = false; Frame_7_Strike = false;
        Frame_8_Spare = false; Frame_8_Strike = false;
        Frame_9_Spare = false; Frame_9_Strike = false;
        Frame_10_Spare = false; Frame_10_Strike1 = false; Frame_10_Strike2 = false; Frame_10_Strike3 = false;
    }

    // Resets pins position stop pins from being set to down
    public void pinReset()
    {
        foreach (GameObject go in pins)
        {
            go.SetActive(true);
            go.GetComponent<ResetPinPosition>().ResetPin();
            pinsDown = 0;
            Pin1Down = false; Pin2Down = false; Pin3Down = false; Pin4Down = false; Pin5Down = false; Pin6Down = false; Pin7Down = false; Pin8Down = false; Pin9Down = false; Pin10Down = false;
        }
    }

    // Keeps track of the players last three ball throws
    // this is due to the way bowling scores are calculated
    // when a spare or strike is scored it becomes a temporary score
    // it adds either next bowl if it was a spare or your next two bowls
    // if it was a strike
    public int UpdateScore(int firstBall, int secondBall, int nextFrameBallOne, int nextFrameBallTwo, int nextnextFrameBallOne, int currentFrame, bool strike, bool spare, bool nextStrike, bool nextnextStrike)
    {
        int tempScore = 0;

        if (strike == false)
        {


            if (spare == false)
            {
                tempScore = firstBall + secondBall;
            }
            else
            {
                tempScore = firstBall + secondBall + nextFrameBallOne;
            }
        }
        else
        {
            if (nextStrike == true)
            {
                if (nextnextStrike == true)
                {
                    tempScore = 30;
                }
                else
                {
                    tempScore = 20 + nextnextFrameBallOne;
                }
            }
            else
            {
                if (ballNumber == currentFrame)
                {
                    tempScore = 10 + nextFrameBallOne + nextFrameBallTwo;
                }
            }
        }

        return tempScore;
    }


    // A method to for the frames to use to update the text meshes with the current score
    public int TextUpdate(GameObject ball1Text, GameObject ball2Text, GameObject totalText, bool strike, bool spare, int ball1Score, int ball2Score, int totalScore)
    {
        int tempInt = 0;

        if(strike == true)
        {
            ball1Text.GetComponent<TextMesh>().text = " ";
            ball2Text.GetComponent<TextMesh>().text = "X";
            totalText.GetComponent<TextMesh>().text = totalScore.ToString();
        }
        else
        {
            if (spare == true)
            {
                ball1Text.GetComponent<TextMesh>().text = ball1Score.ToString();
                ball2Text.GetComponent<TextMesh>().text = "/";
                totalText.GetComponent<TextMesh>().text = totalScore.ToString();
            }
            else
            {
                ball1Text.GetComponent<TextMesh>().text = ball1Score.ToString();
                ball2Text.GetComponent<TextMesh>().text = ball2Score.ToString();
                totalText.GetComponent<TextMesh>().text = totalScore.ToString();
            }
        }

        return tempInt;
    }

    // A method for the 10th frame text to use to update its text, this is different because there are up to 3 bowls on the tenth frame
    public void Frame10Text()
    {
        if(Frame_10_Strike1 == true)
        {
            Frame10Ball1Text.GetComponent<TextMesh>().text = "X";
        }
        else
        {
            Frame10Ball1Text.GetComponent<TextMesh>().text = Frame_10_Ball_1_Score.ToString();
        }
        if (Frame_10_Strike2 == true)
        {
            Frame10Ball2Text.GetComponent<TextMesh>().text = "X";
        }
        if (Frame_10_Strike3 == true)
        {
            Frame10Ball3Text.GetComponent<TextMesh>().text = "X";
        }

        if (Frame_10_Spare == true)
        {
            Frame10Ball1Text.GetComponent<TextMesh>().text = Frame_10_Ball_1_Score.ToString();
            Frame10Ball2Text.GetComponent<TextMesh>().text = "/";
            Frame10Ball3Text.GetComponent<TextMesh>().text = Frame_10_Ball_3_Score.ToString();
        }
        else
        {
            if(Frame_10_Strike1 == false)
            {
                Frame10Ball1Text.GetComponent<TextMesh>().text = Frame_10_Ball_1_Score.ToString();
                Frame10Ball2Text.GetComponent<TextMesh>().text = Frame_10_Ball_2_Score.ToString();
            }
        }

        Frame10TotalText.GetComponent<TextMesh>().text = Frame_10_Score_Total_Score.ToString();
    }

    // Calculates the final score by adding all the frames total score variables
    public void TotalScoreTextUpdate()
    {
        finalScore = Frame_1_Score_Total_Score + Frame_2_Score_Total_Score + Frame_3_Score_Total_Score + Frame_4_Score_Total_Score + Frame_5_Score_Total_Score + 
                     Frame_6_Score_Total_Score + Frame_7_Score_Total_Score + Frame_8_Score_Total_Score + Frame_9_Score_Total_Score + Frame_10_Score_Total_Score;

        TotalScoreText.GetComponent<TextMesh>().text = finalScore.ToString();
    }

    // Resets the text to blank
    public void TextReset()
    {
        foreach (GameObject go in FrameText)
        {
            go.GetComponent<TextMesh>().text = " ";
        }
    }

    
    ////// Frame 1 //////  

    // Sets up the first bowling frame
    public void Frame_1Ball_1()
    {
        print("Frame1 Ball1");
        foreach (GameObject go in pins)
        {
            go.SetActive(true);
        }
        pinReset();
        bowlingBall.SetActive(true);
        TotalScoreTextUpdate();
    }

    public IEnumerator Frame_1_Check_Score()
    {
        yield return new WaitForSeconds(5);
        Frame_1_Ball_1_Score = pinsDown;

        // If it's a strike go to the next frame, frame score eqauls 10 + the next two bowls
        if (pinsDown == 10)
        {
            Frame_1_Strike = true;
            Frame_1_Score_Total_Score = 10;
            ballNumber = 2;
            StartCoroutine(Frame_2Ball_1());
            yield break;
        }
        // If it's not a strike go to ball 2 of the frame 
        // Calculates the scores and updates the text meshes
        else
        {
            Frame_1_Ball_1_Score = pinsDown;
            TextUpdate(Frame1Ball1Text, Frame1Ball2Text, Frame1TotalText, Frame_1_Strike, Frame_1_Spare, Frame_1_Ball_1_Score, Frame_1_Ball_2_Score, Frame_1_Score_Total_Score);
            TotalScoreTextUpdate();
            StartCoroutine(Frame_1Ball_2());
            yield break;
        }

    }

    // Turns off previously knocked pins and leaves remaining pins up
    public IEnumerator Frame_1Ball_2()
    {
        print("Frame1 Ball2");
        if (Pin1Down == true)
        { pin1.SetActive(false); }
        if (Pin2Down == true)
        { pin2.SetActive(false); }
        if (Pin3Down == true)
        { pin3.SetActive(false); }
        if (Pin4Down == true)
        { pin4.SetActive(false); }
        if (Pin5Down == true)
        { pin5.SetActive(false); }
        if (Pin6Down == true)
        { pin6.SetActive(false); }
        if (Pin7Down == true)
        { pin7.SetActive(false); }
        if (Pin8Down == true)
        { pin8.SetActive(false); }
        if (Pin9Down == true)
        { pin9.SetActive(false); }
        if (Pin10Down == true)
        { pin10.SetActive(false); }

        yield break;
    }


    ////// Frame 2 //////  

    public IEnumerator Frame_2Ball_1()
    {
        // Sets up the first bowling frame
        print("Frame2 Ball1");
        if (Frame_1_Strike == false)
        {
            yield return new WaitForSeconds(5);
        }

        // Checks whether the second ball of the previous frame was a spare
        if (pinsDown == 10)
        {
            if (Frame_1_Strike == false)
            {
                Frame_1_Spare = true;
            }
        }

        // Calculates the scores and updates the text meshes and resets pins
        Frame_1_Ball_2_Score = pinsDown - Frame_1_Ball_1_Score;
        Frame_1_Score_Total_Score = UpdateScore(Frame_1_Ball_1_Score, Frame_1_Ball_2_Score, Frame_2_Ball_1_Score, Frame_2_Ball_2_Score, Frame_3_Ball_1_Score, frameNumber2, Frame_1_Strike, Frame_1_Spare, Frame_2_Strike, Frame_3_Strike);

        TextUpdate(Frame1Ball1Text, Frame1Ball2Text, Frame1TotalText, Frame_1_Strike, Frame_1_Spare, Frame_1_Ball_1_Score, Frame_1_Ball_2_Score, Frame_1_Score_Total_Score);
        TotalScoreTextUpdate();

        pinReset();
        yield break;
    }

    public IEnumerator Frame_2_Check_Score()
    {
        yield return new WaitForSeconds(5);

        // If it's a strike go to the next frame, frame score eqauls 10 + the next two bowls
        if (pinsDown == 10)
        {
            Frame_2_Strike = true;
            Frame_2_Score_Total_Score = 10;
            Frame_2_Ball_1_Score = pinsDown;
            ballNumber = 4;
            StartCoroutine(Frame_3Ball_1());
            yield break;
        }
        // If it's not a strike go to ball 2 of the frame 
        // Calculates the ball 1 scores and updates the text meshes
        else
        {
            Frame_2_Ball_1_Score = pinsDown;
            
            TextUpdate(Frame2Ball1Text, Frame2Ball2Text, Frame2TotalText, Frame_2_Strike, Frame_2_Spare, Frame_2_Ball_1_Score, Frame_2_Ball_2_Score, Frame_2_Score_Total_Score);
            TotalScoreTextUpdate();
            StartCoroutine(Frame_2Ball_2());
            yield break;
        }

    }

    // Turns off previously knocked pins and leaves remaining pins up
    public IEnumerator Frame_2Ball_2()
    {
        print("Frame2 Ball2");

        if (Pin1Down == true)
        { pin1.SetActive(false); }
        if (Pin2Down == true)
        { pin2.SetActive(false); }
        if (Pin3Down == true)
        { pin3.SetActive(false); }
        if (Pin4Down == true)
        { pin4.SetActive(false); }
        if (Pin5Down == true)
        { pin5.SetActive(false); }
        if (Pin6Down == true)
        { pin6.SetActive(false); }
        if (Pin7Down == true)
        { pin7.SetActive(false); }
        if (Pin8Down == true)
        { pin8.SetActive(false); }
        if (Pin9Down == true)
        { pin9.SetActive(false); }
        if (Pin10Down == true)
        { pin10.SetActive(false); }

        yield break;
    }


    ////// Frame 3 //////  

    public IEnumerator Frame_3Ball_1()
    {
        // Sets up the first bowling frame
        print("Frame3 Ball1");
        if (Frame_2_Strike == false)
        {
            yield return new WaitForSeconds(5);
        }

        // Checks whether the second ball of the previous frame was a spare
        if (pinsDown == 10)
        {
            if (Frame_2_Strike == false)
            {
                Frame_2_Spare = true;
            }
        }

        // Calculates the scores and updates the text meshes and resets pins
        Frame_2_Ball_2_Score = pinsDown - Frame_2_Ball_1_Score;
        Frame_1_Score_Total_Score = UpdateScore(Frame_1_Ball_1_Score, Frame_1_Ball_2_Score, Frame_2_Ball_1_Score, Frame_2_Ball_2_Score, Frame_3_Ball_1_Score, frameNumber2, Frame_1_Strike, Frame_1_Spare, Frame_2_Strike, Frame_3_Strike);
        Frame_2_Score_Total_Score = UpdateScore(Frame_2_Ball_1_Score, Frame_2_Ball_2_Score, Frame_3_Ball_1_Score, Frame_3_Ball_2_Score, Frame_4_Ball_1_Score, frameNumber3, Frame_2_Strike, Frame_2_Spare, Frame_3_Strike, Frame_4_Strike);

        TextUpdate(Frame1Ball1Text, Frame1Ball2Text, Frame1TotalText, Frame_1_Strike, Frame_1_Spare, Frame_1_Ball_1_Score, Frame_1_Ball_2_Score, Frame_1_Score_Total_Score);
        TextUpdate(Frame2Ball1Text, Frame2Ball2Text, Frame2TotalText, Frame_2_Strike, Frame_2_Spare, Frame_2_Ball_1_Score, Frame_2_Ball_2_Score, Frame_2_Score_Total_Score);
        TotalScoreTextUpdate();

        pinReset();
        yield break;
    }

    public IEnumerator Frame_3_Check_Score()
    {
        yield return new WaitForSeconds(5);

        // If it's a strike go to the next frame, frame score eqauls 10 + the next two bowls
        if (pinsDown == 10)
        {
            print("3 STRIKE");
            Frame_3_Strike = true;
            Frame_3_Score_Total_Score = 10;
            Frame_3_Ball_1_Score = pinsDown;
            ballNumber = 6;
            StartCoroutine(Frame_4Ball_1());
            yield break;
        }
        // If it's not a strike go to ball 2 of the frame 
        // Calculates the ball 1 scores and updates the text meshes
        else
        {
            Frame_3_Ball_1_Score = pinsDown;
            TextUpdate(Frame3Ball1Text, Frame3Ball2Text, Frame3TotalText, Frame_3_Strike, Frame_3_Spare, Frame_3_Ball_1_Score, Frame_3_Ball_2_Score, Frame_3_Score_Total_Score);
            TotalScoreTextUpdate();
            StartCoroutine(Frame_3Ball_2());
            yield break;
        }

    }
    // Turns off previously knocked pins and leaves remaining pins up
    public IEnumerator Frame_3Ball_2()
    {
        print("Frame3 Ball2");

        if (Pin1Down == true)
        { pin1.SetActive(false); }
        if (Pin2Down == true)
        { pin2.SetActive(false); }
        if (Pin3Down == true)
        { pin3.SetActive(false); }
        if (Pin4Down == true)
        { pin4.SetActive(false); }
        if (Pin5Down == true)
        { pin5.SetActive(false); }
        if (Pin6Down == true)
        { pin6.SetActive(false); }
        if (Pin7Down == true)
        { pin7.SetActive(false); }
        if (Pin8Down == true)
        { pin8.SetActive(false); }
        if (Pin9Down == true)
        { pin9.SetActive(false); }
        if (Pin10Down == true)
        { pin10.SetActive(false); }

        yield break;
    }


    ////// Frame 4 //////  

    public IEnumerator Frame_4Ball_1()
    {
        // Sets up the first bowling frame
        print("Frame4 Ball1");
        if (Frame_3_Strike == false)
        {
            yield return new WaitForSeconds(5);
        }
        // Checks whether the second ball of the previous frame was a spare
        if (pinsDown == 10)
        {
            if (Frame_3_Strike == false)
            {
                Frame_3_Spare = true;
            }
        }
        // Calculates the scores and updates the text meshes and resets pins
        Frame_3_Ball_2_Score = pinsDown - Frame_3_Ball_1_Score;
        Frame_1_Score_Total_Score = UpdateScore(Frame_1_Ball_1_Score, Frame_1_Ball_2_Score, Frame_2_Ball_1_Score, Frame_2_Ball_2_Score, Frame_3_Ball_1_Score, frameNumber2, Frame_1_Strike, Frame_1_Spare, Frame_2_Strike, Frame_3_Strike);
        Frame_2_Score_Total_Score = UpdateScore(Frame_2_Ball_1_Score, Frame_2_Ball_2_Score, Frame_3_Ball_1_Score, Frame_3_Ball_2_Score, Frame_4_Ball_1_Score, frameNumber3, Frame_2_Strike, Frame_2_Spare, Frame_3_Strike, Frame_4_Strike);
        Frame_3_Score_Total_Score = UpdateScore(Frame_3_Ball_1_Score, Frame_3_Ball_2_Score, Frame_4_Ball_1_Score, Frame_4_Ball_2_Score, Frame_5_Ball_1_Score, frameNumber4, Frame_3_Strike, Frame_3_Spare, Frame_4_Strike, Frame_5_Strike);

        TextUpdate(Frame1Ball1Text, Frame1Ball2Text, Frame1TotalText, Frame_1_Strike, Frame_1_Spare, Frame_1_Ball_1_Score, Frame_1_Ball_2_Score, Frame_1_Score_Total_Score);
        TextUpdate(Frame2Ball1Text, Frame2Ball2Text, Frame2TotalText, Frame_2_Strike, Frame_2_Spare, Frame_2_Ball_1_Score, Frame_2_Ball_2_Score, Frame_2_Score_Total_Score);
        TextUpdate(Frame3Ball1Text, Frame3Ball2Text, Frame3TotalText, Frame_3_Strike, Frame_3_Spare, Frame_3_Ball_1_Score, Frame_3_Ball_2_Score, Frame_3_Score_Total_Score);
        TotalScoreTextUpdate();

        pinReset();
        yield break;
    }

    public IEnumerator Frame_4_Check_Score()
    {
        yield return new WaitForSeconds(5);

        // If it's a strike go to the next frame, frame score eqauls 10 + the next two bowls
        if (pinsDown == 10)
        {
            Frame_4_Strike = true;
            Frame_4_Score_Total_Score = 10;
            Frame_4_Ball_1_Score = pinsDown;
            ballNumber = 8;
            StartCoroutine(Frame_5Ball_1());
            yield break;
        }
        // If it's not a strike go to ball 2 of the frame 
        // Calculates the ball 1 scores and updates the text meshes
        else
        {
            Frame_4_Ball_1_Score = pinsDown;
            TextUpdate(Frame4Ball1Text, Frame4Ball2Text, Frame4TotalText, Frame_4_Strike, Frame_4_Spare, Frame_4_Ball_1_Score, Frame_4_Ball_2_Score, Frame_4_Score_Total_Score);
            TotalScoreTextUpdate();
            StartCoroutine(Frame_4Ball_2());
            yield break;
        }

    }
    // Turns off previously knocked pins and leaves remaining pins up
    public IEnumerator Frame_4Ball_2()
    {
        print("Frame4 Ball2");
        if (Pin1Down == true)
        { pin1.SetActive(false); }
        if (Pin2Down == true)
        { pin2.SetActive(false); }
        if (Pin3Down == true)
        { pin3.SetActive(false); }
        if (Pin4Down == true)
        { pin4.SetActive(false); }
        if (Pin5Down == true)
        { pin5.SetActive(false); }
        if (Pin6Down == true)
        { pin6.SetActive(false); }
        if (Pin7Down == true)
        { pin7.SetActive(false); }
        if (Pin8Down == true)
        { pin8.SetActive(false); }
        if (Pin9Down == true)
        { pin9.SetActive(false); }
        if (Pin10Down == true)
        { pin10.SetActive(false); }

        yield break;
    }


    ////// Frame 5 //////  

    public IEnumerator Frame_5Ball_1()
    {
        // Sets up the first bowling frame
        print("Frame5 Ball1");
        if (Frame_4_Strike == false)
        {
            yield return new WaitForSeconds(5);
        }
        // Checks whether the second ball of the previous frame was a spare
        if (pinsDown == 10)
        {
            if (Frame_4_Strike == false)
            {
                Frame_4_Spare = true;
            }
        }

        // Calculates the scores and updates the text meshes and resets pins
        Frame_4_Ball_2_Score = pinsDown - Frame_4_Ball_1_Score;
        Frame_2_Score_Total_Score = UpdateScore(Frame_2_Ball_1_Score, Frame_2_Ball_2_Score, Frame_3_Ball_1_Score, Frame_3_Ball_2_Score, Frame_4_Ball_1_Score, frameNumber3, Frame_2_Strike, Frame_2_Spare, Frame_3_Strike, Frame_4_Strike);
        Frame_3_Score_Total_Score = UpdateScore(Frame_3_Ball_1_Score, Frame_3_Ball_2_Score, Frame_4_Ball_1_Score, Frame_4_Ball_2_Score, Frame_5_Ball_1_Score, frameNumber4, Frame_3_Strike, Frame_3_Spare, Frame_4_Strike, Frame_5_Strike);
        Frame_4_Score_Total_Score = UpdateScore(Frame_4_Ball_1_Score, Frame_4_Ball_2_Score, Frame_5_Ball_1_Score, Frame_5_Ball_2_Score, Frame_6_Ball_1_Score, frameNumber5, Frame_4_Strike, Frame_4_Spare, Frame_5_Strike, Frame_6_Strike);

        TextUpdate(Frame2Ball1Text, Frame2Ball2Text, Frame2TotalText, Frame_2_Strike, Frame_2_Spare, Frame_2_Ball_1_Score, Frame_2_Ball_2_Score, Frame_2_Score_Total_Score);
        TextUpdate(Frame3Ball1Text, Frame3Ball2Text, Frame3TotalText, Frame_3_Strike, Frame_3_Spare, Frame_3_Ball_1_Score, Frame_3_Ball_2_Score, Frame_3_Score_Total_Score);
        TextUpdate(Frame4Ball1Text, Frame4Ball2Text, Frame4TotalText, Frame_4_Strike, Frame_4_Spare, Frame_4_Ball_1_Score, Frame_4_Ball_2_Score, Frame_4_Score_Total_Score);
        TotalScoreTextUpdate();

        pinReset();
        yield break;
    }

    public IEnumerator Frame_5_Check_Score()
    {
        yield return new WaitForSeconds(5);

        // If it's a strike go to the next frame, frame score eqauls 10 + the next two bowls
        if (pinsDown == 10)
        {
            Frame_5_Strike = true;
            Frame_5_Score_Total_Score = 10;
            Frame_5_Ball_1_Score = pinsDown;
            ballNumber = 10;
            StartCoroutine(Frame_6Ball_1());
            yield break;
        }
        // If it's not a strike go to ball 2 of the frame 
        // Calculates the ball 1 scores and updates the text meshes
        else
        {
            Frame_5_Ball_1_Score = pinsDown;
            TextUpdate(Frame5Ball1Text, Frame5Ball2Text, Frame5TotalText, Frame_5_Strike, Frame_5_Spare, Frame_5_Ball_1_Score, Frame_5_Ball_2_Score, Frame_5_Score_Total_Score);
            TotalScoreTextUpdate();
            StartCoroutine(Frame_5Ball_2());
            yield break;
        }

    }
    // Turns off previously knocked pins and leaves remaining pins up
    public IEnumerator Frame_5Ball_2()
    {
        print("Frame5 Ball2");
        if (Pin1Down == true)
        { pin1.SetActive(false); }
        if (Pin2Down == true)
        { pin2.SetActive(false); }
        if (Pin3Down == true)
        { pin3.SetActive(false); }
        if (Pin4Down == true)
        { pin4.SetActive(false); }
        if (Pin5Down == true)
        { pin5.SetActive(false); }
        if (Pin6Down == true)
        { pin6.SetActive(false); }
        if (Pin7Down == true)
        { pin7.SetActive(false); }
        if (Pin8Down == true)
        { pin8.SetActive(false); }
        if (Pin9Down == true)
        { pin9.SetActive(false); }
        if (Pin10Down == true)
        { pin10.SetActive(false); }

        yield break;
    }

    
    ////// Frame 6 //////  

    public IEnumerator Frame_6Ball_1()
    {
        // Sets up the first bowling frame
        print("Frame6 Ball1");
        if (Frame_5_Strike == false)
        {
            yield return new WaitForSeconds(5);
        }

        // Checks whether the second ball of the previous frame was a spare
        if (pinsDown == 10)
        {
            if (Frame_5_Strike == false)
            {
                Frame_5_Spare = true;
            }
        }

        // Calculates the scores and updates the text meshes and resets pins
        Frame_5_Ball_2_Score = pinsDown - Frame_5_Ball_1_Score;
        Frame_3_Score_Total_Score = UpdateScore(Frame_3_Ball_1_Score, Frame_3_Ball_2_Score, Frame_4_Ball_1_Score, Frame_4_Ball_2_Score, Frame_5_Ball_1_Score, frameNumber4, Frame_3_Strike, Frame_3_Spare, Frame_4_Strike, Frame_5_Strike);
        Frame_4_Score_Total_Score = UpdateScore(Frame_4_Ball_1_Score, Frame_4_Ball_2_Score, Frame_5_Ball_1_Score, Frame_5_Ball_2_Score, Frame_6_Ball_1_Score, frameNumber5, Frame_4_Strike, Frame_4_Spare, Frame_5_Strike, Frame_6_Strike);
        Frame_5_Score_Total_Score = UpdateScore(Frame_5_Ball_1_Score, Frame_5_Ball_2_Score, Frame_6_Ball_1_Score, Frame_6_Ball_2_Score, Frame_7_Ball_1_Score, frameNumber6, Frame_5_Strike, Frame_5_Spare, Frame_6_Strike, Frame_7_Strike);

        TextUpdate(Frame3Ball1Text, Frame3Ball2Text, Frame3TotalText, Frame_3_Strike, Frame_3_Spare, Frame_3_Ball_1_Score, Frame_3_Ball_2_Score, Frame_3_Score_Total_Score);
        TextUpdate(Frame4Ball1Text, Frame4Ball2Text, Frame4TotalText, Frame_4_Strike, Frame_4_Spare, Frame_4_Ball_1_Score, Frame_4_Ball_2_Score, Frame_4_Score_Total_Score);
        TextUpdate(Frame5Ball1Text, Frame5Ball2Text, Frame5TotalText, Frame_5_Strike, Frame_5_Spare, Frame_5_Ball_1_Score, Frame_5_Ball_2_Score, Frame_5_Score_Total_Score);
        TotalScoreTextUpdate();

        pinReset();
        yield break;
    }

    public IEnumerator Frame_6_Check_Score()
    {
        yield return new WaitForSeconds(5);

        // If it's a strike go to the next frame, frame score eqauls 10 + the next two bowls
        if (pinsDown == 10)
        {
            Frame_6_Strike = true;
            Frame_6_Score_Total_Score = 10;
            Frame_6_Ball_1_Score = pinsDown;
            ballNumber = 12;
            StartCoroutine(Frame_7Ball_1());
            yield break;
        }
        // If it's not a strike go to ball 2 of the frame 
        // Calculates the ball 1 scores and updates the text meshes
        else
        {
            Frame_6_Ball_1_Score = pinsDown;
            TextUpdate(Frame6Ball1Text, Frame6Ball2Text, Frame6TotalText, Frame_6_Strike, Frame_6_Spare, Frame_6_Ball_1_Score, Frame_6_Ball_2_Score, Frame_6_Score_Total_Score);
            TotalScoreTextUpdate();
            StartCoroutine(Frame_6Ball_2());
            yield break;
        }

    }
    // Turns off previously knocked pins and leaves remaining pins up
    public IEnumerator Frame_6Ball_2()
    {
        print("Frame6 Ball2");
        if (Pin1Down == true)
        { pin1.SetActive(false); }
        if (Pin2Down == true)
        { pin2.SetActive(false); }
        if (Pin3Down == true)
        { pin3.SetActive(false); }
        if (Pin4Down == true)
        { pin4.SetActive(false); }
        if (Pin5Down == true)
        { pin5.SetActive(false); }
        if (Pin6Down == true)
        { pin6.SetActive(false); }
        if (Pin7Down == true)
        { pin7.SetActive(false); }
        if (Pin8Down == true)
        { pin8.SetActive(false); }
        if (Pin9Down == true)
        { pin9.SetActive(false); }
        if (Pin10Down == true)
        { pin10.SetActive(false); }

        yield break;
    }


    ////// Frame 7 //////  

    public IEnumerator Frame_7Ball_1()
    {
        // Sets up the first bowling frame
        print("Frame7 Ball1");
        if (Frame_6_Strike == false)
        {
            yield return new WaitForSeconds(5);
        }

        // Checks whether the second ball of the previous frame was a spare
        if (pinsDown == 10)
        {
            if (Frame_6_Strike == false)
            {
                Frame_6_Spare = true;
            }
        }

        // Calculates the scores and updates the text meshes and resets pins
        Frame_6_Ball_2_Score = pinsDown - Frame_6_Ball_1_Score;
        Frame_4_Score_Total_Score = UpdateScore(Frame_4_Ball_1_Score, Frame_4_Ball_2_Score, Frame_5_Ball_1_Score, Frame_5_Ball_2_Score, Frame_6_Ball_1_Score, frameNumber5, Frame_4_Strike, Frame_4_Spare, Frame_5_Strike, Frame_6_Strike);
        Frame_5_Score_Total_Score = UpdateScore(Frame_5_Ball_1_Score, Frame_5_Ball_2_Score, Frame_6_Ball_1_Score, Frame_6_Ball_2_Score, Frame_7_Ball_1_Score, frameNumber6, Frame_5_Strike, Frame_5_Spare, Frame_6_Strike, Frame_7_Strike);
        Frame_6_Score_Total_Score = UpdateScore(Frame_6_Ball_1_Score, Frame_6_Ball_2_Score, Frame_7_Ball_1_Score, Frame_7_Ball_2_Score, Frame_8_Ball_1_Score, frameNumber7, Frame_6_Strike, Frame_6_Spare, Frame_7_Strike, Frame_8_Strike);

        TextUpdate(Frame4Ball1Text, Frame4Ball2Text, Frame4TotalText, Frame_4_Strike, Frame_4_Spare, Frame_4_Ball_1_Score, Frame_4_Ball_2_Score, Frame_4_Score_Total_Score);
        TextUpdate(Frame5Ball1Text, Frame5Ball2Text, Frame5TotalText, Frame_5_Strike, Frame_5_Spare, Frame_5_Ball_1_Score, Frame_5_Ball_2_Score, Frame_5_Score_Total_Score);
        TextUpdate(Frame6Ball1Text, Frame6Ball2Text, Frame6TotalText, Frame_6_Strike, Frame_6_Spare, Frame_6_Ball_1_Score, Frame_6_Ball_2_Score, Frame_6_Score_Total_Score);
        TotalScoreTextUpdate();

        pinReset();
        yield break;
    }

    public IEnumerator Frame_7_Check_Score()
    {
        yield return new WaitForSeconds(5);

        // If it's a strike go to the next frame, frame score eqauls 10 + the next two bowls
        if (pinsDown == 10)
        {
            Frame_7_Strike = true;
            Frame_7_Score_Total_Score = 10;
            Frame_7_Ball_1_Score = pinsDown;
            ballNumber = 14;
            StartCoroutine(Frame_8Ball_1());
            yield break;
        }
        // If it's not a strike go to ball 2 of the frame 
        // Calculates the ball 1 scores and updates the text meshes
        else
        {
            Frame_7_Ball_1_Score = pinsDown;
            TextUpdate(Frame7Ball1Text, Frame7Ball2Text, Frame7TotalText, Frame_7_Strike, Frame_7_Spare, Frame_7_Ball_1_Score, Frame_7_Ball_2_Score, Frame_7_Score_Total_Score);
            TotalScoreTextUpdate();
            StartCoroutine(Frame_7Ball_2());
            yield break;
        }

    }
    // Turns off previously knocked pins and leaves remaining pins up
    public IEnumerator Frame_7Ball_2()
    {
        print("Frame7 Ball2");
        if (Pin1Down == true)
        { pin1.SetActive(false); }
        if (Pin2Down == true)
        { pin2.SetActive(false); }
        if (Pin3Down == true)
        { pin3.SetActive(false); }
        if (Pin4Down == true)
        { pin4.SetActive(false); }
        if (Pin5Down == true)
        { pin5.SetActive(false); }
        if (Pin6Down == true)
        { pin6.SetActive(false); }
        if (Pin7Down == true)
        { pin7.SetActive(false); }
        if (Pin8Down == true)
        { pin8.SetActive(false); }
        if (Pin9Down == true)
        { pin9.SetActive(false); }
        if (Pin10Down == true)
        { pin10.SetActive(false); }

        yield break;
    }


    ////// Frame 8 //////  

    public IEnumerator Frame_8Ball_1()
    {
        // Sets up the first bowling frame
        print("Frame8 Ball1");
        if (Frame_7_Strike == false)
        {
            yield return new WaitForSeconds(5);
        }

        // Checks whether the second ball of the previous frame was a spare
        if (pinsDown == 10)
        {
            if (Frame_7_Strike == false)
            {
                Frame_7_Spare = true;
            }
        }

        // Calculates the scores and updates the text meshes and resets pins
        Frame_7_Ball_2_Score = pinsDown - Frame_7_Ball_1_Score;
        Frame_5_Score_Total_Score = UpdateScore(Frame_5_Ball_1_Score, Frame_5_Ball_2_Score, Frame_6_Ball_1_Score, Frame_6_Ball_2_Score, Frame_7_Ball_1_Score, frameNumber6, Frame_5_Strike, Frame_5_Spare, Frame_6_Strike, Frame_7_Strike);
        Frame_6_Score_Total_Score = UpdateScore(Frame_6_Ball_1_Score, Frame_6_Ball_2_Score, Frame_7_Ball_1_Score, Frame_7_Ball_2_Score, Frame_8_Ball_1_Score, frameNumber7, Frame_6_Strike, Frame_6_Spare, Frame_7_Strike, Frame_8_Strike);
        Frame_7_Score_Total_Score = UpdateScore(Frame_7_Ball_1_Score, Frame_7_Ball_2_Score, Frame_8_Ball_1_Score, Frame_8_Ball_2_Score, Frame_9_Ball_1_Score, frameNumber8, Frame_7_Strike, Frame_7_Spare, Frame_8_Strike, Frame_9_Strike);

        TextUpdate(Frame5Ball1Text, Frame5Ball2Text, Frame5TotalText, Frame_5_Strike, Frame_5_Spare, Frame_5_Ball_1_Score, Frame_5_Ball_2_Score, Frame_5_Score_Total_Score);
        TextUpdate(Frame6Ball1Text, Frame6Ball2Text, Frame6TotalText, Frame_6_Strike, Frame_6_Spare, Frame_6_Ball_1_Score, Frame_6_Ball_2_Score, Frame_6_Score_Total_Score);
        TextUpdate(Frame7Ball1Text, Frame7Ball2Text, Frame7TotalText, Frame_7_Strike, Frame_7_Spare, Frame_7_Ball_1_Score, Frame_7_Ball_2_Score, Frame_7_Score_Total_Score);
        TotalScoreTextUpdate();

        pinReset();
        yield break;
    }

    public IEnumerator Frame_8_Check_Score()
    {
        yield return new WaitForSeconds(5);

        // If it's a strike go to the next frame, frame score eqauls 10 + the next two bowls
        if (pinsDown == 10)
        {
            Frame_8_Strike = true;
            Frame_8_Score_Total_Score = 10;
            Frame_8_Ball_1_Score = pinsDown;
            ballNumber = 16;
            StartCoroutine(Frame_9Ball_1());
            yield break;
        }
        // If it's not a strike go to ball 2 of the frame 
        // Calculates the ball 1 scores and updates the text meshes
        else
        {
            Frame_8_Ball_1_Score = pinsDown;
            TextUpdate(Frame8Ball1Text, Frame8Ball2Text, Frame8TotalText, Frame_8_Strike, Frame_8_Spare, Frame_8_Ball_1_Score, Frame_8_Ball_2_Score, Frame_8_Score_Total_Score);
            TotalScoreTextUpdate();
            StartCoroutine(Frame_8Ball_2());
            yield break;
        }

    }
    // Turns off previously knocked pins and leaves remaining pins up
    public IEnumerator Frame_8Ball_2()
    {
        print("Frame8 Ball2");
        if (Pin1Down == true)
        { pin1.SetActive(false); }
        if (Pin2Down == true)
        { pin2.SetActive(false); }
        if (Pin3Down == true)
        { pin3.SetActive(false); }
        if (Pin4Down == true)
        { pin4.SetActive(false); }
        if (Pin5Down == true)
        { pin5.SetActive(false); }
        if (Pin6Down == true)
        { pin6.SetActive(false); }
        if (Pin7Down == true)
        { pin7.SetActive(false); }
        if (Pin8Down == true)
        { pin8.SetActive(false); }
        if (Pin9Down == true)
        { pin9.SetActive(false); }
        if (Pin10Down == true)
        { pin10.SetActive(false); }

        yield break;
    }


    ////// Frame 9 //////  

    public IEnumerator Frame_9Ball_1()
    {
        // Sets up the first bowling frame
        print("Frame9 Ball1");
        if (Frame_8_Strike == false)
        {
            yield return new WaitForSeconds(5);
        }

        // Checks whether the second ball of the previous frame was a spare
        if (pinsDown == 10)
        {
            if (Frame_8_Strike == false)
            {
                Frame_8_Spare = true;
            }
        }

        // Calculates the scores and updates the text meshes and resets pins
        Frame_8_Ball_2_Score = pinsDown - Frame_8_Ball_1_Score;
        Frame_6_Score_Total_Score = UpdateScore(Frame_6_Ball_1_Score, Frame_6_Ball_2_Score, Frame_7_Ball_1_Score, Frame_7_Ball_2_Score, Frame_8_Ball_1_Score, frameNumber7, Frame_6_Strike, Frame_6_Spare, Frame_7_Strike, Frame_8_Strike);
        Frame_7_Score_Total_Score = UpdateScore(Frame_7_Ball_1_Score, Frame_7_Ball_2_Score, Frame_8_Ball_1_Score, Frame_8_Ball_2_Score, Frame_9_Ball_1_Score, frameNumber8, Frame_7_Strike, Frame_7_Spare, Frame_8_Strike, Frame_9_Strike);
        Frame_8_Score_Total_Score = UpdateScore(Frame_8_Ball_1_Score, Frame_8_Ball_2_Score, Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_10_Ball_1_Score, frameNumber9, Frame_8_Strike, Frame_8_Spare, Frame_9_Strike, Frame_10_Strike1);

        TextUpdate(Frame6Ball1Text, Frame6Ball2Text, Frame6TotalText, Frame_6_Strike, Frame_6_Spare, Frame_6_Ball_1_Score, Frame_6_Ball_2_Score, Frame_6_Score_Total_Score);
        TextUpdate(Frame7Ball1Text, Frame7Ball2Text, Frame7TotalText, Frame_7_Strike, Frame_7_Spare, Frame_7_Ball_1_Score, Frame_7_Ball_2_Score, Frame_7_Score_Total_Score);
        TextUpdate(Frame8Ball1Text, Frame8Ball2Text, Frame8TotalText, Frame_8_Strike, Frame_8_Spare, Frame_8_Ball_1_Score, Frame_8_Ball_2_Score, Frame_8_Score_Total_Score);
        TotalScoreTextUpdate();

        pinReset();
        yield break;
    }

    public IEnumerator Frame_9_Check_Score()
    {
        yield return new WaitForSeconds(5);

        // If it's a strike go to the next frame, frame score eqauls 10 + the next two bowls
        if (pinsDown == 10)
        {
            Frame_9_Strike = true;
            Frame_9_Score_Total_Score = 10;
            Frame_9_Ball_1_Score = pinsDown;
            ballNumber = 18;
            StartCoroutine(Frame_10_Ball_Setup());
            yield break;
        }
        // If it's not a strike go to ball 2 of the frame 
        // Calculates the ball 1 scores and updates the text meshes
        else
        {
            Frame_9_Ball_1_Score = pinsDown;
            TextUpdate(Frame9Ball1Text, Frame9Ball2Text, Frame9TotalText, Frame_9_Strike, Frame_9_Spare, Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_9_Score_Total_Score);
            TotalScoreTextUpdate();
            StartCoroutine(Frame_9Ball_2());
            yield break;
        }

    }
    // Turns off previously knocked pins and leaves remaining pins up
    public IEnumerator Frame_9Ball_2()
    {
        print("Frame9 Ball2");
        if (Pin1Down == true)
        { pin1.SetActive(false); }
        if (Pin2Down == true)
        { pin2.SetActive(false); }
        if (Pin3Down == true)
        { pin3.SetActive(false); }
        if (Pin4Down == true)
        { pin4.SetActive(false); }
        if (Pin5Down == true)
        { pin5.SetActive(false); }
        if (Pin6Down == true)
        { pin6.SetActive(false); }
        if (Pin7Down == true)
        { pin7.SetActive(false); }
        if (Pin8Down == true)
        { pin8.SetActive(false); }
        if (Pin9Down == true)
        { pin9.SetActive(false); }
        if (Pin10Down == true)
        { pin10.SetActive(false); }

        yield break;
    }


    ////// Frame 10 //////  

    public IEnumerator Frame_10_Ball_Setup()
    {
        // Sets up the first bowling frame
        print("Frame10 Ball1");
        if (Frame_9_Strike == false)
        {
            yield return new WaitForSeconds(5);
        }

        // Checks whether the second ball of the previous frame was a spare
        if (pinsDown == 10)
        {
            if (Frame_9_Strike == false)
            {
                Frame_9_Spare = true;
            }
        }

        // Calculates the scores and updates the text meshes and resets pins
        Frame_9_Ball_2_Score = pinsDown - Frame_9_Ball_1_Score;
        Frame_7_Score_Total_Score = UpdateScore(Frame_7_Ball_1_Score, Frame_7_Ball_2_Score, Frame_8_Ball_1_Score, Frame_8_Ball_2_Score, Frame_9_Ball_1_Score, frameNumber8, Frame_7_Strike, Frame_7_Spare, Frame_8_Strike, Frame_9_Strike);
        Frame_8_Score_Total_Score = UpdateScore(Frame_8_Ball_1_Score, Frame_8_Ball_2_Score, Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_10_Ball_1_Score, frameNumber9, Frame_8_Strike, Frame_8_Spare, Frame_9_Strike, Frame_10_Strike1);
        Frame_9_Score_Total_Score = UpdateScore(Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_10_Ball_1_Score, Frame_10_Ball_2_Score, Frame_10_Ball_3_Score, frameNumber10, Frame_10_Strike1, Frame_9_Spare, Frame_10_Strike1, Frame_10_Strike2);

        TextUpdate(Frame7Ball1Text, Frame7Ball2Text, Frame7TotalText, Frame_7_Strike, Frame_7_Spare, Frame_7_Ball_1_Score, Frame_7_Ball_2_Score, Frame_7_Score_Total_Score);
        TextUpdate(Frame8Ball1Text, Frame8Ball2Text, Frame8TotalText, Frame_8_Strike, Frame_8_Spare, Frame_8_Ball_1_Score, Frame_8_Ball_2_Score, Frame_8_Score_Total_Score);
        TextUpdate(Frame9Ball1Text, Frame9Ball2Text, Frame9TotalText, Frame_9_Strike, Frame_9_Spare, Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_9_Score_Total_Score);
        TotalScoreTextUpdate();

        pinReset();
        yield break;
    }

    public IEnumerator Frame_10_Ball_1()
    {
        print("Frame10 Ball1");
        yield return new WaitForSeconds(5);

        // Calculates the scores and updates the text meshes
        Frame_10_Ball_1_Score = pinsDown;
        Frame_8_Score_Total_Score = UpdateScore(Frame_8_Ball_1_Score, Frame_8_Ball_2_Score, Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_10_Ball_1_Score, frameNumber9, Frame_8_Strike, Frame_8_Spare, Frame_9_Strike, Frame_10_Strike1);
        Frame_9_Score_Total_Score = UpdateScore(Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_10_Ball_1_Score, Frame_10_Ball_2_Score, Frame_10_Ball_3_Score, frameNumber10, Frame_10_Strike1, Frame_9_Spare, Frame_10_Strike1, Frame_10_Strike2);

        TextUpdate(Frame8Ball1Text, Frame8Ball2Text, Frame8TotalText, Frame_8_Strike, Frame_8_Spare, Frame_8_Ball_1_Score, Frame_8_Ball_2_Score, Frame_8_Score_Total_Score);
        TextUpdate(Frame9Ball1Text, Frame9Ball2Text, Frame9TotalText, Frame_9_Strike, Frame_9_Spare, Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_9_Score_Total_Score);
        TotalScoreTextUpdate();

        // If it's a strike go to the next frame, frame 1 score eqauls 10 + the next two bowls
        if (pinsDown == 10)
        {
            Frame_10_Strike1 = true;
            Frame_10_Score_Total_Score = 10;
            Frame10Text();
            pinReset();
            yield break;
        }

        // Turns off previously knocked pins and leaves remaining pins up
        else
        {
            Frame_10_Strike1 = false;

            if (Pin1Down == true)
            { pin1.SetActive(false); }
            if (Pin2Down == true)
            { pin2.SetActive(false); }
            if (Pin3Down == true)
            { pin3.SetActive(false); }
            if (Pin4Down == true)
            { pin4.SetActive(false); }
            if (Pin5Down == true)
            { pin5.SetActive(false); }
            if (Pin6Down == true)
            { pin6.SetActive(false); }
            if (Pin7Down == true)
            { pin7.SetActive(false); }
            if (Pin8Down == true)
            { pin8.SetActive(false); }
            if (Pin9Down == true)
            { pin9.SetActive(false); }
            if (Pin10Down == true)
            { pin10.SetActive(false); }
            yield break;
        }

    }

    public IEnumerator Frame_10_Ball_2()
    {
        print("Frame10 Ball2");
        yield return new WaitForSeconds(5);

        // Calculates the scores and updates the text meshes and resets pins
        Frame_9_Score_Total_Score = UpdateScore(Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_10_Ball_1_Score, Frame_10_Ball_2_Score, Frame_10_Ball_3_Score, frameNumber10, Frame_10_Strike1, Frame_9_Spare, Frame_10_Strike1, Frame_10_Strike2);
        TextUpdate(Frame9Ball1Text, Frame9Ball2Text, Frame9TotalText, Frame_9_Strike, Frame_9_Spare, Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_9_Score_Total_Score);
        TotalScoreTextUpdate();

        // If ball 2 is a strike go to the next ball 
        if (pinsDown == 10)
        {
            // If it's a strike go to the next ball
            if (Frame_10_Strike1 == true)
            {
                Frame_10_Strike2 = true;
                Frame_10_Score_Total_Score = 20;
                Frame_10_Ball_2_Score = pinsDown;
                Frame_9_Score_Total_Score = UpdateScore(Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_10_Ball_1_Score, Frame_10_Ball_2_Score, Frame_10_Ball_3_Score, frameNumber10, Frame_10_Strike1, Frame_9_Spare, Frame_10_Strike1, Frame_10_Strike2);
                TextUpdate(Frame9Ball1Text, Frame9Ball2Text, Frame9TotalText, Frame_9_Strike, Frame_9_Spare, Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_9_Score_Total_Score);
                TotalScoreTextUpdate();
                Frame10Text();
                pinReset();
                yield break;
            }
            // If it's not a strike go to ball 2 of the frame 
            // Calculates the ball 1 and 2 scores and updates the text meshes
            else
            {
                Frame_10_Strike2 = false;
                Frame_10_Spare = true;
                Frame_10_Ball_2_Score = pinsDown - Frame_10_Ball_1_Score;
                Frame_9_Score_Total_Score = UpdateScore(Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_10_Ball_1_Score, Frame_10_Ball_2_Score, Frame_10_Ball_3_Score, frameNumber10, Frame_10_Strike1, Frame_9_Spare, Frame_10_Strike1, Frame_10_Strike2);
                TextUpdate(Frame9Ball1Text, Frame9Ball2Text, Frame9TotalText, Frame_9_Strike, Frame_9_Spare, Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_9_Score_Total_Score);
                TotalScoreTextUpdate();
                Frame10Text();
                pinReset();
                yield break;
            }

        }
        // If it's not a strike go to ball 2 of the frame 
        // Calculates the ball 1 and 2 scores and updates the text meshes
        else
        {
            Frame_10_Score_Total_Score = Frame_10_Ball_1_Score + Frame_10_Ball_2_Score;
            Frame_10_Strike2 = false;
            Frame_10_Spare = false;
            Frame_9_Score_Total_Score = UpdateScore(Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_10_Ball_1_Score, Frame_10_Ball_2_Score, Frame_10_Ball_3_Score, frameNumber10, Frame_10_Strike1, Frame_9_Spare, Frame_10_Strike1, Frame_10_Strike2);
            TextUpdate(Frame9Ball1Text, Frame9Ball2Text, Frame9TotalText, Frame_9_Strike, Frame_9_Spare, Frame_9_Ball_1_Score, Frame_9_Ball_2_Score, Frame_9_Score_Total_Score);
            Frame10Text();
            TotalScoreTextUpdate();
            foreach (GameObject go in pins)
            {
                go.SetActive(false);
            }

            bowlingBall.SetActive(false);
            playingBowling = false;
        }

    }

    public IEnumerator Frame_10_Ball_3()
    {
        print("Frame10 Ball3");
        yield return new WaitForSeconds(5);

        if (pinsDown == 10)
        {
            Frame_10_Strike3 = true;
        }

        // Calculates final scores and updates text meshes
        Frame_10_Ball_3_Score = pinsDown;
        Frame_10_Score_Total_Score = Frame_10_Ball_1_Score + Frame_10_Ball_2_Score + Frame_10_Ball_3_Score;
        Frame10Text();
        TotalScoreTextUpdate();

        // Turns pins off 
        foreach (GameObject go in pins)
        {
            go.SetActive(false);
        }

        // Resets and turns off bowling ball and stops the match 
        bowlingBall.transform.position = bowlingBallRespawn.transform.position;
        bowlingBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        bowlingBall.SetActive(false);
        playingBowling = false;
    }


}
