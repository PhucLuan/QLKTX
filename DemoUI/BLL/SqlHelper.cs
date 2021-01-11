using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;


public static class SqlHelper
{
    public static IEnumerable<string> ListLocalSqlInstances()
    {
        if (!Environment.Is64BitOperatingSystem)
        {
            foreach (string item in ListLocalSqlInstances(Registry.LocalMachine))
            {
                yield return item;
            }

            yield break;
        }

        using (RegistryKey hive = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
        {
            foreach (string item in ListLocalSqlInstances(hive))
            {
                yield return item;
            }
        }

        using (RegistryKey hive = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
        {
            foreach (string item in ListLocalSqlInstances(hive))
            {
                yield return item;
            }
        }
    }
    public static string check = "";//Xem chuỗi
    private static IEnumerable<string> ListLocalSqlInstances(RegistryKey hive)
    {
        const string keyName = @"Software\Microsoft\Microsoft SQL Server";
        const string valueName = "InstalledInstances";
        const string defaultName = "MSSQLSERVER";

        using (RegistryKey key = hive.OpenSubKey(keyName, false))
        {
            if (key == null || !(key.GetValue(valueName) is string[] instances))
            {
                return Enumerable.Empty<string>();
            }

            for (int index = 0; index < instances.Length; index++)
            {
                instances[index] = string.Equals(instances[index], defaultName, StringComparison.OrdinalIgnoreCase) ? "." : @".\" + instances[index];
            }

            return instances;
        }
    }

    //Lấy database trên sql của máy
    public static IEnumerable<string> GetDatabases(string sqlServerName, string userName = "", string password = "")
    {
        string connectionString = "";
        // If use Windows authentication
        if (string.IsNullOrWhiteSpace(userName) && string.IsNullOrWhiteSpace(password))
        {
            connectionString = string.Format($"Data Source={sqlServerName};Integrated Security=True");
        }
        else
        {
            connectionString = string.Format($"Data Source={sqlServerName}; User ID={userName};Password={password};Integrated Security=True");
        }
        

        DataTable databases = null;
        try
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                databases = sqlConnection.GetSchema("Databases");
            }
        }
        catch (Exception)
        {
            yield break;
        }

        foreach (DataRow row in databases.Rows)
        {
            yield return row.ItemArray.First().ToString();
        }
    }
    public static void ChangeDatabase(this DbContext source, string ConnectString)
    {
        source.Database.Connection.ConnectionString = ConnectString;
    }
    public static void ChangeDatabase(this DbContext source, string initialCatalog = "", string dataSource = "", string userId = "", string password = "", bool integratedSecuity = true, string configConnectionStringName = "")
    {
        try
        {
            string configName = string.IsNullOrEmpty(configConnectionStringName) ? source.GetType().Name : configConnectionStringName;


            var entityConStrBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings[configName].ConnectionString);

            var connectionStringBuilder = new SqlConnectionStringBuilder(entityConStrBuilder.ProviderConnectionString);

            if (!string.IsNullOrEmpty(initialCatalog))
            {
                connectionStringBuilder.InitialCatalog = initialCatalog;
            }
            if (!string.IsNullOrEmpty(dataSource))
            {
                connectionStringBuilder.DataSource = dataSource;
            }
            if (!string.IsNullOrEmpty(userId))
            {
                connectionStringBuilder.UserID = userId;
            }

            if (!string.IsNullOrEmpty(password))
            {
                connectionStringBuilder.Password = password;
            }

            connectionStringBuilder.IntegratedSecurity = integratedSecuity;

            source.Database.Connection.ConnectionString = connectionStringBuilder.ConnectionString;
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message}");
        }
    }
}