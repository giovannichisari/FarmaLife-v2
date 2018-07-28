using System;
using cadastro_remedios.Models;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    public class clientQuery
    {
        public void Add(Client lClient)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);

                connection.Open();

                 string insert = "INSERT INTO cadastro_cliente(for_nome,for_cpf,for_cep,for_endereco,for_bairro,for_cidade,for_uf,for_fone,for_email)" + "values ('"
                 + lClient.clientName + "','" + lClient.clientDocument + "','" + lClient.clientZipCode + "','" + lClient.clientStreet + "','" + lClient.clientDistrict + "','" + lClient.clientCity + "','" + lClient.clientState + "','"
                 + lClient.clientTelephone + "','" + lClient.clientEmail + "')";
                MySqlCommand command = new MySqlCommand(insert, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                errorQuery lerrorQuery = new errorQuery();
                lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Cadastro Funcionario");
            }
        }
        public void Update(Client lClient)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                string update = "UPDATE cadastro_cliente set for_nome= '" + lClient.clientName + "',for_endereco= '" + lClient.clientStreet + "',for_bairro= '" + lClient.clientDistrict + "',for_cidade= '" + lClient.clientCity +
                    "',for_uf ='" + lClient.clientState + "',for_cpf= '" + lClient.clientDocument + "',for_cep='" + lClient.clientZipCode + "',for_fone='" + lClient.clientTelephone +
                    "',for_email='" + lClient.clientEmail + "' WHERE for_cod='" + lClient.clientId + "';";

                MySqlCommand command = new MySqlCommand(update, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                errorQuery lerrorQuery = new errorQuery();
                lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lErrorUpdate, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Cadastro Cliente");
            }
        }
    }
}


            
        
    


