using UnityEngine;

internal class GameplaySettings : MonoBehaviour
{
    private static bool haveNeeds = true;

    public static bool HasNeeds { get { return haveNeeds; } }
    public void EmployessHaveNeeds(bool Needs)
    {
        haveNeeds = Needs;
    }
}