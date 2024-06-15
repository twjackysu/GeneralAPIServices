namespace API.Configuration
{
    public class Settings
    {
        public required HashSet<string> ValidKeys { get; set; }
        public required QAD QAD { get; set; }
        public required Swagger Swagger { get; set; }
    }
    public class Swagger
    {
        public required string DocumentFilter { get; set; }
    }
    public class QAD
    {
        public required QADEndPoints EndPoints { get; set; }
    }
    public class QADEndPoints
    {
        public required string MaintainGeneralizedCode { get; set; }
    }
}