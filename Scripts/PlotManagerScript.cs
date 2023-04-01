using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlotManagerScript : MonoBehaviour
{
    //narrative
    private string[] plot_0 = {"Jack had been away from his hometown for years, but as he pulled into the gas station, he couldn't shake the feeling of nostalgia that washed over him. " +
        "He had left when he was just 12 years old, running away from the pain and heartache that had consumed his life. But now, he was back, and he had a mission to accomplish. " +
        "As he filled up his car, a man approached him, admiring the sleek, black sports car. ",
    //guy4
    "Nice ride, You mind if I challenge you to a race? I've got a pretty fast car myself.",
    //narrative
    "Jack hesitated for a moment, the memories of his older brother's untimely death in an illegal car race still fresh in his mind. " +
        "But he couldn't resist the temptation to show off his skills on the road, and he agreed to the challenge." };

    //narrative
    private string[] plot_1 = { "As he pulled back into the gas station, a woman named Caroline approached him, a sly smile on her face.",
    //Caroline 1
    "Impressive driving, I have a proposition for you. I run a racing team, and I think you have the skills to win the annual race. Are you interested in joining us?",
    //Jack 3
    "Because I can win and we miss a proper driver, someone like You. Think about it, you'll find me in my garage, here is the adress.",
    //narrative
    "Caroline drived away. Her offer made an impression on Jack who decided to visit her garage."};

    //Caroline 3
    private string[] plot_2 = {"I can see you made up your mind and you will join us, won't you?",
    //Jack 4
    "You have intrigued me, I'm here to get to know the details.",
    //Caroline 1
    "Fine, I get that. So let me introduce you to the racing world.",
    "Our goal is too participate in the annual race, and hopefully, win it. But that might be difficult, current champion Damian has never lose and is the champion since over 15 yeras.",
    "But lets not focuse on that part yet. First we have to guarantee a spot in annual race. To do so our team has to win 5 out of 8 races, only then we will be invited.",
    "On the technical side, this is our garage. We keep here cars and the teams mechanics are tiunning them. You can use LAPTOP on the desk to manage your cars.",
    "If you feel like joining us, it's time to make a decision. We are short on time and need a good driver asap.",
    //Jack 3
    "Well, I was going to do it on my own but I think we can help each other."};

    //Caroline 2
    private string[] plot_3 = { "Good job racer. Keep on going like today and I won’t regret I took you to the team." };

    //Caroline 4
    private string[] plot_4 = {"Great race, again. I was wondering, what's your motivation for racing? Is it just the thrill of the sport or is there something else?",
    //Jack 3
    "I just love racing."};

    //Caroline 3
    private string[] plot_5 = {"There has to be more to it than just passion, I can see the fire in your eyes when you race. It's like you're racing for something more than just the thrill.",
    //Jack 4
    "\"I can't tell you,\" Jack said, a hint of sadness in his voice. \"But trust me, I have a good reason for wanting to win.\"" };

    //narrative
    private string[] plot_6 = {"After the rourth race, Jack and Caroline sat in the garage talking. Caroline confided in Jack about the hardships she had faced in her life, and Jack found himself opening up to her.",
    //Caroline 3
    "Caroline asked Jack about his past. \"Where did you learn to drive like that?\" she asked.",
    //Jack 3
    "\"I've always had a passion for it,\" Jack replied, avoiding the question. \"I used to race with my older brother when I was younger.\"",
    //Caroline 1
    "\"What happened to him?\" Caroline asked.",
    //Jack 1
    "Jack hesitated, not wanting to reveal the truth. But he knew he couldn't keep it from her any longer. \"He died in a race against Damian,\" he said, his voice shaking with emotion." +
        " \"I've come back to this town to seek revenge against him and win the annual race.\"",
    //Caroline 3
    "Caroline was shocked, but she promised to help Jack in any way she could. \"I'll do everything in my power to help you win,\" she said. \"But you have to promise me one thing.\"",
    //Jack 2
    "\"What's that?\" Jack asked.",
    //Caroline 1
    "\"Promise me that you'll use your racing skills for good from now on,\" Caroline said. " +
        "\"No more seeking revenge or getting involved in illegal activities. It's not worth it in the end.\"",
    //narrative
    "Jack nodded, knowing that Caroline was right. He had finally found the support and guidance he needed to achieve his goals, and he didn't want to risk losing it all again. " +
        "From now on, he would use his skills on the track for the love of the sport and nothing else."};

    //Caroline 4
    private string[] plot_7 = {"As Caroline congratulated him, Jack couldn't help but feel a sense of accomplishment and pride. \"You did it,\" she said. " +
        "\"You've qualified for the annual race. But remember, this is about more than just avenging your brother. It's about showing the world what you're capable of.\"",
    //Jack 1
    "Jack nodded, knowing that Caroline was right. He had worked hard for this moment, and he was determined to make the most of it."};

    private string[] plot_9 = {"After the race, Jack and Damian had a tense confrontation. \"I can't believe you beat me,\" Damian said. \"You'll never be able to do it again.\"",
    //Jack 3
    "\"I don't race for revenge,\" Jack replied. \"I race for the love of the sport. And I'll always be a better driver than you.\"",
    //narrative
    "Damian glared at Jack before storming off, vowing to never return to the town again.",
    //narrative
    "As Jack and Caroline were celebrating his victory, Jack couldn't help but feel a sense of accomplishment and pride. He had overcome his past, found his passion, and achieved his goal.",
    //narrative
    "And with Caroline by his side, he knew he could take on anything. He had found a new sense of purpose and direction in life, and they were ready to take on whatever challenges came their way."};



    [SerializeField] private TMP_Text text;
    [SerializeField] private Image img;

    private PlayerData PD;

    [SerializeField] private Sprite randomGuy;
    [SerializeField] private Sprite damian;
    [SerializeField] private Sprite caroline1;
    [SerializeField] private Sprite caroline2;
    [SerializeField] private Sprite caroline3;
    [SerializeField] private Sprite caroline4;
    [SerializeField] private Sprite jack1;
    [SerializeField] private Sprite jack2;
    [SerializeField] private Sprite jack3;
    [SerializeField] private Sprite jack4;
    [SerializeField] private Sprite narrative;

    private int plotStage = -1;
    private int i = 0;

    void Start()
    {
        PD = SaveData.Load();
        plotStage = PD.getPlotStage();
        Play();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Play();
        }
    }

    void Play()
    {
        switch (plotStage)
        {
            case 0:
                Plot_0(); break;
            case 1:
                Plot_1(); break;
            case 2:
                Plot_2(); break;
            case 3:
                Plot_3(); break;
            case 4:
                Plot_4(); break;
            case 5:
                Plot_5(); break;
            case 6:
                Plot_6(); break;
            case 7:
                Plot_7(); break;
            case 8:
                Plot_8(); break;
        }
        i++;
    }

    void End()
    {
        PD.addPlotStage();
        SaveData.Save(PD);
        if (PD.getPlotStage() < 3)
        {
            SceneManager.LoadScene("Overworld");
        }
        else 
        {
           SceneManager.LoadScene("Garage");
        }
    }

    void Plot_0() 
    {
        if (i == 0)
        {
            text.text = plot_0[i];
            img.sprite = narrative;
        }
        else if (i == 1)
        {
            text.text = plot_0[i];
            img.sprite = randomGuy;
        }
        else if(i == 2)
        {
            text.text = plot_0[i];
            img.sprite = narrative;
        }
        else if(i == 3)
        {
            End();
        }
    }
    void Plot_1()
    {
        if (i == 0)
        {
            text.text = plot_1[i];
            img.sprite = narrative;
        }
        else if (i == 1)
        {
            text.text = plot_1[i];
            img.sprite = caroline1;
        }
        else if (i == 2)
        {
            text.text = plot_1[i];
            img.sprite = jack3;
        }
        else if (i == 3)
        {
            text.text = plot_1[i];
            img.sprite = narrative;
        }
        else if (i == 4)
        {
            End();
        }
    }
    void Plot_2()
    {
        if (i == 0)
        {
            text.text = plot_2[i];
            img.sprite = caroline3;
        }
        else if (i == 1)
        {
            text.text = plot_2[i];
            img.sprite = jack4;
        }
        else if (i == 2)
        {
            text.text = plot_2[i];
            img.sprite = caroline1;
        }
        else if (i == 3)
        {
            text.text = plot_2[i];
            img.sprite = caroline1;
        }
        else if (i == 4)
        {
            text.text = plot_2[i];
            img.sprite = caroline1;
        }
        else if (i == 5)
        {
            text.text = plot_2[i];
            img.sprite = caroline1;
        }
        else if (i == 6)
        {
            text.text = plot_2[i];
            img.sprite = caroline1;
        }
        else if (i == 7)
        {
            text.text = plot_2[i];
            img.sprite = jack4;
        }
        else if (i == 8)
        {
            End();
        }
    }
    void Plot_3()
    {
        if (i == 0)
        {
            text.text = plot_3[i];
            img.sprite = caroline2;
        }
        else if (i == 1)
        {
            End();
        }
    }
    void Plot_4()
    {
        if (i == 0)
        {
            text.text = plot_4[i];
            img.sprite = caroline4;
        }
        else if (i == 1)
        {
            text.text = plot_4[i];
            img.sprite = jack3;
        }
        else if (i == 2)
        {
            End();
        }
    }
    void Plot_5()
    {
        {
            if (i == 0)
            {
                text.text = plot_5[i];
                img.sprite = caroline3;
            }
            else if (i == 1)
            {
                text.text = plot_5[i];
                img.sprite = jack4;
            }
            else if (i == 2)
            {
                End();
            }
        }
    }
    void Plot_6()
    {
        if (i == 0)
        {
            text.text = plot_6[i];
            img.sprite = narrative;
        }
        else if (i == 1)
        {
            text.text = plot_6[i];
            img.sprite = caroline3;
        }
        else if (i == 2)
        {
            text.text = plot_6[i];
            img.sprite = jack3;
        }
        else if (i == 3)
        {
            text.text = plot_6[i];
            img.sprite = caroline2;
        }
        else if (i == 4)
        {
            text.text = plot_6[i];
            img.sprite = jack2;
        }
        else if (i == 5)
        {
            text.text = plot_6[i];
            img.sprite = caroline3;
        }
        else if (i == 6)
        {
            text.text = plot_6[i];
            img.sprite = jack2;
        }
        else if (i == 7)
        {
            text.text = plot_6[i];
            img.sprite = caroline1;
        }
        else if (i == 8)
        {
            text.text = plot_6[i];
            img.sprite = narrative;
        }
        else if (i == 9)
        {
            End();
        }
    }
    void Plot_7()
    {
        if (i == 0)
        {
            text.text = plot_7[i];
            img.sprite = caroline4;
        }
        else if (i == 1)
        {
            text.text = plot_7[i];
            img.sprite = jack1;
        }
        else if (i == 2)
        {
            End();
        }
    }
    void Plot_8()
    {
        if (i == 0)
        {
            text.text = plot_9[i];
            img.sprite = damian;
        }
        else if (i == 1)
        {
            text.text = plot_9[i];
            img.sprite = jack3;
        }
        else if (i == 2)
        {
            text.text = plot_9[i];
            img.sprite = narrative;
        }
        else if (i == 3)
        {
            text.text = plot_9[i];
            img.sprite = narrative;
        }
        else if (i == 4)
        {
            text.text = plot_9[i];
            img.sprite = narrative;
        }
        else if (i == 5)
        {
            PD.addPlotStage();
            SaveData.Save(PD); 
            SceneManager.LoadScene("Menu");
        }
    }
}
