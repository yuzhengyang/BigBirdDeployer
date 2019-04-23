using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using BigBirdConsole.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBirdConsole.Modules.StoreModule
{
    public static class StorePersistanceTask
    {
        public static void Start()
        {
            Task.Factory.StartNew(() =>
            {
                while (!R.MainUI.IsDisposed)
                {
                    if (Ls.Ok(R.Tx.Hosts))
                    {
                        R.Store.Persistence();
                    }
                    Sleep.S(10);
                }
            });
        }
    }
}
