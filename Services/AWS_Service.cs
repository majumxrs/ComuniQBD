using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.DeviceFarm.Model;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using ComuniQBD.Models;
using Azure.Core;
using dotenv.net;


namespace ComuniQBD.Services
{
    public class AWS_Service
    {
        private readonly AmazonS3Client AWS_CLIENT;
        public AWS_Service()
        {;

            DotEnv.Load();
            var setup = DotEnv.Read();
            if(setup["accessKey"] != "" && setup["secretKey"] != "") 
            {
                var credentials = new BasicAWSCredentials(setup["accessKey"], setup["secretKey"]);
                AWS_CLIENT = new AmazonS3Client(credentials, RegionEndpoint.USEast1);
            }
        }

        public async Task<bool> UploadObject(HttpRequest request, string identifier, string key)
        {
            var file = request.Form.Files[0];
            if (file.Length > 0)
            {
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        ms.Position = 0;

                        var S3object = new PutObjectRequest
                        {
                            BucketName = "comuniq",
                            Key = key + "_" + identifier + ".jpg",
                            InputStream = ms,
                            ContentType = file.ContentType
                        };
                        PutObjectResponse response = await AWS_CLIENT.PutObjectAsync(S3object);

                        if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
                        {
                            throw new Exception("Falha no upload para S3. Status code: " + response.HttpStatusCode);
                        }
                    }

                }
                catch (AmazonS3Exception e)
                {
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {

                    AWS_CLIENT?.Dispose();
                }
                return true;

            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteObject(string keyObject)
        {
            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = "comuniq",
                    Key = keyObject
                };
                await AWS_CLIENT.DeleteObjectAsync(deleteObjectRequest);
                return true;
            }
            catch (AmazonS3Exception e)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                AWS_CLIENT?.Dispose();
            }
        }
    }
}
