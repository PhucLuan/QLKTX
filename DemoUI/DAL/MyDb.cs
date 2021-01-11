namespace DemoUI
{
    public class MyDb
    {
        private static DEMOQLKTXEntities dbContext { get; set; }

        private MyDb()
        {
        }

        public static DEMOQLKTXEntities GetInstance()
        {
            if (dbContext == null)
            {
                dbContext = new DEMOQLKTXEntities();
            }

            return dbContext;
        }
    }
}
