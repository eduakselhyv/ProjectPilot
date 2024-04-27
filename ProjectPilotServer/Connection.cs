namespace ProjectPilotServer
{
    public class Connection
    {
        public static string server = ""; // connection url, change when it is updated.
                                                           // when pushing into github, please make it blank!
                                                           // example: 2.tcp.eu.ngrok.io

        public static string port = ""; // connection port, change when it is updated.
                                             // when pushing into github, please make it blank as well!
                                             // example: 19672

        public static string database = "project_pilot";
        public static string user = "root";
        public static string password = "admin";

        public static string connStr =
            "server=" + server + ";" +
            "port=" + port + ";" +
            "database=" + database + ";" +
            "uid=" + user + ";" +
            "password=" + password + ";";
    }
}