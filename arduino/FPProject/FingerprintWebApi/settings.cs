namespace FingerprintWebApi {
    public static class settings {
        public static string connectionString =
                                   "server = localhost\\SQLEXPRESS;" +
                                   "Trusted_Connection=True;" +
                                   "database=student; ";
        public static string studentBDTableName = "ieder";
        public static string passwordToAccesThisServer = "testWachtwoord";
    }
}