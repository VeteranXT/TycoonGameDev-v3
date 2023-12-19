using Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Employee : MonoBehaviour, IEmployee
{
    [SerializeField] private AIPath path;
    [SerializeField] private AIDestinationSetter destination;
    [SerializeField] private List<CharacterStat> characterStats = new();
    [SerializeField] private string firstName = "Joe";
    [SerializeField] private float salaryWage = 1_000;
    [SerializeField] private bool isCEO = false;
    [SerializeField] private EmployeeSate employeeState = EmployeeSate.Idle;
    [SerializeField] private NeedFurniture needObj = null;
    [SerializeField] private WorkFurniture workTable = null;
    //[SerializeField] private Room assignedRoom = null;
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
    }
    public virtual void Update()
    {
      
        

        UpdateEmployeeState();
    }
    //private void FindWorkSation()
    //{
    //    if(assignedRoom.HasFreeWorkStation())
    //    {
    //        workTable = assignedRoom.GetFirstFreeWorkstation();
    //        workTable.Assign(this);
    //    }     
    //}
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
            case EmployeeSate.Idle:
                break;
            case EmployeeSate.Thinking:
                break;
            case EmployeeSate.Working:
                break;
        }
    }

    public virtual void DoTask()
    {
        EventDoneTask?.Invoke(this);
    }
    //Check if we are in range of our workstation
   
    //public static void CreateEmployeeInstance(EmployeeData employeeData, Vector3 positoon),//Room room)
    //{
    //    Employee em = Instantiate(employeeData.EmployeePrefabs, positoon, Quaternion.identity);
    //    em.Setup(employeeData);
    //    //if(room != null)
    //        //em.assignedRoom = room;
    //}
    public virtual void Setup(EmployeeData employeeData)
    {
        AddNewSkill(new CharacterStat(employeeData.GraphicsStat));
        AddNewSkill(new CharacterStat(employeeData.ProgrammingStat));
        AddNewSkill(new CharacterStat(employeeData.SoundStat));
        AddNewSkill(new CharacterStat(employeeData.AiSkill));
        AddNewSkill(new CharacterStat(employeeData.PhysicsSkill));
        this.firstName = name;
    }
  
    private bool WeAtWorkStation { get { return Vector3.Distance(transform.position, workTable.transform.position) < 1f; } }
 
    #region Modding?
    public void AddNewSkill(CharacterStat characterStat)
    {
        characterStats?.Add(characterStat);
    }


    #endregion
}