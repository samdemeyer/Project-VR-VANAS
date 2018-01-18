using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour {

    public Canvas[] instrucSlides;

    public Text bookMark;
    int currentSlide, showSlideNbr;
	// Use this for initialization
	void Start () 
    {
        // eerste slide enabled
        for (int i = 0; i < instrucSlides.Length; i ++)
        {
            instrucSlides[i].enabled = false;

		}

        currentSlide = 0;
        instrucSlides[currentSlide].enabled = true;


        updateBookMark();
	}
	
	public void clickRight()
	{
        // disable current slide
        instrucSlides[currentSlide].enabled = false;

        // enable next slide ++
        currentSlide++;

		// if slide is > [lenght-1], go to [0]
		if(currentSlide > instrucSlides.Length - 1)
        {
            currentSlide = 0;
        }

        instrucSlides[currentSlide].enabled = true;

        updateBookMark();


	}

    public void clickLeft()
    {
		// disable current slide
		instrucSlides[currentSlide].enabled = false;

		// enable next slide ++
		currentSlide--;

		// if slide is <[O], go to [lenght -1]
		if (currentSlide < 0 )
		{
			currentSlide = instrucSlides.Length - 1;
		}

		instrucSlides[currentSlide].enabled = true;

        updateBookMark();

	}

    void updateBookMark()
    {
        showSlideNbr = currentSlide + 1;

        bookMark.text = showSlideNbr + " / " + instrucSlides.Length;
    }
}
