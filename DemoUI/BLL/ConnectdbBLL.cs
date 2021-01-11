using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoUI.BLL
{
    class ConnectdbBLL
    {
        public void saveConnectionstring(string yourInitialCatalog, string yourDataSource, string userName, string passWord)
        {
            DEMOQLKTXEntities selectedDb = MyDb.GetInstance();
            selectedDb.ChangeDatabase(initialCatalog: yourInitialCatalog.Trim(), dataSource: yourDataSource.Trim(), userName, passWord);

            User firstUser = selectedDb.Users.FirstOrDefault();
            if (firstUser == null)
            {
                MessageBox.Show("Error");
            }

            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file. You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllText("ConnectString.txt", selectedDb.Database.Connection.ConnectionString);
        }
    }
}
