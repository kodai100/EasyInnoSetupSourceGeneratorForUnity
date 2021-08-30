using System;
using System.Collections.Generic;
using System.Text;

using CommandLine;

namespace EasyInnoSetupForUnity
{
    class Options
    {

        [Value(0, MetaName = "Template File Path")]
        public string TemplatePath { get; set; }

        [Value(1, MetaName = "ISS Output Path")]
        public string ISSOutputPath { get; set; }


        [Option('i', "uuid", Required = true, HelpText = "App UUID")]
        public string Uuid { get; set; }

        [Option('n', "name", Required = true, HelpText = "App Name")]
        public string AppName { get; set; }

        [Option('v', "version", Required = false, HelpText = "App Version")]
        public string AppVersion{ get; set; }

        [Option('p', "publisher", Required = true, HelpText = "App Publisher")]
        public string AppPublisher { get; set; }

        [Option('u', "url", Required = false, HelpText = "App URL")]
        public string AppUrl { get; set; }

        [Option('e', "exename", Required = true, HelpText = "App Exe Name")]
        public string AppExeName { get; set; }

        [Option('r', "resource_dir", Required = true, HelpText = "Unity Artifact Resource Directory (the folder contains .exe)")]
        public string ResourceDir { get; set; }

        [Option('o', "iss_output_dir", Required = true, HelpText = "Installer Output Directory")]
        public string OutputDir { get; set; }

        [Option('b', "output_base_file_name", Required = true, HelpText = "Installer Output Base File Name")]
        public string OutputBaseFileName { get; set; }
    }
}
