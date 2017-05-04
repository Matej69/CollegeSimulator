using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public static EndGame instance;

    public Sprite spr_graveyard;
    public Sprite spr_house;

    Image background;

    void Awake()
    {
        instance = this;

        background = GetComponent<Image>();
    }
    

    public void TriggerEndGame(StatsInfo _info)
    {
        background.color = new Color(background.color.r, background.color.g, background.color.b, 1);
        AudioManager.instance.volumeState = AudioManager.E_VOLUME_STATE.NOT_MUTED;
        //BAD ENDING
        if(_info.GetStatsValue(StatsInfo.E_STATS_ID.ECTS) < LevelManager.MAX_ECTS)
        {
            AudioManager.instance.SetBackgroundMusic(AudioManager.E_AUDIO_ID.SAD_ENDING);
            background.sprite = spr_graveyard;
            Textbox.GetInstance().EnableMessageBox(new List<TextboxMessageInfo>() {
                new TextboxMessageInfo("You had scored " + _info.GetStatsValue(StatsInfo.E_STATS_ID.ECTS)+ "/" + LevelManager.MAX_ECTS + " ECTS points."),
                new TextboxMessageInfo("You FAILED and couldn't get the degree."),
                new TextboxMessageInfo("You couldn't make enough money to survive so you started cleaning toilets for living."),
                new TextboxMessageInfo("Your girlfriend said that you can't live in her house anymore and threw you out."),
                new TextboxMessageInfo("You died on street."),
                new TextboxMessageInfo("R.I.P.")
            });
        }
        //GOOD ENDING
        else
        {
            background.sprite = spr_house;
            //GOOD ENDING 1
            if (_info.GetStatsValue(StatsInfo.E_STATS_ID.INTELLIGENCE) < 300 && _info.GetStatsValue(StatsInfo.E_STATS_ID.SOCIAL) < 300)
            {
                Textbox.GetInstance().EnableMessageBox(new List<TextboxMessageInfo>() {
                    new TextboxMessageInfo("You had scored " + _info.GetStatsValue(StatsInfo.E_STATS_ID.ECTS)+ "/" + LevelManager.MAX_ECTS + " ECTS points."),
                    new TextboxMessageInfo("You left college with less then 300 intelligence so you ended up cleaning houses for living."),
                    new TextboxMessageInfo("Your social skills were also less then 300 so you couldn't find wife or any friends."),
                    new TextboxMessageInfo("You are currently living at your mums house."),
                    new TextboxMessageInfo("Your mum showers every 13 days."),
                    new TextboxMessageInfo("You hate your life and wish you were dead.")
                });
            }
            //GOOD ENDING 2
            if (_info.GetStatsValue(StatsInfo.E_STATS_ID.INTELLIGENCE) >= 300 && _info.GetStatsValue(StatsInfo.E_STATS_ID.SOCIAL) < 300)
            {
                Textbox.GetInstance().EnableMessageBox(new List<TextboxMessageInfo>() {
                    new TextboxMessageInfo("You had scored " + _info.GetStatsValue(StatsInfo.E_STATS_ID.ECTS)+ "/" + LevelManager.MAX_ECTS + " ECTS points."),
                    new TextboxMessageInfo("You left college with more then 300 intelligence so you ended up working as the video game programmer."),
                    new TextboxMessageInfo("Since your social skills were less then 300 you married your average looking cousin."),
                    new TextboxMessageInfo("Since she was independent woman you could pay more attention to work."),
                    new TextboxMessageInfo("You created the most selling game of decade called 'Blenderman' where you need to collect 69 pages."),
                    new TextboxMessageInfo("You have sold it for 2.5 billion dollars to Apple and bought a house on Beverly Hills."),
                    new TextboxMessageInfo("Your ex girlfriend tried to sue you but failed."),
                    new TextboxMessageInfo("Your uncle slapped you for marrying your cousin but was cool after your 'Blenderman' hit 1.4 billion mark."),
                    new TextboxMessageInfo("You did it! Your mum is proud of you.")
                });
            }
            //GOOD ENDING 3
            if (_info.GetStatsValue(StatsInfo.E_STATS_ID.INTELLIGENCE) < 300 && _info.GetStatsValue(StatsInfo.E_STATS_ID.SOCIAL) >= 300)
            {
                Textbox.GetInstance().EnableMessageBox(new List<TextboxMessageInfo>() {
                    new TextboxMessageInfo("You had scored " + _info.GetStatsValue(StatsInfo.E_STATS_ID.ECTS)+ "/" + LevelManager.MAX_ECTS + " ECTS points."),
                    new TextboxMessageInfo("You left college with less then 300 intelligence so you ended up being unemployed for 2 years."),
                    new TextboxMessageInfo("As you were walking home some guy tried to sell you book but you sold him pen by accident."),
                    new TextboxMessageInfo("You discovered you have a gift and started to sell all stuff you could find."),
                    new TextboxMessageInfo("Since your intelligence were less then 300 you accidentally sold your pills to stranger."),
                    new TextboxMessageInfo("You had seizure, ended up in hospital and almost died."),
                    new TextboxMessageInfo("Stranger was feeling sorry for your stupidity and decided to employ you in his firm as window cleaner."),
                    new TextboxMessageInfo("To this day you keep telling yourself.... 'Don't look down'")
                });
            }
            //GOOD ENDING 4
            if (_info.GetStatsValue(StatsInfo.E_STATS_ID.INTELLIGENCE) >= 300 && _info.GetStatsValue(StatsInfo.E_STATS_ID.SOCIAL) >= 300)
            {
                Textbox.GetInstance().EnableMessageBox(new List<TextboxMessageInfo>() {
                    new TextboxMessageInfo("You had scored " + _info.GetStatsValue(StatsInfo.E_STATS_ID.ECTS)+ "/" + LevelManager.MAX_ECTS + " ECTS points."),
                    new TextboxMessageInfo("You left college with more then 300 intelligence and started your own company."),
                    new TextboxMessageInfo("Since your social skills were more then 300 you found couple of friends and started going to clubs every third night."),
                    new TextboxMessageInfo("Many illegal substances were being used during your nightclub adventures."),
                    new TextboxMessageInfo("One day you woke up in hospital and had no idea what happend."),
                    new TextboxMessageInfo("From that day you decided that weed is only way to go."),
                    new TextboxMessageInfo("You started selling shirts with cannabis sign and made 45.4 million dollars."),
                    new TextboxMessageInfo("You just bought more weed and married Snoop Dogs uncle."),
                    new TextboxMessageInfo("You were high.")
                });
            }
        }
    }





}
