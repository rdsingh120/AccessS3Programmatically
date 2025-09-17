using Amazon.S3.Model;

namespace AccessS3Programmatically
{
    internal class BucketOperations
    {
        public async Task<CreateBucketResponse> CreateBucket(string bucketName)
        {
            var putBucketRequest = new PutBucketRequest
            {
                BucketName = bucketName,
                UseClientRegion = true,
            };

            var response = await S3ClientProvider.s3Client.PutBucketAsync(putBucketRequest);

            return new CreateBucketResponse
            {
                BucketName = bucketName,
                RequestId = response.ResponseMetadata.RequestId
            };
        }

        public async Task GetBucketList()
        {
            ListBucketsResponse response = await S3ClientProvider.s3Client.ListBucketsAsync();
            foreach (S3Bucket bucket in response.Buckets)
            {
                Console.WriteLine(bucket.BucketName + " " + bucket.CreationDate.Value.ToShortDateString());
            }
        }
    }
}
