﻿using System.Data;
using System.Data.SqlClient;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces;
using WebMusicShop.Models.Interfaces.IUsuario;

namespace WebMusicShop.Models.Context
{
    public class UsuarioContext : IUsuarioContext
    {
        private readonly SqlConnection _connection;
        public UsuarioContext(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }


        public void CadastraUsuarioContext(Usuario usuario)
        {
            try
            {
                string proc = "SpIns_Usuario";
                SqlCommand cmdIns = new SqlCommand(proc, _connection);
                cmdIns.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                cmdIns.Parameters.Add("Nome", SqlDbType.VarChar).Value = usuario.Nome;
                cmdIns.Parameters.Add("CPF", SqlDbType.VarChar).Value = usuario.CPF;
                cmdIns.Parameters.Add("Email", SqlDbType.VarChar).Value = usuario.Email;
                cmdIns.Parameters.Add("Senha", SqlDbType.VarChar).Value = usuario.Senha;
                cmdIns.Parameters.Add("StatusId", SqlDbType.Int).Value = usuario.StatusEnum;
                cmdIns.Parameters.Add("PerfilId", SqlDbType.Int).Value = usuario.PerfilEnum;
                cmdIns.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            }

        public List<Usuario> ListarUsuariosContext()
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();
                string proc = "SpSel_Usuario";
                SqlCommand cmdSel = new SqlCommand(proc, _connection);
                cmdSel.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                SqlDataReader dataReader = cmdSel.ExecuteReader();

                while (dataReader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = dataReader.GetInt32("Id");
                    usuario.Nome = dataReader.GetString("Nome");
                    usuario.CPF = dataReader.GetString("CPF");
                    usuario.Email = dataReader.GetString("Email");
                    usuario.Senha = dataReader.GetString("Senha");
                    usuario.Status = dataReader.GetString("Status");
                    usuario.Perfil = dataReader.GetString("Perfil");
                    usuarios.Add(usuario);
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
        public void AtualizaUsuarioContext(Usuario usuario)
        {
            try
            {
                string proc = "SpUpd_Usuario";
                SqlCommand cmdUpd = new SqlCommand(proc, _connection);
                cmdUpd.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                cmdUpd.Parameters.Add("Id", SqlDbType.Int).Value = usuario.Id;
                cmdUpd.Parameters.Add("Nome", SqlDbType.VarChar).Value = usuario.Nome;
                cmdUpd.Parameters.Add("CPF", SqlDbType.VarChar).Value = usuario.CPF;
                cmdUpd.Parameters.Add("Email", SqlDbType.VarChar).Value = usuario.Email;
                cmdUpd.Parameters.Add("StatusId", SqlDbType.Int).Value = usuario.StatusEnum;
                cmdUpd.Parameters.Add("PerfilId", SqlDbType.Int).Value = usuario.PerfilEnum;
                cmdUpd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeletaUsuarioContext(int id)
        {
            try
            {
                string proc = "SpDel_Usuario";
                SqlCommand cmdDel = new SqlCommand(proc, _connection);
                cmdDel.CommandType = CommandType.StoredProcedure;
                _connection.Open();

                cmdDel.Parameters.Add("Id", SqlDbType.Int).Value = id;
                cmdDel.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
