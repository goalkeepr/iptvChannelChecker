using System.Collections.Generic;
using System.Threading;

namespace iptvChannelChecker
{
    /// <summary>
    ///     Thread wrapper class used for running threads in .NET
    /// </summary>
    public class ThreadHandler
    {
        /// <summary>
        ///     Initializes a new instance of the class
        /// </summary>
        /// <param name="maximumThreads">The maximum number of threads that can be run at any given time.</param>
        public ThreadHandler(int maximumThreads = 4) : this(new List<Thread>(), maximumThreads)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the class
        /// </summary>
        /// <param name="threadList">The list of Thread classes that will be run.</param>
        /// <param name="maximumThreads">The maximum number of threads that can be run at any given time.</param>
        public ThreadHandler(List<Thread> threadList, int maximumThreads = 4)
        {
            ThreadList = threadList;
            MaximumThreads = maximumThreads;

            WaitingThreads = new Queue<Thread>();

            foreach (var thread in ThreadList) WaitingThreads.Enqueue(thread);
        }

        /// <summary>
        ///     The list of Thread classes that will be run.
        /// </summary>
        public List<Thread> ThreadList { get; }

        /// <summary>
        ///     The maximum number of threads that can be run at any given time.
        /// </summary>
        public int MaximumThreads { get; }

        private Queue<Thread> WaitingThreads { get; }

        /// <summary>
        ///     Checks if any threads are still running.
        /// </summary>
        public bool IsAlive => ActiveThreads > 0 || WaitingThreads.Count > 0;

        public bool KillThreads = false;


        /// <summary>
        ///     Returns the number of currently running threads
        /// </summary>
        public int ActiveThreads
        {
            get
            {
                var count = 0;

                lock (ThreadList)
                {
                    foreach (var thread in ThreadList)
                        if (thread.IsAlive)
                            count++;
                }

                return count;
            }
        }

        /// <summary>
        ///     Runs the threads continuously as they are added to the thread list.  The outside process must continuously check
        ///     the
        ///     IsAlive property to determine when all the threads have been run.
        /// </summary>
        public void RunAsynch()
        {
            while (!KillThreads)
                lock (WaitingThreads)
                {
                    if (WaitingThreads.Count != 0 && ActiveThreads < MaximumThreads)
                    {
                        var nextThread = WaitingThreads.Dequeue();
                        nextThread.Start();
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
        }

        /// <summary>
        ///     Runs all the threads in the thread list.  The method will exit when all threads have been run.
        /// </summary>
        public void Run()
        {
            var thread = new Thread(RunAsynch) {IsBackground = true};

            thread.Start();

            do
            {
                Thread.Sleep(1000);
            } while (IsAlive);
        }

        /// <summary>
        ///     Adds a new Thread to the thread list and puts the thread in the waiting threads queue.
        /// </summary>
        /// <param name="start"></param>
        public void Add(ThreadStart start)
        {
            var thread = new Thread(start);

            lock (ThreadList)
            {
                ThreadList.Add(thread);
            }

            lock (WaitingThreads)
            {
                WaitingThreads.Enqueue(thread);
            }
        }
    }
}