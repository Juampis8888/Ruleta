using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TextNum1;

    public TextMeshProUGUI TextNum2;

    public TextMeshProUGUI TextNum3;

    public AudioClip SoundEffectRoulette;

    private AudioSource AudioSource;

    private readonly int MaxNum = 190;

    private readonly float Time = 0.04f;

    private Animator AnimatorNum;

    private Animator AnimatorNum2;

    private Animator AnimatorNum3;

    private void Awake()
    {
        AudioSource = gameObject.GetComponent<AudioSource>();
        AnimatorNum = TextNum1.gameObject.GetComponentInParent<Animator>();
        AnimatorNum2 = TextNum2.gameObject.GetComponentInParent<Animator>();
        AnimatorNum3 = TextNum3.gameObject.GetComponentInParent<Animator>();
    }

    private void Start()
    {
        AudioSource.clip = SoundEffectRoulette;
    }

    public void CallRoulette()
    {
        StartCoroutine(Roulette());
        
    }

    private IEnumerator Roulette()
    {
        AudioSource.Play();
        AnimatorNum.Play("Move");
        AnimatorNum2.Play("Move");
        AnimatorNum3.Play("Move");
        int NumMaxTaken = 0;
        while (true) 
        {
            var RandomNum1 = Random.Range(0, 9);
            var RandomNum2 = Random.Range(0, 9);
            var RandomNum3 = Random.Range(0, 9);
            TextNum1.text = RandomNum1.ToString();
            TextNum2.text = RandomNum2.ToString();
            TextNum3.text = RandomNum3.ToString();
            NumMaxTaken++;
            yield return new WaitForSeconds(Time);
            if(NumMaxTaken == MaxNum)
            {
                AnimatorNum.Play("Idle");
                AnimatorNum2.Play("Idle");
                AnimatorNum3.Play("Idle");
                RandomNum1 = Random.Range(0, 9);
                RandomNum2 = Random.Range(0, 9);
                RandomNum3 = Random.Range(0, 9);
                TextNum1.text = RandomNum1.ToString();
                TextNum2.text = RandomNum2.ToString();
                TextNum3.text = RandomNum3.ToString();
                break;
            }

        }
    }
}
