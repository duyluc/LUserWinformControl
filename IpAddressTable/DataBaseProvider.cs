using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LiteDB;

namespace IpAddressTable
{
    public class ClientIp
    {
        public int Id { get; set; }
        public string IP { get; set; }
    }
    public class DataBaseProvider
    {
        public string DatabaseFilePath = "";
        public string Name = "";

        public DataBaseProvider(string name)
        {
            this.Name = name;
            this.DatabaseFilePath = Path.Combine(".\\", "Database", $"{Name}.db");
            ValidateDatabase();
        }
        
        public bool ValidateDatabase()
        {
            if (!Directory.Exists(".\\Database"))
            {
                Directory.CreateDirectory(".\\Database");
                return false;
            }
            return true;
        }
        
        public void WriteTable(List<string> ipList)
        {
            ClientIp[] ClientIps = new ClientIp[ipList.Count];
            for(int i = 0; i < ipList.Count; i++)
            {
                ClientIps[i] = new ClientIp { IP = ipList[i] };
            }
            using (LiteDatabase db = new LiteDatabase(this.DatabaseFilePath))
            {
                var col = db.GetCollection<ClientIp>();
                col.DeleteAll();
                foreach(ClientIp i in ClientIps)
                {
                    col.Insert(i);
                }
            }
        }

        public ClientIp[] GetTable()
        {
            ClientIp[] _ipList;
            using (LiteDatabase db = new LiteDatabase(this.DatabaseFilePath))
            {
                var col = db.GetCollection<ClientIp>();
                _ipList = col.FindAll().ToArray();
                if(_ipList == null)
                {
                    _ipList = new ClientIp[0];
                }
            }
            return _ipList;
        }
    }
}
