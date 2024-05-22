using kullanici_kayit_web_ui.apicom.apiModels.StudentObject;
using Newtonsoft.Json;
using System.Text;

namespace kullanici_kayit_web_ui.apicom;

public class ApiComForStudentObject
{

    /*
     API communication class
     */
    string mainapiUrl;

    private string getMainapiUrlFromJson()
    {
        IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        string portNumber = Configuration.GetSection("apiConnectionUrl:port").Value.ToString();
        string baseurl = Configuration.GetSection("apiConnectionUrl:url").Value.ToString();
        string apikeyword = Configuration.GetSection("apiConnectionUrl:keyword").Value.ToString();
        string resulturl = baseurl + ":" + portNumber + "/" + apikeyword;
        return resulturl;
    }



    public ApiComForStudentObject(string apiurl)
    {
        this.mainapiUrl = apiurl;
    }



    public async Task<string> AddStudent(AddStudentRequest student)
    {
        //http://localhost:5290/api/Values/addstudent
        string localApiUrl = String.Concat(mainapiUrl, "/Values/addstudent");
        HttpClient client = new HttpClient();
        string jsonContent = JsonConvert.SerializeObject(student);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(localApiUrl, content);
        if (response.IsSuccessStatusCode)
        {
            //response başarılı
            client.Dispose();
            return "başarılı";
        }
        else
        {
            //response başarısız
            client.Dispose();
            return "başarısız";
        }

    }
    public async Task<List<GetStudentRequest>> GetStudents()
    {
        //http://localhost:5290/api/Values/getstudents
        string localApiUrl = String.Concat(mainapiUrl, "/Values/getstudents");
        HttpClient client = new HttpClient();
        List<GetStudentRequest> dataList = new List<GetStudentRequest>();
        HttpResponseMessage response = await client.GetAsync(localApiUrl);
        if (response.IsSuccessStatusCode)
        {
            //response başarılı
            string responseData = await response.Content.ReadAsStringAsync();
            dataList = JsonConvert.DeserializeObject<List<GetStudentRequest>>(responseData);

        }
        else
        {
            //response başarısız
        }


        client.Dispose();
        return dataList;
    }

}
