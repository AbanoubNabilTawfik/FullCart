﻿using Autofac;
using FullCart.Core.Common;
using FullCart.Core.Interfaces;
using FullCart.Repositories.Generic;
using FullCart.Repositories.UOW;
using FullCart.Repositories.User;
using FullCart.Services.GlobalService;
using FullCart.Services.SecurityService;
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

            #region Common
            builder.RegisterType<ResponseDTO>().As<IResponseDTO>().InstancePerLifetimeScope();
            #endregion

            #region Security
            builder.RegisterType<FullCart.Services.SecurityService.SecurityService>().As<ISecurityService>().InstancePerLifetimeScope();
            #endregion

            #region User
            builder.RegisterType<FullCart.Repositories.User.UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            #endregion

            #region Upload
            builder.RegisterType<FullCart.Services.GlobalService.UploadFileService>().As<IUploadFileService>().InstancePerLifetimeScope();
            #endregion

        }
    }
}
