﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL
{
    //StoreOutOrder
    public partial class StoreOutOrder
    {

        private readonly DTcms.DAL.StoreOutOrder dal = new DTcms.DAL.StoreOutOrder();
        public StoreOutOrder()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id, int CustomerId)
        {
            return dal.Exists(Id, CustomerId);
        }

        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.StoreOutOrder model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.StoreOutOrder model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.StoreOutOrder GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public DTcms.Model.StoreOutOrder GetModelByCache(int Id)
        //{

        //    string CacheKey = "StoreOutOrderModel-" + Id;
        //    object objModel = DTcms.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = DTcms.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DTcms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (DTcms.Model.StoreOutOrder)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.StoreOutOrder> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.StoreOutOrder> DataTableToList(DataTable dt)
        {
            List<DTcms.Model.StoreOutOrder> modelList = new List<DTcms.Model.StoreOutOrder>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DTcms.Model.StoreOutOrder model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DTcms.Model.StoreOutOrder();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["CustomerId"].ToString() != "")
                    {
                        model.CustomerId = int.Parse(dt.Rows[n]["CustomerId"].ToString());
                    }
                    if (dt.Rows[n]["StoreInUnitPriceStoreInOrderId"].ToString() != "")
                    {
                        model.StoreInOrderId = int.Parse(dt.Rows[n]["StoreInUnitPriceStoreInOrderId"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    model.Admin = dt.Rows[n]["Admin"].ToString();
                    if (dt.Rows[n]["TotalMoney"].ToString() != "")
                    {
                        model.TotalMoney = decimal.Parse(dt.Rows[n]["TotalMoney"].ToString());
                    }
                    if (dt.Rows[n]["InvoiceMoney"].ToString() != "")
                    {
                        model.InvoiceMoney = decimal.Parse(dt.Rows[n]["InvoiceMoney"].ToString());
                    }
                    if (dt.Rows[n]["HasBeenInvoiced"].ToString() != "")
                    {
                        if ((dt.Rows[n]["HasBeenInvoiced"].ToString() == "1") || (dt.Rows[n]["HasBeenInvoiced"].ToString().ToLower() == "true"))
                        {
                            model.HasBeenInvoiced = true;
                        }
                        else
                        {
                            model.HasBeenInvoiced = false;
                        }
                    }
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion

    }
}