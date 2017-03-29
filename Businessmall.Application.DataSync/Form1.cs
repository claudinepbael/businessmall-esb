using Businessmall.Application.DataSyncServices.Queries;
using Businessmall.Application.DataSyncServices.QueryResults;
using Businessmall.Application.DataSyncServices.Services;
using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Businessmall.Application.DataSync {
    public partial class Form1 : Form {
        private static Form1 instance;
        private IQueryDispatcher _queryDispatcher ;
        private ICommandDispatcher _commandDispatcher;
      
        public Form1() {
            InitializeComponent();
         
          
        }
   

        public static Form1 Instance {
            get{
                if(instance == null){
                    
                    instance = new Form1();

                }

                return instance;
            }
            set{
                instance = value;
            }
        }
        public void Start(){
            // call the service
           Form1 form1 = new Form1();
            
            SyncData service = new SyncData();
            service.SyndProductData();
         
        }
    }
}
