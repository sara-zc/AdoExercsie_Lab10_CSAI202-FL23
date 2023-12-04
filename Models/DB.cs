using System.Data;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.X86;

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

        public string UpdateEmployee(Employee emp)
        {
            string msg = "";
            string query = $"update Employee set fname='{emp.Fname}', lname='{emp.Lname}', minit='{emp.Minit}' where SSN={emp.SSN}";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                msg = cmd.ExecuteNonQuery().ToString();

            }
            catch (SqlException err)
            {
                msg = err.Message;
            }
            finally
            {
                con.Close();
            }
            return msg;
        }

        public Employee? getEmployee(string ssn)
        {
            string msg = "";
            string query = $"select * from Employee where SSN={ssn}";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();

            Employee employee = new Employee();

            try
            {
                con.Open();
                dt.Load(cmd.ExecuteReader());

                // handle not found employee
                if(dt.Rows.Count == 0)
                {
                    msg = "No employee with this ssn found";
                    Console.WriteLine(msg);
                    return null;
                }

                // transfer data from returned datatable into employee object
                employee.SSN = dt.Rows[0]["SSN"].ToString();
                employee.Fname = dt.Rows[0]["fname"].ToString();
                employee.Lname = dt.Rows[0]["lname"].ToString();
                employee.Minit = ((string)dt.Rows[0]["minit"])[0];  // minit is coming from db as string, but it's a char in the Employee.cs, so I'm just converting from string to char here.

            }
            catch (SqlException err)
            {
                msg = err.Message;
                Console.WriteLine(msg);
            }
            finally
            {
                con.Close();
            }
            return employee;

        }
    }
}
