using InvoiceApplication.Database;
using InvoiceApplication.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace InvoiceApplication.Service
{
    public class InvoiceService : IInvoiceService
    {
        string defaultconnection = "Server=DESKTOP-ULCQKM6\\SQLEXPRESS;Database=Invoice;Integrated Security=True;TrustServerCertificate=True;";
        public List<Invoice_Table> GetInvoices()
        {

            List<Invoice_Table> list = new List<Invoice_Table>();

            using (SqlConnection conn = new SqlConnection(defaultconnection))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_GetAllInvoice", conn);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader dr = sqlcmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Invoice_Table
                    {
                        Invoice_Number = Convert.ToInt32(dr["Invoice_Number"]),
                        Invoice_Date = DateOnly.FromDateTime(
                            dr.GetDateTime(dr.GetOrdinal("Invoice_Date"))
                        ),
                        Billing_Name = dr["Shipping_Name"].ToString(),
                        Shipping_Name = dr["Billing_Name"].ToString(),

                        BillingAddress_Address = dr["BillingAddress_Address"].ToString(),
                        BillingAddress_City = dr["BillingAddress_City"].ToString(),
                        BillingAddress_State = dr["BillingAddress_State"].ToString(),
                        BillingAddress_Phone = dr["BillingAddress_Phone"].ToString(),

                        ShippingAddress_Address = dr["ShippingAddress_Address"].ToString(),
                        ShippingAddress_City = dr["ShippingAddress_City"].ToString(),
                        ShippingAddress_State = dr["ShippingAddress_State"].ToString(),
                        ShippingAddress_Phone = dr["ShippingAddress_Phone"].ToString(),

                        //Product_Id = Convert.ToInt32(dr["Product_Id"])
                    });
                }
            }
            return list;
        }

        //public void CreateInvoice(Invoice_Table invoice)
        //{
        //    using (SqlConnection conn = new SqlConnection(defaultconnection))
        //    {
        //        SqlCommand sqlcmd = new SqlCommand("sp_CreateInvoice", conn);
        //        sqlcmd.CommandType = CommandType.StoredProcedure;

        //        sqlcmd.Parameters.AddWithValue("@Invoicedate", invoice.Invoice_Date);
        //        sqlcmd.Parameters.AddWithValue("@CustomerName", invoice.Customer_Name);

        //        sqlcmd.Parameters.AddWithValue("@BillingAddressAddress", invoice.BillingAddress_Address);
        //        sqlcmd.Parameters.AddWithValue("@BillingAddressCity", invoice.BillingAddress_City);
        //        sqlcmd.Parameters.AddWithValue("@BillingAddressState", invoice.BillingAddress_State);
        //        sqlcmd.Parameters.AddWithValue("@BillingAddressPhone", invoice.BillingAddress_Phone);

        //        sqlcmd.Parameters.AddWithValue("@ShippingAddressAddress", invoice.ShippingAddress_Address);
        //        sqlcmd.Parameters.AddWithValue("@ShippingAddressCIty", invoice.ShippingAddress_City);
        //        sqlcmd.Parameters.AddWithValue("@ShippingAddressState", invoice.ShippingAddress_State);
        //        sqlcmd.Parameters.AddWithValue("@ShippingAddressPhone", invoice.ShippingAddress_Phone);

        //        //sqlcmd.Parameters.AddWithValue("@ProductId", invoice.Product_Id);

        //        conn.Open();
        //        sqlcmd.ExecuteNonQuery();
        //    }
        //}

        //public Invoice_Table GetById(int id )
        //{
        //    Invoice_Table? invoice = null;
        //    using (SqlConnection con = new SqlConnection(defaultconnection))
        //    {
        //        SqlCommand sqlcmd = new SqlCommand("sp_GetById", con);
        //        sqlcmd.CommandType = CommandType.StoredProcedure;
        //        sqlcmd.Parameters.AddWithValue("@Invoice_Number", id);

        //        con.Open();

        //        SqlDataReader dr = sqlcmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            invoice = new Invoice_Table
        //            {
        //                Invoice_Number = Convert.ToInt32(dr["Invoice_Number"]),
        //                Invoice_Date = DateOnly.FromDateTime(
        //                    dr.GetDateTime(dr.GetOrdinal("Invoice_Date"))
        //                ),
        //                Customer_Name = dr["Customer_Name"].ToString(),
        //                BillingAddress_Address = dr["BillingAddress_Address"].ToString(),
        //                BillingAddress_City = dr["BillingAddress_City"].ToString(),
        //                BillingAddress_State = dr["BillingAddress_State"].ToString(),
        //                BillingAddress_Phone = dr["BillingAddress_Phone"].ToString(),
        //                ShippingAddress_Address = dr["ShippingAddress_Address"].ToString(),
        //                ShippingAddress_City = dr["ShippingAddress_City"].ToString(),
        //                ShippingAddress_State = dr["ShippingAddress_State"].ToString(),
        //                ShippingAddress_Phone = dr["ShippingAddress_Phone"].ToString()
        //            };
        //        }

        //        invoice.Products = new List<InvoiceProduct>();

        //        if (dr.NextResult())
        //        {
        //            while (dr.Read())
        //            {
        //                invoice.Products.Add(new InvoiceProduct
        //                {
        //                    Detail_Id = Convert.ToInt32(dr["Detail_Id"]),
        //                    InvoiceNumber = Convert.ToInt32(dr["Invoice_Number"]),
        //                    Name = dr["Product_Name"].ToString(),
        //                    Price = Convert.ToDecimal(dr["Price"]),
        //                    Qty = Convert.ToInt32(dr["Quantity"]),
        //                    Total = Convert.ToDecimal(dr["Total"])
        //                });
        //            }
        //        }

        //    }
        //    return invoice;
        //}

        public Invoice_Table GetById(int id)
        {
            Invoice_Table invoice = null;

            using (SqlConnection con = new SqlConnection(defaultconnection))
            {
                SqlCommand cmd = new SqlCommand("sp_GetById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Invoice_Number", id);

                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    // ====== Read Main Invoice Table ======
                    if (dr.Read())
                    {
                        invoice = new Invoice_Table
                        {
                            Invoice_Number = Convert.ToInt32(dr["Invoice_Number"]),
                            Invoice_Date = DateOnly.FromDateTime(Convert.ToDateTime(dr["Invoice_Date"])),
                            Billing_Name = dr["Billing_Name"].ToString(),
                            Shipping_Name = dr["Shipping_Name"].ToString(),

                            BillingAddress_Address = dr["BillingAddress_Address"].ToString(),
                            BillingAddress_State = dr["BillingAddress_State"].ToString(),
                            BillingAddress_City = dr["BillingAddress_City"].ToString(),
                            BillingAddress_Phone = dr["BillingAddress_Phone"].ToString(),

                            ShippingAddress_Address = dr["ShippingAddress_Address"].ToString(),
                            ShippingAddress_State = dr["ShippingAddress_State"].ToString(),
                            ShippingAddress_City = dr["ShippingAddress_City"].ToString(),
                            ShippingAddress_Phone = dr["ShippingAddress_Phone"].ToString(),

                            // IMPORTANT: initialize product list
                            Products = new List<InvoiceProduct>()
                        };
                    }

                    // If no invoice found → return null
                    if (invoice == null) return null;

                    // ====== Read Invoice Products (Second Result Set) ======
                    if (dr.NextResult())
                    {
                        while (dr.Read())
                        {
                            invoice.Products.Add(new InvoiceProduct
                            {
                                Detail_Id = Convert.ToInt32(dr["Detail_Id"]),
                                InvoiceNumber = Convert.ToInt32(dr["Invoice_Number"]),
                                Name = dr["Product_Name"].ToString(),
                                Price = Convert.ToDecimal(dr["Price"]),
                                Qty = Convert.ToInt32(dr["Quantity"]),
                                Total = Convert.ToDecimal(dr["Total"])
                            });
                        }
                    }
                }
            }
            return invoice;
        }

        public void EditInvoice(Invoice_Table invoice, List<InvoiceProduct> products)
        {
            using (SqlConnection conn = new SqlConnection(defaultconnection))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_EditInvoice", conn);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@Invoice_Number", invoice.Invoice_Number);
                sqlcmd.Parameters.AddWithValue("@Invoice_Date", invoice.Invoice_Date);
                sqlcmd.Parameters.AddWithValue("@BillingName", invoice.Billing_Name);
                sqlcmd.Parameters.AddWithValue("@ShippingName", invoice.Shipping_Name);

                sqlcmd.Parameters.AddWithValue("@BillingAddressAddress", invoice.BillingAddress_Address);
                sqlcmd.Parameters.AddWithValue("@BillingAddressCity", invoice.BillingAddress_City);
                sqlcmd.Parameters.AddWithValue("@BillingAddressState", invoice.BillingAddress_State);
                sqlcmd.Parameters.AddWithValue("@BillingAddressPhone", invoice.BillingAddress_Phone);

                sqlcmd.Parameters.AddWithValue("@ShippingAddressAddress", invoice.ShippingAddress_Address);
                sqlcmd.Parameters.AddWithValue("@ShippingAddressCity", invoice.ShippingAddress_City);
                sqlcmd.Parameters.AddWithValue("@ShippingAddressState", invoice.ShippingAddress_State);
                sqlcmd.Parameters.AddWithValue("@ShippingAddressPhone", invoice.ShippingAddress_Phone);


                conn.Open();
                sqlcmd.ExecuteNonQuery();
            }

            int invoiceId = invoice.Invoice_Number;   // 🚀 FIXED

            // 🔥 Delete previous products before inserting new ones
            using (SqlConnection conn = new SqlConnection(defaultconnection))
            {
                SqlCommand delCmd = new SqlCommand("DELETE FROM Invoice_Detail WHERE Invoice_Number=@Invoice_Number", conn);
                delCmd.Parameters.AddWithValue("@Invoice_Number", invoiceId);

                conn.Open();
                delCmd.ExecuteNonQuery();
            }
            // Insert product list
            foreach (var p in products)
            {
                using (SqlConnection conn2 = new SqlConnection(defaultconnection))
                {
                    SqlCommand cmd2 = new SqlCommand(
                        "INSERT INTO Invoice_Detail VALUES (@Invoice_Number, @Name, @Price, @Qty, @Total)", conn2);

                    cmd2.Parameters.AddWithValue("@Invoice_Number", invoiceId);
                    cmd2.Parameters.AddWithValue("@Name", p.Name);
                    cmd2.Parameters.AddWithValue("@Price", p.Price);
                    cmd2.Parameters.AddWithValue("@Qty", p.Qty);
                    cmd2.Parameters.AddWithValue("@Total", p.Total);

                    conn2.Open();
                    cmd2.ExecuteNonQuery();
                }
            }
        }

        public void CreateInvoice(Invoice_Table invoice, List<InvoiceProduct> products)
        {
            int newInvoiceId = 0;


            using (SqlConnection conn = new SqlConnection(defaultconnection))
            {
                SqlCommand cmd = new SqlCommand("sp_CreateInvoice", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@InvoiceDate", invoice.Invoice_Date);
                cmd.Parameters.AddWithValue("@BillingName", invoice.Billing_Name);
                cmd.Parameters.AddWithValue("@ShippingName", invoice.Shipping_Name);

                cmd.Parameters.AddWithValue("@BillingAddressAddress", invoice.BillingAddress_Address);
                cmd.Parameters.AddWithValue("@BillingAddressCity", invoice.BillingAddress_City);
                cmd.Parameters.AddWithValue("@BillingAddressState", invoice.BillingAddress_State);
                cmd.Parameters.AddWithValue("@BillingAddressPhone", invoice.BillingAddress_Phone);

                cmd.Parameters.AddWithValue("@ShippingAddressAddress", invoice.ShippingAddress_Address);
                cmd.Parameters.AddWithValue("@ShippingAddressCity", invoice.ShippingAddress_City);
                cmd.Parameters.AddWithValue("@ShippingAddressState", invoice.ShippingAddress_State);
                cmd.Parameters.AddWithValue("@ShippingAddressPhone", invoice.ShippingAddress_Phone);

                conn.Open();
                newInvoiceId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // Insert product list
            foreach (var p in products)
            {
                using (SqlConnection conn2 = new SqlConnection(defaultconnection))
                {
                    SqlCommand cmd2 = new SqlCommand(
                        "INSERT INTO Invoice_Detail VALUES (@Invoice_Number, @Name, @Price, @Qty, @Total)", conn2);

                    cmd2.Parameters.AddWithValue("@Invoice_Number", newInvoiceId);
                    cmd2.Parameters.AddWithValue("@Name", p.Name);
                    cmd2.Parameters.AddWithValue("@Price", p.Price);
                    cmd2.Parameters.AddWithValue("@Qty", p.Qty);
                    cmd2.Parameters.AddWithValue("@Total", p.Total);

                    conn2.Open();
                    cmd2.ExecuteNonQuery();
                }

            }
        }

        public void deleteInvoice(int Invoice_Number)
        {
                using (SqlConnection conn = new SqlConnection(defaultconnection))
                {
                    SqlCommand sqlcmd = new SqlCommand("sp_DeleteInvoice", conn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;

                    sqlcmd.Parameters.AddWithValue("@Invoice_Number", Invoice_Number);


                    conn.Open();
                    sqlcmd.ExecuteNonQuery();
                }
            
        }

        public void ErrorHandaling(SqlException error)
        {
            using (SqlConnection conn = new SqlConnection(defaultconnection))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_Errorhandaling", conn);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@ErrorMessage", error.Message);
                sqlcmd.Parameters.AddWithValue("@ErrorTime", DateTime.Now);
                sqlcmd.Parameters.AddWithValue("@ErrorLocation", "Dashboard/" +error.StackTrace);


                conn.Open();
                sqlcmd.ExecuteNonQuery();
            }
        }
        public void ErrorHandaling(Exception error)
        {
            using (SqlConnection conn = new SqlConnection(defaultconnection))
            {
                SqlCommand sqlcmd = new SqlCommand("sp_Errorhandaling", conn);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@ErrorMessage", error.Message);
                sqlcmd.Parameters.AddWithValue("@ErrorTime", DateTime.Now);
                sqlcmd.Parameters.AddWithValue("@ErrorLocation", error.StackTrace);


                conn.Open();
                sqlcmd.ExecuteNonQuery();
            }
        }

    }
}
