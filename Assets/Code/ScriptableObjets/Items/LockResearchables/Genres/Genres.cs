using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "New Genre", menuName = "Features/New Genre")]
public class Genres : LockResearchables
{
    [SerializeField] private Genres[] goodGenreCombosList;
    [SerializeField] private TargetAudence themeAudence;
    [SerializeField] private OptimalGenreSettings genreSettings;


    public bool GetSecondaryGenreCombo(Genres SecondaryGenre)
    {
        //Add to final Score if it matches
        if(goodGenreCombosList.Contains(SecondaryGenre))
            return true;
        //Reduce final socre
        return false;
    }

 
}

