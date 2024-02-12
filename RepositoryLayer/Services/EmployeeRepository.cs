using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        string connectionstring = @"Data Source=BOOK-L13QO8KE6K\SQLEXPRESS01;Initial Catalog=ApiCoreDb;Integrated Security=True";

        public IEnumerable<Employee> GetAllEmployees()
        {

            List<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {

                SqlCommand cmd = new SqlCommand("spGetAllEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Employee employee = new Employee();

                    employee.Id = Convert.ToInt32(dataReader["Id"]);
                    employee.Name = dataReader["Name"].ToString();
                    employee.ProfileImage = dataReader["ProfileImage"].ToString();
                    employee.Gender = dataReader["Gender"].ToString();
                    employee.Department = dataReader["Department"].ToString();
                    employee.Salary = Convert.ToInt64(dataReader["Salary"]);
                    employee.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                    employee.Notes = dataReader["Notes"].ToString();
                    employees.Add(employee);

                }
                conn.Close();
                return employees;
            }
        }


        public bool AddEmployee(EmployeeModel employee)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;

            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;

            }
        }

        public bool DeleteEmployee(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { conn.Close(); }
                return false;
            }
        }



        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spGetEmployeeById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {

                        employee.Id = Convert.ToInt32(dataReader["Id"]);
                        employee.Name = dataReader["Name"].ToString();
                        employee.ProfileImage = dataReader["ProfileImage"].ToString();
                        employee.Gender = dataReader["Gender"].ToString();
                        employee.Department = dataReader["Department"].ToString();
                        employee.Salary = Convert.ToInt64(dataReader["Salary"]);
                        employee.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                        employee.Notes = dataReader["Notes"].ToString();

                    }
                    return employee;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return null;

            }
        }

        public Employee Login(LoginModel loginModel)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
             
                    SqlCommand cmd = new SqlCommand("spLoginModel", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", loginModel.Id);
                    cmd.Parameters.AddWithValue("@Name", loginModel.Name);
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Employee model = new Employee();
                        model.Id = Convert.ToInt32(dataReader["Id"]);
                        model.Name = dataReader["Name"].ToString();
                        return model;
                    }
                    return null; ;


                }
    }
        public IEnumerable<Employee> GetEmployeeByChar(string letter)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spGetEmployeeByChar", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", letter);
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Employee employee = new Employee();

                        employee.Id = Convert.ToInt32(dataReader["Id"]);
                        employee.Name = dataReader["Name"].ToString();
                        employee.ProfileImage = dataReader["ProfileImage"].ToString();
                        employee.Gender = dataReader["Gender"].ToString();
                        employee.Department = dataReader["Department"].ToString();
                        employee.Salary = Convert.ToInt64(dataReader["Salary"]);
                        employee.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                        employee.Notes = dataReader["Notes"].ToString();
                        employees.Add(employee);


                    }
                    return employees;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return null;

            }
        }

        public IEnumerable<Employee> GetEmployeeByDate(DateTime date)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spGetEmployeeByDate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@date", date);
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Employee employee = new Employee();

                        employee.Id = Convert.ToInt32(dataReader["Id"]);
                        employee.Name = dataReader["Name"].ToString();
                        employee.ProfileImage = dataReader["ProfileImage"].ToString();
                        employee.Gender = dataReader["Gender"].ToString();
                        employee.Department = dataReader["Department"].ToString();
                        employee.Salary = Convert.ToInt64(dataReader["Salary"]);
                        employee.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                        employee.Notes = dataReader["Notes"].ToString();
                        employees.Add(employee);


                    }
                    return employees;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return null;

            }
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("spGetByName",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", name);
                conn.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Employee employee = new Employee();

                    employee.Id = Convert.ToInt32(dataReader["Id"]);
                    employee.Name = dataReader["Name"].ToString();
                    employee.ProfileImage = dataReader["ProfileImage"].ToString();
                    employee.Gender = dataReader["Gender"].ToString();
                    employee.Department = dataReader["Department"].ToString();
                    employee.Salary = Convert.ToInt64(dataReader["Salary"]);
                    employee.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                    employee.Notes = dataReader["Notes"].ToString();
                    employees.Add(employee);
                    return employees;


                }
                conn.Close();
             
            return null;

        }
    }
                    

        }


    }

    

