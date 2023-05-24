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



public class SqlDb_ShoeiMySQLDB
{

    // サーバー接続情報
    private string server = "192.168.0.156";
    private string database = "shoei_skanri";
    private string user = "alluser";
    private string pass = "wew111589";
    private string charset = "utf8";

    private MySqlConnection _Mycon = null/* TODO Change to default(_) if this is not a reference type */;

    public SqlDb_ShoeiMySQLDB(string svr = "192.168.0.156", string dbn = "marktv", string uid = "alluser", string pas = "wew111589")
    {
        server = svr;
        database = dbn;
        user = uid;
        pass = pas;
    }

    // #################
    // ##　データベースとの接続
    // #################
    private void Connect()
    {
        try
        {

            // 接続確認
            if (_Mycon == null)
                _Mycon = new MySqlConnection();

            // 接続
            string connstr = string.Format("Server={0};Database={1};Uid={2};Pwd={3};Charset={4}", server, database, user, pass, charset);
            _Mycon.ConnectionString = connstr;
            _Mycon.Open();
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
            _Mycon.Close();
        }
        catch (Exception ex)
        {
            throw new Exception("Disconnect Error", ex);
        }
    }

    // ####################
    // ##　SQL実行(データ取得)
    // ####################
    public DataTable ExecuteSql(string sql)
    {
        this.Connect();
        DataTable dt = new DataTable();

        try
        {
            MySqlCommand sqlCommand = new MySqlCommand(sql, _Mycon);

            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlCommand);

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

        int dt = new int();

        try
        {
            MySqlCommand sqlCommand = new MySqlCommand(sql, _Mycon);

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
            MySqlCommand sqlCommand = new MySqlCommand(sql, _Mycon);

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



    public void Change_db(string db_name)
    {
        database = db_name;
    }
}