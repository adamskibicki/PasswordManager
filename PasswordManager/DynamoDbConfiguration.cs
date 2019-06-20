namespace PasswordManager
{
    public class DynamoDbConfiguration : IDynamoDbConfiguration
    {
        public string DynamoDBSecretAccessKey { get; set; }
        public string DynamoDBAccessKeyId { get; set; }
    }
}