using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    class Params
    {
        private string resourcesFolder;

        public Params()
        {
            var ind = Directory.GetCurrentDirectory().ToString()
                .IndexOf("bin", StringComparison.Ordinal); //Индекс папки bin
            string binFolder = Directory.GetCurrentDirectory().ToString().Substring(0, ind).ToString();
            resourcesFolder = binFolder + "resources\\";
        }
    }
}
