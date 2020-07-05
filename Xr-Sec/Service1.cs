using System.ServiceProcess;
using System.Threading;

namespace Xr_Sec
{
    /*
     * класс, определяющий функциональность сервиса 
     * OnStart запускает Wathcman, который отслеживает события ФС в отедельном потоке
     * OnStop останавливает поток с Wathcman
     */
    public partial class Service1 : ServiceBase
    {
        private Watchman watchman;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.Diagnostics.Debugger.Launch(); //пуск дебагера TODO убрать после проверок
            watchman = new Watchman();
            Thread watchmanThread = new Thread(new ThreadStart(watchman.Start));
            watchmanThread.Start();
        }

        protected override void OnStop()
        {
            watchman.Stop();
            Thread.Sleep(1000);
        }
    }
}
