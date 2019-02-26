using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace AnimalShelter.Models
{
  public class Rabbit
  {
    private string _name;
    private string _breed;
    private char _sex;
    private DateTime _admissionDate;

    public Rabbit(string name, string breed, char sex, DateTime admissionDate)
    {
      _name = name;
      _breed = breed;
      _sex = sex;
      _admissionDate = admissionDate;
    }

    public string GetName()
    {
      return _name;
    }
    public string GetBreed()
    {
      return _breed;
    }

    public char GetSex()
    {
      return _sex;
    }

    public DateTime GetAdmissionDate()
    {
      return _admissionDate;
    }

    public static List<Rabbit> GetAllRabbits()
    {
      List<Rabbit> allRabbits = new List<Rabbit> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM rabbit;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int rabbitId = rdr.GetInt32(0);
        string rabbitName = rdr.GetString(1);
        string rabbitBreed = rdr.GetString(2);
        char rabbitSex = rdr.GetChar(3);
        DateTime rabbitDate = rdr.GetDateTime(4);
        Rabbit newRabbit = new Rabbit(rabbitName, rabbitBreed, rabbitSex, rabbitDate);
        allRabbits.Add(newRabbit);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allRabbits;
    }

    public static class DBConfiguration
    {
      public static string ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=animalshelter;";
    }
  }
}
