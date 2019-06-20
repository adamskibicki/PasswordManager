namespace PasswordManager
{
    public interface IDynamoDbConfiguration
    {
        string DynamoDBSecretAccessKey { get; set; }
        string DynamoDBAccessKeyId { get; set; }
    }
}