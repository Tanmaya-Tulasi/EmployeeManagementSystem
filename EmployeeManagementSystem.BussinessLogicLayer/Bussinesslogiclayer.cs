using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeManagementSystem.BussinessLogicLayer
{
   
    public class Bussinesslogiclayer
    {
        public int id;
        public string name;
        public int age;

        public void AddEmployee(int id,string name,int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
          
        }
         public void UpdateEmployee()
        {
            Console.WriteLine("Enter new Employee");
            string new_name = Console.ReadLine();
            Console.WriteLine("Enter new age");
            int new_age =Convert.ToInt32(Console.ReadLine());
            this.name =new_name;
            this.age = new_age;
           
        }
        public void DisplayEmployee()
        {
            Console.WriteLine("id:{0} ,name:{1} ,age:{2}" ,this.id,this.name,this.age);
        }
        public void SearchgEmployee()
        {
            Console.WriteLine("name" + this.name);
        }

    }
}
