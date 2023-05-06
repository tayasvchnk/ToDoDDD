﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoDDD.DAL.Datas;
using ToDoDDD.BLL.Repositories;
using ToDoDDD.DAL.Entities;
using ToDoDDD.DAL.Interfaces;

namespace ToDoDDD.BLL.UOW
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext context;
        public UnitOfWork( AppDbContext _context )
        {
            context = _context;
        }

        private TaskRepository taskRepository;
        private StatusRepository statusRepository;
        private PriorityRepository prioritetRepository;

        public TaskRepository TaskRepository
        {
            get
            {
                if (taskRepository == null)
                {
                    taskRepository = new TaskRepository(context);
                }
                return taskRepository;
            }
        }

        public StatusRepository StatusRepository
        {
            get
            {
                if (statusRepository == null)
                {
                    statusRepository = new StatusRepository(context);
                }
                return statusRepository;
            }
        }

        public PriorityRepository PrioritetRepository
        {
            get
            {
                if (prioritetRepository == null)
                {
                    prioritetRepository = new PriorityRepository(context);
                }
                return prioritetRepository;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}