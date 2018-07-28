using System;
using cadastro_remedios.Models;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    class employeeQuery
    {
        public void Add(Employee emp)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                 string insert = "INSERT INTO employee(empStatus,empName,empStreet,empDistrict, empNumber, empCity,empRegionState,empMarriageStatus,empBirthDate,empZipCode,empFixedTelephone," +
                "empCellphone,empEmail,empUsername,empPassword,empRole,empDocument)" + "values ('"
                 + emp.employeeStatus + "','" + emp.employeeName + "','" + emp.employeeStreet + "','" + emp.employeeDistrict + "','" + emp.employeeNumber + "','" + emp.employeeCity + "','" + emp.employeeState + "','" + emp.employeeCivilState + "','" + emp.employeeBirthDate + "','"
                 + emp.employeeZipCode + "','" + emp.employeeTelephone + "','" + emp.employeeCellPhone + "','" + emp.employeeEmail + "','" + emp.employeeUsername + "','" + emp.employeePassword + "','" + emp.employeeRole + "','" + emp.employeeDocument + "')";
                MySqlCommand command = new MySqlCommand(insert, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(MessageBoxResult.lErrorCommand + ex.Message);
            }
        }
        internal void Update(Employee emp)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                string update = "UPDATE employee set empStatus= '" +emp.employeeStatus + "',empName= '" + emp.employeeName + "',empNumber= '" + emp.employeeNumber + "',empStreet= '" + emp.employeeStreet + "',empDistrict= '" + emp.employeeDistrict + "',empCity= '" + emp.employeeCity +
                    "',empRegionState ='" + emp.employeeState + "',empMarriageStatus= '" + emp.employeeCivilState + "',empBirthDate='"
                    + emp.employeeBirthDate + "',empZipCode='" + emp.employeeZipCode + "',empFixedTelephone='" + emp.employeeTelephone + "',empCellphone='" + emp.employeeCellPhone +
                    "',empEmail='" + emp.employeeEmail + "',empUsername='" + emp.employeeUsername + "',empPassword='" + emp.employeePassword + "',empRole='" + emp.employeeRole + "',empDocument='" + emp.employeeDocument + "' WHERE empId='" + emp.employeeId + "';";

                MySqlCommand command = new MySqlCommand(update, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(MessageBoxResult.lErrorCommand + ex.Message);
            }
        }
        public const string GetEmployeById = @" SELECT  	
                                                    empId             AS Codigo  		       , 
			                                        empName           AS Nome  			       ,
	                                                empStreet         AS Endereco		       ,
	                                                empDistrict 	  AS Bairro			       ,
                                                    empNumber         AS Numero                ,
		                                            empCity 		  AS Cidade			 	   ,
                                                    empRegionState    AS UF				       ,
	                                                empMarriageStatus AS 'Estado Civil'	 	   ,
			                                        empBirthDate      AS 'Data de Nascimento'  ,
			                                        empZipCode        AS Cep			       ,
			                                        empFixedTelephone AS Telefone		       ,
                                                    empCellphone      AS Celular		       ,
			                                        empEmail          AS Email			       ,
			                                        empUsername       AS Login			       ,
			                                        empRole           AS Cargo			       ,
			                                        empDocument       AS CPF			       ,
			                                        empStatus         AS Status  
                                            FROM employee 
                                           WHERE empId 
                                            LIKE @value 
	                                         AND empStatus= 'A';";

        public const string GetEmployeByName = @" SELECT  	
                                                    empId             AS Codigo  		       , 
			                                        empName           AS Nome  			       ,
	                                                empStreet         AS Endereco		       ,
	                                                empDistrict 	  AS Bairro			       ,
                                                    empNumber         AS Numero                ,
		                                            empCity 		  AS Cidade			 	   ,
                                                    empRegionState    AS UF				       ,
	                                                empMarriageStatus AS 'Estado Civil'	 	   ,
			                                        empBirthDate      AS 'Data de Nascimento'  ,
			                                        empZipCode        AS Cep			       ,
			                                        empFixedTelephone AS Telefone		       ,
                                                    empCellphone      AS Celular		       ,
			                                        empEmail          AS Email			       ,
			                                        empUsername       AS Login			       ,
			                                        empRole           AS Cargo			       ,
			                                        empDocument       AS CPF			       ,
			                                        empStatus         AS Status  
                                            FROM employee 
                                           WHERE empName 
                                            LIKE @value 
	                                         AND empStatus= 'A';";

        public const string GetActiveEmployee = @" SELECT  	
                                                    empId             AS Codigo  		       , 
			                                        empName           AS Nome  			       ,
	                                                empStreet         AS Endereco		       ,
	                                                empDistrict 	  AS Bairro			       ,
		                                            empCity 		  AS Cidade			 	   ,
                                                    empNumber         AS Numero                ,
                                                    empRegionState    AS UF				       ,
	                                                empMarriageStatus AS 'Estado Civil'	 	   ,
			                                        empBirthDate      AS 'Data de Nascimento'  ,
			                                        empZipCode        AS Cep			       ,
			                                        empFixedTelephone AS Telefone		       ,
                                                    empCellphone      AS Celular		       ,
			                                        empEmail          AS Email			       ,
			                                        empUsername       AS Login			       ,
			                                        empRole           AS Cargo			       ,
			                                        empDocument       AS CPF			       ,
			                                        empStatus         AS Status  
                                            FROM employee 
                                           WHERE empStatus= 'A';";

        public const string GetInativeEmployee = @" SELECT  	
                                                    empId             AS Codigo  		       , 
			                                        empName           AS Nome  			       ,
	                                                empStreet         AS Endereco		       ,
	                                                empDistrict 	  AS Bairro			       ,
		                                            empCity 		  AS Cidade			 	   ,
                                                    empRegionState    AS UF				       ,
	                                                empMarriageStatus AS 'Estado Civil'	 	   ,
                                                    empNumber         AS Numero                ,
			                                        empBirthDate      AS 'Data de Nascimento'  ,
			                                        empZipCode        AS Cep			       ,
			                                        empFixedTelephone AS Telefone		       ,
                                                    empCellphone      AS Celular		       ,
			                                        empEmail          AS Email			       ,
			                                        empUsername       AS Login			       ,
			                                        empRole           AS Cargo			       ,
			                                        empDocument       AS CPF			       ,
			                                        empStatus         AS Status  
                                            FROM employee 
                                           WHERE empStatus= 'I';";

        public const string GetAllEmployees = @" SELECT  	
                                                    empId             AS Codigo  		       , 
			                                        empName           AS Nome  			       ,
	                                                empStreet         AS Endereco		       ,
	                                                empDistrict 	  AS Bairro			       ,
		                                            empCity 		  AS Cidade			 	   ,
                                                    empNumber         AS Numero                ,
                                                    empRegionState    AS UF				       ,
	                                                empMarriageStatus AS 'Estado Civil'	 	   ,
			                                        empBirthDate      AS 'Data de Nascimento'  ,
			                                        empZipCode        AS Cep			       ,
			                                        empFixedTelephone AS Telefone		       ,
                                                    empCellphone      AS Celular		       ,
			                                        empEmail          AS Email			       ,
			                                        empUsername       AS Login			       ,
			                                        empRole           AS Cargo			       ,
			                                        empDocument       AS CPF			       ,
			                                        empStatus         AS Status  
                                            FROM employee;";
    }
}
            
        
    



