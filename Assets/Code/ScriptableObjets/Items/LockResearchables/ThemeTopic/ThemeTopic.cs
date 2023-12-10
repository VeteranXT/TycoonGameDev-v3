using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Theme",menuName = "Features/New Theme")]
public class ThemeTopic : LockResearchables
{
    [SerializeField] private List<Genres> _genresMatches;
    [SerializeField] private TargetAudence themeAudence;

    public bool MatchesWithGenre(Genres genres)
    {
        if(genres != null)
        {
            if (_genresMatches.Contains(genres))
            {
                return true;
            }
        }
        return false;
    }
}