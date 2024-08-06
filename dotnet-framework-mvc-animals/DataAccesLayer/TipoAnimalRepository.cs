using dotnet_framework_mvc_animals.DataAccesLayer.Connection;
using dotnet_framework_mvc_animals.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace dotnet_framework_mvc_animals.DataAccesLayer
{
    public class TipoAnimalRepository
    {
        private SqlConnection _connection;

        public TipoAnimalRepository()
        {
            DatabaseConnection cd = new DatabaseConnection();
            _connection = cd.SqlConnection;
        }

        public List<TipoAnimal> GetTipoAnimalListFromDB()
        {
            List<TipoAnimal> animals = new List<TipoAnimal>();

            _connection.Open();
            try
            {

                string query = "SELECT * FROM TipoAnimal;";
                SqlCommand cmd = new SqlCommand(query, this._connection);

                // Recuperamos un lector...
                SqlDataReader records = cmd.ExecuteReader();

                while (records.Read())
                {
                    TipoAnimal tipoAnimal = new TipoAnimal();
                    tipoAnimal.IdTipoAnimal = records.GetInt32(records.GetOrdinal("IdTipoAnimal"));
                    tipoAnimal.TipoDescripcion = records.GetString(records.GetOrdinal("TipoDescripcion"));

                    // Agrega más campos según la estructura de tu tabla y tu clase Job
                    animals.Add(tipoAnimal);
                }
                _connection.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return animals;
        }

        public void InsertTipoAnimalToDB(TipoAnimal newTipoAnimal)
        {
            try
            {
                this._connection.Open();
                string sql = @"INSERT INTO TipoAnimal(
                                             TipoDescripcion) 

                                VALUES ( 
                                        @TipoDescripcion)";


                using (SqlCommand cmd = new SqlCommand(sql, this._connection))
                {
                    cmd.Parameters.AddWithValue("@TipoDescripcion", newTipoAnimal.TipoDescripcion);

                    cmd.ExecuteNonQuery();
                }
                this._connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateTipoAnimalInDB(TipoAnimal updatedTipoAnimal)
        {
            try
            {
                this._connection.Open();
                string sql = @"UPDATE TipoAnimal
                       SET TipoDescripcion = @TipoDescripcion
                       WHERE IdTipoAnimal = @IdTipoAnimal";

                using (SqlCommand cmd = new SqlCommand(sql, this._connection))
                {
                    cmd.Parameters.AddWithValue("@TipoDescripcion", updatedTipoAnimal.TipoDescripcion);
                    cmd.Parameters.AddWithValue("@IdTipoAnimal", updatedTipoAnimal.IdTipoAnimal);

                    cmd.ExecuteNonQuery();
                }
                this._connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void DeleteTipoAnimalFromDB(int idTipoAnimal)
        {
            try
            {
                this._connection.Open();
                string sql = @"DELETE FROM TipoAnimal
                       WHERE IdTipoAnimal = @IdTipoAnimal";

                using (SqlCommand cmd = new SqlCommand(sql, this._connection))
                {
                    cmd.Parameters.AddWithValue("@IdTipoAnimal", idTipoAnimal);

                    cmd.ExecuteNonQuery();
                }
                this._connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}