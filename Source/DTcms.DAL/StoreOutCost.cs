﻿using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL  
	
{
	 	//StoreOutCost
		public partial class StoreOutCost
	{
   		     
		public bool Exists(int StoreOutOrderId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreOutCost");
			strSql.Append(" where ");
			                                       strSql.Append(" StoreOutOrderId = @StoreOutOrderId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@StoreOutOrderId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreOutOrderId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DTcms.Model.StoreOutCost model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreOutCost(");			
            strSql.Append("StoreOutOrderId,Name,Count,UnitPrice,TotalPrice,Status,PaidTime,Admin,Customer,HasBeenInvoiced,InvoicedTime,InvoicedOperator,Remark");
			strSql.Append(") values (");
            strSql.Append("@StoreOutOrderId,@Name,@Count,@UnitPrice,@TotalPrice,@Status,@PaidTime,@Admin,@Customer,@HasBeenInvoiced,@InvoicedTime,@InvoicedOperator,@Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@StoreOutOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@PaidTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Customer", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@HasBeenInvoiced", SqlDbType.Bit,1) ,            
                        new SqlParameter("@InvoicedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@InvoicedOperator", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.StoreOutOrderId;                        
            parameters[1].Value = model.Name;                        
            parameters[2].Value = model.Count;                        
            parameters[3].Value = model.UnitPrice;                        
            parameters[4].Value = model.TotalPrice;                        
            parameters[5].Value = model.Status;                        
            parameters[6].Value = model.PaidTime;                        
            parameters[7].Value = model.Admin;                        
            parameters[8].Value = model.Customer;                        
            parameters[9].Value = model.HasBeenInvoiced;                        
            parameters[10].Value = model.InvoicedTime;                        
            parameters[11].Value = model.InvoicedOperator;                        
            parameters[12].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.StoreOutCost model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreOutCost set ");
			                        
            strSql.Append(" StoreOutOrderId = @StoreOutOrderId , ");                                    
            strSql.Append(" Name = @Name , ");                                    
            strSql.Append(" Count = @Count , ");                                    
            strSql.Append(" UnitPrice = @UnitPrice , ");                                    
            strSql.Append(" TotalPrice = @TotalPrice , ");                                    
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" PaidTime = @PaidTime , ");                                    
            strSql.Append(" Admin = @Admin , ");                                    
            strSql.Append(" Customer = @Customer , ");                                    
            strSql.Append(" HasBeenInvoiced = @HasBeenInvoiced , ");                                    
            strSql.Append(" InvoicedTime = @InvoicedTime , ");                                    
            strSql.Append(" InvoicedOperator = @InvoicedOperator , ");                                    
            strSql.Append(" Remark = @Remark  ");            			
			strSql.Append(" where StoreOutOrderId=@StoreOutOrderId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@StoreOutOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Count", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@PaidTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Customer", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@HasBeenInvoiced", SqlDbType.Bit,1) ,            
                        new SqlParameter("@InvoicedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@InvoicedOperator", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.StoreOutOrderId;                        
            parameters[1].Value = model.Name;                        
            parameters[2].Value = model.Count;                        
            parameters[3].Value = model.UnitPrice;                        
            parameters[4].Value = model.TotalPrice;                        
            parameters[5].Value = model.Status;                        
            parameters[6].Value = model.PaidTime;                        
            parameters[7].Value = model.Admin;                        
            parameters[8].Value = model.Customer;                        
            parameters[9].Value = model.HasBeenInvoiced;                        
            parameters[10].Value = model.InvoicedTime;                        
            parameters[11].Value = model.InvoicedOperator;                        
            parameters[12].Value = model.Remark;                        
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreOutOrderId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreOutCost ");
			strSql.Append(" where StoreOutOrderId=@StoreOutOrderId ");
						SqlParameter[] parameters = {
					new SqlParameter("@StoreOutOrderId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreOutOrderId;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.StoreOutCost GetModel(int StoreOutOrderId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StoreOutOrderId, Name, Count, UnitPrice, TotalPrice, Status, PaidTime, Admin, Customer, HasBeenInvoiced, InvoicedTime, InvoicedOperator, Remark  ");			
			strSql.Append("  from StoreOutCost ");
			strSql.Append(" where StoreOutOrderId=@StoreOutOrderId ");
						SqlParameter[] parameters = {
					new SqlParameter("@StoreOutOrderId", SqlDbType.Int,4)			};
			parameters[0].Value = StoreOutOrderId;

			
			DTcms.Model.StoreOutCost model=new DTcms.Model.StoreOutCost();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["StoreOutOrderId"].ToString()!="")
				{
					model.StoreOutOrderId=int.Parse(ds.Tables[0].Rows[0]["StoreOutOrderId"].ToString());
				}
																																				model.Name= ds.Tables[0].Rows[0]["Name"].ToString();
																												if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UnitPrice"].ToString()!="")
				{
					model.UnitPrice=decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["TotalPrice"].ToString()!="")
				{
					model.TotalPrice=decimal.Parse(ds.Tables[0].Rows[0]["TotalPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["PaidTime"].ToString()!="")
				{
					model.PaidTime=DateTime.Parse(ds.Tables[0].Rows[0]["PaidTime"].ToString());
				}
																																				model.Admin= ds.Tables[0].Rows[0]["Admin"].ToString();
																																model.Customer= ds.Tables[0].Rows[0]["Customer"].ToString();
																																												if(ds.Tables[0].Rows[0]["HasBeenInvoiced"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["HasBeenInvoiced"].ToString()=="1")||(ds.Tables[0].Rows[0]["HasBeenInvoiced"].ToString().ToLower()=="true"))
					{
					model.HasBeenInvoiced= true;
					}
					else
					{
					model.HasBeenInvoiced= false;
					}
				}
																if(ds.Tables[0].Rows[0]["InvoicedTime"].ToString()!="")
				{
					model.InvoicedTime=DateTime.Parse(ds.Tables[0].Rows[0]["InvoicedTime"].ToString());
				}
																																				model.InvoicedOperator= ds.Tables[0].Rows[0]["InvoicedOperator"].ToString();
																																model.Remark= ds.Tables[0].Rows[0]["Remark"].ToString();
																										
				return model;
			}
			else
			{
				return null;
			}
		}
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM StoreOutCost ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM StoreOutCost ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

