using Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Employee : MonoBehaviour, IEmployee
{
    [SerializeField] private AIPath path;
    [SerializeField] private AIDestinationSetter destination;
    [SerializeField] private List<CharacterStat> characterStats = new List<CharacterStat>();
    [SerializeField] private List<EmployeeNeeds> needsList;
    [SerializeField] private string firstName = "Joe";
    [SerializeField] private float salaryWage = 1_000;
    [SerializeField] private bool isCEO = false;
    private NeedFurniture needObj = null;
    private WorkFurniture workFurniture = null;
    private Room assignedRoom = null;
    private float workTimer = 1f;
    private float timer = 0;
    //TO DO: BREAKS!! like golfing, drinking coffe, watching tv, playing games
    private float breakTimer = 0;
    private float breakLength = 100;

    //TO DO: Subscribe to EmloyeeeSettings and set curreth length  to current settings
    private void SetBreakLenght(float lenght)
    {
        breakLength = lenght;
    }
    private EmployeeSate employeeState = EmployeeSate.Idle;

    #region Getter Setter
    public bool IsCEO { get { return isCEO; } }
    public float GetWage { get { return salaryWage; } }
    public string FirstName { get { return firstName; } }
    public List<CharacterStat> GetSkills { get; }
    public EmployeeSate EmpState { get { return employeeState; } }

    #endregion 
    float needsTimer = 0f;
    public virtual void Update()
    {
        //We have nowere to form 
        if (workFurniture == null)
        {
            //We are assigned to room
            if (assignedRoom != null)
            {
                float searchRadius = 300f;
                Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius);
                foreach (var collider in colliders)
                {
                    WorkFurniture freeTable = collider.GetComponent<WorkFurniture>();
                    //Check if that table is exits and that is not taken by other people in this room
                    if (freeTable != null && !freeTable.IsTaken)
                    {
                        //Found Free work station
                        freeTable.AssignFurniture(this);
                    }
                }
            }

            foreach (var need in needsList)
            {
                //Check if employee have needs
                if (GameplaySettings.HasNeeds)
                {
                    needsTimer += Time.deltaTime;
                    if (needsTimer >= 1f)
                    {
                        need.CurrentNeed -= need.Reducer;
                        needsTimer = 0f;
                    }
                }
                if (need.IsNeededToRefill)
                {
                    //Find Neariest object to fill need
                    needObj = FindNeariestNeedObject(need.ObjectToFullFillNeed);
                    employeeState = EmployeeSate.GoingToFullfillNeed;
                    destination.target = needObj.transform;
                }
                else if (need.IsCriticalyLow)
                {
                    //TO DO
                    //display need  icon in normal.
                    //Find Corespoding object
                    //Fill Need
                    //go back  to work
                }
                else
                {
                    //TO DO: Reduce Motivation
                }
            }
            switch (employeeState)
            {
                case EmployeeSate.Idle:
                    if (assignedRoom.CurrentTask != null)
                        employeeState = EmployeeSate.Working;
                    else
                        employeeState = EmployeeSate.Idle;
                    break;
                case EmployeeSate.Working:
                    //Do work in room
                    if (assignedRoom != null)
                    {
                        DoTask();
                    }
                    break;
                case EmployeeSate.GoingToFullfillNeed:
                    if (path.reachedDestination)
                    {
                       
                        //TO DO:
                        //Play Animation or wait there like dummy
                        //fullfill need
                        //Switch state after we fullfiled our need
                        employeeState = EmployeeSate.FullfilingNeeed;
                    }
                    break;
                case EmployeeSate.GoingBackToDesk:
                    //We are not in our at our work.
                    if(Vector3.Distance(transform.position,workFurniture.GetWorkPosition.position) < 1f)
                    {
                        destination.target = workFurniture.GetWorkPosition;
                    }
                    break;
                case EmployeeSate.FullfilingNeeed:
                    //Check if we reached our WorkSttatin
                    if (path.reachedDestination)
                    {
                        if (needObj != null)
                        {
                            foreach (var item in needsList)
                            {
                                if (item.NeedName == needObj.GetFullfillingNeed.NeedName)
                                {
                                    needObj.StartFullfiling(item);
                                }
                            }
                        }
                        employeeState = EmployeeSate.Working;
                    }
                    break;
                case EmployeeSate.NotAssignedToRoom:
                    //TO DO
                    //Roam Around like crazy person with a question mark above head 
                    //Enter random rooms for sake of confusion
                    //Touch random stuff
                    //Inspect random stuff
                    //Sabotage random people...?
                    //Quit out of boredom?
                    break;
            }
        }
    }

    public virtual void Start()
    {
        destination = GetComponent<AIDestinationSetter>();
        path = GetComponent<AIPath>();
        path.maxSpeed = 3f;
        needsList = Resources.LoadAll<EmployeeNeeds>("").ToList();
    }
    public void AddNewSkill(CharacterStat characterStat)
    {
        if (characterStats != null)
        {
            characterStats.Add(characterStat);
        }
    }

    public void AddNewNeed(EmployeeNeeds need)
    {
        needsList.Add(need);
    }
    public static void CreateInstance(EmployeeData employeeData, Vector3 positoon,Room room)
    {
        Employee em = Instantiate(employeeData.EmployeePrefabs, positoon, Quaternion.identity);
        em.Setup(employeeData);
        if(room != null)
        {
            em.assignedRoom = room;
        }
        else
        {
            //Wonder around
            em.employeeState = EmployeeSate.NotAssignedToRoom;
        }
    }
    public virtual void Setup(EmployeeData employeeData)
    {
        AddNewSkill(new CharacterStat(employeeData.GraphicsStat));
        AddNewSkill(new CharacterStat(employeeData.ProgrammingStat));
        AddNewSkill(new CharacterStat(employeeData.SoundStat));
        AddNewSkill(new CharacterStat(employeeData.AiSkill));
        AddNewSkill(new CharacterStat(employeeData.PhysicsSkill));
        this.firstName = name;
    }
    public virtual void DoNeed(EmployeeNeeds neeed)
    {
        foreach(var item in needsList)
        {
            if(item.NeedName == neeed.NeedName)
            {
                item.FullfillNeed();
            }
        }
    }
    public virtual void DoTask()
    {
        if (assignedRoom != null && assignedRoom.CurrentTask != null)
            timer -= Time.deltaTime;

        if (timer >= workTimer)
        {
            if(assignedRoom != null && assignedRoom.CurrentTask != null)
            {
               // assignedRoom.DoTask();
            }
            else
            {
                employeeState = EmployeeSate.Idle;
            }
            
            workTimer = 0;
        }
    }
    public virtual void GoToWorkAfterFullfillNeed()
    {
        employeeState = EmployeeSate.GoingBackToDesk;

    }
    //Find neariest  Need object to fullfill need
    private NeedFurniture FindNeariestNeedObject(NeedFurniture[] gameObject)
    {
        float searchRadius = 300f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius);

        foreach (var collider in colliders)
        {
            NeedFurniture fullfilingFurnturie = collider.GetComponent<NeedFurniture>();

            foreach (var needs in gameObject)
            {

                if (fullfilingFurnturie != null && !fullfilingFurnturie.IsTaken() && fullfilingFurnturie.GetFullfillingNeed.NeedName == needs.name)
                {
                    return fullfilingFurnturie; 
                }
            }
        }
        return null;
    }  
}