using Microsoft.VisualStudio.TestTools.UnitTesting;
using PW.ExtensionsLibrary;
using System;
using System.Data.SQLite;

namespace PW.ExtensionsLibraryTest
{
  [TestClass]
  public class UnitTest1
  {

    [TestMethod]
    public void TestDBCommand()
    {
      string ConnectionString = "Data Source=:memory:;Version=3;New=True;";
      string sql;
      using (SQLiteConnection cnx = new SQLiteConnection(ConnectionString))
      {
        cnx.Open();

        string sqlTablePerson = "create table person (name varchar(20), age int)";
        using (SQLiteCommand cmd = new SQLiteCommand(sqlTablePerson, cnx))
        {
          cmd.ExecuteNonQuery();
        }

        sql = "insert into person (name, age) values ('John', 30)";
        using (SQLiteCommand cmd = new SQLiteCommand(sql, cnx))
        {
          cmd.ExecuteNonQuery();
        }

        using (SQLiteCommand cmd = new SQLiteCommand("select * from person where name = @name", cnx))
        {
          var parameter = cmd.CreateParameter();
          parameter.ParameterName = "@name";
          parameter.Value = "John";
          cmd.Parameters.Add(parameter);
          Assert.AreEqual(cmd.ActualCommandText(), "select * from person where name = 'John'", true);
        }

        //string sqlTableTeacher = "create table teacher (name varchar(20))";
        //using (SQLiteCommand cmd = new SQLiteCommand(sqlTableTeacher, cnx))
        //{
        //  cmd.ExecuteNonQuery();
        //}

      }
    }
  }
}
