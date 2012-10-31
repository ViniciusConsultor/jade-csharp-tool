using System;
using System.Linq;

using Autofac;
using Autofac.Core.Lifetime;
using Jade.CQA.Robot.Services;
using Jade.CQA.Robot.Interfaces;
using Jade.CQA.Robot.Extensions;

namespace Jade.CQA.Robot
{
	public class CrawlerModule : Module
	{
		#region Constructors

        static CrawlerModule()
		{
			Setup();
		}

		#endregion

		#region Instance Methods

		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(c => new WebDownloaderV2()).As<IWebDownloader>().SingleInstance().ExternallyOwned();
            // 默认使用BloomFilterHistoryService
            builder.Register(c => new InMemoryCrawlerHistoryService()).As<ICrawlerHistory>().InstancePerDependency();
			builder.Register(c => new InMemoryCrawlerQueueService()).As<ICrawlerQueue>().InstancePerDependency();
            builder.Register(c => new ConsoleLoggerService()).As<ILog>().InstancePerDependency();
#if !DOTNET4
			builder.Register(c => new ThreadTaskRunnerService()).As<ITaskRunner>().InstancePerDependency();
#else
			builder.Register(c => new NativeTaskRunnerService()).As<ITaskRunner>().InstancePerDependency();
#endif
			builder.Register((c, p) => new RobotService(p.TypedAs<Uri>(), c.Resolve<IWebDownloader>())).As<IRobot>().InstancePerDependency();
			builder.Register((c, p) => new CrawlerRulesService(p.TypedAs<Crawler>(), c.Resolve<IRobot>(p), p.TypedAs<Uri>())).As<ICrawlerRules>().InstancePerDependency();
		}

		#endregion

		#region Class Properties

		public static IContainer Container { get; private set; }

		#endregion

		#region Class Methods

		public static void Register(Action<ContainerBuilder> registerCallback)
		{
			ContainerBuilder builder = new ContainerBuilder();
			Container.ComponentRegistry.
				Registrations.
				Where(c => !c.Activator.LimitType.IsAssignableFrom(typeof(LifetimeScope))).
				ForEach(c => builder.RegisterComponent(c));
			registerCallback(builder);
			Container = builder.Build();
		}

		public static void Setup()
		{
            Setup(new CrawlerModule());
		}

        /// <summary>
        /// 注册默认
        /// </summary>
        /// <param name="modules"></param>
		public static void Setup(params Module[] modules)
		{
			ContainerBuilder builder = new ContainerBuilder();
			modules.ForEach(module => builder.RegisterModule(module));
			Container = builder.Build();
		}

		#endregion
	}
}