using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bitpredict2 : MonoBehaviour
{
    public GameObject[] questionBullets;
    public GameObject score;

    public GameObject PlayerWin;
    public GameObject PlayerLose;

    public int bit = 0;
    public int biterror = -1;
    public int human_answer = 0;
    public int q_number = 0;
    public int correct_ai = 0;
    public int correct_human = 0;
    private int question = 0;
    private int q_numberAI;

    public Sprite bullet;
    public Sprite bulletwrong;

    private void Update()
    {
        Debug.Log("Current biterror = " + biterror);

        if (q_number == 10)
        {
            if (correct_human >= correct_ai)
            {
                PlayerWin.SetActive(true);
            }
            else
            {
                PlayerLose.SetActive(true);
            }
        }
    }
    private void Start()
    {
        PlayerWin.SetActive(false);
        PlayerLose.SetActive(false);
        q_number = -1;
        biterror = -1;
        generate_questions();
        q_numberAI = q_number + 10;
    }

    public void generate_questions()
    {
        question = Random.Range(0, 2);
        q_number++;
        q_numberAI++;
    }

    //questionBullets[0].GetComponent<SpriteRenderer>().sprite = bullet;

    //ai----------------------------------------------------------
    public void correct_one_ai()//goes to next question and increases the score
    {
        questionBullets[q_numberAI].GetComponent<SpriteRenderer>().sprite = bullet;
        correct_ai++;
        //new additions!!
        if (bit == 1)//correct answer is 1
        {
            if (biterror < 2)//if biterror is 1, increase it to 2 | < 3 for 3 bit scheme
            {
                biterror++;
            }
            if (biterror >= 1)//changes bit value|should probably put into a function
            {
                bit = 1;
            }
        }
        if (bit == 0)
        {
            if (biterror > -1)//if biterror is 0, decrease it to -1 | > -2 for 3 bit scheme
            {
                biterror--;
            }
            if (biterror <= 0)//changes bit value|should probably put into a function
            {
                bit = 0;
            }
        }
    }

    public void wrong_ai()//has new additions!!
    {
        questionBullets[q_numberAI].GetComponent<SpriteRenderer>().sprite = bulletwrong;

        if (bit == 0)//correct answer is 1
        {
            biterror++;
            if (biterror >= 1)//changes bit value|should probably put into a function
            {
                bit = 1;
            }
        }
        else
        {//correct answer is 0
            biterror--;
            if (biterror <= 0)//changes bit value|should probably put into a function
            {
                bit = 0;
            }
        }
    }

    public void predict_ai()//prediction, this is what actually runs. runs on either button
    {
        if (bit == question)
        {
            correct_one_ai();
        }
        else
        {
            wrong_ai();
        }
    }

    //human----------------------------------------------------------


    public void human_zero()//human guesses zero. runs on zero button
    {
        if (q_number >= 10)
        {

        }
        else
        {
            human_answer = 0;
            checkAnswer();

            predict_ai();
            generate_questions();
        }
    }

    public void human_one()//human guesses one. runs on one button.
    {
        if (q_number >= 10)
        {

        }
        else
        {
            human_answer = 1;
            checkAnswer();

            predict_ai();
            generate_questions();
        }

    }

    private void checkAnswer()
    {
        if (q_number >= 10)
        {

        }
        else if (question == human_answer)
        {
            correct_human++;
            score.GetComponent<Text>().text = (correct_human * 100).ToString();

            questionBullets[q_number].GetComponent<SpriteRenderer>().sprite = bullet;
        }
        else
        {
            questionBullets[q_number].GetComponent<SpriteRenderer>().sprite = bulletwrong;
        }
    }
}
