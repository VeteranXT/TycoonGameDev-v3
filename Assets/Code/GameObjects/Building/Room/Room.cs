using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Room : MonoBehaviour
{
    private BuildingGrid roomGrid;
    private List<Employee> assingedEmployees = new List<Employee>();
    private List<Furniture> furnitureList = new List<Furniture>();

    public List<Furniture> FurnitureInRoom { get {  return furnitureList; } }
    public virtual void DoTask(Employee taskDone)
    {


    }
    public virtual void AddEmployeeToRoom(Employee employee)
    {
        if (employee != null)
        {
            employee.EventFiredEmployee += RemoveEmployeeFromRoom;
            employee.EventDoneTask += DoTask;
            assingedEmployees.Add(employee);           
        }
    }
    public virtual void AddEmployeesToRoom(Employee[] employees)
    {
        foreach (var newEmployee in employees)
        {
            if (newEmployee != null)
            {
                newEmployee.EventFiredEmployee += RemoveEmployeeFromRoom;
                newEmployee.EventDoneTask += DoTask;
                assingedEmployees.Add(newEmployee);
            }
        }
    }
    public virtual void RemoveEmployeeFromRoom(Employee employee)
    {
        if (employee != null)
        {
            employee.EventFiredEmployee -= RemoveEmployeeFromRoom;
            employee.EventDoneTask -= DoTask;
            assingedEmployees.Remove(employee);
        }
    }
    public virtual void RemoveEmployeesFromRoom(Employee[] employee)
    {
        foreach (var employeeinRoom in employee) 
        {
            if (employeeinRoom != null)
            {
                employeeinRoom.EventFiredEmployee -= RemoveEmployeeFromRoom;
                employeeinRoom.EventDoneTask -= DoTask;
                assingedEmployees.Remove(employeeinRoom);
            }
        }
        
    }
 
    public bool HasFreeWorkStation()
    {
        int freeStations = furnitureList.Where(x => x.IsAssignable && !x.IsAssiged()&& x.IsWorkStation).Count();
        
        return freeStations > 0;
    }
    public WorkFurniture GetFirstFreeWorkstation()
    {
        if (FurnitureInRoom != null && furnitureList.Count > 0)
        {
            foreach (var workStations in FurnitureInRoom)
            {
                WorkFurniture furn = workStations.GetComponent<WorkFurniture>();
                if (furn != null && furn.IsAssignable && !furn.IsAssiged())
                {
                    return furn;
                }
            }
        }
        return null;
    }
    public virtual void SetupTask(TaskDo task)
    {
    }
}