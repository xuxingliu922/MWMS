﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="storeout_waiting_goods_edit.aspx.cs" Inherits="DTcms.Web.admin.business.storeout_waiting_goods_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,goods-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑待出库货物</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            //创建上传附件
            $("#div_vehicle_container .attach-btn").click(function () {
                var vehicleDialog = top.dialog({
                    id: 'vehilcleDialogId',
                    title: "选择运输车辆",
                    url: '/admin/dialog/dialog_vehicle_list.aspx',
                    width: 700,
                    onclose: function () {

                    }
                }).showModal();
                vehicleDialog.data = $("#showVehicleList ul");
            });
        });

        function delNode(obj) {
            $(obj).parent().remove();
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="store_waiting.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="store_waiting.aspx"><span>待出库货物管理</span></a>
            <i class="arrow"></i>
            <span>编辑待出库货物</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">基本资料</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content" style="min-height: 800px;">
            <dl>
                <dt>入库单</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlStoreInOrder" runat="server" datatype="*" errormsg="请选择入库单" sucmsg=" " AutoPostBack="True" OnSelectedIndexChanged="ddlStoreInOrder_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>入库货物</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlStoreInGoods" runat="server" datatype="*" errormsg="请选择入库货物" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>计划出库时间</dt>
                <dd>
                    <asp:TextBox ID="txtStoringTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>操作员</dt>
                <dd>
                    <asp:TextBox ID="txtAdmin" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " Text=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>描述说明</dt>
                <dd>
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="input normal" TextMode="MultiLine" />
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl id="div_vehicle_container">
                <dt>运输车辆</dt>
                <dd>
                    <a class="icon-btn add attach-btn"><span>选择车辆</span></a>
                    <div id="showVehicleList" class="attach-list">
                        <ul>
                            <asp:Repeater ID="rptGoodsVehicleList" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a href="javascript:;" onclick="delNode(this);" class="del" title="删除"></a>
                                        <div class="btns">
                                            <input type="hidden" name="VehicleId" value="<%#Eval("VehicleId") %>" style="width: 70%;" />
                                            车牌号：<%#Eval("VehicleName") %>
                                        </div>
                                        <div class="btns">
                                            数&nbsp;&nbsp;&nbsp;量：<input type="text" name="Count" value="<%#Eval("Count") %>" style="width: 70%;" />
                                        </div>
                                        <div class="btns">
                                            备&nbsp;&nbsp;&nbsp;注：<input type="text" name="GoodsVehicleRemark" value="<%#Eval("Remark") %>" style="width: 70%;" />
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
