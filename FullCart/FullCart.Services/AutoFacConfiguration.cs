using Autofac;
using FullCart.Repositories.Generic;
using FullCart.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services
{
    public class AutoFacConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region UOW
            //Register Unit of work service
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>));
            #endregion

        }
    }
}
