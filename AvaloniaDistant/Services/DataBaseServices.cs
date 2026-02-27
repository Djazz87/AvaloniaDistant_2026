using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AvaloniaDistant.Models;
using CommunityToolkit.Mvvm.Input;
using MySqlConnector;
namespace AvaloniaDistant.Services;

public class DataBaseServices
{
    private static MySqlConnection _connection;

    static DataBaseServices()
    {
        _connection = new MySqlConnection(
            "database=1125_Solop;user id=student;password=student;port=3306;server=192.168.200.13;characterset=utf8");
    }

    public static List<IllnessRecordDTO> GetIllnessRecords()
    {
        string sql = @"SELECT
    r.Id,r.StartDate,r.EndDate,r.DiagnosisNote,
    e.Id AS EmployeeId,e.FullName,e.Position,e.HireDate,
    d.Id AS DepartmentId,d.Name AS DepartmentName,d.Floor,
    t.Id AS IllnessTypeId,t.Name AS IllnessName,t.IsInfectious,t.QuarantineDays
FROM illnessrecords r  JOIN employees e ON r.EmployeeId = e.Id JOIN departments d ON e.DepartmentId = d.Id
JOIN illnesstypes t ON r.IllnessTypeId = t.Id;";

        List<IllnessRecordDTO> list = new();

        if (OpenConnection())
        {
            using var cmd = new MySqlCommand(sql, _connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new IllnessRecordDTO()
                {
                    FullName = reader.GetString(name: "FullName"),
                    Department = reader.GetString("DepartmentName"),
                    StartDate = reader.GetDateTime("StartDate"),
                    EndDate = reader.GetDateTime("EndDate"),
                    Days = reader.GetInt32("QuarantineDays"),
                    Illness = reader.GetString("IllnessName"),
                });





            }

            CloseConnection();
        }
       return list;
    }




    static bool OpenConnection()
    {
        try
        {
            _connection.Open();
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }
    
    static void CloseConnection()
    {
        try
        {
            _connection.Close();
        }
        catch (Exception e)
        {
        }
    }
    
    
    
}