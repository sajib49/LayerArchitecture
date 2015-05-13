using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerArchitectureApp.MODEL;

namespace LayerArchitectureApp.DAL
{
    public class PersonGateWay
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LayerArchitectureApp"].ConnectionString;
        public int InsertIntoGateWay(PersonClass aPerson)
        {
            
            SqlConnection aConnection = new SqlConnection(connectionString);

            string query = "INSERT INTO LayerArchitectureTable VALUES ('" + aPerson.name + "', '" + aPerson.age + "')";
            SqlCommand aCommand = new SqlCommand(query, aConnection);
            aConnection.Open();

            int rowEffect = aCommand.ExecuteNonQuery();
            aConnection.Close();
            return rowEffect;
        }

        public PersonClass IsNameExists(string aName)
        {
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM LayerArchitectureTable WHERE Name ='" + aName + "'";
            
            SqlCommand aCommand = new SqlCommand(query,aConnection);
            aConnection.Open();

            SqlDataReader reader = aCommand.ExecuteReader();

            PersonClass aPerson = null;
            while (reader.Read())
            {
                if (aPerson == null)
                {
                    aPerson = new PersonClass();
                }

                aPerson.Id = int.Parse(reader["ID"].ToString());
                aPerson.name = reader["Name"].ToString();
                aPerson.age = reader["Age"].ToString();
            }
            
           reader.Close();
            aConnection.Close();

            return aPerson;
        }

        List<PersonClass> allPersonList = new List<PersonClass>(); 
        public List<PersonClass> GetAllPerson()
        {
            SqlConnection aConnection = new SqlConnection(connectionString);

            string query = "SELECT * FROM LayerArchitectureTable";
            SqlCommand aCommand = new SqlCommand(query,aConnection);
            aConnection.Open();
            SqlDataReader aReader = aCommand.ExecuteReader();

            while (aReader.Read())
            {
                PersonClass aPerson = new PersonClass();
                aPerson.Id = int.Parse(aReader["ID"].ToString());
                aPerson.name = aReader["Name"].ToString();
                aPerson.age = aReader["Age"].ToString();

                allPersonList.Add(aPerson);
            }

            return allPersonList;
        }

        public PersonClass GetPersonByID(int personID)
        {
            SqlConnection aConnection = new SqlConnection(connectionString);

            string query = "SELECT * FROM LayerArchitectureTable WHERE ID= '" + personID + "' ";
            SqlCommand aCommand = new SqlCommand(query, aConnection);
            aConnection.Open();
            SqlDataReader aReader = aCommand.ExecuteReader();

            PersonClass aPerson = new PersonClass();
            while (aReader.Read())
            {
                
                aPerson.Id = int.Parse(aReader["ID"].ToString());
                aPerson.name = aReader["Name"].ToString();
                aPerson.age = aReader["Age"].ToString();

            }
            aReader.Close();
            aConnection.Close();
            return aPerson;
            
        }

        public int Update(PersonClass aPerson)
        {
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "UPDATE LayerArchitectureTable SET Name='" + aPerson.name + "',Age= '" + aPerson.age + "' WHERE ID= '"+aPerson.Id+"' ";
            SqlCommand aCommand = new SqlCommand(query, aConnection);
            aConnection.Open();
            int rowEffect = aCommand.ExecuteNonQuery();
            aConnection.Close();
            return rowEffect;
        }

        public int Delete(PersonClass aPerson)
        {
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "DELETE LayerArchitectureTable WHERE ID = '"+aPerson.Id+"' ";
             SqlCommand aCommand = new SqlCommand(query, aConnection);
            aConnection.Open();
            int rowEffect = aCommand.ExecuteNonQuery();
            aConnection.Close();
            return rowEffect;
        }

    }
}

