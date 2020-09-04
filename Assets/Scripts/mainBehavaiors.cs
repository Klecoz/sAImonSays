using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainBehavaiors : MonoBehaviour
{
    //buttons for switching
    public GameObject yButton;
    public GameObject bButton;
    public GameObject aButton;
    public GameObject xButton;
    //leftrightupdown buttons for switching
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject upButton;
    public GameObject downButton;
    //button logic cases UI
    public GameObject caseAButton;
    public GameObject caseBButton;
    public GameObject caseXButton;
    public GameObject caseYButton;
    //color logic cases UI
    public GameObject colorRed;
    public GameObject colorBlue;
    public GameObject colorGreen;
    public GameObject colorYellow;
    //updown logic cases UI
    public GameObject upUI;
    public GameObject downUI;
    public GameObject leftUI;
    public GameObject rightUI;

    //True Logical Button Switching
    public int trueA = 1;
    public int trueB = 2;
    public int trueX = 3;
    public int trueY = 4;

    //True Logical DPAD Switching
    public int trueUp = 5;
    public int trueDown = 6;
    public int trueLeft = 7;
    public int trueRight = 8;

    //Variable to hold temp true number

    public int tempTrueNum;


    //Audio SFX
    public AudioClip goodSound;
    public AudioClip badSound;
    AudioSource audiosource;

    //Power Bars
    public GameObject powerBars;


    //Counters

    private int points;
    private int gameCounter;

    public bool pressOnlyOnce = false;
    public bool gameContinue = true;

    private int randomNumber;
    private int randomNumberSwitch;

    //Original Positons of Buttons
    private Vector2 originalpositonA;
    private Vector2 originalpositonB;
    private Vector2 originalpositonX;
    private Vector2 originalpositonY;

    //Original Positions of DPAD
    private Vector2 originalpositonUp;
    private Vector2 originalpositonDown;
    private Vector2 originalpositonLeft;
    private Vector2 originalpositonRight;


    //Temp positon to hold for switching.
    Vector2 tempPosition;

    // Use this for initialization
    void Start()
    {
        points = 5; //health
        gameCounter = 0;

        randomNumber = Random.Range(1, 13);
        randomNumberSwitch = Random.Range(1, 8);
        //Init button positons
        originalpositonA = aButton.transform.position;
        originalpositonB = bButton.transform.position;
        originalpositonX = xButton.transform.position;
        originalpositonY = yButton.transform.position;
        //Init DPAD
        originalpositonUp = upButton.transform.position;
        originalpositonDown = downButton.transform.position;
        originalpositonLeft = leftButton.transform.position;
        originalpositonRight = rightButton.transform.position;

        //Init Audio
        audiosource = GetComponent<AudioSource>();

        //Repeat Every 2
        InvokeRepeating("timeDown", 4.0f, 1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        buttonChanger();


        StartCoroutine(playTime());
        //lose condition
        if (points == 0)
        {
            Application.LoadLevel("youlose");
        }

        //makes the game harder
        if (points > 15)
        {
            CancelInvoke();
            InvokeRepeating("timeDown", 0.0f, 0.9f);

        }

        /*Switching 
        if (Input.GetButtonDown("A"))
        {
            Vector2 tempPosition = bButton.transform.position;
            bButton.transform.position = xButton.transform.position;
            xButton.transform.position = tempPosition;
        }
        */

    }

    void loseBar()
    {
        powerBars.transform.Find("bar" + points).gameObject.SetActive(false);
    }

    void timeDown()
    {
        powerBars.transform.Find("bar" + points).gameObject.SetActive(false);
        points--;
    }

    void gainBar()
    {
        if (points < 21)
        {
            powerBars.transform.Find("bar" + points).gameObject.SetActive(true);
        }
    }

    void switcherButton()
    {
        switch (randomNumberSwitch)
        {
            case 1:
                makeOriginalButton();
                tempPosition = bButton.transform.position; // b to x
                bButton.transform.position = xButton.transform.position;
                xButton.transform.position = tempPosition;

                tempTrueNum = trueB;
                trueB = trueX;
                trueX = tempTrueNum;

                break;
            case 2:
                makeOriginalButton();
                tempPosition = aButton.transform.position; // a to x
                aButton.transform.position = xButton.transform.position;
                xButton.transform.position = tempPosition;

                tempTrueNum = trueA;
                trueA = trueX;
                trueX = tempTrueNum;
                break;
            case 3:
                makeOriginalButton();
                tempPosition = yButton.transform.position; // y to b
                yButton.transform.position = bButton.transform.position;
                bButton.transform.position = tempPosition;

                tempTrueNum = trueY;
                trueY = trueB;
                trueB = tempTrueNum;
                break;
            case 4:
                makeOriginalButton();
                tempPosition = yButton.transform.position; //y to a
                yButton.transform.position = aButton.transform.position;
                aButton.transform.position = tempPosition;

                tempTrueNum = trueY;
                trueY = trueA;
                trueA = tempTrueNum;
                break;
            case 5:
                makeOriginalButton();
                tempPosition = yButton.transform.position; //y to x
                yButton.transform.position = xButton.transform.position;
                xButton.transform.position = tempPosition;

                tempTrueNum = trueY;
                trueY = trueX;
                trueX = tempTrueNum;
                break;
            case 6:
                makeOriginalButton();
                tempPosition = bButton.transform.position; //b to a
                bButton.transform.position = aButton.transform.position;
                aButton.transform.position = tempPosition;

                tempTrueNum = trueB;
                trueB = trueA;
                trueA = tempTrueNum;
                break;
            case 7:
                makeOriginalButton();
                break;

        }
    }

    void arrowSwitcher()
    {
        switch (randomNumberSwitch)
        {
            case 1:
                makeOriginalDPAD();
                tempPosition = upButton.transform.position; //up to down
                upButton.transform.position = downButton.transform.position;
                downButton.transform.position = tempPosition;

                tempTrueNum = trueUp;
                trueUp = trueDown;
                trueDown = tempTrueNum;
                break;
            case 2:
                makeOriginalDPAD();
                tempPosition = leftButton.transform.position; //left to right
                leftButton.transform.position = rightButton.transform.position;
                rightButton.transform.position = tempPosition;

                tempTrueNum = trueLeft;
                trueLeft = trueRight;
                trueRight = tempTrueNum;
                break;
            case 3:
                makeOriginalDPAD();
                tempPosition = leftButton.transform.position; //left to up
                leftButton.transform.position = upButton.transform.position;
                upButton.transform.position = tempPosition;

                tempTrueNum = trueLeft;
                trueLeft = trueUp;
                trueUp = tempTrueNum;
                break;
            case 4:
                makeOriginalDPAD();
                tempPosition = rightButton.transform.position; //right to up
                rightButton.transform.position = upButton.transform.position;
                upButton.transform.position = tempPosition;

                tempTrueNum = trueRight;
                trueRight = trueUp;
                trueUp = tempTrueNum;
                break;
            case 5:
                makeOriginalDPAD();
                tempPosition = leftButton.transform.position; //left to down
                leftButton.transform.position = downButton.transform.position;
                downButton.transform.position = tempPosition;

                tempTrueNum = trueLeft;
                trueLeft = trueDown;
                trueDown = tempTrueNum;
                break;
            case 6:
                makeOriginalDPAD();
                tempPosition = rightButton.transform.position; //right to down
                rightButton.transform.position = downButton.transform.position;
                downButton.transform.position = tempPosition;

                tempTrueNum = trueRight;
                trueRight = trueDown;
                trueDown = tempTrueNum;
                break;
            case 7:
                makeOriginalDPAD();
                break;

        }
    }

    void makeOriginalDPAD()
    {
        upButton.transform.position = originalpositonUp; //original positons DPAD
        downButton.transform.position = originalpositonDown;
        leftButton.transform.position = originalpositonLeft;
        rightButton.transform.position = originalpositonRight;
        trueUp = 5;
        trueDown = 6;
        trueLeft = 7;
        trueRight = 8;
    }

    void makeOriginalButton()
    {
        aButton.transform.position = originalpositonA; // original positons BUTTONS
        bButton.transform.position = originalpositonB;
        xButton.transform.position = originalpositonX;
        yButton.transform.position = originalpositonY;
        trueA = 1;
        trueB = 2;
        trueX = 3;
        trueY = 4;
    }

    IEnumerator playTime()
    {
        switch (randomNumber)
        {
            case 1:
                press1();
                break;
            case 2:
                press2();
                break;
            case 3:
                press3();
                break;
            case 4:
                press4();
                break;
            case 5:
                press5();
                break;
            case 6:
                press6();
                break;
            case 7:
                press7();
                break;
            case 8:
                press8();
                break;
            case 9:
                dpadUp();
                break;
            case 10:
                dpadDown();
                break;
            case 11:
                dpadLeft();
                break;
            case 12:
                dpadRight();
                break;
        }
        yield return null;
    }



    void press1()
    {
        /*First Case A*/
        upUI.SetActive(false);
        downUI.SetActive(false);
        leftUI.SetActive(false);
        rightUI.SetActive(false);
        caseAButton.SetActive(true); //true
        caseBButton.SetActive(false);
        caseXButton.SetActive(false);
        caseYButton.SetActive(false);
        colorBlue.SetActive(false);
        colorRed.SetActive(false);
        colorGreen.SetActive(false);
        colorYellow.SetActive(false);
        if ((Input.GetButtonDown("A") && trueA == 1) || (Input.GetButtonDown("B") && trueA == 2) || (Input.GetButtonDown("X") && trueA == 3) || (Input.GetButtonDown("Y") && trueA == 4))
        {
            audiosource.PlayOneShot(goodSound, 0.7f);
            points += 1;
            gainBar();
            gameCounter += 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(5, 13);
            if ((gameCounter % 2 == 0) && gameCounter != 0)
            {
                switcherButton();
                randomNumberSwitch = Random.Range(1, 8);
                Debug.Log("Switching is occuring.");
            }

            if ((gameCounter % 3 == 0) && gameCounter != 0)
            {
                arrowSwitcher();
                randomNumberSwitch = Random.Range(1, 8);
            }
        }
        else if ((Input.GetButtonDown("A") && trueA != 1) || (Input.GetButtonDown("B") && trueA != 2) || (Input.GetButtonDown("X") && trueA != 3) || (Input.GetButtonDown("Y") && trueA != 4))
        {
            audiosource.PlayOneShot(badSound, 0.7f);
            loseBar();
            points -= 1;

            Debug.Log(points + " is now health");
            randomNumber = Random.Range(5, 13);
        }
    }

    void press2()
    {
        /*Second Case B*/
        upUI.SetActive(false);
        downUI.SetActive(false);
        leftUI.SetActive(false);
        rightUI.SetActive(false);
        caseBButton.SetActive(true); //true
        caseAButton.SetActive(false);
        caseXButton.SetActive(false);
        caseYButton.SetActive(false);
        colorBlue.SetActive(false);
        colorRed.SetActive(false);
        colorGreen.SetActive(false);
        colorYellow.SetActive(false);
        if ((Input.GetButtonDown("B") && trueB == 2) || (Input.GetButtonDown("A") && trueB == 1) || (Input.GetButtonDown("X") && trueB == 3) || (Input.GetButtonDown("Y") && trueB == 4))
        {
            audiosource.PlayOneShot(goodSound, 0.7f);
            points += 1;
            gainBar();
            gameCounter += 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 13);

            if ((gameCounter % 2 == 0) && gameCounter != 0)
            {
                switcherButton();
                randomNumberSwitch = Random.Range(1, 8);
                Debug.Log("Switching is occuring.");
            }

            if ((gameCounter % 3 == 0) && gameCounter != 0)
            {
                arrowSwitcher();
                randomNumberSwitch = Random.Range(1, 8);
            }
        }
        else if ((Input.GetButtonDown("B") && trueB != 2) || (Input.GetButtonDown("A") && trueB != 1) || (Input.GetButtonDown("X") && trueB != 3) || (Input.GetButtonDown("Y") && trueB != 4))
        {
            audiosource.PlayOneShot(badSound, 0.7f);
            loseBar();
            points -= 1;

            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 13);
        }
    }

    void press3()
    {
        /*Third Case X*/
        upUI.SetActive(false);
        downUI.SetActive(false);
        leftUI.SetActive(false);
        rightUI.SetActive(false);
        caseXButton.SetActive(true); //true
        caseBButton.SetActive(false);
        caseAButton.SetActive(false);
        caseYButton.SetActive(false);
        colorBlue.SetActive(false);
        colorRed.SetActive(false);
        colorGreen.SetActive(false);
        colorYellow.SetActive(false);
        if ((Input.GetButtonDown("X") && trueX == 3) || (Input.GetButtonDown("A") && trueX == 1) || (Input.GetButtonDown("B") && trueX == 2) || (Input.GetButtonDown("Y") && trueX == 4))
        {
            audiosource.PlayOneShot(goodSound, 0.7f);
            points += 1;
            gainBar();
            gameCounter += 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 13);

            if ((gameCounter % 2 == 0) && gameCounter != 0)
            {
                switcherButton();
                randomNumberSwitch = Random.Range(1, 8);
                Debug.Log("Switching is occuring.");
            }

            if ((gameCounter % 3 == 0) && gameCounter != 0)
            {
                arrowSwitcher();
                randomNumberSwitch = Random.Range(1, 8);
            }
        }
        else if ((Input.GetButtonDown("X") && trueX != 3) || (Input.GetButtonDown("A") && trueX != 1) || (Input.GetButtonDown("B") && trueX != 2) || (Input.GetButtonDown("Y") && trueX != 4))
        {
            audiosource.PlayOneShot(badSound, 0.7f);
            loseBar();
            points -= 1;

            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 13);
        }
    }

    void press4()
    {
        /*Fourth Case Y*/
        upUI.SetActive(false);
        downUI.SetActive(false);
        leftUI.SetActive(false);
        rightUI.SetActive(false);
        caseYButton.SetActive(true); //true
        caseBButton.SetActive(false);
        caseXButton.SetActive(false);
        caseAButton.SetActive(false);
        colorBlue.SetActive(false);
        colorRed.SetActive(false);
        colorGreen.SetActive(false);
        colorYellow.SetActive(false);
        if ((Input.GetButtonDown("Y") && trueY == 4) || (Input.GetButtonDown("A") && trueY == 1) || (Input.GetButtonDown("B") && trueY == 2) || (Input.GetButtonDown("X") && trueY == 3))
        {
            audiosource.PlayOneShot(goodSound, 0.7f);
            points += 1;
            gainBar();
            gameCounter += 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(5, 13);

            if ((gameCounter % 2 == 0) && gameCounter != 0)
            {
                switcherButton();
                randomNumberSwitch = Random.Range(1, 8);
                Debug.Log("Switching is occuring.");
            }

            if ((gameCounter % 3 == 0) && gameCounter != 0)
            {
                arrowSwitcher();
                randomNumberSwitch = Random.Range(1, 8);
            }
        }
        else if ((Input.GetButtonDown("Y") && trueY != 4) || (Input.GetButtonDown("A") && trueY != 1) || (Input.GetButtonDown("B") && trueY != 2) || (Input.GetButtonDown("X") && trueY != 3))
        {
            audiosource.PlayOneShot(badSound, 0.7f);
            loseBar();
            points -= 1;

            Debug.Log(points + " is now health");
            randomNumber = Random.Range(5, 13);
        }
    }

    void press5()
    {
        /*Fifth Case Red (B)*/
        upUI.SetActive(false);
        downUI.SetActive(false);
        leftUI.SetActive(false);
        rightUI.SetActive(false);
        colorRed.SetActive(true); //true
        colorBlue.SetActive(false);
        colorGreen.SetActive(false);
        colorYellow.SetActive(false);
        caseYButton.SetActive(false);
        caseBButton.SetActive(false);
        caseXButton.SetActive(false);
        caseAButton.SetActive(false);
        if ((Input.GetButtonDown("B") && trueB == 2) || (Input.GetButtonDown("A") && trueB == 1) || (Input.GetButtonDown("X") && trueB == 3) || (Input.GetButtonDown("Y") && trueB == 4))
        {
            audiosource.PlayOneShot(goodSound, 0.7f);
            points += 1;
            gainBar();
            gameCounter += 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 13);

            if ((gameCounter % 2 == 0) && gameCounter != 0)
            {
                switcherButton();
                randomNumberSwitch = Random.Range(1, 8);
                Debug.Log("Switching is occuring.");
            }

            if ((gameCounter % 3 == 0) && gameCounter != 0)
            {
                arrowSwitcher();
                randomNumberSwitch = Random.Range(1, 8);
            }
        }
        else if ((Input.GetButtonDown("B") && trueB != 2) || (Input.GetButtonDown("A") && trueB != 1) || (Input.GetButtonDown("X") && trueB != 3) || (Input.GetButtonDown("Y") && trueB != 4))
        {
            audiosource.PlayOneShot(badSound, 0.7f);
            loseBar();
            points -= 1;

            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 13);
        }
    }

    void press6()
    {
        /*Sixth Case Blue (X)*/
        upUI.SetActive(false);
        downUI.SetActive(false);
        leftUI.SetActive(false);
        rightUI.SetActive(false);
        colorRed.SetActive(false);
        colorBlue.SetActive(true); //true
        colorGreen.SetActive(false);
        colorYellow.SetActive(false);
        caseYButton.SetActive(false);
        caseBButton.SetActive(false);
        caseXButton.SetActive(false);
        caseAButton.SetActive(false);
        if ((Input.GetButtonDown("X") && trueX == 3) || (Input.GetButtonDown("A") && trueX == 1) || (Input.GetButtonDown("B") && trueX == 2) || (Input.GetButtonDown("Y") && trueX == 4))
        {
            audiosource.PlayOneShot(goodSound, 0.7f);
            points += 1;
            gainBar();
            gameCounter += 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 13);

            if ((gameCounter % 2 == 0) && gameCounter != 0)
            {
                switcherButton();
                randomNumberSwitch = Random.Range(1, 8);
                Debug.Log("Switching is occuring.");
            }

            if ((gameCounter % 3 == 0) && gameCounter != 0)
            {
                arrowSwitcher();
                randomNumberSwitch = Random.Range(1, 8);
            }
        }
        else if ((Input.GetButtonDown("X") && trueX != 3) || (Input.GetButtonDown("A") && trueX != 1) || (Input.GetButtonDown("B") && trueX != 2) || (Input.GetButtonDown("Y") && trueX != 4))
        {
            audiosource.PlayOneShot(badSound, 0.7f);
            loseBar();
            points -= 1;

            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 13);
        }
    }

    void press7()
    {
        /*Seventh Case Green (A)*/
        upUI.SetActive(false);
        downUI.SetActive(false);
        leftUI.SetActive(false);
        rightUI.SetActive(false);
        colorRed.SetActive(false);
        colorBlue.SetActive(false);
        colorGreen.SetActive(true); //true
        colorYellow.SetActive(false);
        caseYButton.SetActive(false);
        caseBButton.SetActive(false);
        caseXButton.SetActive(false);
        caseAButton.SetActive(false);
        if ((Input.GetButtonDown("A") && trueA == 1) || (Input.GetButtonDown("B") && trueA == 2) || (Input.GetButtonDown("X") && trueA == 3) || (Input.GetButtonDown("Y") && trueA == 4))
        {
            audiosource.PlayOneShot(goodSound, 0.7f);
            points += 1;
            gainBar();
            gameCounter += 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 13);

            if ((gameCounter % 2 == 0) && gameCounter != 0)
            {
                switcherButton();
                randomNumberSwitch = Random.Range(1, 8);
                Debug.Log("Switching is occuring.");
            }

            if ((gameCounter % 3 == 0) && gameCounter != 0)
            {
                arrowSwitcher();
                randomNumberSwitch = Random.Range(1, 8);
            }
        }
        else if ((Input.GetButtonDown("A") && trueA != 1) || (Input.GetButtonDown("B") && trueA != 2) || (Input.GetButtonDown("X") && trueA != 3) || (Input.GetButtonDown("Y") && trueA != 4))
        {
            audiosource.PlayOneShot(badSound, 0.7f);
            loseBar();
            points -= 1;

            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 13);
        }
    }

    void press8()
    {
        /*Fourth Case Yellow (Y)*/
        upUI.SetActive(false);
        downUI.SetActive(false);
        leftUI.SetActive(false);
        rightUI.SetActive(false);
        colorRed.SetActive(false);
        colorBlue.SetActive(false);
        colorGreen.SetActive(false);
        colorYellow.SetActive(true); //true
        caseYButton.SetActive(false);
        caseBButton.SetActive(false);
        caseXButton.SetActive(false);
        caseAButton.SetActive(false);
        if ((Input.GetButtonDown("Y") && trueY == 4) || (Input.GetButtonDown("A") && trueY == 1) || (Input.GetButtonDown("B") && trueY == 2) || (Input.GetButtonDown("X") && trueY == 3))
        {
            audiosource.PlayOneShot(goodSound, 0.7f);
            points += 1;
            gainBar();
            gameCounter += 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 13);

            if ((gameCounter % 2 == 0) && gameCounter != 0)
            {
                switcherButton();
                randomNumberSwitch = Random.Range(1, 8);
                Debug.Log("Switching is occuring.");
            }

            if ((gameCounter % 3 == 0) && gameCounter != 0)
            {
                arrowSwitcher();
                randomNumberSwitch = Random.Range(1, 8);
            }
        }
        else if ((Input.GetButtonDown("Y") && trueY != 4) || (Input.GetButtonDown("A") && trueY != 1) || (Input.GetButtonDown("B") && trueY != 2) || (Input.GetButtonDown("X") && trueY != 3))
        {
            audiosource.PlayOneShot(badSound, 0.7f);
            loseBar();
            points -= 1;

            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 13);
        }
    }

    void dpadLeft() //you press the left dpad
    {
        /*Case 9 DPAD LEFT (<)*/
        upUI.SetActive(false);
        downUI.SetActive(false);
        leftUI.SetActive(true);
        rightUI.SetActive(false);
        colorRed.SetActive(false);
        colorBlue.SetActive(false);
        colorGreen.SetActive(false);
        colorYellow.SetActive(false);
        caseYButton.SetActive(false);
        caseBButton.SetActive(false);
        caseXButton.SetActive(false);
        caseAButton.SetActive(false);
        //(Input.GetButtonDown("Y") && trueY == 4) || (Input.GetButtonDown("A") && trueY == 1) || (Input.GetButtonDown("B") && trueY == 2) || (Input.GetButtonDown("X") && trueY == 3)
        if (((Input.GetAxis("leftright") == -1) && trueLeft == 7) || ((Input.GetAxis("leftright") == 1) && trueLeft == 8) || ((Input.GetAxis("updown") == -1) && trueLeft == 5) || ((Input.GetAxis("updown") == 1) && trueLeft == 6))
        {
            audiosource.PlayOneShot(goodSound, 0.7f);
            points += 1;
            gainBar();
            gameCounter += 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 9);

            if ((gameCounter % 2 == 0) && gameCounter != 0)
            {
                switcherButton();
                randomNumberSwitch = Random.Range(1, 8);
                Debug.Log("Switching is occuring.");
            }

            if ((gameCounter % 3 == 0) && gameCounter != 0)
            {
                arrowSwitcher();
                randomNumberSwitch = Random.Range(1, 8);
            }
        }
        else if (((Input.GetAxis("leftright") == -1) && trueLeft != 7) || ((Input.GetAxis("leftright") == 1) && trueLeft != 8) || ((Input.GetAxis("updown") == -1) && trueLeft != 5) || ((Input.GetAxis("updown") == 1) && trueLeft != 6))
        {
            audiosource.PlayOneShot(badSound, 0.7f);
            loseBar();
            points -= 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 9);
        }
    }

    void dpadRight() //you press the right dpad
    {
        /*Case 10 DPAD right (>)*/
        upUI.SetActive(false);
        downUI.SetActive(false);
        leftUI.SetActive(false);
        rightUI.SetActive(true); //true
        colorRed.SetActive(false);
        colorBlue.SetActive(false);
        colorGreen.SetActive(false);
        colorYellow.SetActive(false);
        caseYButton.SetActive(false);
        caseBButton.SetActive(false);
        caseXButton.SetActive(false);
        caseAButton.SetActive(false);
        if (((Input.GetAxis("leftright") == 1) && trueRight == 8) || ((Input.GetAxis("leftright") == -1) && trueRight == 7) || ((Input.GetAxis("updown") == -1) && trueRight == 5) || ((Input.GetAxis("updown") == 1) && trueRight == 6))
        {
            audiosource.PlayOneShot(goodSound, 0.7f);
            points += 1;
            gainBar();
            gameCounter += 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 9);

            if ((gameCounter % 2 == 0) && gameCounter != 0)
            {
                switcherButton();
                randomNumberSwitch = Random.Range(1, 8);
                Debug.Log("Switching is occuring.");
            }

            if ((gameCounter % 3 == 0) && gameCounter != 0)
            {
                arrowSwitcher();
                randomNumberSwitch = Random.Range(1, 8);
            }
        }
        else if (((Input.GetAxis("leftright") == -1) && trueRight != 8) || ((Input.GetAxis("leftright") == 1) && trueRight != 7) || ((Input.GetAxis("updown") == -1) && trueRight != 5) || ((Input.GetAxis("updown") == 1) && trueRight != 6))
        {
            audiosource.PlayOneShot(badSound, 0.7f);
            loseBar();
            points -= 1;

            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 9);
        }
    }

    void dpadUp() //you press the up dpad
    {
        /*Case 11 UP DPAD (<)*/
        upUI.SetActive(true);
        downUI.SetActive(false);
        leftUI.SetActive(false);
        rightUI.SetActive(false);
        colorRed.SetActive(false);
        colorBlue.SetActive(false);
        colorGreen.SetActive(false);
        colorYellow.SetActive(false);
        caseYButton.SetActive(false);
        caseBButton.SetActive(false);
        caseXButton.SetActive(false);
        caseAButton.SetActive(false);
        if (((Input.GetAxis("updown") == -1) && trueUp == 5) || ((Input.GetAxis("updown") == 1) && trueUp == 6) || ((Input.GetAxis("leftright") == -1) && trueUp == 7) || ((Input.GetAxis("leftright") == 1) && trueUp == 8))
        {
            audiosource.PlayOneShot(goodSound, 0.7f);
            points += 1;
            gainBar();
            gameCounter += 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 9);

            if ((gameCounter % 2 == 0) && gameCounter != 0)
            {
                switcherButton();
                randomNumberSwitch = Random.Range(1, 8);
                Debug.Log("Switching is occuring.");
            }

            if ((gameCounter % 3 == 0) && gameCounter != 0)
            {
                arrowSwitcher();
                randomNumberSwitch = Random.Range(1, 8);
            }
        }
        else if (((Input.GetAxis("updown") == -1) && trueUp != 5) || ((Input.GetAxis("updown") == 1) && trueUp != 6) || ((Input.GetAxis("leftright") == -1) && trueUp != 7) || ((Input.GetAxis("leftright") == 1) && trueUp != 8))
        {
            audiosource.PlayOneShot(badSound, 0.7f);
            loseBar();
            points -= 1;

            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 9);
        }
    }

    void dpadDown() //you press the down dpad
    {
        /*Case 12 DOWN DPAD (<)*/
        upUI.SetActive(false);
        downUI.SetActive(true);
        leftUI.SetActive(false);
        rightUI.SetActive(false);
        colorRed.SetActive(false);
        colorBlue.SetActive(false);
        colorGreen.SetActive(false);
        colorYellow.SetActive(false);
        caseYButton.SetActive(false);
        caseBButton.SetActive(false);
        caseXButton.SetActive(false);
        caseAButton.SetActive(false);
        if (((Input.GetAxis("updown") == 1) && trueDown == 6) || ((Input.GetAxis("updown") == -1) && trueDown == 5) || ((Input.GetAxis("leftright") == -1) && trueDown == 7) || ((Input.GetAxis("leftright") == 1) && trueDown == 8))
        {
            audiosource.PlayOneShot(goodSound, 0.7f);
            points += 1;
            gainBar();
            gameCounter += 1;
            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 9);

            if ((gameCounter % 2 == 0) && gameCounter != 0)
            {
                switcherButton();
                randomNumberSwitch = Random.Range(1, 8);
                Debug.Log("Switching is occuring.");
            }

            if ((gameCounter % 3 == 0) && gameCounter != 0)
            {
                arrowSwitcher();
                randomNumberSwitch = Random.Range(1, 8);
            }
        }
        else if (((Input.GetAxis("updown") == 1) && trueDown != 6) || ((Input.GetAxis("updown") == -1) && trueDown != 5) || ((Input.GetAxis("leftright") == -1) && trueDown != 7) || ((Input.GetAxis("leftright") == 1) && trueDown != 8))
        {
            audiosource.PlayOneShot(badSound, 0.7f);
            loseBar();
            points -= 1;

            Debug.Log(points + " is now health");
            randomNumber = Random.Range(1, 9);
        }
    }



    void buttonChanger()
    {
        /*Button Inputs*/
        if (Input.GetButtonDown("A"))
        {
            if (trueA == 1)
                aButton.GetComponent<SpriteRenderer>().color = Color.black;
            if (trueA == 2)
                bButton.GetComponent<SpriteRenderer>().color = Color.black;
            if (trueA == 3)
                xButton.GetComponent<SpriteRenderer>().color = Color.black;
            if (trueA == 4)
                yButton.GetComponent<SpriteRenderer>().color = Color.black;

            //Debug.Log("A is pressed");
        }

        if (Input.GetButtonUp("A"))
        {

            aButton.GetComponent<SpriteRenderer>().color = Color.white;

            bButton.GetComponent<SpriteRenderer>().color = Color.white;

            xButton.GetComponent<SpriteRenderer>().color = Color.white;

            yButton.GetComponent<SpriteRenderer>().color = Color.white;
        }



        if (Input.GetButtonDown("B"))
        {
            if (trueB == 2)
                bButton.GetComponent<SpriteRenderer>().color = Color.black;
            if (trueB == 1)
                aButton.GetComponent<SpriteRenderer>().color = Color.black;
            if (trueB == 3)
                xButton.GetComponent<SpriteRenderer>().color = Color.black;
            if (trueB == 4)
                yButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        if (Input.GetButtonUp("B"))
        {

            bButton.GetComponent<SpriteRenderer>().color = Color.white;

            aButton.GetComponent<SpriteRenderer>().color = Color.white;

            xButton.GetComponent<SpriteRenderer>().color = Color.white;

            yButton.GetComponent<SpriteRenderer>().color = Color.white;
            //Debug.Log("B is pressed");
        }


        if (Input.GetButtonDown("X"))
        {
            if (trueX == 3)
                xButton.GetComponent<SpriteRenderer>().color = Color.black;
            if (trueX == 1)
                aButton.GetComponent<SpriteRenderer>().color = Color.black;
            if (trueX == 2)
                bButton.GetComponent<SpriteRenderer>().color = Color.black;
            if (trueX == 4)
                yButton.GetComponent<SpriteRenderer>().color = Color.black;
            //Debug.Log("X is pressed");
        }

        if (Input.GetButtonUp("X"))
        {

            xButton.GetComponent<SpriteRenderer>().color = Color.white;

            aButton.GetComponent<SpriteRenderer>().color = Color.white;

            bButton.GetComponent<SpriteRenderer>().color = Color.white;

            yButton.GetComponent<SpriteRenderer>().color = Color.white;
            //Debug.Log("X is pressed");
        }

        if (Input.GetButtonDown("Y"))
        {
            if (trueY == 4)
                yButton.GetComponent<SpriteRenderer>().color = Color.black;
            if (trueY == 1)
                aButton.GetComponent<SpriteRenderer>().color = Color.black;
            if (trueY == 2)
                bButton.GetComponent<SpriteRenderer>().color = Color.black;
            if (trueY == 3)
                xButton.GetComponent<SpriteRenderer>().color = Color.black;
            //Debug.Log("Y is pressed");
        }

        if (Input.GetButtonUp("Y"))
        {

            yButton.GetComponent<SpriteRenderer>().color = Color.white;

            aButton.GetComponent<SpriteRenderer>().color = Color.white;

            bButton.GetComponent<SpriteRenderer>().color = Color.white;

            xButton.GetComponent<SpriteRenderer>().color = Color.white;
            //Debug.Log("Y is pressed");
        }

        /* Directional Inputs */
        if (Input.GetAxis("leftright") == -1 && pressOnlyOnce == false)

        {
            //Debug.Log("left DPAD is pressed");
            if (trueLeft == 7)
            {
                leftButton.GetComponent<SpriteRenderer>().color = Color.black;
 
            }

            //Debug.Log("left DPAD is pressed");
            if (trueLeft == 8)
            {
                rightButton.GetComponent<SpriteRenderer>().color = Color.black;

            }

            //Debug.Log("left DPAD is pressed");
            if (trueLeft == 5)
            {
                upButton.GetComponent<SpriteRenderer>().color = Color.black;
  
            }

            //Debug.Log("left DPAD is pressed");
            if (trueLeft == 6)
            {
                downButton.GetComponent<SpriteRenderer>().color = Color.black;

            }
            pressOnlyOnce = true;

        }

        if (Input.GetAxis("leftright") == 1 && pressOnlyOnce == false)

        {
            if (trueRight == 8)
            {
                //Debug.Log("right DPAD is pressed");
                rightButton.GetComponent<SpriteRenderer>().color = Color.black;

            }

            if (trueRight == 7)
            {
                //Debug.Log("right DPAD is pressed");
                leftButton.GetComponent<SpriteRenderer>().color = Color.black;

            }

            if (trueRight == 5)
            {
                //Debug.Log("right DPAD is pressed");
                upButton.GetComponent<SpriteRenderer>().color = Color.black;

            }

            if (trueRight == 6)
            {
                //Debug.Log("right DPAD is pressed");
                downButton.GetComponent<SpriteRenderer>().color = Color.black;

            }

            pressOnlyOnce = true;
        }

        if (Input.GetAxis("leftright") == 0 && Input.GetAxis("updown") != -1 && Input.GetAxis("updown") != 1)

        {
            leftButton.GetComponent<SpriteRenderer>().color = Color.white;
            rightButton.GetComponent<SpriteRenderer>().color = Color.white;
            pressOnlyOnce = false;
        }

        if (Input.GetAxis("updown") == -1 && pressOnlyOnce == false)

        {
            if (trueUp == 5)
            {
                //Debug.Log("up DPAD is pressed");
                upButton.GetComponent<SpriteRenderer>().color = Color.black;

            }

            if (trueUp == 6)
            {
                //Debug.Log("up DPAD is pressed");
                downButton.GetComponent<SpriteRenderer>().color = Color.black;

            }

            if (trueUp == 7)
            {
                //Debug.Log("up DPAD is pressed");
                leftButton.GetComponent<SpriteRenderer>().color = Color.black;

            }

            if (trueUp == 8)
            {
                //Debug.Log("up DPAD is pressed");
                rightButton.GetComponent<SpriteRenderer>().color = Color.black;

            }
            pressOnlyOnce = true;
        }

        if (Input.GetAxis("updown") == 1 && pressOnlyOnce == false)

        {
            if (trueDown == 6)
            {
                //Debug.Log("up DPAD is pressed");
                downButton.GetComponent<SpriteRenderer>().color = Color.black;
            }

            if (trueDown == 5)
            {
                //Debug.Log("up DPAD is pressed");
                upButton.GetComponent<SpriteRenderer>().color = Color.black;
            }

            if (trueDown == 7)
            {
                //Debug.Log("up DPAD is pressed");
                leftButton.GetComponent<SpriteRenderer>().color = Color.black;
            }

            if (trueDown == 8)
            {
                //Debug.Log("up DPAD is pressed");
                rightButton.GetComponent<SpriteRenderer>().color = Color.black;
            }

            pressOnlyOnce = true;
        }

        if (Input.GetAxis("updown") == 0 && Input.GetAxis("leftright") != -1 && Input.GetAxis("leftright") != 1)

        {
            upButton.GetComponent<SpriteRenderer>().color = Color.white;
            downButton.GetComponent<SpriteRenderer>().color = Color.white;
            pressOnlyOnce = false;
        }
    }

}


