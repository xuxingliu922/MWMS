﻿using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.business
{
    public partial class storeout_waiting_goods : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int storein_order_id;
        protected int goods_id;
        protected string beginTime = string.Empty;
        protected string endTime = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.storein_order_id = DTRequest.GetQueryInt("storein_order_id");
            this.goods_id = DTRequest.GetQueryInt("goods_id");
            this.beginTime = DTRequest.GetQueryString("beginTime");
            this.endTime = DTRequest.GetQueryString("endTime");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("storeout_waiting_manage", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind("");
                RptBind(" and A.Status = 0 " + CombSqlTxt(this.storein_order_id, this.goods_id, this.beginTime, this.endTime), "A.StoringOutTime ASC");
            }
        }

        private void TreeBind(string strWhere)
        {
            BLL.StoreInOrder storeinOrderBLL = new BLL.StoreInOrder();
            DataTable customerDT = storeinOrderBLL.GetList(0, " Status = 2 ", "Id desc").Tables[0];

            this.ddlStoreInOrder.Items.Clear();
            this.ddlStoreInOrder.Items.Add(new ListItem("所属入库单", ""));
            foreach (DataRow dr in customerDT.Rows)
            {
                this.ddlStoreInOrder.Items.Add(new ListItem(dr["AccountNumber"].ToString(), dr["Id"].ToString()));
            }

            BLL.Goods goodsBLL = new BLL.Goods();
            DataTable goodsDT = goodsBLL.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlGoods.Items.Clear();
            this.ddlGoods.Items.Add(new ListItem("货物", ""));
            foreach (DataRow dr in goodsDT.Rows)
            {
                this.ddlGoods.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }

        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _goodsby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (this.storein_order_id > 0)
            {
                this.ddlStoreInOrder.SelectedValue = this.storein_order_id.ToString();
            }
            if (this.goods_id > 0)
            {
                this.ddlGoods.SelectedValue = this.goods_id.ToString();
            }
            txtBeginTime.Text = this.beginTime;
            txtEndTime.Text = this.endTime;
            BLL.StoreOutWaitingGoods bll = new BLL.StoreOutWaitingGoods();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _goodsby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("storeout_waiting_goods.aspx", "storein_order_id={0}&goods_id={1}&beginTime={2}&endTime={3}&page={4}",
                this.storein_order_id.ToString(), this.goods_id.ToString(), this.beginTime.ToString(), this.endTime, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _storein_order_id, int _goods_id, string _beginTime, string _endTime)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_storein_order_id > 0)
            {
                strTemp.Append(" and A.StoreInOrderId=" + _storein_order_id);
            }
            if (_goods_id > 0)
            {
                strTemp.Append(" and A.GoodsId=" + _goods_id);
            }
            if (!string.IsNullOrEmpty(beginTime))
            {
                strTemp.Append(" and A.StoringOutTime>='" + _beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strTemp.Append(" and A.StoringOutTime <='" + _endTime + "'");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("storeout_waiting_page_size", "DTcmsPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion


        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("storeout_waiting_goods.aspx", "storein_order_id={0}&goods_id={1}&beginTime={2}&endTime={3}",
                this.storein_order_id.ToString(), this.goods_id.ToString(), txtBeginTime.Text, txtEndTime.Text));
        }

        //待出库状态
        protected void ddlStoreInOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("storeout_waiting_goods.aspx", "storein_order_id={0}&goods_id={1}&beginTime={2}&endTime={3}",
                ddlStoreInOrder.SelectedValue, this.goods_id.ToString(), this.beginTime, this.endTime));
        }

        //支付状态
        protected void ddlGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("storeout_waiting_goods.aspx", "storein_order_id={0}&goods_id={1}&beginTime={2}&endTime={3}",
                this.storein_order_id.ToString(), ddlGoods.SelectedValue, this.beginTime, this.endTime));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("storeout_waiting_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("storeout_waiting_goods.aspx", "storein_order_id={0}&goods_id={1}&beginTime={2}&endTime={3}",
                this.storein_order_id.ToString(), this.goods_id.ToString(), this.beginTime.ToString(), this.endTime));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("storeout_waiting_manage", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.StoreOutWaitingGoods bll = new BLL.StoreOutWaitingGoods();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除待出库成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("storeout_waiting_goods.aspx", "storein_order_id={0}&goods_id={1}&beginTime={2}&endTime={3}",
                this.storein_order_id.ToString(), this.goods_id.ToString(), this.beginTime.ToString(), this.endTime));
        }

    }
}