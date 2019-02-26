using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;

namespace AnimalShelter.Models
{
  public class Cat
  {
    private string _name;
    private string _breed;
    private char _sex;
    private DateTime _admissionDate;


    public Cat(string name, string breed, char sex, DateTime admissionDate)
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

    public static List<Cat> GetAllCats()
    {
      List<Cat> allCats = new List<Cat> {};
      MySqlConnection conn= DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM cat;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int catId = rdr.GetInt32(0);
        string catName = rdr.GetString(1);
        string catBreed = rdr.GetString(2);
        char catSex = rdr.GetChar(3);
        DateTime catDate = rdr.GetDateTime(4);
        Cat newCat = new Cat(catName, catBreed, catSex, catDate);
        allCats.Add(newCat);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCats;

    }

    public static List<Cat> GetAllCatsByBreed()
    {
      List<Cat> allCats = new List<Cat> {};
      MySqlConnection conn= DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM cat;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int catId = rdr.GetInt32(0);
        string catName = rdr.GetString(1);
        string catBreed = rdr.GetString(2);
        char catSex = rdr.GetChar(3);
        DateTime catDate = rdr.GetDateTime(4);
        Cat newCat = new Cat(catName, catBreed, catSex, catDate);
        allCats.Add(newCat);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      List<Cat> catListBreed = allCats.OrderBy(cat => cat._breed).ToList();
      return catListBreed;

    }




  }

  public static class DBConfiguration
  {
    public static string ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=animalshelter;";
  }

}
