using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using ImageService.Communication.Singleton;
using ImageService.Communication.Model;
using ImageService.Infrastructure.Enums;

namespace ImageService.WebApplication.Models {
    public class Config {
        private bool finished;
        public Config() {
            Folders = new List<string>();
            if(ClientCommunication.Instance.Connected) {
                finished = false;
                ClientCommunication.Instance.OnDataRecieved += GetConfigs;
                ClientCommunication.Instance.Send(new CommandMessage(CommandEnum.GetConfigCommand, new string[] { }));
                SpinWait.SpinUntil(() => finished);
            }
        }

        private void GetConfigs(object sender, Communication.Model.Event.DataReceivedEventArgs e) {
            CommandMessage cmdMsg = CommandMessage.FromJSON(e.Data);

            if(cmdMsg.CmdId == CommandEnum.GetConfigCommand) {
                this.SourceName = cmdMsg.Args[0];
                this.LogName = cmdMsg.Args[1];
                this.OutputDirPath = cmdMsg.Args[2];
                this.ThumbnailSize = cmdMsg.Args[3];

                foreach(string folder in cmdMsg.Args[4].Trim().Split(';')) {
                    if(!folder.Equals(""))
                        Folders.Add(folder);
                }

                ClientCommunication.Instance.OnDataRecieved -= GetConfigs;
                finished = true;
            }
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "SourceName")]
        public string SourceName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "LogName")]
        public string LogName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "OutputDirPath")]
        public string OutputDirPath { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ThumbnailSize")]
        public string ThumbnailSize { get; set; }

        [Required]
        [Display(Name = "Folders")]
        public List<string> Folders { get; set; }
    }
}