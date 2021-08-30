using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;

namespace EasyInnoSetupForUnity
{
    class Program
    {

        static void Main(string[] args)
        {

            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(HandleParsed)
                   .WithNotParsed(HandleNotParsed);

            
        }

        private static void HandleParsed(Options o)
        {

            // read
            var text = File.ReadAllText(o.TemplatePath);



            var replaced = text.Replace("##APP_UUID##", o.Uuid);
            replaced = replaced.Replace("##APP_NAME##", o.AppName);

            if(string.IsNullOrEmpty(o.AppVersion))
            {
                replaced = replaced.Replace("##APP_VERSION##", "");
            }
            else
            {
                replaced = replaced.Replace("##APP_VERSION##", o.AppVersion);
            }
            
            replaced = replaced.Replace("##PUBLISHER##", o.AppPublisher);

            if(string.IsNullOrEmpty(o.AppUrl))
            {
                replaced = replaced.Replace("##APP_URL##", "");
            }
            else
            {
                replaced = replaced.Replace("##APP_URL##", o.AppUrl);
            }
            
            replaced = replaced.Replace("##APP_EXE_NAME##", o.AppExeName);
            replaced = replaced.Replace("##RESOURCE_DIR##", o.ResourceDir);
            replaced = replaced.Replace("##OUTPUT_DIR##", o.OutputDir);
            replaced = replaced.Replace("##OUTPUT_BASE_FILE_NAME##", o.OutputBaseFileName);

            // export
            File.WriteAllText(o.ISSOutputPath, replaced);

        }

        private static void HandleNotParsed(IEnumerable<Error> errors)
        {

            Console.Error.WriteLine("Argument Error. Exit");

            foreach(var e in errors)
            {
                Console.Error.WriteLine(e.ToString());
            }

            return;
        }

    }




}
