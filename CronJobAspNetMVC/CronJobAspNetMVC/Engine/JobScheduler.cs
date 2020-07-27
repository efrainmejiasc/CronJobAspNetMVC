using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CronJobAspNetMVC.Engine
{
    public class JobScheduler
    {
        public static async System.Threading.Tasks.Task StartAsync()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
           _= scheduler.Start();

            IJobDetail job = JobBuilder.Create<EngineSendEmail>().Build();

            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(60)
            .RepeatForever())
            .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}