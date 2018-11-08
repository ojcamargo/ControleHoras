[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ControleHoras.APRESENTACAO.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ControleHoras.APRESENTACAO.App_Start.NinjectWebCommon), "Stop")]

namespace ControleHoras.APRESENTACAO.App_Start
{
    using System;
    using System.Web;
    using DATA.Interfaces;
    using DATA.Repositories;
    using DATA.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IBaseService<>)).To(typeof(BaseService<>));
            kernel.Bind(typeof(IAlocacaoService)).To(typeof(AlocacaoService));
            kernel.Bind(typeof(IClienteService)).To(typeof(ClienteService));
            kernel.Bind(typeof(IClienteIpService)).To(typeof(ClienteIpService));
            kernel.Bind(typeof(IClienteLocalService)).To(typeof(ClienteLocalService));
            kernel.Bind(typeof(IContratoService)).To(typeof(ContratoService));
            kernel.Bind(typeof(ILancamentoService)).To(typeof(LancamentoService));
            kernel.Bind(typeof(IProfissionalDispositivoService)).To(typeof(ProfissionalDispositivoService));
            kernel.Bind(typeof(IProfissionalService)).To(typeof(ProfissionalService));
            kernel.Bind(typeof(IUsuarioService)).To(typeof(UsuarioService));
            kernel.Bind(typeof(IDemonstrativoHorasService)).To(typeof(DemonstrativoHorasService));
            kernel.Bind(typeof(IRelatorioService)).To(typeof(RelatorioService));

            kernel.Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            kernel.Bind(typeof(IAlocacaoRepository)).To(typeof(AlocacaoRepository));
            kernel.Bind(typeof(IClienteRepository)).To(typeof(ClienteRepository));
            kernel.Bind(typeof(IClienteIpRepository)).To(typeof(ClienteIpRepository));
            kernel.Bind(typeof(IClienteLocalRepository)).To(typeof(ClienteLocalRepository));
            kernel.Bind(typeof(IContratoRepository)).To(typeof(ContratoRepository));
            kernel.Bind(typeof(ILancamentoRepository)).To(typeof(LancamentoRepository));
            kernel.Bind(typeof(IProfissionalDispositivoRepository)).To(typeof(ProfissionalDispositivoRepository));
            kernel.Bind(typeof(IProfissionalRepository)).To(typeof(ProfissionalRepository));
            kernel.Bind(typeof(IUsuarioRepository)).To(typeof(UsuarioRepository));
            kernel.Bind(typeof(IDemonstrativoHorasRepository)).To(typeof(DemonstrativoHorasRepository));
            kernel.Bind(typeof(IRelatorioRepository)).To(typeof(RelatorioRepository));
        }        
    }
}
