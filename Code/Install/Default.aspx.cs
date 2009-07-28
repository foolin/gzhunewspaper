using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using Studio.IO;
using Studio.Web;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;



public partial class Install_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        string install = Request.QueryString["hasinstall"];
        if (install == null || install == "")
        {
            if (File.Exists(Server.MapPath("Install.lock")))
                Response.Redirect("Default.aspx?hasinstall=true&#step=hasInstall");
        }
         */

        if (File.Exists(Server.MapPath("Install.lock")))
            Response.Redirect("HasInstall.html");


    }


    public bool InitSysConfig(string connStr, string installPath)
    {
        bool flag = false;
        if (TestDBConnent(connStr))
        {
            //连接成功
            WebAgent.Alert("连接数据库成功！");


            //生成配置文件
            string strWebConfig = FileAgent.ReadText(Server.MapPath("inc/WebConfig.xml"), Encoding.Default);
            strWebConfig = strWebConfig.Replace("{$=DBString}", "server=localhost\\SQL2005;database=NewsPaper;uid=sa;pwd=123456");
            strWebConfig = strWebConfig.Replace("{$=InstallDir}", installPath);
            FileAgent.WriteText(Server.MapPath("../Web.Config"), strWebConfig, false, Encoding.Default);
            WebAgent.Alert("生成配置文件成功！");


            //执行创建表
            if (ExecuteScript(Server.MapPath("inc/data.sql"), connStr))
            {
                WebAgent.Alert("创建数据库表成功！");

                if (ExecuteScript(Server.MapPath("inc/proc.sql"), connStr))
                {
                    WebAgent.Alert("创建存储过程成功！");

                    flag = true;
                }
                else
                {
                    WebAgent.Alert("创建存储过程失败！");

                }
            }
            else
            {
                WebAgent.Alert("创建数据库表失败！");

            }
        }
        else
        {
            //this.State.Text = "连接数据库失败！";
            WebAgent.Alert("连接数据库失败！");


        }

        return flag;
    }


    protected bool TestDBConnent(string connString)
    {
        SqlConnection conn; 
        string strConnString = "";
        bool isSuccess = false;

        //获取数据库连接字符串
        strConnString = connString;

        //创建连接对象
        conn = new SqlConnection(strConnString);

        try
        {
            //Open DataBase
            //打开数据库
            conn.Open();
                isSuccess = true;
        }
        catch (Exception ex)
        {
            //throw new Exception("ExecuteScript Failed: ", ex);
            //Can not Open DataBase
            //打开不成功 则连接不成功
            isSuccess = false;

        }
        finally
        {
            //Close DataBase
            //关闭数据库连接
            conn.Close();
        }
        return isSuccess;

    }


 

    static public bool ExecuteScript(string scriptPath, string connString)
    {
        bool isSuccess = false; //判断是否成功执行
        //SqlConnection myConnection = new SqlConnection(connString);
        string strScript = GetScript(scriptPath);
        List<string> errors = new List<string>();
        // Subdivide script based on GO keyword
        string[] sqlCommands = Regex.Split(strScript, "\\sGO\\s", RegexOptions.IgnoreCase);

        //SqlConnection myConnection = new SqlConnection("server=localhost\\SQL2005;database=NewsPaper;uid=sa;pwd=123456");
        SqlConnection myConnection = new SqlConnection(connString);
        myConnection.Open();
        //SqlTransaction myTrans = myConnection.BeginTransaction();
        SqlTransaction myTrans;
        string transactionName = "Foolin";
        myTrans = myConnection.BeginTransaction(IsolationLevel.RepeatableRead, transactionName);

        try
        {
            for (int s = 0; s <= sqlCommands.GetUpperBound(0); s++)
            {
                string mySqlText = sqlCommands[s].Trim();

                try
                {

                    if (mySqlText.Length > 0)
                    {
                        //myConnection.Open();

                        using (SqlCommand sqldbCommand = new SqlCommand())
                        {
                            sqldbCommand.Connection = myConnection;
                            sqldbCommand.CommandType = CommandType.Text;
                            sqldbCommand.Transaction = myTrans;
                            sqldbCommand.CommandText = mySqlText;
                            sqldbCommand.CommandTimeout = 150;
                            sqldbCommand.ExecuteNonQuery();
                        }


                    }
                }

				catch (Exception ex)
				{
					myTrans.Rollback();

					//throw new DatabaseUnreachableException("ExecuteScript Failed: " + mySqlText, ex);
					throw new Exception("ExecuteScript Failed: " + mySqlText, ex);
				}
			}
			// Succesfully applied this script
			myTrans.Commit();
            isSuccess = true;
		}

		catch (Exception ex)
		{
            //throw new Exception("ExecuteScript Failed: ", ex);
            isSuccess = false;
		}

		finally
		{

			if (myConnection.State == ConnectionState.Open)
				myConnection.Close();
		}
		return isSuccess;
	}





        /// <summary>
    /// Get the script from a file
    /// </summary>
    /// <returns></returns>
    private static string GetScript(string scriptPath)
    {
        string strScript = string.Empty;

        using (System.IO.StreamReader objStreamReader = new System.IO.StreamReader(scriptPath, System.Text.Encoding.Default))
        {
            strScript = objStreamReader.ReadToEnd();
            objStreamReader.Close();
        }
        return strScript + Environment.NewLine;
    }



    protected void btnInstall_Click(object sender, EventArgs e)
    {
        if (DBserver.Text == "" || DBname.Text == "")
        {
            WebAgent.AlertAndBack("请填写完整数据库配置信息！");
        }
        if (path.Text == "")
        {
            WebAgent.AlertAndBack("请填写当前的安装目录！");
        }

        string connstr = "server=" + DBserver.Text + ";database= " + DBname.Text + ";uid=" + DBuid.Text + ";pwd=" + DBpwd.Text;
        string installPath = path.Text.ToString();
        StreamWriter sw = null;     //写入配置文件和锁定文件用到的对象。


        if (TestDBConnent(connstr))
        {

            //连接成功
            //WebAgent.Alert("连接数据库成功！");
            Session["ConnectState"] = "<span class=\"success\">√成功</span>";
            Session["InstallPath"] = "<span class=\"success\"> " + installPath + "</span>";
            //生成配置文件
            /*
            string strWebConfig = FileAgent.ReadText(Server.MapPath("inc/WebConfig.xml"), Encoding.Default);
            strWebConfig = strWebConfig.Replace("{$=DBString}", "server=localhost\\SQL2005;database=NewsPaper;uid=sa;pwd=123456");
            strWebConfig = strWebConfig.Replace("{$=InstallDir}", installPath);
            FileAgent.WriteText(Server.MapPath("../Web.Config"), strWebConfig, false, Encoding.Default);
            WebAgent.Alert("生成配置文件成功！");
            Session["CreateConfigState"] = "<span class=\"success\">√成功</span>";
             */


            //写入配置文件
            try
            {
                string strWebConfig = FileAgent.ReadText(Server.MapPath("inc/WebConfig.xml"), Encoding.Default);
                strWebConfig = strWebConfig.Replace("{$=DBString}", connstr);
                strWebConfig = strWebConfig.Replace("{$=InstallDir}", installPath);
                sw = new StreamWriter(Server.MapPath("../Web.Config"), false, Encoding.Default);
                sw.WriteLine(strWebConfig);
                Session["CreateConfigState"] = "<span class=\"success\">√成功</span>";
                //FileAgent.WriteText("c:\\Unlock.txt", "###UnLock###", false, Encoding.Default);
            }
            catch (Exception ex)
            {
                //WebAgent.Alert("写入文件失败！");
                Session["CreateConfigState"] = "<span class=\"error\">×写入Web.Config配置文件失败！<br />请检查根目录Web.Config配置文件是否具有写入权限。或者按照安装说明自行配置该文件！</span>";
                //throw new Exception("ExecuteScript Failed: ", ex);
            }
            finally
            {
                if (sw != null) sw.Close();
            }

            //写入锁定文件
            try
            {
                sw = new StreamWriter(Server.MapPath("Install.lock"), false, Encoding.Default);
                sw.WriteLine("E酷工作室 Authro:Foolin E-mail:Foolin@126.com www.eekku.com");
                Session["LockInstallState"] = "<span class=\"success\">√成功</span> ";
                //FileAgent.WriteText("c:\\Unlock.txt", "###UnLock###", false, Encoding.Default);
            }
            catch (Exception ex)
            {
                //WebAgent.Alert("写入文件失败！");
                Session["LockInstallState"] = "<span class=\"error\">锁定安装文件失败，为了系统的安全，请自行删除Install目录及所有文件！</span> ";
                //throw new Exception("ExecuteScript Failed: ", ex);
            }
            finally
            {
                if (sw != null) sw.Close();
            }


            //创建数据库表文件
            if (ExecuteScript(Server.MapPath("inc/CreateTables.sql"), connstr))
            {
                //WebAgent.Alert("创建数据库表成功！");
                Session["CreateTableState"] = "<span class=\"success\">√成功</span>";
                //执行创建存储过程
                if (ExecuteScript(Server.MapPath("inc/CreateProc.sql"), connstr))
                {

                    //提示安装成功！
                    //WebAgent.Alert("创建存储过程成功！");
                    Session["CreateProcState"] = "<span class=\"success\">√成功</span>";
                    //初始化帐号和密码
                    Session["AdminAndPwd"] = "帐号：admin &nbsp;&nbsp;&nbsp;&nbsp; 密码：123456";
                    //写入已经安装文件
                    //FileAgent.WriteText(Server.MapPath("Install.lock"), "E酷工作室 Authro:Foolin E-mail:Foolin@126.com www.eekku.com", false, Encoding.Default);

                    HttpContext.Current.Response.Write("<script language='javascript'>window.location.href='#step=step3';</script>");
                    //Response.Redirect("?hasinstall=true&#step=step3");
                }
                else
                {
                    //WebAgent.Alert("创建存储过程失败！");
                    Session["CreateProcState"] = "<span class=\"error\">× 失败！请按照安装说明自行在数据库中执行【App_Data/CreateProcedure.sql】脚本。</span>";
                    Session["AdminAndPwd"] = "<span class=\"error\">×错误！未初始化帐号和密码！请按照安装说明，自行在数据库中执行【App_Data/CreateProcedure.sql】脚本。 </span>";
                    HttpContext.Current.Response.Write("<script language='javascript'>window.location.href='#step=step3';</script>");
                }
            }
            else
            {
                //WebAgent.Alert("创建数据库表失败！");
                Session["CreateTableState"] = "<span class=\"error\">× 失败！请按照安装说明，自行在数据库中执行【App_Data/CreateTables.sql】脚本。</span>";
                Session["CreateProcState"] = "<span class=\"error\">× 失败！请按照安装说明，自行在数据库中执行【App_Data/CreateProcedure.sql】脚本。</span>";
                Session["AdminAndPwd"] = "<span class=\"error\">×错误！未初始化帐号和密码！请按照安装说明，自行在数据库中执行【App_Data/CreateProcedure.sql】脚本。 </span>";
                HttpContext.Current.Response.Write("<script language='javascript'>window.location.href='#step=step3';</script>");
            }
        }
        else
        {
            WebAgent.AlertAndBack("连接数据库失败！请检查连接数据库配置填写是否正确！");
        }

    }
}
