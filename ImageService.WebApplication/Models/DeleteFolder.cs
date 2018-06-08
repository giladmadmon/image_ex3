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
    public class DeleteFolder {
        private bool finished;
        public DeleteFolder(string folder) {
            this.Folder = folder;
        }

        private void OnClientClose(object sender, Communication.Model.Event.DataReceivedEventArgs e) {
            CommandMessage cmdMsg = CommandMessage.FromJSON(e.Data);

            if(cmdMsg.CmdId == CommandEnum.CloseCommand && Folder.Equals(cmdMsg.Args[0])) {
                ClientCommunication.Instance.OnDataRecieved -= OnClientClose;
                finished = true;
            }
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Folder")]
        public string Folder { get; set; }

        public void SendDelete() {
            if(ClientCommunication.Instance.Connected) {
                finished = false;
                ClientCommunication.Instance.OnDataRecieved += OnClientClose;
                ClientCommunication.Instance.Send(new CommandMessage(CommandEnum.CloseCommand, new string[] { Folder }));
                SpinWait.SpinUntil(() => finished);
            }
        }
    }
}