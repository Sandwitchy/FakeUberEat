using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using FakeUberEat.Models;
using MySql.Data.MySqlClient;

namespace FakeUberEat.Repository
{
    public class PlatRepository : IRepository
    {
        private MySqlConnection dbConn;


        public PlatRepository(MySqlDatabase db){
            this.dbConn = db.Connection;
        }


        /**
            Return all Plat from MySql
        */
        public List<object> All(){
            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText = "SELECT id,titre,image,description,price from plat";

            try
            {
                dbConn.Open();                
            } catch (Exception erro) {
                Console.WriteLine(erro);
            }

            MySqlDataReader reader = cmd.ExecuteReader();
            var ret = new List<object>();
            while (reader.Read())
            {
                var plat = new Plat(){
                    Id = reader.GetInt16(0),
                    Titre = reader.GetString(1),
                    Image = reader.GetString(2),
                    Description = reader.GetString(3),
                    Price = reader.GetDecimal(4)
                };
                ret.Add(plat);
            }
            return ret;
        }
        /**
        Return the plat with the Id gived
        */
        public object getById(int id)
        {
            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText = "select id,titre,image,description,price from plat where id ="+ id;

            try
            {
                dbConn.Open();                
            } catch (Exception erro) {
                Console.WriteLine(erro);
            }

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()){
                var ret = new Plat(){
                    Id = reader.GetInt16(0),
                    Titre = reader.GetString(1),
                    Image = reader.GetString(2),
                    Description = reader.GetString(3),
                    Price = reader.GetDecimal(4)
                };  

                return ret;
            }
            throw new Exception("Aucune donnée trouvé");
        }

        /**
            Save the Parameter Plat in MySql 
            Do Insert and Update with the Id existing or not
        */
        public void Save(object ObjectToSave)
        {
            Plat plat = (Plat)ObjectToSave;
            MySqlCommand cmd = dbConn.CreateCommand();
            if(plat.Id != null){
                cmd.CommandText = "UPDATE plat SET titre = @Titre,image = @Image,description = @Description,price = @Price WHERE id = @Id";
                cmd.Parameters.AddWithValue("@Id", plat.Id); 
            }else{
                cmd.CommandText = "insert into plat values(null,@Titre,@Description,@Image,@Price)";
            }
            try{
                dbConn.Open();
            }catch(Exception ex){
                Debug.Write(ex);
            }
            try{  
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Titre", plat.Titre);  
                cmd.Parameters.AddWithValue("@Image", plat.Image);  
                cmd.Parameters.AddWithValue("@Description", plat.Description);  
                cmd.Parameters.AddWithValue("@Price", plat.Price);    
  
                cmd.ExecuteNonQuery();  
                dbConn.Close();
            }  
            catch(Exception ex)  
            {  
                dbConn.Close(); 
                Debug.WriteLine(ex);
                throw new Exception(""+ex); 
            }  
        }
    }
}