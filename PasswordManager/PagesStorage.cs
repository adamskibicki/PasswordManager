using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;

namespace PasswordManager
{
    public class PagesStorage : IPagesStorage
    {
        private readonly IDynamoDbConfiguration _dynamoDbConfiguration;

        public PagesStorage(IDynamoDbConfiguration dynamoDbConfiguration)
        {
            _dynamoDbConfiguration = dynamoDbConfiguration;
        }

        public async Task<bool> AddAsync(Page page)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(new BasicAWSCredentials(_dynamoDbConfiguration.DynamoDBAccessKeyId, _dynamoDbConfiguration.DynamoDBSecretAccessKey), RegionEndpoint.USEast2);

            Table table = Table.LoadTable(client, "Pages");

            var pageDocument = new Document();
            pageDocument[nameof(page.Name)] = page.Name;
            pageDocument[nameof(page.Url)] = page.Url;
            pageDocument[nameof(page.Password)] = page.Password;
            pageDocument["Id"] = Guid.NewGuid().ToString();

            var result = await table.PutItemAsync(pageDocument, CancellationToken.None);

            return true;
        }
    }
}