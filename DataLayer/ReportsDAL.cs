using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace DataLayer
{
    public class ReportsDAL
    {
        public MemoryStream ReporteMaterialsDate(string fechainicio, string fechafin)
        {
            DataTable table_Materials = new DataTable();
            MemoryStream memoria = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConn.conn))
                {
                    conn.Open();
                    using (var adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = new SqlCommand("ReporteMaterialesByDate", conn);
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        adapter.SelectCommand.Parameters.AddWithValue("@fechaInicio", DateTime.Parse(fechainicio).ToString("dd/MM/yyyy"));
                        adapter.SelectCommand.Parameters.AddWithValue("@fechaFin", DateTime.Parse(fechafin).ToString("dd/MM/yyyy"));

                        adapter.Fill(table_Materials);
                    }
                }

                using (var libro = new XLWorkbook())
                {
                    table_Materials.TableName = "Materiales";
                    var hoja = libro.Worksheets.Add(table_Materials);
                    hoja.ColumnsUsed().AdjustToContents();

                    memoria = new MemoryStream();
                    libro.SaveAs(memoria);
                    memoria.Position = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
            return memoria;
        }
        public MemoryStream ReporteMaterialsGeneral()
        {
            DataTable table_Materials = new DataTable();
            MemoryStream memoria = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConn.conn))
                {
                    conn.Open();
                    using (var adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = new SqlCommand("ReporteMaterialesGeneral", conn);
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                        adapter.Fill(table_Materials);
                    }
                }

                using (var libro = new XLWorkbook())
                {
                    table_Materials.TableName = "Materiales";
                    var hoja = libro.Worksheets.Add(table_Materials);
                    hoja.ColumnsUsed().AdjustToContents();

                    memoria = new MemoryStream();
                    libro.SaveAs(memoria);
                    memoria.Position = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
            return memoria;
        }
        public MemoryStream ReporteMaterialTransactionsByDate(string fechainicio, string fechafin)
        {
            DataTable table_Materials = new DataTable();
            MemoryStream memoria = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConn.conn))
                {
                    conn.Open();
                    using (var adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = new SqlCommand("ReporteMaterialTransactionsByDate", conn);
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        adapter.SelectCommand.Parameters.AddWithValue("@fechaInicio", DateTime.Parse(fechainicio).ToString("dd/MM/yyyy"));
                        adapter.SelectCommand.Parameters.AddWithValue("@fechaFin", DateTime.Parse(fechafin).ToString("dd/MM/yyyy"));

                        adapter.Fill(table_Materials);
                    }
                }

                using (var libro = new XLWorkbook())
                {
                    table_Materials.TableName = "Transacciones";
                    var hoja = libro.Worksheets.Add(table_Materials);
                    hoja.ColumnsUsed().AdjustToContents();

                    memoria = new MemoryStream();
                    libro.SaveAs(memoria);
                    memoria.Position = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
            return memoria;
        }
        public MemoryStream ReporteMaterialTransactionsGeneral()
        {
            DataTable table_Materials = new DataTable();
            MemoryStream memoria = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConn.conn))
                {
                    conn.Open();
                    using (var adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = new SqlCommand("ReporteMaterialTransactions", conn);
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                        adapter.Fill(table_Materials);
                    }
                }

                using (var libro = new XLWorkbook())
                {
                    table_Materials.TableName = "Materiales";
                    var hoja = libro.Worksheets.Add(table_Materials);
                    hoja.ColumnsUsed().AdjustToContents();

                    memoria = new MemoryStream();
                    libro.SaveAs(memoria);
                    memoria.Position = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
            return memoria;
        }
    }
}
