using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "New Genre", menuName = "Features/New Genre")]
public class Genres : LockResearchables
{
    [SerializeField] private Genres[] goodCombosList;
    [SerializeField] private ThemeTopic[] matchingTopics;
    public bool GetGoodCombo(Genres SecondaryGenre)
    {
        //Add to final Score if it matches
        if(goodCombosList.Contains(SecondaryGenre))
            return true;
        //Reduce final socre
        return false;
    }

    //We can use this to check if primary matches and Secondary Match 
    public bool GetThemeMatch(ThemeTopic matchTheme)
    {
        //Add to final Score if it matches
        if (matchingTopics.Contains(matchTheme))
            return true;
        //Reduce final socre
        return false;
    }
}

