using Streams.BackgroundWorkerExample;
using Streams.ParallelExample;
using Streams.Streams;
using Streams.TasksExmaple;
using Streams.ThreadPoolExmaple;
using System;

ThreadExample.ThradUsing();                                 // Вызов потока без параметров
ThreadParamExample.ThradParamUsing();                       // Вызов потока с параметрами

ThreadPoolExample.ThradUsingThreadPool();                   // Вызов потока из пула

BackgroundWorkerExample.BackgroundUsingExample();           // Вызов BackgroundWorker

TasksResultExample.TaskResultUsing();                       // Вызов Task с результатом

ParallelInvokeExmaple.ParallelInvokeUsing();

