﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerReview : Dialogue
{
    [Range(1, 5)]
    public int review_stars; 

    public void generateReview(double finalScore)
    {
        if(finalScore>=190)
        {
            generateGoodReview();
        }
        else
        {
            generateBadReview();
        }
    }

    private void generateBadReview()
    {
        review_stars = Random.Range(1, 4);

        randomCustomerReviewNegDialogue();
    }

    private void generateGoodReview()
    {
        review_stars = Random.Range(4, 6);

        randomCustomerReviewPosDialogue();
    }

    private void randomCustomerReviewPosDialogue()
    {
        string[] script = null;

        switch (Random.Range(1, 6))
        {
            case 1:
                script = new string[] { "Great job, done quick, no sweat!" };
                break;
            case 2:
                script = new string[] { "they did good" };
                break;
            case 3:
                script = new string[] { "Completely satisfied with the results and the service. Consider me a returning client!! " };
                break;
            case 4:
                script = new string[] { "They did a super awesome job! 11/10!!!" };
                break;
            case 5:
                script = new string[] { "Solid work" };
                break;
        }

        sentences = script;
    }

    private void randomCustomerReviewNegDialogue()
    {

        string[] script = null;

        switch (Random.Range(1, 6))
        {
            case 1:
                script = new string[] { "Horrible. I don’t know what went wrong but everyone was completely unprofessional." };
                break;
            case 2:
                script = new string[] { "The work was alright, the employees could’ve been better." };
                break;
            case 3:
                script = new string[] { "10/10 would not contract again" };
                break;
            case 4:
                script = new string[] { "This was the worst waste of money ever!!! Will NOT be seeing you again!" };
                break;
            case 5:
                script = new string[] { "I totally didn’t get what I paid for. " };
                break;
        }

        sentences = script;
    }
}
