using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace AnimalShelter.Models
{
  public class Dog
  {
    private string _name;
    private string _breed;
    private char _sex;
    private DateTime _admissionDate;

    public Dog(string name, string breed, char sex, DateTime admissionDate)
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

    public static List<Dog> GetAllDogs()
    {
      List<Dog> allDogs = new List<Dog> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM dog;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int dogId = rdr.GetInt32(0);
        string dogName = rdr.GetString(1);
        string dogBreed = rdr.GetString(2);
        char dogSex = rdr.GetChar(3);
        DateTime dogDate = rdr.GetDateTime(4);
        Dog newDog = new Dog(dogName, dogBreed, dogSex, dogDate);
        allDogs.Add(newDog);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allDogs;
    }

    public static class DBConfiguration
    {
      public static string ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=animalshelter;";
    }
  }
}
