using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

public class SqlDb_TPiCSDB41
{
    private SqlConnection _con = null;
    private SqlTransaction _trn = null;

    // #################
    // ##　データベースとの接続
    // #################


    //private void Connect(string svr = @"SD099\SQLEXPRESS2019", string dbn = "IM_Local", string uid = "IMTEST_USER", string pas = "test", int tot = -1)   Local接続情報
    private void Connect(string svr = @"tpicsserver\SQLServer2016", string dbn = "TPiCSDB41", string uid = "shoeidenkotpics", string pas = "tpics", int tot = -1)
    {
        try
        {
            if (_con == null)
                _con = new SqlConnection();

            string cst = "";
            cst = cst + "Server=" + svr;
            cst = cst + ";Database=" + dbn;
            cst = cst + ";User ID=" + uid;
            cst = cst + ";Password=" + pas;
            if (tot > -1)
                // _con.ConnectionTimeout = tot
                cst = cst + ";Connect Timeout=" + tot.ToString();
            _con.ConnectionString = cst;

            if (_con.State == ConnectionState.Open)
            {
            }
            else
            {
            }
            _con.Open();
        }
        catch (Exception ex)
        {
            throw new Exception("Connect Error", ex);
        }
    }

    // ####################
    // ##　データベースとの接続解除
    // ####################
    private void Disconnect()
    {
        try
        {
            _con.Close();
            if (_con.State == ConnectionState.Open)
            {
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Disconnect Error", ex);
        }
    }

    // ####################
    // ##　SQL実行(データ取得)
    // ####################
    public DataTable ExecuteSql(string sql, int tot = -1)
    {
        this.Connect();
        DataTable dt = new();


        try
        {
            SqlCommand sqlCommand = new(sql, _con, _trn);

            if (tot > -1)
                sqlCommand.CommandTimeout = tot;

            SqlDataAdapter adapter = new(sqlCommand);

            adapter.Fill(dt);
            adapter.Dispose();
            sqlCommand.Dispose();
        }
        catch (Exception ex)
        {
            throw new Exception("ExecuteSql Error", ex);
        }

        this.Disconnect();
        return dt;
    }

    // ####################
    // ##　SQL実行(データ取得)
    // ####################
    public string ExecuteScalar(string sql, int tot = -1)
    {
        this.Connect();
        string db_Scalar;
        object ReturnValue;


        try
        {
            SqlCommand sqlCommand = new(sql, _con, _trn);

            if (tot > -1)
                sqlCommand.CommandTimeout = tot;


            ReturnValue = sqlCommand.ExecuteScalar();
            if (ReturnValue == DBNull.Value | ReturnValue == null)
                db_Scalar = "";
            else
                db_Scalar = ReturnValue.ToString();
            sqlCommand.Dispose();
        }
        catch (Exception ex)
        {
            throw new Exception("ExecuteSql Error", ex);
        }

        this.Disconnect();
        return db_Scalar;
    }
}




public class SqlDb_ShoeiDB
{
    private SqlConnection _con = null;
    private SqlTransaction _trn = null;

    // #################
    // ##　データベースとの接続
    // #################

    //private void Connect(string svr = @"SD099\SQLEXPRESS2019", string dbn = "IM_Local", string uid = "IMTEST_USER", string pas = "test", int tot = -1)   Local接続情報
    private void Connect(string svr = @"tpicsserver\SQLServer2016", string dbn = "ShoeiDB", string uid = "shoeidenkotpics", string pas = "tpics", int tot = -1)
    {
        try
        {
            if (_con == null)
                _con = new SqlConnection();

            string cst = "";
            cst = cst + "Server=" + svr;
            cst = cst + ";Database=" + dbn;
            cst = cst + ";User ID=" + uid;
            cst = cst + ";Password=" + pas;
            if (tot > -1)
                // _con.ConnectionTimeout = tot
                cst = cst + ";Connect Timeout=" + tot.ToString();
            _con.ConnectionString = cst;

            if (_con.State == ConnectionState.Open)
            {
            }
            else
            {
            }
            _con.Open();
        }
        catch (Exception ex)
        {
            throw new Exception("Connect Error", ex);
        }
    }

    // ####################
    // ##　データベースとの接続解除
    // ####################
    private void Disconnect()
    {
        try
        {
            _con.Close();
            if (_con.State == ConnectionState.Open)
            {
            }
            else
            {
            }
        }

        catch (Exception ex)
        {
            throw new Exception("Disconnect Error", ex);
        }
    }

    // ####################
    // ##　SQL実行(データ取得)
    // ####################
    public DataTable ExecuteSql(string sql, int tot = -1)
    {
        this.Connect();
        DataTable dt = new();

        try
        {
            SqlCommand sqlCommand = new(sql, _con, _trn);

            if (tot > -1)
                sqlCommand.CommandTimeout = tot;

            SqlDataAdapter adapter = new(sqlCommand);

            adapter.Fill(dt);
            adapter.Dispose();
            sqlCommand.Dispose();
        }
        catch (Exception ex)
        {
            throw new Exception("ExecuteSql Error", ex);
        }

        this.Disconnect();
        return dt;
    }

    // ####################
    // ##　SQL実行(Update, Insert)
    // ####################
    public int ExecutenonSql(string sql, int tot = -1)
    {
        this.Connect();

        int dt = new();

        try
        {
            SqlCommand sqlCommand = new(sql, _con, _trn);

            if (tot > -1)
                sqlCommand.CommandTimeout = tot;


            dt = sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();
        }
        catch (Exception ex)
        {
            throw new Exception("ExecuteSql Error", ex);
        }

        this.Disconnect();
        return dt;
    }

    // ####################
    // ##　SQL実行(データ取得)
    // ####################
    public string ExecuteScalar(string sql, int tot = -1)
    {
        this.Connect();
        string db_Scalar;
        object ReturnValue;

        try
        {
            SqlCommand sqlCommand = new(sql, _con, _trn);

            if (tot > -1)
                sqlCommand.CommandTimeout = tot;


            ReturnValue = sqlCommand.ExecuteScalar();
            if (ReturnValue == DBNull.Value | ReturnValue == null)
                db_Scalar = "";
            else
                db_Scalar = ReturnValue.ToString();
            sqlCommand.Dispose();
        }
        catch (Exception ex)
        {
            throw new Exception("ExecuteSql Error", ex);
        }

        this.Disconnect();
        return db_Scalar;
    }
}





public class MySqlDb_Karabako
{
    private MySqlConnection _MyCon = null;
    private MySqlTransaction _trn = null;

    private void Connect()
    {
        string server = "192.168.0.156";
        string database = "karabako";
        string user = "alluser";
        string pass = "wew111589";
        string charset = "utf8";
        string connstr = string.Format("Server={0};Database={1};Uid={2};Pwd={3};Charset={4};SslMode = none", server, database, user, pass, charset);

        _MyCon = new MySqlConnection(connstr);
        _MyCon.Open();
    }



    private void Disconnect()
    {
        try
        {
            _MyCon.Close();
            if (_MyCon.State == ConnectionState.Open) { }
            else { }
        }
        catch (Exception ex)
        {
            throw new Exception("Disconnect Error", ex);
        }
    }



    public DataTable ExecuteMySql(string Mysql, int tot = -1)
    {
        this.Connect();

        // データを格納するテーブル作成
        DataTable dt = new();

        // SQL文と接続情報を指定し、データアダプタを作成
        MySqlDataAdapter da = new(Mysql, _MyCon);

        // データ取得
        da.Fill(dt);

        this.Disconnect();
        return dt;
    }

    public int ExecutenonMySql(string Mysql, int tot = -1)
    {
        this.Connect();

        int dt = new();

        try
        {
            MySqlCommand mysqlCommand = new(Mysql, _MyCon, _trn);

            if (tot > -1)
                mysqlCommand.CommandTimeout = tot;


            dt = mysqlCommand.ExecuteNonQuery();

            mysqlCommand.Dispose();
        }
        catch (Exception ex)
        {
            throw new Exception("ExecuteSql Error", ex);
        }

        this.Disconnect();
        return dt;
    }
}
