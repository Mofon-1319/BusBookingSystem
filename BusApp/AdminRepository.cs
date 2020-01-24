using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BusApp
{    interface iAdminRepository
    {
        void LogIn();
        void SignUp();
    }

    class AdminRepository : iAdminRepository
    {
        public void LogIn()
        {
            List<Customer> adminList = new List<Customer>();

            using (SqlConnection sqlConnection = Connection.GetDBConnection())
            {
                sqlConnection.Open();
                string sql = "Get_Details_Admin";
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "UserLogin_Table");
                foreach (DataRow i in dataSet.Tables["UserLogin_Table"].Rows)
                {
                    Customer user = new Customer(i[0].ToString(), i[1].ToString());
                    adminList.Add(user);
                }
            }
            Console.WriteLine("Enter your User Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();
            int count = 0;
            foreach (Customer i in adminList)
            {
                if (name == i.userId && password == i.userPassword)
                {
                    count = 1;
                    break;
                }
            }
            adminList.Clear();
            if (count == 1)
            {
                Console.WriteLine("Logged in successfully");
                //AdminRepository busList = new AdminRepository();
                //busList.ViewDetails();
            }
            else
            {
                Console.WriteLine("Invalid Account");
            }
        }

        public void SignUp()
        {
            using (SqlConnection sqlConnection = Connection.GetDBConnection())
            {
                sqlConnection.Open();
                Console.Write("Enter your Name : ");
                string name = Console.ReadLine();
                Console.Write("Enter your Phone Number : ");
                string phone = Console.ReadLine();
                Console.Write("Enter your Age : ");
                int age = Convert.ToInt16(Console.ReadLine());
                Console.Write("Enter your UserId : ");
                string userId = Console.ReadLine();
                Console.Write("Enter your Password : ");
                string password = Console.ReadLine();

                string detailQuery = "Admin_Id_Procedure";
                SqlCommand sqlCommand = new SqlCommand(detailQuery, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter();
                para.ParameterName = "@UserId";
                para.Value = userId;
                para.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(para);

                para = new SqlParameter();
                para.ParameterName = "@Password";
                para.Value = password;
                para.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(para);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.InsertCommand = sqlCommand;
                int retRows = sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                string idQuery = "Admin_Details_Procedure";
                sqlCommand = new SqlCommand(idQuery, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                para = new SqlParameter();
                para.ParameterName = "@UserId";
                para.Value = userId;
                para.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(para);

                para = new SqlParameter();
                para.ParameterName = "@Name";
                para.Value = name;
                para.SqlDbType = SqlDbType.Char;
                sqlCommand.Parameters.Add(para);

                para = new SqlParameter();
                para.ParameterName = "@Phone";
                para.Value = phone;
                para.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(para);

                para = new SqlParameter();
                para.ParameterName = "@Age";
                para.Value = age;
                para.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(para);

                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.InsertCommand = sqlCommand;
                retRows = sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                if (retRows >= 1)
                {
                    Console.WriteLine("Admin Added...");
                }
                else
                {
                    Console.WriteLine("Admin cannot be Added...");
                }
            }
        }
    }
}
