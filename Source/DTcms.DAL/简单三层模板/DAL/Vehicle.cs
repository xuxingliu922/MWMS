﻿using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
	.DTcms.DAL
{
	 	//Vehicle
		public partial class Vehicle
	{
   		     
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Vehicle");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = SQL2012Id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4)			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.Vehicle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Vehicle(");			
            strSql.Append("Id,PlateNumber,Driver,LinkTel,LinkAddress,Remark");
			strSql.Append(") values (");
            strSql.Append("SQL2012Id,SQL2012PlateNumber,SQL2012Driver,SQL2012LinkTel,SQL2012LinkAddress,SQL2012Remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012PlateNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Driver", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LinkAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.PlateNumber;                        
            parameters[2].Value = model.Driver;                        
            parameters[3].Value = model.LinkTel;                        
            parameters[4].Value = model.LinkAddress;                        
            parameters[5].Value = model.Remark;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Vehicle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Vehicle set ");
			                        
            strSql.Append(" Id = SQL2012Id , ");                                    
            strSql.Append(" PlateNumber = SQL2012PlateNumber , ");                                    
            strSql.Append(" Driver = SQL2012Driver , ");                                    
            strSql.Append(" LinkTel = SQL2012LinkTel , ");                                    
            strSql.Append(" LinkAddress = SQL2012LinkAddress , ");                                    
            strSql.Append(" Remark = SQL2012Remark  ");            			
			strSql.Append(" where Id=SQL2012Id  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012PlateNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Driver", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LinkAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Remark", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.PlateNumber;                        
            parameters[2].Value = model.Driver;                        
            parameters[3].Value = model.LinkTel;                        
            parameters[4].Value = model.LinkAddress;                        
            parameters[5].Value = model.Remark;                        
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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Vehicle ");
			strSql.Append(" where Id=SQL2012Id ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4)			};
			parameters[0].Value = Id;


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
		public Maticsoft.Model.Vehicle GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, PlateNumber, Driver, LinkTel, LinkAddress, Remark  ");			
			strSql.Append("  from Vehicle ");
			strSql.Append(" where Id=SQL2012Id ");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4)			};
			parameters[0].Value = Id;

			
			Maticsoft.Model.Vehicle model=new Maticsoft.Model.Vehicle();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																				model.PlateNumber= ds.Tables[0].Rows[0]["PlateNumber"].ToString();
																																model.Driver= ds.Tables[0].Rows[0]["Driver"].ToString();
																																model.LinkTel= ds.Tables[0].Rows[0]["LinkTel"].ToString();
																																model.LinkAddress= ds.Tables[0].Rows[0]["LinkAddress"].ToString();
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
			strSql.Append(" FROM Vehicle ");
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
			strSql.Append(" FROM Vehicle ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

