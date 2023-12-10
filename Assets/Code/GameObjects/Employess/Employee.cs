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
    [SerializeField] private float workTime = 1f;
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
                //TO DO: Do it late in development
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
                if (!WeAtWorkStation)
                {
                    destination.target = workTable.transform;
                    if (WeAtWorkStation)
                    {
                        employeeState = EmployeeSate.Working;
                    }
                }
                break;
            case EmployeeSate.Idle:
                //TO Do: Check if have things to do?
                break;
            case EmployeeSate.Working:
                work += Time.deltaTime;
                if(work >= workTime)
                {
                    DoTask();
                    work = 0;
                }
                break;
            case EmployeeSate.GoingToBreak:
                break;
            case EmployeeSate.OnBreak:
                break;
            case EmployeeSate.GoingToFillNeed:
                //TO DO:
                //Scan are
                break;
            case EmployeeSate.FillingNeed:
                break;
        }
    }

    public virtual void DoTask()
    {
        EventDoneTask?.Invoke(this);
    }
    //Check if we are in range of our workstation
   
    public static void CreateEmployeeInstance(EmployeeData employeeData, Vector3 positoon,Room room)
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
        //TO DO:
 
    }
    private bool WeAtWorkStation { get { return Vector3.Distance(transform.position, workTable.transform.position) < 1f; } }
 
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