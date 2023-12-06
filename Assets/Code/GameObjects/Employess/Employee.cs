using Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private EmployeeSate employeeState = EmployeeSate.Idle;
    [SerializeField] private NeedFurniture needObj = null;
    [SerializeField] private WorkFurniture workTable = null;
    [SerializeField] private Room assignedRoom = null;
    [SerializeField] private float workTimer = 1f;
    [SerializeField] private float work = 0;
    public event Action<Employee> EventDoneTask;
    public event Action<Employee> EventFiredEmployee;
    #region Getters Setters
    public string FirstName { get { return firstName; } }
    public float GetWage { get { return salaryWage; } }
    public bool IsCEO { get { return isCEO; } }
    public List<CharacterStat> GetSkills { get; }
    public EmployeeSate EmployeeState { get { return employeeState; } }

    #endregion

    public virtual void Start()
    {
        destination = GetComponent<AIDestinationSetter>();
        path = GetComponent<AIPath>();
        path.maxSpeed = 3f;
        path.gravity = Vector3.zero;

        needsList = Resources.LoadAll<EmployeeNeeds>("").ToList();
    }
    public virtual void Update()
    {
        if (GameplaySettings.HasNeeds)
        {
            //Check your needs.
            foreach (var need in needsList)
            {
                //needsTimer += Time.deltaTime;
                //if (needsTimer >= 1f)
                //{
                //    need.ReuceNeed();
                //    needsTimer = 0f;
                //}

                //Is this critical need to fullfill
                //Bathroom, Eat etc?
                //if (need.IsCritical && need.IsNeededToRefill)
                //{
                //    TO DO: wait for break
                //    Find object
                //    Fullfill need
                //}
                //else if (need.IsCriticalyLow)
                //{

                //}
            }
        }

        UpdateEmployeeState();
    }
    private void FindWorkSation()
    {
        if(assignedRoom.HasFreeWorkStation())
        {
            workTable = assignedRoom.GetFirstFreeWorkstation();
            workTable.Assign(this);
        }     
    }

    public void FireEmployee()
    {
        if (CanFire())
        {
            EventFiredEmployee?.Invoke(this);
            workTable.UnAssign();
            Destroy(gameObject);
        }
    }
    public bool CanFire()
    {
        if (IsCEO)
        {
            return false;
        }
        return true;
    }

    private void UpdateEmployeeState()
    {
        switch (employeeState)
        {
            case EmployeeSate.LookingForWorkTable:
                FindWorkSation();
                break;
            case EmployeeSate.GoingToWorkTable:
                if (!WeAtWorkStation())
                {
                    if(workTable != null)
                    {
                        destination.target = workTable.transform;
                        if (WeAtWorkStation())
                            employeeState = EmployeeSate.Working;
                    }
                    else
                    {
                        employeeState = EmployeeSate.LookingForWorkTable;
                    }

                }
                break;
            case EmployeeSate.Idle:
                if(assignedRoom.CurrentTask != null)
                    employeeState = EmployeeSate.Working;
                break;
            case EmployeeSate.Working:
                if(assignedRoom.CurrentTask != null)
                    DoTask();
                else
                    employeeState = EmployeeSate.Idle;
                break;
                //TO DO rest of needs
            case EmployeeSate.GoingToBreak:
                break;
            case EmployeeSate.OnBreak:
                break;
            case EmployeeSate.GointToFillNeed:
                break;
            case EmployeeSate.FillingNeed:
                break;
        }
    }

    public virtual void DoTask()
    {
        if (assignedRoom != null && assignedRoom.CurrentTask != null)
            work += Time.deltaTime;
        if (work >= workTimer)
        {
            workTimer = 0;
            EventDoneTask?.Invoke(this);
        }
    }

    private bool WeAtWorkStation()
    {
        return Vector3.Distance(transform.position, workTable.transform.position) < 1f;
    }
    public static void CreateInstance(EmployeeData employeeData, Vector3 positoon,Room room)
    {
        Employee em = Instantiate(employeeData.EmployeePrefabs, positoon, Quaternion.identity);
        em.Setup(employeeData);
        if(room != null)
            em.assignedRoom = room;
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
                //TO DO:
                //Do Animation need
                //Resert need
            }
        }
    }

    #region Modding?
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
    #endregion
}