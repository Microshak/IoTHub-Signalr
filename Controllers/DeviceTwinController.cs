using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Devices;

namespace iToi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceTwinController 
    {
       static RegistryManager registryManager;
    static string connectionString = "HostName=itoiHubDev.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=RV32SzmWonWHeHOUHYRJpDxFH2mdJRlVXQb5vxO2/hE=";
  
    
  
        // GET api/values
        [HttpGet]
        public  ActionResult<IEnumerable<string>> Get()
        {
 

 registryManager = RegistryManager.CreateFromConnectionString(connectionString);

          var query = registryManager.CreateQuery("SELECT * FROM devices", 100);
     var outty = query.GetNextAsTwinAsync().Result;
  //  Console.WriteLine("Devices in Redmond43: {0}", 
  //    string.Join(", ", twinsInRedmond43.Select(t => t.DeviceId)));
    List<string> res = new List<string>();
    foreach(var x in outty)
    {
    res.Add(x.DeviceId);
    }
    return  res.ToArray(); 
    
  //return new string[] { "value1", "value2" };

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
   
        }
    }
