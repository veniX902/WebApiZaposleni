using Microsoft.Data.SqlClient;
using System.Data;

namespace Employees.Models
{
    public class Person
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Person()
        {
            
        }
        public static List<Person> FetchAllPersons()
        {
            List<Person> allPersons = new List<Person>();
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = Program.Configuration.GetConnectionString("PrimaryConnectionString");
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT EmployeeID, FirstName, LastName, BirthDate From Employees", conn);
                    Person person = null;
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            person = new Person();
                            person.EmployeeId = Convert.ToInt32(reader["EmployeeID"]);
                            person.FirstName = reader["FirstName"].ToString();
                            person.LastName = reader["LastName"].ToString();
                            person.BirthDate = (DateTime)reader["BirthDate"];
                            allPersons.Add(person);
                        }
                    }
                }
            }
            catch(Exception)
            {

            }
            return allPersons;
        }
        public static int DeletePersonById (int personid)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Program.Configuration.GetConnectionString("PrimaryConnectionString");
            int rows = 0;
            try
            {
                using(conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("UPDATE Employees WHERE EmployeeID=@EmpolyeeID", conn);
                    SqlParameter myParam = new SqlParameter("@EmployeeID",SqlDbType.Int,9);
                    myParam.Value = personid;
                    command.Parameters.Add(myParam);
                    rows = command.ExecuteNonQuery();
                }
            }
            catch(Exception err)
            {

            }
            return rows;
        }

        public static Person FetchEmployeesById(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Program.Configuration.GetConnectionString("PrimaryConnectionString");
            Person person = null;
            try
            {
                using(conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT FirstName, LastName, BirthDate FROM Employees WHERE EmployeeID =" + id, conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        person = new Person();
                        person.EmployeeId = id;
                        person.FirstName = (string)reader["FirstName"];
                        person.LastName = (string)reader["LastName"];
                        person.BirthDate = (DateTime)reader["BirthDate"];
                    }
                }
            }
            catch(Exception err)
            {

            }
            return person;
           
        }
        public int UpdateEmployees()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Program.Configuration.GetConnectionString("PrimaryConnectrionString");
            int rows = 0;
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("UPDATE Employees FirstName=@FirstName, LastName=@LastName, @BirthDate=@BirthDate WHERE EmployeeID=EmployeeID", conn);

                    SqlParameter firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar);
                    firstNameParam.Value = FirstName;

                    SqlParameter lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar);
                    lastNameParam.Value = LastName;

                    SqlParameter birthDateParam = new SqlParameter("@BirthDate", SqlDbType.Date);
                    birthDateParam.Value = BirthDate;

                    SqlParameter myParam = new SqlParameter("@EmployeeID", SqlDbType.Int, 9);
                    myParam.Value = EmployeeId;

                    command.Parameters.Add(firstNameParam);
                    command.Parameters.Add(lastNameParam);
                    command.Parameters.Add(birthDateParam);
                    command.Parameters.Add(myParam);

                    rows = command.ExecuteNonQuery();
                }
            }
            catch(Exception err)
            {

            }
            return rows;
        }
        public int InsertPerson()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Program.Configuration.GetConnectionString("PrimaryConnectionString");
            int rows = 0;
            try
            {
                using (conn)
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO Employees(FirstName, LastName, BirthDate) VALUES(@FirstName, @LastName, @BirthDate);", conn);

                    SqlParameter firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar);
                    firstNameParam.Value = FirstName;

                    SqlParameter lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar);
                    lastNameParam.Value = LastName;

                    SqlParameter birthDateParam = new SqlParameter("@BirthDate", SqlDbType.Date);
                    birthDateParam.Value = BirthDate;

                    command.Parameters.Add(firstNameParam);
                    command.Parameters.Add(lastNameParam);
                    command.Parameters.Add(birthDateParam);

                    rows = command.ExecuteNonQuery();
                }
            }
            catch(Exception err)
            {

            }
            return rows;
        }
    }
}
