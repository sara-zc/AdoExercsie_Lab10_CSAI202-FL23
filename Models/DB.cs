using System.Data;
using System.Data.SqlClient;

namespace FL23_Lab10_AdoExercise.Models
{
    public class DB
    {
        public string connectionString { get; set; }
        public SqlConnection con = new SqlConnection();

        public DB() {
            connectionString = "Data Source=DESKTOP-1DD8VBL;Integrated Security=True;Initial Catalog=COMPANYDB_Lab10";
            con.ConnectionString = connectionString;
        }

        public DataTable ReadTable(string table)
        {
            DataTable dt = new DataTable();
            dt.TableName = table;
            string query = "select * from Employee";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                dt.Load(cmd.ExecuteReader());

            } catch(SqlException err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public string AddEmployee(Employee emp)
        {
            string query = $"insert into Employee(fname, minit, lname, ssn, bdate) " +
                $"values('{emp.Fname}', '{emp.Minit}', '{emp.Lname}', '{emp.SSN}','{emp.BirthDate}')";

            SqlCommand cmd = new SqlCommand(query, con);
            string res = "";

            try
            {
                con.Open();
                res = cmd.ExecuteNonQuery().ToString();
            }
            catch (SqlException err)
            {
                Console.WriteLine(err.Message);
                res = err.Message;
            }
            finally
            {
                con.Close();
            }
            return res;
        }

        public string DeleteEmployee(string ssn)
        {
            string msg = "";
            string query = $"delete from Employee where SSN={ssn}";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                msg = cmd.ExecuteNonQuery().ToString();

            } catch(SqlException err)
            {
                msg = err.Message;
            }
            finally
            {
                con.Close();
            }
            return msg;
        }
    }
}
