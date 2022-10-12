
using EmployeeManagementSystem.BussinessLogicLayer;
using EmployeeManagementSystem.Entitties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EmployeeManagementSystem.Presentation
{
    class program
    {
       

        public static void Main( )
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=DESKTOP-ACVD8RJ;Initial Catalog=EmployeeDB;Integrated Security=True";
            ArrayList myemployee = new ArrayList();
            int id;
            string name;
            int age;
            int choice;
            do
            {
                Console.WriteLine("1.Add a Employee");
                Console.WriteLine("2.Display a Employee");
                Console.WriteLine("3.seach a Employee");
                Console.WriteLine("4.update a Employee");
                Console.WriteLine("5.delete a Employee");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Entert choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                       
                        try
                        {
                            sqlConnection = new SqlConnection(connectionString);
                            sqlConnection.Open();
                            Console.WriteLine("Connected");
                            Console.WriteLine("Enter id");
                            id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Employee name:");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter age");
                            age = Convert.ToInt32(Console.ReadLine());

                            Bussinesslogiclayer obj = new Bussinesslogiclayer();
                            obj.AddEmployee(id, name,age);
                            myemployee.Add(obj);
                            string insertQuery = "INSERT INTO Employee(id,name,age)VALUES(" + id + ",'" + name + "',"+age+")";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("inserted");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case 2:
                        foreach (Bussinesslogiclayer product in myemployee)
                        {
                            product.DisplayEmployee();
                        }


                        break;
                    case 3:
                        Console.WriteLine("Enter  Employee id");
                        id = Convert.ToInt32(Console.ReadLine());
                        foreach (Bussinesslogiclayer product in myemployee)
                        {
                            if (id == product.id)
                            {
                                product.DisplayEmployee();
                                break;
                            }
                        }
                        break;
                    case 4:
                        try
                        {
                            sqlConnection = new SqlConnection(connectionString);
                            sqlConnection.Open();
                            Console.WriteLine("Connected");
                            Console.WriteLine("Enter id");
                            id = Convert.ToInt32(Console.ReadLine());
                            foreach (Bussinesslogiclayer product in myemployee)
                            {
                                if (id == product.id)
                                {
                                    product.UpdateEmployee();
                                    

                                    string updatequery = "update dbo.Employee set name='" + product.name + "',age=" + product.age + " where id=" + product.id + "";
                                    SqlCommand updateCommand = new SqlCommand(updatequery, sqlConnection);
                                    updateCommand.ExecuteNonQuery();
                                    Console.WriteLine("updated");
                                }
                                break;
                            }
                            
                            
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case 5:
                        sqlConnection = new SqlConnection(connectionString);
                        sqlConnection.Open();
                        Console.WriteLine("Connected");
                        sqlConnection = new SqlConnection(connectionString);
                        sqlConnection.Open();
                        Console.WriteLine("Connected");
                        Console.WriteLine("Enter id");
                        id = Convert.ToInt32(Console.ReadLine());
                        int i = 0;
                        foreach (Bussinesslogiclayer product in myemployee)
                        {
                            if (id == product.id)
                            {

                                break;
                            }
                            i += 1;
                        }
                        myemployee.RemoveAt(i);
                        string deletequery = "delete from dbo.Employee where id =" + id + "";
                        SqlCommand deleteCommand = new SqlCommand(deletequery, sqlConnection);
                        deleteCommand.ExecuteNonQuery();
                        Console.WriteLine("deleted");

                        break;
                    default:
                        break;


                }

                } while (choice != 0) ;

            }

       
    }

    }
